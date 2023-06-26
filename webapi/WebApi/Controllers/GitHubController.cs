using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public GitHubController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("{owner}/{repos}")]
        public async Task<IActionResult> GetRepositories(string owner, string repos)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://api.github.com/repos/{owner}/{repos}/commits");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var repositories = await response.Content.ReadAsAsync<List<Repository>>();

                // Do something with the repositories list, such as returning it in the response
                return Ok(repositories);
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