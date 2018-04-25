using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using M2H_Crawler.Models;

namespace M2H_Crawler.Workers
{
    public class TopicWorker : Webpage, IWebpage
    {
        public TopicWorker(Uri webpageURL, ISmfTheme websiteTheme)
            : base(webpageURL, websiteTheme) { }



        protected override List<IWebpage> Parse()
        {
            Console.WriteLine("{0, 50} : Parse Topic content", base.URL);

            var nextWebpages = new List<IWebpage>();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(base.SourceCode);

            var nextPageUrl = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='main_content_section']//div[@class='pagesection']//div[@class='pagelinks floatleft']//strong//following-sibling::a[@class='navPages']").Attributes["href"].Value;

            if (nextPageUrl != null)
                nextWebpages.Add(new TopicWorker(new Uri(nextPageUrl), Theme));

            return new List<IWebpage>();
        }

        private void ExtractMessages(HtmlDocument htmlDoc)
        {
            var messageMainFrame = htmlDoc.DocumentNode.SelectNodes("//div[@id='forumposts']//div[@class='windowbg' or @class='windowbg2']");

            foreach (var message in messageMainFrame)
            {
                string messageURL = message.SelectSingleNode(".//div[@class='postarea']//div[@class='flow_hidden']//a").Attributes["href"].Value;
                int messageID = Convert.ToInt32(messageURL.Substring(messageURL.IndexOf("#")));

                string post = message.SelectSingleNode(".//div[@class='postarea']").InnerText;
            }
        }
    }
}
