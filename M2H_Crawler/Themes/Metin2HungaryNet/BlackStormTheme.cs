using M2H_Crawler.Models;

namespace M2H_Crawler.Themes.Metin2HungaryNet
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



        public BlackStormTheme()
        {
            ForumCategories       = "//div[@id='boardindex_table']//table//tbody[@class='header' or @class='content']";
            ForumBoard            = ".//tr[not(contains (@class, 'sub_cat'))]";
            ForumBoardName        = ".//td[@class='info']//a[@class='subject']";
            ForumBoardDescription = ".//td[@class='info']//p";
            ForumBoardChieldBoard = ".//td//a";

            ForumBoards    = "//div[@id='boardindex_table']//table//tbody[@class='content']//tr[@class='windowbg2']//td[@class='info']";
            ForumBoardLink = ".//a";
        }
    }
}
