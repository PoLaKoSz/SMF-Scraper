using M2H_Crawler.Models;
using M2H_Crawler.Themes.Metin2HungaryNet;
using M2H_Crawler.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace M2H_Crawler_Tests.Workers.Metin2HungaryNet.BlackStorm
{
	[TestClass]
	public class ForumWorkerTests
    {
        private ISmfTheme Theme = new BlackStormTheme();

        [TestMethod]
        public void BlackStormTheme_GetForumBoardsWithoutAuthentication()
        {
            var expected = new List<IWebpage>()
            {
                new BoardWorker(new Uri("http://metin2hungary.net/index.php/board,25.0.html"), Theme),
                new BoardWorker(new Uri("http://metin2hungary.net/index.php/board,24.0.html"), Theme),

                new BoardWorker(new Uri("http://metin2hungary.net/index.php/board,5.0.html"), Theme),
                new BoardWorker(new Uri("http://metin2hungary.net/index.php/board,2.0.html"), Theme),
                new BoardWorker(new Uri("http://metin2hungary.net/index.php/board,1.0.html"), Theme),
                new BoardWorker(new Uri("http://metin2hungary.net/index.php/board,14.0.html"), Theme),
                new BoardWorker(new Uri("http://metin2hungary.net/index.php/board,15.0.html"), Theme),
                new BoardWorker(new Uri("http://metin2hungary.net/index.php/board,3.0.html"), Theme),
                new BoardWorker(new Uri("http://metin2hungary.net/index.php/board,19.0.html"), Theme),
                new BoardWorker(new Uri("http://metin2hungary.net/index.php/board,54.0.html"), Theme),
                new BoardWorker(new Uri("http://metin2hungary.net/index.php/board,23.0.html"), Theme),
            };

            string savedSourceCode = File.ReadAllText("StaticResource/Metin2Hungary.net/HomePage/BlackStorm/2018_04_24_NonAuthenticated.html");

            var forumScrapper = new ForumWorker(savedSourceCode, Theme);
            var actual        = forumScrapper.NextWebpages();

            CollectionAssert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void BlackStormTheme_GetForumCategoriesWithoutAuthentication()
        {
            var expected = new List<Category>()
            {
                new Category(4, 0, "Hírek", new List<Board>()
                {
                    new Board(25, 4, "DDMT2 hírek",                                   "A DDMT2 szerver hírei.", 0),
                    new Board(24, 4, "Fórum hírek", "Itt a fórummal kapcsolatos híreket/információkat találod", 1),
                }),
                new Category(2, 1, "Metin2", new List<Board>()
                {
                    new Board( 5, 2,              "Segítség", "A játékkal kapcsolatos kérdések.", 0, new List<Board>()
                    {
                        new Board(80, 2, "Lezárt témák", 0),
                    }),
                    new Board( 2, 2,    "Karakterek Építése", "Segítség a karakterek építéséhez", 1, new List<Board>()
                    {
                        new Board( 9, 2,   "Ninja", 0),
                        new Board(11, 2,  "Shaman", 1),
                        new Board(10, 2,    "Sura", 2),
                        new Board( 8, 2, "Warrior", 3),
                    }),
                    new Board( 1, 2,      "Tippek - Trükkök",  "Amire álmodban sem gondolnál...", 2),
                    new Board(14, 2,            "Küldetések",               "Küldetések leírása", 3),
                    new Board(15, 2,                "Itemek",                                 "", 4),
                    new Board( 3, 2,                "Metin2",       "Játékkal kapcsolatos témák", 5),
                    new Board(19, 2,         "Keres - Kínál",                                 "", 6),
                    new Board(54, 2, "Karakter kereskedelem",                                 "", 7, new List<Board>()
                    {
                        new Board(55, 2, "Vásárolni akarok", 0),
                        new Board(56, 2,    "Eladni akarok", 1),
                        new Board(57, 2,  "Cserélni akarok", 2),
                    }),
                    new Board(23, 2,      "Privát szerverek",   "Nem hivatalos Metin2 szerverek", 8, new List<Board>()
                    {
                        new Board(32, 2, "ddmt2 - magyar pserver", 0),
                        new Board(33, 2, "Egyéb privát szerverek", 1),
                        new Board(35, 2,       "Szerver készítés", 2),
                        new Board(70, 2,         "Computer World", 3),
                        new Board(45, 2,       "Web - fejlesztés", 4),
                    }),
                }),
            };

            string savedSourceCode = File.ReadAllText("StaticResource/Metin2Hungary.net/HomePage/BlackStorm/2018_04_24_NonAuthenticated.html");

            var forumScrapper = new ForumWorker(savedSourceCode, Theme);
            var        actual = forumScrapper.GetForumCategories();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
