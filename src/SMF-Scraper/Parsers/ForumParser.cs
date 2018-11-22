using HtmlAgilityPack;
using PoLaKoSz.SMF.Scraper.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PoLaKoSz.SMF.Scraper.Parsers
{
    internal class ForumParser
    {
        /// <summary>
        /// Gets a list of <see cref="Category"/> from the given source code.
        /// </summary>
        /// <exception cref="NodeNotFoundException"></exception>
        /// <exception cref="Exception"></exception>
        public List<Category> Execute(string sourceCode, ISmfTheme theme)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(sourceCode);

            var forumCategories = htmlDoc.DocumentNode.SelectNodes(theme.ForumCategories);

            if (forumCategories.Count % 2 != 0)
                throw new NodeNotFoundException("forumCategories.Count is not what is should be!");

            var categorieCollection = new List<Category>();

            for (int i = 0; i < forumCategories.Count - 1; i += 2)
            {
                var categoryHeader = forumCategories[i];
                var categoryBody = forumCategories[i + 1];

                int categoryID = Convert.ToInt32(categoryHeader.Id.Substring(9));
                int categoryOrder = i / 2;
                string categoryName = categoryHeader.InnerText.Trim();

                var boardCollection = GetCategoryBoards(categoryBody, theme);

                if (boardCollection.Count > 0)
                    categorieCollection.Add(new Category(categoryID, categoryOrder, categoryName, boardCollection));
                else
                    categorieCollection.Add(new Category(categoryID, categoryOrder, categoryName));
            }

            return categorieCollection;
        }


        private List<Board> GetCategoryBoards(HtmlNode categoryBody, ISmfTheme theme)
        {
            var boardCollection = new List<Board>();

            var boardNodes = categoryBody.SelectNodes(theme.ForumBoard);

            for (int i = 0; i < boardNodes.Count; i++)
            {
                var board = boardNodes[i];

                int boardID = Convert.ToInt32(board.Id.Substring(6));
                string boardName = board.SelectSingleNode(theme.ForumBoardName).InnerText.Trim();
                string boardDescription = board.SelectSingleNode(theme.ForumBoardDescription).InnerText.Trim();

                if (HasChildrenBoards(boardNodes, i))
                {
                    boardCollection.Add(new Board(boardID, boardName, boardDescription, GetBoardChieldBoards(boardNodes[i + 1], theme)));
                    i++;//prevent crawling children board and step to the next board
                }
                else
                    boardCollection.Add(new Board(boardID, boardName, boardDescription));
            }

            return boardCollection;
        }

        private bool HasChildrenBoards(HtmlNodeCollection boardNodes, int currentIndex)
        {
            if (boardNodes.Count <= currentIndex + 1)
                return false;

            return boardNodes[currentIndex + 1].Id.Contains("_children");
        }

        private List<Board> GetBoardChieldBoards(HtmlNode parentBoard, ISmfTheme theme)
        {
            var boardCollection = new List<Board>();

            var chieldBoardNotes = parentBoard.SelectNodes(theme.ForumBoardChieldBoard);

            for (int i = 0; i < chieldBoardNotes.Count; i++)
            {
                var board = chieldBoardNotes[i];

                var boardURL = board.Attributes["href"].Value;
                var match = Regex.Match(boardURL, @"(?<=board.)\d{1,2}");

                if (!match.Success)
                    throw new Exception("Regex couldn't find the child boardID for this URL: " + boardURL);

                int boardID = Convert.ToInt32(match.Value);
                string boardName = board.InnerText;

                boardCollection.Add(new Board(boardID, boardName));
            }

            return boardCollection;
        }
    }
}
