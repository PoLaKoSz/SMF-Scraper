using PoLaKoSz.SMF.Scraper.Models;

namespace PoLaKoSz.SMF.Scraper.Themes.Metin2HungaryNet
{
    public class BlackStormTheme : ISmfTheme
    {
        /// <summary>
        /// XPath for the forum categories container to extract into a Categorie Model
        /// </summary>
        public string ForumCategories { get; private set; }

        /// <summary>
        /// XPath to the given Categorie's Board container to extract into a Board Model
        /// </summary>
        public string ForumBoard { get; private set; }

        public string ForumBoardName { get; private set; }
        public string ForumBoardDescription { get; private set; }

        public string ForumBoardChieldBoard { get; private set; }


        /// <summary>
        /// XPath for the forum's boards
        /// </summary>
        public string ForumBoards { get; private set; }

        /// <summary>
        /// XPath for the forum's boards link
        /// </summary>
        public string ForumBoardLink { get; private set; }




        /// <summary>
        /// XPath to the current board children boards to extract each one of it to a Board Model
        /// </summary>
        public string BoardChildrenBoards { get; private set; }

        /// <summary>
        /// XPath to extract the board children board name to the Board Model
        /// </summary>
        public string BoardChildrenBoardName { get; private set; }


        /// <summary>
        /// XPath to extract the current Board's topics to a Topic Model
        /// </summary>
        public string BoardTopicModel { get; private set; }

        /// <summary>
        /// XPath to the Topic URL
        /// </summary>
        public string BoardTopicLink { get; private set; }



        /// <summary>
        /// XPath to extract the current Topic's messages to a Message Model
        /// </summary>
        public string TopicMessageModel { get; private set; }

        /// <summary>
        /// XPath to the Topic URL with the current Message
        /// </summary>
        public string TopicMessageLink { get; private set; }

        /// <summary>
        /// XPath to the current Message posted time section
        /// </summary>
        public string TopicMessagePostedTime { get; private set; }

        /// <summary>
        /// XPath to the current Message body section
        /// </summary>
        public string TopicMessageBody { get; private set; }

        /// <summary>
        /// XPath to the current Message edited section
        /// </summary>
        public string TopicMessageEdited { get; private set; }



        public BlackStormTheme()
        {
            ForumCategories       = "//div[@id='boardindex_table']//table//tbody[@class='header' or @class='content']";
            ForumBoard            = ".//tr[not(contains (@class, 'sub_cat'))]";
            ForumBoardName        = ".//td[@class='info']//a[@class='subject']";
            ForumBoardDescription = ".//td[@class='info']//p";
            ForumBoardChieldBoard = ".//td//a";

            ForumBoards    = "//div[@id='boardindex_table']//table//tbody[@class='content']//tr[@class='windowbg2']//td[@class='info']";
            ForumBoardLink = ".//a";

            BoardChildrenBoards    = "//div[@class='tborder childboards']//div[@class='table_frame']//table[@class='table_list']//tbody[@class='content']//tr";
            BoardChildrenBoardName = ".//td[@class='info']//a";

            BoardTopicModel = "//div[@id='messageindex']//table[@class='table_grid']//tbody//tr";
            BoardTopicLink  = ".//td[contains(@class, 'subject')]//div//span//a";

            TopicMessageModel      = "//div[@id='forumposts']//form//div[@class='windowbg' or @class='windowbg2']//div[@class='post_wrapper']";
            TopicMessageLink       = ".//div[@class='postarea']//div[@class='flow_hidden']//div[@class='keyinfo']//h5[contains(@id, 'subject_')]//a";
            TopicMessagePostedTime = ".//div[@class='postarea']//div[@class='flow_hidden']//div[@class='keyinfo']//div[@class='smalltext']//text()[2]";
            TopicMessageBody       = ".//div[@class='postarea']//div[@class='post']//div[@class='inner']";
            TopicMessageEdited     = ".//div[@class='moderatorbar']//div[@class='smalltext modified']//em";
        }
    }
}
