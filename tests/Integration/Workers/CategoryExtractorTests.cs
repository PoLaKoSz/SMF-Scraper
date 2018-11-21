using PoLaKoSz.SMF.Scraper.Workers;
using NUnit.Framework;

namespace PoLaKoSz.SMF.Scraper.Tests.Integration.Workers
{
    class CategoryExtractorTests : TestClassBase
    {
        public CategoryExtractorTests()
            : base("Metin2Hungary.net", "Board", "BlackStorm") { }



        [Test]
        public void BlackStormTheme_WithoutAuthentication_CategoryExtractor_GetIDFromNavigationSection()
        {
            var expected = 2;

            var sourceCode = base.GetHtmlData("2018_04_25_NonAuthenticated");
            var actual = new CategoryExtractor(sourceCode).GetIDFromNavigationSection();

            Assert.AreEqual(expected, actual);
        }
    }
}
