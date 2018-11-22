using HtmlAgilityPack;
using PoLaKoSz.SMF.Scraper.Models;
using System.Collections.Generic;

namespace PoLaKoSz.SMF.Scraper.Parsers
{
    public class BoardParser
    {
        public void Execute(Board board, string sourceCode, ISmfTheme theme, IUrlParser urlParser)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(sourceCode);

            var boardMainFrameNode = htmlDoc.DocumentNode.SelectSingleNode(theme.BoardContainer);

            // TODO : This is good, when the board has only one page, but what if not?
            board.ChildBoards = ParseChildrenBoards(boardMainFrameNode, theme);

            board.Topics = ParseTopics(boardMainFrameNode, theme, urlParser);
        }


        private List<Board> ParseChildrenBoards(HtmlNode boardMainFrame, ISmfTheme theme)
        {
            var boards = new List<Board>();

            var boardNodes = boardMainFrame.SelectNodes(theme.BoardChildrenBoards);

            if (boardNodes == null)
                return boards;

            foreach (var board in boardNodes)
            {
                var boardNode = board.SelectSingleNode(theme.BoardChildrenBoardName);

                string boardID = boardNode.Attributes["name"].Value;
                int id = int.Parse(boardID.Substring(1));

                string name = boardNode.InnerText;

                boards.Add(new Board(id, name));
            }

            return boards;
        }

        private List<Topic> ParseTopics(HtmlNode boardMainFrame, ISmfTheme theme, IUrlParser urlParser)
        {
            var topics = new List<Topic>();

            var topicNodes = boardMainFrame.SelectNodes(theme.BoardTopicModel);

            if (topicNodes == null)
                return topics;

            foreach (var topicNode in topicNodes)
            {
                var urlNode = topicNode.SelectSingleNode(theme.BoardTopicLink);

                string topicURL = urlNode.Attributes["href"].Value;
                int id = urlParser.FromURL(topicURL, "topic");

                string name = urlNode.InnerText.Trim();

                topics.Add(new Topic(id, name));
            }

            return topics;
        }
    }
}
