using M2H_Crawler.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace M2H_Crawler_Tests.Converters
{
    [TestClass]
    public class TextColorConverterTests
    {
        [TestClass]
        public class RemoveTextColorMethod
        {
            [TestMethod]
            public void Converters_TextColor_NoHtmlTagInside()
            {
                var expected = "[color=blue]Welcome![/color]";

                var actual = new TextColorConverter("<span style=\"color: blue;\" class=\"bbc_color\">Welcome!</span>")
                    .RemoveTextColor();

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void Converters_TextColor_HtmlTagInside()
            {
                var expected = "[color=blue]<b>Welcome!</b>[/color]";

                var actual = new TextColorConverter("<span style=\"color: blue;\" class=\"bbc_color\"><b>Welcome!</b></span>")
                    .RemoveTextColor();

                Assert.AreEqual(expected, actual);
            }
        }
    }
}
