using M2H_Crawler.Themes.Metin2HungaryNet;
using M2H_Crawler.Workers;
using System;

namespace M2H_Crawler
{
	class Program
	{
        static void Main(string[] args)
        {
            var theme        = new BlackStormTheme();
            var forumRootUrl = new Uri("http://metin2hungary.dev/");

            var scrapper = new NonAuthenticated(forumRootUrl, theme);
            scrapper.Run();

            Console.WriteLine("Press any key to continue ...");
            Console.Read();

        }
    }
}
