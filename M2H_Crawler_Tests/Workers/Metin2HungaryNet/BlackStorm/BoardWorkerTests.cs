using M2H_Crawler.Models;
using M2H_Crawler.Themes.Metin2HungaryNet;
using M2H_Crawler.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace M2H_Crawler_Tests.Workers.Metin2HungaryNet.BlackStorm
{
    [TestClass]
    public class BoardWorkerTests
    {
        [TestMethod]
        public void BlackStormTheme_WithoutAuthentication_BoardWorker_GetChildrenBoards()
        {
            var expected = new List<Board>()
            {
                new Board(80, 2, "Lezárt témák", 0),
            };

            var sourceCode = File.ReadAllText("StaticResource/Metin2Hungary.net/Board/BlackStorm/2018_04_25_NonAuthenticated.html");
            var     actual = new BoardWorker(sourceCode, new BlackStormTheme())
                .GetChildrenBoards();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
