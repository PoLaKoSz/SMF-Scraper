using PoLaKoSz.SMF.Scraper.DataAccessLayer.Web;
using PoLaKoSz.SMF.Scraper.Models;
using PoLaKoSz.SMF.Scraper.Parsers;
using System.Threading.Tasks;

namespace PoLaKoSz.SMF.Scraper.Workers
{
    public class BoardEndPoint : EndPoint
    {
        private readonly ISmfTheme _theme;
        private readonly BoardParser _parser;
        private readonly IUrlParser _urlParser;



        public BoardEndPoint(ForumSettings settings, IHttpClient httpClient)
            : base("board", settings.RootURL, httpClient)
        {
            _theme = settings.Theme;
            _parser = new BoardParser();
            _urlParser = settings.UrlParser;
        }



        public async Task<RootObject<Board>> Info(Board board, int page = 0)
        {
            string sourceCode = await base.GetAsync($"{_urlParser.Separator}{board.ID}.{page}");

            return _parser.Execute(board, sourceCode, _theme, _urlParser);
        }
    }
}
