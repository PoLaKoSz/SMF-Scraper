using HtmlAgilityPack;
using M2H_Crawler.Models;
using System;
using System.Collections.Generic;

namespace M2H_Crawler.Workers
{
    public class BoardWorker : Webpage, IWebpage
    {
        public BoardWorker(Uri boardURL, ISmfTheme websiteTheme)
            : base(boardURL, websiteTheme) { }



        protected override List<IWebpage> Parse()
        {
            Console.WriteLine("{0, 50} : Parse Board content", base.URL);

            var nextWebpages = new List<IWebpage>();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(base.SourceCode);

            var boardMainFrame = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='main_content_section']");

            nextWebpages.AddRange(GetChildrenBoards(boardMainFrame.SelectNodes(".//div[@class='tborder childboards']//tr[@class='windowbg2']//td[@class='info']")));
            nextWebpages.AddRange(GetTopics(boardMainFrame.SelectNodes(".//div[@id='messageindex']//tbody//tr")));

            return nextWebpages;
        }

        private List<IWebpage> GetChildrenBoards(HtmlNodeCollection boardChildrenBoards)
        {
            if (boardChildrenBoards == null)
                return new List<IWebpage>();

            var nextWebpages = new List<IWebpage>();

            foreach (var board in boardChildrenBoards)
            {
                string boardURL = board.SelectSingleNode(".//a").Attributes["href"].Value;
                Uri    boardUri = new Uri(boardURL);

                nextWebpages.Add(new BoardWorker(boardUri, Theme));
            }

            return nextWebpages;
        }

        private List<IWebpage> GetTopics(HtmlNodeCollection boardTopics)
        {
            if (boardTopics == null)
                return new List<IWebpage>();

            var nextWebpages = new List<IWebpage>();

            foreach (var topic in boardTopics)
            {
                string topicURL = topic.SelectSingleNode(".//td[@class='subject windowbg2']//span//a").Attributes["href"].Value;
                Uri    topicUri = new Uri(topicURL);

                nextWebpages.Add(new TopicWorker(topicUri, Theme));
            }

            return nextWebpages;
        }
    }
}
