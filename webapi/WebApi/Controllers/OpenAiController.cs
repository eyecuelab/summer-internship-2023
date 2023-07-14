using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using WebApi.DataAccess;
using Microsoft.EntityFrameworkCore;

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

    [HttpPost("SummarizeCommitsByDates/{startDate}/{endDate}")]
    public async Task<IActionResult> SummarizeText(string startDate, string endDate)
    {

      DateTime startDateTime, endDateTime;

      if (!DateTime.TryParse(startDate, out startDateTime) || !DateTime.TryParse(endDate, out endDateTime))
      {
        return BadRequest("Invalid date format");
      }

      startDateTime = DateTime.SpecifyKind(startDateTime, DateTimeKind.Utc);
      endDateTime = DateTime.SpecifyKind(endDateTime, DateTimeKind.Utc);

      var commits = await _context.Commits
          .Where(c => c.Date >= startDateTime && c.Date <= endDateTime)
          .Select(c => c.message)
          .ToListAsync();

      string concatenatedCommits = string.Join(". ", commits);

      var openAiEndpoint = "https://api.openai.com/v1/chat/completions";
      var openAiClient = _clientFactory.CreateClient();


      openAiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _openAiApiKey);
      openAiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


      var openAiRequest = new
      {
        model = "gpt-3.5-turbo",
        concatenatedCommits,
        temperature = 0.2,
      };

      var json = JsonConvert.SerializeObject(openAiRequest);
      var content = new StringContent(json, Encoding.UTF8, "application/json");

      var openAiResponse = await openAiClient.PostAsync(openAiEndpoint, content);
      var responseContent = await openAiResponse.Content.ReadAsStringAsync();

      if (openAiResponse.IsSuccessStatusCode)
      {
        var response = JsonConvert.DeserializeObject<dynamic>(responseContent);
        var summary = response.choices[0].message.content.ToString();

        return Ok();
      }
      else
      {
        // Handle the case when OpenAI API request was not successful
        var statusCode = (int)openAiResponse.StatusCode;
        throw new Exception($"OpenAI API request failed with status code: {statusCode}");
      }
    }
  }
}
