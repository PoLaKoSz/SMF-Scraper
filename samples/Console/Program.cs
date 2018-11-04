using PoLaKoSz.SMF.Scraper.Themes.Metin2HungaryNet;
using PoLaKoSz.SMF.Scraper.Workers;
using System;

namespace PoLaKoSz.SMF.Scraper.Samples.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var theme = new BlackStormTheme();
            var forumRootUrl = new Uri("http://metin2hungary.dev/");

            var scrapper = new NonAuthenticated(forumRootUrl, theme);
            scrapper.Run();

            Console.WriteLine("Press any key to continue ...");
            Console.Read();
        }
    }
}
