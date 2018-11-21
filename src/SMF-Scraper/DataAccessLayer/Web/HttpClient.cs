using System.Net.Http;

namespace PoLaKoSz.SMF.Scraper.DataAccessLayer.Web
{
    public class HttpClient : System.Net.Http.HttpClient, IHttpClient
    {
        public HttpClient()
            : base(new HttpClientHandler(), disposeHandler: true)
        {
            DefaultRequestHeaders.Add("Accept", "*/*");
            DefaultRequestHeaders.Add("User-Agent", "github.com PoLaKoSz SMF-Scraper");
        }
    }
}
