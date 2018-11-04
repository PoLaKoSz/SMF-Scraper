using PoLaKoSz.SMF.Scraper.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace PoLaKoSz.SMF.Scraper.Tests.Integration.Workers
{
    [TestClass]
    public class CategoryExtractorTests
    {
        [TestMethod]
        public void BlackStormTheme_WithoutAuthentication_CategoryExtractor_GetIDFromNavigationSection()
        {
            var expected = 2;

            var sourceCode = File.ReadAllText(@"..\Debug\StaticResource\Metin2Hungary.net\Board\BlackStorm\2018_04_25_NonAuthenticated.html");
            var actual = new CategoryExtractor(sourceCode).GetIDFromNavigationSection();

            Assert.AreEqual(expected, actual);
        }
    }
}
