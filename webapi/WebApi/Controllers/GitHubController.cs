using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using WebApi.Models;
using Newtonsoft.Json;
using WebApi.Migrations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IDataAccessProvider _dataAccessProvider;

        public GitHubController(IHttpClientFactory clientFactory, IDataAccessProvider dataAccessProvider)
        {
            _clientFactory = clientFactory;
            _dataAccessProvider = dataAccessProvider;
        }

        // GET ALL COMMITS FOR ONE REPO 
        [HttpGet("commits/{owner}/{repo}")]
        public async Task<IActionResult> GetListOfCommits(string owner, string repo)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://api.github.com/repos/{owner}/{repo}/commits");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var commits = JsonConvert.DeserializeObject<List<ListOfCommits>>(json);

                foreach (var commit in commits)
                {
                    // Extract author information from the commit
                    var author = commit.commit.author;
                    var commitInfo = commit.commit;
                     // Replace with the appropriate property from your JSON model
                    // Add the author to the database
                    _dataAccessProvider.AddAuthor(author);
                    _dataAccessProvider.AddCommit(commitInfo);
                    
                }
                return Ok(commits);
            }
            else
            {
                // Handle the case when the API request was not successful
                // You can return an appropriate response or error message
                return StatusCode((int)response.StatusCode);
            }



        }
        // GET LATEST RELEASE FROM A REPO
        [HttpGet("release/{owner}/{repos}")]
        public async Task<IActionResult> GetLatestRelease(string owner, string repo)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://api.github.com/repos/{owner}/{repo}/releases/latest");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

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

        [HttpGet("members/{org}")]
        public async Task<IActionResult> GetOrgMembers(string org)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://api.github.com/orgs/{org}/members");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

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