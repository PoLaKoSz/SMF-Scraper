using PoLaKoSz.SMF.Scraper.Models;
using PoLaKoSz.SMF.Scraper.Themes.Metin2HungaryNet;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PoLaKoSz.SMF.Scraper.EndPoints;

namespace PoLaKoSz.SMF.Scraper.Tests.Integration.EndPoints
{
    class ForumEndPointTests : TestClassBase
    {
        private ForumSettings _settings;
        private HttpClientMock _httpClient;



        [OneTimeSetUp]
        public void Init()
        {
            _settings = new ForumSettings(new BlackStormTheme(), new Uri("http://metin2hungary.test"));
            _httpClient = new HttpClientMock();
        }

        public ForumEndPointTests()
            : base("Metin2Hungary.net", "HomePage", "BlackStorm") { }



        [Test]
        public async Task BlackStormTheme_WithoutAuthentication_ForumWorker_GetForumCategories()
        {
            var expected = new List<Category>()
            {
                new Category(4, 0,  "Hírek", new List<Board>()
                {
                    new Board(25, "DDMT2 hírek",                                   "A DDMT2 szerver hírei."),
                    new Board(24, "Fórum hírek", "Itt a fórummal kapcsolatos híreket/információkat találod"),
                }),
                new Category(2, 1, "Metin2", new List<Board>()
                {
                    new Board( 5,               "Segítség", "A játékkal kapcsolatos kérdések.", new List<Board>()
                    {
                        new Board(80, "Lezárt témák"),
                    }),
                    new Board( 2,     "Karakterek Építése", "Segítség a karakterek építéséhez", new List<Board>()
                    {
                        new Board( 9,   "Ninja"),
                        new Board(11,  "Shaman"),
                        new Board(10,    "Sura"),
                        new Board( 8, "Warrior"),
                    }),
                    new Board( 1,       "Tippek - Trükkök", "Amire álmodban sem gondolnál..."),
                    new Board(14,             "Küldetések",              "Küldetések leírása"),
                    new Board(15,                 "Itemek"),
                    new Board( 3,                 "Metin2",      "Játékkal kapcsolatos témák"),
                    new Board(19,          "Keres - Kínál"),
                    new Board(54,  "Karakter kereskedelem",                                 "", new List<Board>()
                    {
                        new Board(55, "Vásárolni akarok"),
                        new Board(56,    "Eladni akarok"),
                        new Board(57,  "Cserélni akarok"),
                    }),
                    new Board(23,       "Privát szerverek",   "Nem hivatalos Metin2 szerverek", new List<Board>()
                    {
                        new Board(32, "ddmt2 - magyar pserver"),
                        new Board(33, "Egyéb privát szerverek"),
                        new Board(35,       "Szerver készítés"),
                        new Board(70,         "Computer World"),
                        new Board(45,       "Web - fejlesztés"),
                    }),
                }),
            };

            _httpClient.ResponseHTML = base.GetHtmlData("2018_04_24_NonAuthenticated");

            var forumScrapper = new ForumEndPoint(_settings, _httpClient);
            var actual = await forumScrapper.GetCategories();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
