using System;

namespace M2H_Crawler.Models
{
    public interface ISmfTheme
    {
        /// <summary>
        /// XPath to the forum categories container to extract into a Categorie Model
        /// </summary>
        string ForumCategories { get; }

        /// <summary>
        /// XPath to the given Categorie's Board container to extract into a Board Model
        /// </summary>
        string ForumBoard { get; }

        string ForumBoardName { get; }
        string ForumBoardDescription { get; }

        string ForumBoardChieldBoard { get; }


        /// <summary>
        /// XPath for the forum's boards
        /// </summary>
        string ForumBoards { get; }

        /// <summary>
        /// XPath for the forum's boards link
        /// </summary>
        string ForumBoardLink { get; }
    }
}
