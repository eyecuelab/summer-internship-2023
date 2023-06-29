using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TrelloController : ControllerBase
    {

        private readonly IHttpClientFactory _clientFactory;

        public TrelloController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("board/{cardId}/{apikey}/{apitoken}")]
        public async Task<IActionResult> GetTrelloBoard(string cardId, string apikey, string apitoken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://api.trello.com/1/boards/{cardId}?key={apikey}&token={apitoken}");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");

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

    }
}