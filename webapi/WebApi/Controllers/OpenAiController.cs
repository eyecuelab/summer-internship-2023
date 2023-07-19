using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WebApi.Models;
using WebApi.DataAccess;
using System.Linq;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private string _openAiApiKey;
        private readonly PostgreSqlContext _context;

        public OpenAIController(IHttpClientFactory clientFactory, IConfiguration configuration, PostgreSqlContext context)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
            _openAiApiKey = _configuration.GetValue<string>("OpenAI:ApiKey");
            _context = context;
        }

        [Serializable]
        public class OpenAIResponse
        {
            public Choice[] choices { get; set; }
        }

        public class Choice
        {
            public string text { get; set; }
        }

        public class Message
        {
            public string role { get; set; }
            public string content { get; set; }
        }

        private string FilterAndCleanCommits(IEnumerable<string> commits)
        {
            var filteredCommits = new List<string>();

            foreach (var commit in commits)
            {
                // Ignore if commit message is a merge or contains the term 'Sz/api'
                if (commit.Contains("Merge pull request") || commit.Contains("Sz/api"))
                    continue;

                // Ignore if it is the common message about repeated merges
                if (commit.Contains("Merging to work off the new new"))
                    continue;

                // If commit message is about updated styling and we already have one such commit, ignore
                if (commit.Contains("Updated styling") && filteredCommits.Any(c => c.Contains("Updated styling")))
                    continue;

                filteredCommits.Add(commit);
            }

            return string.Join(". ", filteredCommits);
        }

        [HttpGet("responses")]
        public async Task<IActionResult> GetResponses([FromQuery] string startDate, [FromQuery] string endDate)
        {
            try
            {
                if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
                {
                    return BadRequest("Both startDate and endDate must be provided");
                }

                DateTime startDateTime;
                DateTime endDateTime;

                string format = "yyyy-MM-dd";

                if (!DateTime.TryParseExact(startDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out startDateTime)
                    || !DateTime.TryParseExact(endDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out endDateTime))
                {
                    return BadRequest("Invalid date format");
                }

                startDateTime = DateTime.SpecifyKind(startDateTime, DateTimeKind.Utc);
                endDateTime = DateTime.SpecifyKind(endDateTime, DateTimeKind.Utc);

                var responses = await _context.Responses
                              .Where(r => r.StartDate >= startDateTime && r.EndDate >= endDateTime)
                              .ToListAsync();

                return Ok(responses);
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Error in GetResponses: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }

                // Return a 500 Internal Server Error status code along with a custom message
                return StatusCode(500, "An error occurred while processing your request. Please try again later.");
            }
        }

        [HttpPost("SummarizeCommitsByDates/{startDate}/{endDate}")]
        public async Task<IActionResult> SummarizeText(string startDate, string endDate)
        {
            try
            {
                DateTime startDateTime;
                DateTime endDateTime;

                string format = "yyyy-MM-dd";

                if (!DateTime.TryParseExact(startDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out startDateTime)
                    || !DateTime.TryParseExact(endDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out endDateTime))
                {
                    return BadRequest("Invalid date format");
                }

                startDateTime = DateTime.SpecifyKind(startDateTime, DateTimeKind.Utc);
                endDateTime = DateTime.SpecifyKind(endDateTime, DateTimeKind.Utc);

                var commits = await _context.Commits
                    .Where(c => c.Date >= startDateTime && c.Date <= endDateTime)
                    .Select(c => c.message)
                    .ToListAsync();

                string cleanedCommits = FilterAndCleanCommits(commits);
                var openAiEndpoint = "https://api.openai.com/v1/chat/completions";
                var openAiClient = _clientFactory.CreateClient();

                var openAiRequest = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new { role = "system", content = "You are an advanced AI assistant, capable of interpreting software changes from commit messages, categorizing them into broad areas like 'New Features', 'Improvements', 'Bug Fixes', 'UI changes', etc. Your goal is to generate a summarized, user-friendly version of these updates as release notes, intended for both technical and non-technical audiences." },
                        new { role = "user", content = $"Here are the commit messages: {cleanedCommits}. Please categorize and summarize these into release notes." },
                    },
                    temperature = 0.2,
                };

                openAiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _openAiApiKey);
                openAiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(openAiRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var openAiResponse = await openAiClient.PostAsync(openAiEndpoint, content);
                var responseContent = await openAiResponse.Content.ReadAsStringAsync();

                if (openAiResponse.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject<dynamic>(responseContent);
                    var summary = response.choices[0].message.content.ToString();

                    var summaryResponse = new Response
                    {
                        ResponseText = summary,
                        StartDate = startDateTime,
                        EndDate = endDateTime,
                    };

                    _context.Responses.Add(summaryResponse);
                    await _context.SaveChangesAsync();

                    return Ok(summary);
                }
                else
                {
                    // Handle the case when OpenAI API request was not successful
                    var statusCode = (int)openAiResponse.StatusCode;
                    Console.WriteLine($"OpenAI API request failed with status code: {statusCode}, response: {responseContent}");
                    return StatusCode(statusCode, $"OpenAI API request failed with status code: {statusCode}");
                }
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Error in SummarizeText: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }

                // Return a 500 Internal Server Error status code along with a custom message
                return StatusCode(500, "An error occurred while processing your request. Please try again later.");
            }
        }

        // Rest of the code, including the Choice and Message classes and the FilterAndCleanCommits method, remains the same.
    }
}