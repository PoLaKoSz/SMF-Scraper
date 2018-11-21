using PoLaKoSz.SMF.Scraper.DataAccessLayer.Web;
using PoLaKoSz.SMF.Scraper.EndPoints;
using PoLaKoSz.SMF.Scraper.Models;
using PoLaKoSz.SMF.Scraper.Themes.Metin2HungaryNet;
using System;

namespace PoLaKoSz.SMF.Scraper.Samples.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var theme = new BlackStormTheme();
            var rootUrl = new Uri("http://metin2hungary.net/");

            var forumSettings = new ForumSettings(theme, rootUrl)
            {
                CustomHomePageURL = "action=forum"
            };

            var forumHomePage = new ForumEndPoint(forumSettings, new HttpClient());

            var forumCategories = forumHomePage.GetCategories().GetAwaiter().GetResult();

            Console.WriteLine("Press any key to continue ...");
            Console.Read();
        }
    }
}
