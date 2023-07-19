using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IDataAccessProvider _dataAccessProvider;
        private readonly IConfiguration _configuration;
        private readonly PostgreSqlContext _context;

        public GitHubController(IHttpClientFactory clientFactory, IDataAccessProvider dataAccessProvider, IConfiguration configuration, PostgreSqlContext context)
        {
            _clientFactory = clientFactory;
            _dataAccessProvider = dataAccessProvider;
            _configuration = configuration;
            _context = context;
        }

        // GET ALL COMMITS FOR ONE REPO 
        [HttpGet("commits/{owner}/{repo}")]
        public async Task<IActionResult> GetListOfCommits(string owner, string repo)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.github.com/repos/{owner}/{repo}/commits?per_page=100&page=5");

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
                    var commitSha = commit.sha;

                    commitInfo.commitSha = commitSha;
                    commitInfo.Date = commit.commit.author.date; // Assign the date directly

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

        // GET ALL COMMITS IN COMMITS TABLE
        [HttpGet("dbcommits")]
        public async Task<IActionResult> GetCommits()
        {
            var dbCommits = await _context.Commits
                .Include(c => c.author) // Eagerly load the Author data
                .Where(c => !c.message.Contains("Merge pull request")) // Ignore merge commits
                .ToListAsync();

            return Ok(dbCommits);
        }

        [HttpGet("dbauthors")]
        public async Task<IActionResult> GetAuthors()
        {
            var dbAuthors = await _context.Authors.ToListAsync();
            return Ok(dbAuthors);
        }

        // GET LATEST RELEASE FROM A REPO
        [HttpGet("release/{owner}/{repo}")]
        public async Task<IActionResult> GetLatestRelease(string owner, string repo)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.github.com/repos/{owner}/{repo}/releases/latest");
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
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.github.com/orgs/{org}/members");
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

        [HttpGet("getallcommitsString/{startDate}/{endDate}")]
        public async Task<IActionResult> GetCommitsByDate(string startDate, string endDate)
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

            return Ok(concatenatedCommits);
        }
    }
}