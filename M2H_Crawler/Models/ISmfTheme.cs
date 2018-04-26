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



        /// <summary>
        /// XPath to the current board children boards to extract each one of it to a Board Model
        /// </summary>
        string BoardChildrenBoards { get; }

        /// <summary>
        /// XPath to extract the board children board name to the Board Model
        /// </summary>
        string BoardChildrenBoardName { get; }


        /// <summary>
        /// XPath to extract the current Board's topics to a Topic Model
        /// </summary>
        string BoardTopicModel { get; }
        
        /// <summary>
        /// XPath to the Topic URL
        /// </summary>
        string BoardTopicLink { get; }


        /// <summary>
        /// XPath to extract the current Topic's messages to a Message Model
        /// </summary>
        string TopicMessageModel { get; }

        /// <summary>
        /// XPath to the Topic URL with the current Message
        /// </summary>
        string TopicMessageLink { get; }

        /// <summary>
        /// XPath to the current Message posted time section
        /// </summary>
        string TopicMessagePostedTime { get; }

        /// <summary>
        /// XPath to the current Message body section
        /// </summary>
        string TopicMessageBody { get; }

        /// <summary>
        /// XPath to the current Message edited section
        /// </summary>
        string TopicMessageEdited { get; }
    }
}
