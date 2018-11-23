using System.Threading.Tasks;
using PoLaKoSz.SMF.Scraper.DataAccessLayer.Web;
using PoLaKoSz.SMF.Scraper.Models;
using PoLaKoSz.SMF.Scraper.Parsers;

namespace PoLaKoSz.SMF.Scraper.EndPoints
{
    public class TopicEndPoint : EndPoint
    {
        private readonly ISmfTheme _theme;
        private readonly TopicParser _parser;
        private readonly IUrlParser _urlParser;



        public TopicEndPoint(ForumSettings settings, IHttpClient httpClient)
            : base("topic", settings.RootURL, httpClient)
        {
            _theme = settings.Theme;
            _parser = new TopicParser();
            _urlParser = settings.UrlParser;
        }



        public async Task<RootObject<Topic>> Info(Topic topic, int page = 0)
        {
            string sourceCode = await base.GetAsync($"{_urlParser.Separator}{topic.ID}.{page}");

            return _parser.Execute(topic, sourceCode, _theme, _urlParser);
        }
    }
}
