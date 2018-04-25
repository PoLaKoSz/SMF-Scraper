using M2H_Crawler.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace M2H_Crawler.Workers
{
	public class NonAuthenticated
	{
		private List<Task<Webpage>> Tasks { get; set; }
        private Uri ForumURL { get; set; }

        private ISmfTheme Theme { get; set; }

        public int MaxPagesToCrawl { get; private set; }
        public int CurrentCrawledPages { get; private set; }



        public NonAuthenticated(Uri forumHomePageUrl, ISmfTheme webpageTheme)
            : this(forumHomePageUrl, webpageTheme, int.MaxValue) { }

        public NonAuthenticated(Uri forumHomePageUrl, ISmfTheme webpageTheme, int maxPageToCrawl)
        {
            Tasks    = new List<Task<Webpage>>();
            ForumURL = forumHomePageUrl;

            Theme = webpageTheme;

            MaxPagesToCrawl = maxPageToCrawl;
        }



        public void Run()
        {
            ScrapeWebpage(new ForumWorker(ForumURL, Theme));

            Task.WaitAll(Tasks.ToArray());
        }

        private void ScrapeWebpage(IWebpage webpage)
        {
            if (CurrentCrawledPages >= MaxPagesToCrawl)
            {
                Console.WriteLine("Crawled page count reached the maximum");
                return;
            }

            Console.WriteLine("{0, 50} : Starting to scrape", webpage.URL);

            webpage.Download();

            CurrentCrawledPages++;

            Console.WriteLine("{0, 50} : SourceCode downloaded", webpage.URL);

            foreach (Webpage newWebpage in webpage.NextWebpages())
                ScrapeWebpage(newWebpage);
        }
    }
}
