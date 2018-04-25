using M2H_Crawler.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace M2H_Crawler_Tests.Workers
{
    [TestClass]
    public class CategoryExtractorTests
    {
        [TestMethod]
        public void BlackStormTheme_GetIDFromNavigationSection_WithoutAuthentication()
        {
            var expected = 2;

            var sourceCode = File.ReadAllText(@"..\Debug\StaticResource\Metin2Hungary.net\Board\BlackStorm\2018_04_25_NonAuthenticated.html");
            var actual = new CategoryExtractor(sourceCode).GetIDFromNavigationSection();

            Assert.AreEqual(expected, actual);
        }
    }
}
