using M2H_Crawler.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace M2H_Crawler_Tests.Converters
{
    [TestClass]
    public class EmojiConverterTests
    {
        [TestClass]
        public class RemoveEmojiImagesMethod
        {
            [TestMethod]
            public void Converters_Emoji_RemoveSmiley()
            {
                var expected = ":) Szia :)";

                var actual = new EmojiConverter("<img src=\"http://metin2hungary.dev/Smileys/default/smiley.gif\" alt=\":)\" title=\"Mosolyog\" class=\"smiley\"> Szia <img src=\"http://metin2hungary.dev/Smileys/default/smiley.gif\" alt=\":)\" title=\"Mosolyog\" class=\"smiley\">")
                    .RemoveEmojiImages();

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
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
