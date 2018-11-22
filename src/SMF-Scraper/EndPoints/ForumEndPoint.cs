using PoLaKoSz.SMF.Scraper.DataAccessLayer.Web;
using PoLaKoSz.SMF.Scraper.Models;
using PoLaKoSz.SMF.Scraper.Parsers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoLaKoSz.SMF.Scraper.EndPoints
{
    public class ForumEndPoint : EndPoint
    {
        private readonly ISmfTheme _theme;
        private readonly ForumParser _parser;



        public ForumEndPoint(ForumSettings settings, IHttpClient httpClient)
            : base(settings.CustomHomePageURL, settings.RootURL, httpClient)
        {
            _theme = settings.Theme;
            _parser = new ForumParser();
        }



        /// <summary>
        /// Gets a list of <see cref="Category"/> from the Forum home page.
        /// </summary>
        /// <exception cref="NodeNotFoundException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<List<Category>> GetCategories()
        {
            string sourceCode = await base.GetAsync("");

            return _parser.Execute(sourceCode, _theme);
        }
    }
}
