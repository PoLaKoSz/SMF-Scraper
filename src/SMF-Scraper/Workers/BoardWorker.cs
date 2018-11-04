using HtmlAgilityPack;
using SMF_Scraper.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SMF_Scraper.Workers
{
    public class BoardWorker : Webpage, IWebpage
    {
        public BoardWorker(string sourceCode, ISmfTheme websiteTheme)
            : base(sourceCode, websiteTheme) { }

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

        /// <summary>
        /// Extract the current Board children Boards
        /// </summary>
        /// <returns></returns>
        public List<Board> GetChildrenBoards()
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(base.SourceCode);

            var childrenBoardsCollection = htmlDoc.DocumentNode.SelectNodes(Theme.BoardChildrenBoards);

            var childBoards = new List<Board>();

            if (childrenBoardsCollection == null)
                return childBoards;
            
            int categoryID = new CategoryExtractor(htmlDoc.DocumentNode).GetIDFromNavigationSection();

            foreach (var chieldBoard in childrenBoardsCollection)
            {
                int      boardID = Convert.ToInt32(chieldBoard.Id.Substring(6));
                string boardName = chieldBoard.SelectSingleNode(Theme.BoardChildrenBoardName).InnerText;

                childBoards.Add(new Board(boardID, categoryID, boardName, childBoards.Count));
            }

            return childBoards;
        }

        /// <summary>
        /// Return every Topic in this Board webpage
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        /// <exception cref="RegexMatchTimeoutException"></exception>
        public List<Topic> GetBoardTopics()
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(base.SourceCode);

            var topicCollection = htmlDoc.DocumentNode.SelectNodes(Theme.BoardTopicModel);

            var boardTopics = new List<Topic>();

            if (topicCollection == null)
                return boardTopics;

            foreach (var topic in topicCollection)
            {
                var asd = topic.SelectSingleNode(Theme.BoardTopicLink);
                var  topicURL = topic.SelectSingleNode(Theme.BoardTopicLink).Attributes["href"].Value;
                int   topicID = Convert.ToInt32(Regex.Match(topicURL, @"(?<=topic,)\d+").Value);
                var topicName = topic.SelectSingleNode(Theme.BoardTopicLink).InnerText.Trim();

                boardTopics.Add(new Topic(topicID, topicName));
            }

            return boardTopics;
        }
    }
}
