using CatFactApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CatFactApp.Tests
{
    public class CatFactServiceTests
    {
        [Fact]
        public async Task GetFactAsync_ShouldReturnDeserializedCatFact()
        {
            // Arrange
            string json =
                """{"fact":"Test cat fact","length":13}""";

            var handler =
                new FakeHttpMessageHandler(json);

            var httpClient =
                new HttpClient(handler)
                {
                    BaseAddress = new Uri("https://test.local/")
                };

            var fileService =
                new FakeFileService();

            var service =
                new CatFactService(httpClient, fileService);

            // Act
            var result =
                await service.GetFactAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test cat fact", result.Fact);
            Assert.Equal(13, result.Length);
        }

        [Fact]
        public async Task GetFactAsync_ShouldSaveFactToFile()
        {
            // Arrange
            string json =
                """{"fact":"Test cat fact","length":13}""";

            var handler =
                new FakeHttpMessageHandler(json);

            var httpClient =
                new HttpClient(handler)
                {
                    BaseAddress = new Uri("https://test.local/")
                };

            var fileService =
                new FakeFileService();

            var service =
                new CatFactService(httpClient, fileService);

            // Act
            await service.GetFactAsync();

            // Assert
            Assert.Equal(
                "Test cat fact | Length: 13",
                fileService.SavedText
            );
        }

        [Fact]
        public async Task GetFactAsync_ShouldThrowException_WhenApiReturnsError()
        {
            // Arrange
            var handler =
                new FakeHttpMessageHandler(
                    "",
                    HttpStatusCode.NotFound
                );

            var httpClient =
                new HttpClient(handler)
                {
                    BaseAddress = new Uri("https://test.local/")
                };

            var fileService =
                new FakeFileService();

            var service =
                new CatFactService(httpClient, fileService);

            // Act + Assert
            await Assert.ThrowsAsync<HttpRequestException>(
                () => service.GetFactAsync()
            );
        }
    }
}
