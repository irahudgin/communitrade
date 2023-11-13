using NUnit.Framework;
using Moq;
using Moq.Protected;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using communiTrade.MVVM.ViewModel;
using Newtonsoft.Json;
using System;

namespace communiTrade.Tests
{
    [TestFixture]
    public class FeaturedViewModelTests
    {
        private Mock<HttpMessageHandler> handlerMock;
        private string content;

        [SetUp]
        public void Setup()
        {
            handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            content = JsonConvert.SerializeObject(new { items = new[] { new { Name = "Test Item" } } });
        }

        [Test]
        public async Task InitializeAsync_SuccessfulConnection_ShouldSetFeaturedItems()
        {
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(content),
                })
                .Verifiable();

            var client = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://localhost:7009/Trade/")
            };

            var viewModel = new FeaturedViewModel(client);

            await viewModel.InitializeAsync();

            Assert.IsNotNull(viewModel.FeaturedItems);
            Assert.IsNotEmpty(viewModel.FeaturedItems);
        }

        [Test]
        public async Task InitializeAsync_UnsuccessfulConnection_ShouldNotSetFeaturedItems()
        {
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(""),
                })
                .Verifiable();

            var client = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://localhost:7009/Trade/")
            };

            var viewModel = new FeaturedViewModel(client);

            await viewModel.InitializeAsync();

            Assert.IsNull(viewModel.FeaturedItems, "FeaturedItems should be null when the connection is unsuccessful.");
        }
    }
}
