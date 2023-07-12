using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration; // Remember to include this for IConfiguration

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private string _openAiApiKey;

        public OpenAIController(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
            _openAiApiKey = _configuration.GetValue<string>("OpenAI:ApiKey");
        }

        // POST: api/OpenAI/Summarize
        [HttpPost("Summarize")]
        public async Task<IActionResult> SummarizeText([FromBody] string text)
        {
            var openAiEndpoint = "https://api.openai.com/v1/engines/text-davinci-003/completions";
            var openAiClient = _clientFactory.CreateClient();

            var prompt = $"Create a short summary of the commit message: {text}";
            var openAiRequest = new HttpRequestMessage(HttpMethod.Post, openAiEndpoint)
            {
                Headers =
                {
                    { "Authorization", $"Bearer {_openAiApiKey}" }, // Use the apiKey from config
                },
                Content = new StringContent(JsonConvert.SerializeObject(new { prompt = prompt, max_tokens = 60 }), System.Text.Encoding.UTF8, "application/json")
            };

            var openAiResponse = await openAiClient.SendAsync(openAiRequest);
            var json = await openAiResponse.Content.ReadAsStringAsync();
            return Ok(json);
        }
    }
}
