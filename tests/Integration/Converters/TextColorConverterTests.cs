using PoLaKoSz.SMF.Scraper.Converters;
using NUnit.Framework;

namespace PoLaKoSz.SMF.Scraper.Tests.Integration.Converters
{
    public class TextColorConverterTests
    {
        public class RemoveTextColorMethod
        {
            [Test]
            public void Converters_TextColor_NoHtmlTagInside()
            {
                var expected = "[color=blue]Welcome![/color]";

                var actual = new TextColorConverter("<span style=\"color: blue;\" class=\"bbc_color\">Welcome!</span>")
                    .RemoveTextColor();

                Assert.AreEqual(expected, actual);
            }

            [Test]
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
