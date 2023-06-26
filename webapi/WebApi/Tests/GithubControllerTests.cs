using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Tests
{
    [TestFixture]
    public class GitHubControllerTests
    {
        [Test]
        public async Task GetRepositories_ValidOwnerAndRepo_ReturnsRepositoriesList()
        {
            // Arrange
            var owner = "your-owner-name";
            var repo = "your-repo-name";
            var expectedRepositories = new List<Repository>
            {
                // Create some mock repositories for testing purposes
                new Repository { Name = "Repo 1", Description = "First repository" },
                new Repository { Name = "Repo 2", Description = "Second repository" }
            };

            // Create a mock HttpClient that returns a success response with the expected repositories
            var mockHttpClient = new Mock<HttpClient>();
            mockHttpClient
                .Setup(c => c.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<List<Repository>>(
                        expectedRepositories,
                        new System.Net.Http.Formatting.JsonMediaTypeFormatter()
                    )
                });

            // Create a mock IHttpClientFactory that returns the mock HttpClient
            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
            mockHttpClientFactory.Setup(f => f.CreateClient(It.IsAny<string>()))
                .Returns(mockHttpClient.Object);

            var controller = new GitHubController(mockHttpClientFactory.Object);

            // Act
            var result = await controller.GetRepositories(owner, repo);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.Value, Is.EqualTo(expectedRepositories));
        }
    }
}