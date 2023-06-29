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
            $"https://api.trello.com/1/cards/{cardId}/attachments?key={apikey}&token={apitoken}");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");

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