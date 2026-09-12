using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CatFactApp.Tests
{
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        private readonly string _responseContent;
        private readonly HttpStatusCode _statusCode;

        public FakeHttpMessageHandler(
            string responseContent,
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            _responseContent = responseContent;
            _statusCode = statusCode;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response =
                new HttpResponseMessage(_statusCode)
                {
                    Content = new StringContent(_responseContent)
                };

            return Task.FromResult(response);
        }
    }
}
