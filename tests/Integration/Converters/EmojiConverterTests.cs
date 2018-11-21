using PoLaKoSz.SMF.Scraper.Converters;
using NUnit.Framework;

namespace PoLaKoSz.SMF.Scraper.Tests.Integration.Converters
{
    public class EmojiConverterTests
    {
        public class RemoveEmojiImagesMethod
        {
            [Test]
            public void Converters_Emoji_RemoveSmiley()
            {
                var expected = ":) Szia :)";

                var actual = new EmojiConverter("<img src=\"http://metin2hungary.dev/Smileys/default/smiley.gif\" alt=\":)\" title=\"Mosolyog\" class=\"smiley\"> Szia <img src=\"http://metin2hungary.dev/Smileys/default/smiley.gif\" alt=\":)\" title=\"Mosolyog\" class=\"smiley\">")
                    .RemoveEmojiImages();

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void Converters_Emoji_RemoveWink()
            {
                var expected = "Hi ;)";

                var actual = new EmojiConverter("Hi <img src=\"http://metin2hungary.dev/Smileys/default/wink.gif\" alt=\";)\" title=\"Kacsint\" class=\"smiley\">")
                    .RemoveEmojiImages();

                Assert.AreEqual(expected, actual);
            }
        }
    }
}
