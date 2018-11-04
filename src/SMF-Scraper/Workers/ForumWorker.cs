using HtmlAgilityPack;
using SMF_Scraper.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SMF_Scraper.Workers
{
    public class ForumWorker : Webpage, IWebpage
    {
        public List<Category> ForumCategories { get; private set; }



        public ForumWorker(string sourceCode, ISmfTheme websiteTheme)
            : base(sourceCode, websiteTheme)
        {
            ForumCategories = new List<Category>();
        }

        public ForumWorker(Uri webpageURL, ISmfTheme websiteTheme)
            : base(webpageURL, websiteTheme)
        {
            ForumCategories = new List<Category>();
        }



        protected override List<IWebpage> Parse()
        {
            Console.WriteLine("{0, 50} : Parse Forum content", base.URL);

            var nextWebpages = new List<IWebpage>();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(base.SourceCode);

            var forumBoards = htmlDoc.DocumentNode.SelectNodes(Theme.ForumBoards);

            foreach (var boardNode in forumBoards)
            {
                var boardURL = RemovePhpSessid(boardNode.SelectSingleNode(Theme.ForumBoardLink).Attributes["href"].Value);
                var boardUri = new Uri(boardURL);

                nextWebpages.Add(new BoardWorker(boardUri, Theme));
            }

            return nextWebpages;
        }

        public string RemovePhpSessid(string value)
        {
            return Regex.Replace(value, @"\?PHPSESSID=\w+", "");
        }

        /// <summary>
        /// Return the forum main categories with their boards in it
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Category> GetForumCategories()
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(base.SourceCode);

            var forumCategories = htmlDoc.DocumentNode.SelectNodes(Theme.ForumCategories);

            if (forumCategories.Count % 2 != 0)
                throw new Exception("forumCategories.Count is not what is should be!");

            var categorieCollection = new List<Category>();

            for (int i = 0; i < forumCategories.Count - 1; i+=2)
            {
                var categoryHeader = forumCategories[i];
                var   categoryBody = forumCategories[i + 1];

                int      categoryID = Convert.ToInt32(categoryHeader.Id.Substring(9));
                int   categoryOrder = i / 2;
                string categoryName = categoryHeader.InnerText.Trim();

                var boardCollection = GetCategorieBoards(categoryID, categoryBody);

                if (boardCollection.Count > 0)
                    categorieCollection.Add(new Category(categoryID, categoryOrder, categoryName, boardCollection));
                else
                    categorieCollection.Add(new Category(categoryID, categoryOrder, categoryName));
            }

            return categorieCollection;
        }

        public List<Board> GetCategorieBoards(int categoryID, HtmlNode categoryBody)
        {
            var boardCollection = new List<Board>();

            var boardNodes = categoryBody.SelectNodes(Theme.ForumBoard);

            for (int i = 0; i < boardNodes.Count; i++)
            {
                var board = boardNodes[i];

                int             boardID = Convert.ToInt32(board.Id.Substring(6));
                string        boardName = board.SelectSingleNode(Theme.ForumBoardName).InnerText.Trim();
                string boardDescription = board.SelectSingleNode(Theme.ForumBoardDescription).InnerText.Trim();
                int          boardOrder = boardCollection.Count;

                if (HasChildrenBoards(boardNodes, i))
                {
                    boardCollection.Add(new Board(boardID, categoryID, boardName, boardDescription, boardOrder, GetBoardChieldBoards(categoryID, boardNodes[i + 1])));
                    i++;//prevent crawling children board and step to the next board
                }
                else
                    boardCollection.Add(new Board(boardID, categoryID, boardName, boardDescription, boardOrder));
            }

            return boardCollection;
        }

        public bool HasChildrenBoards(HtmlNodeCollection boardNodes, int currentIndex)
        {
            if (boardNodes.Count <= currentIndex + 1)
                return false;

            return boardNodes[currentIndex + 1].Id.Contains("_children");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="parentBoard"></param>
        /// <returns></returns>
        public List<Board> GetBoardChieldBoards(int categoryID, HtmlNode parentBoard)
        {
            var boardCollection = new List<Board>();

            var chieldBoardNotes = parentBoard.SelectNodes(Theme.ForumBoardChieldBoard);

            for (int i = 0; i < chieldBoardNotes.Count; i++)
            {
                var board = chieldBoardNotes[i];

                var  boardURL = board.Attributes["href"].Value;
                var     match = Regex.Match(boardURL, @"(?<=board.)\d{1,2}");

                if (!match.Success)
                    throw new Exception("Regex couldn't find the child boardID for this URL: " + boardURL);

                int      boardID = Convert.ToInt32(match.Value);
                string boardName = board.InnerText;
                int   boardOrder = i;

                boardCollection.Add(new Board(boardID, categoryID, boardName, "", boardOrder));
            }

            return boardCollection;
        }
    }
}
