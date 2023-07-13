// Updated OpenAIController class

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

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
        [Serializable]
        public class OpenAIResponse {
            public Choice[] choices {get; set;} 
            }

            public class Choice {
            public string text {get; set;}
        }
        public class Message
        {
            public string role {get; set;}
            public string content {get; set;}
        }
        string inputText = "This is a test";

        [HttpPost("Summarize")]
        public async Task<IActionResult> SummarizeText([FromBody] List<string> commitMessages)
        {
            var openAiEndpoint = "https://api.openai.com/v1/chat/completions";
            var openAiClient = _clientFactory.CreateClient();

            openAiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _openAiApiKey);
            openAiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var messages = new List<Message>{

            new Message 
            {
                role = "user",
                content = "Summarize this: " + inputText //string.Join(". ", commitMessages)
            }

            };

            var openAiRequest = new
            {
                model = "gpt-3.5-turbo",
                messages = messages
            };

            Console.WriteLine(JsonConvert.SerializeObject(openAiRequest));

            var json = JsonConvert.SerializeObject(openAiRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var openAiResponse = await openAiClient.PostAsync(openAiEndpoint, content);
            var responseContent = await openAiResponse.Content.ReadAsStringAsync();

            if (openAiResponse.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<OpenAIResponse>(responseContent);
                Console.WriteLine(JsonConvert.SerializeObject(response));
                var summary = response.choices[0].text;
                Console.WriteLine(summary);
                var summaries = response?.choices?.Select(choice => choice.text).ToList();

                return Ok(summaries);
            }
            else
            {
                // Handle the case when OpenAI API request was not successful
                var statusCode = (int)openAiResponse.StatusCode;
                return StatusCode(statusCode);
            }
        }
    }
}
