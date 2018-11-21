using System.Net.Http;

namespace PoLaKoSz.SMF.Scraper.DataAccessLayer.Web
{
    public class HttpClient : System.Net.Http.HttpClient, IHttpClient
    {
        public HttpClient()
            : base(new HttpClientHandler(), disposeHandler: true)
        {
            DefaultRequestHeaders.Add("Accept", "*/*");
            DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:63.0) Gecko/20100101 Firefox/63.0");
        }
    }
}
