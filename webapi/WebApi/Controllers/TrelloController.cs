using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;
using System;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TrelloController : ControllerBase
    {
        public class Sprint
        {
            public string Number { get; set; }
            public DateTime Date { get; set; }
            public string Name { get; set; }
        }

        private readonly IHttpClientFactory _clientFactory;
        private readonly PostgreSqlContext _context;

        public TrelloController(IHttpClientFactory clientFactory, PostgreSqlContext context)
        {
            _clientFactory = clientFactory;
            _context = context;
        }
        // Get Entire trello board
        [HttpGet("board/{boardId}/{apikey}/{apitoken}")]
        public async Task<IActionResult> GetTrelloBoard(string boardId, string apikey, string apitoken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://api.trello.com/1/boards/${boardId}/cards?key=${apikey}&token=${apitoken}&attachments=true");
            request.Headers.Add("Accept", "application/json");

            // https://api.trello.com/1/boards/64823e0ae015b3e2013c7f6b?key=fe91479f8115fc056c49911580effd95&token=ATTA6cff2e9c9ca4b4b103bb93ed6180651b0cb9a138113d3e73da4fc9f2bf646d7c9B79F36B

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                // Do something with the repositories list, such as returning it in the response
                return Ok(json);
            }
            else
            {
                // Handle the case when the API request was not successful
                // You can return an appropriate response or error message
                return StatusCode((int)response.StatusCode);
            }
        }

        [HttpGet("gitattachments/{cardId}/{apikey}/{apitoken}")]
        public async Task<IActionResult> GetGitTrelloAttachments(string cardId, string apikey, string apitoken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://api.trello.com/1/cards/{cardId}/attachments?key={apikey}&token={apitoken}");
            request.Headers.Add("Accept", "application/jsony");

            // https://api.trello.com/1/boards/64823e0ae015b3e2013c7f6b?key=fe91479f8115fc056c49911580effd95&token=ATTA6cff2e9c9ca4b4b103bb93ed6180651b0cb9a138113d3e73da4fc9f2bf646d7c9B79F36B

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                // Do something with the repositories list, such as returning it in the response
                return Ok(json);
            }
            else
            {
                // Handle the case when the API request was not successful
                // You can return an appropriate response or error message
                return StatusCode((int)response.StatusCode);
            }
        }

        [HttpGet("sprints")]
        public async Task<IActionResult> GetSprints()
        {
            var sprints = await _context.Sprints.ToListAsync();
            sprints = sprints.OrderBy(s => s.StartDate).ToList();
            return Ok(sprints);
        }



        [HttpPost("/api/getsprintnames/{boardId}/{apiKey}/{apiToken}")]
        public async Task<IActionResult> GetBoardTitles(string boardId, string apiKey, string apiToken)
        {
            var url = $"https://api.trello.com/1/boards/{boardId}/lists?key={apiKey}&token={apiToken}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON into a JArray
                var sprintData = JArray.Parse(json);

                // Initialize a list to store the extracted sprints
                var sprints = new List<Models.Sprint>();

                foreach (var obj in sprintData)
                {
                    string name = obj["name"].Value<string>();

                    if (name.StartsWith("Sprint-"))
                    {
                        // Extract the sprint number
                        string sprintNumber = name.Split(' ')[0].Replace("Sprint-", "");

                        // Extract the start and end date strings
                        string dateRange = name.Split(' ')[1];
                        string startDateString = dateRange.Split('-')[0];
                        string endDateString = dateRange.Split('-')[1];

                        // Parse the start and end dates using custom date format
                        DateTime startDate = DateTime.ParseExact(startDateString, "MM/dd/yy", null).ToUniversalTime();
                        DateTime endDate = DateTime.ParseExact(endDateString, "MM/dd/yy", null).ToUniversalTime();

                        // Extract the sprint name without the sprint number and date range
                        string sprintName = string.Join(' ', name.Split(' ').Skip(2));

                        // Create the sprint object and add it to the list
                        var sprint = new Models.Sprint
                        {
                            Number = sprintNumber,
                            StartDate = startDate,
                            EndDate = endDate,
                            Name = sprintName
                        };

                        sprints.Add(sprint);
                    }
                }

                // Sort the sprints by start date
                sprints = sprints.OrderBy(s => s.StartDate).ToList();

                // Save the sorted and filtered sprints to the database
                foreach (var sprint in sprints)
                {
                    _context.Sprints.Add(sprint);
                }
                _context.SaveChanges();

                // Return the sorted and filtered sprints as JSON
                return Ok(sprints);
            }
            else
            {
                // Handle the case when the API request was not successful
                // You can return an appropriate response or error message
                return StatusCode((int)response.StatusCode);
            }
        }

    }
}