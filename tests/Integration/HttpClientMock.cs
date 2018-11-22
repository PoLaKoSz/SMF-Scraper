using PoLaKoSz.SMF.Scraper.DataAccessLayer.Web;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PoLaKoSz.SMF.Scraper.Tests.Integration
{
    internal class HttpClientMock : IHttpClient
    {
        public HttpRequestHeaders DefaultRequestHeaders => throw new NotImplementedException();
        public string ResponseHTML { get; set; }



        public HttpClientMock()
        {
            ResponseHTML = "";
        }



        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ResponseHTML)
            };

            return Task.Run(() => httpResponse);
        }
    }
}
