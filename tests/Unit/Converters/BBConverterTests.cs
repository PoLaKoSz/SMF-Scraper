using NUnit.Framework;
using PoLaKoSz.SMF.Scraper.Converters;

namespace PoLaKoSz.SMF.Scraper.Tests.Unit.Converters
{
    class BBConverterTests
    {
        [Test]
        public void Can_Convert_Multiple_HTML_Tags_One_By_One_In_One_String()
        {
            var expected = "[b]BOLD[/b]<br>" +
                "[i]ITALIC[/i]<br>" +
                "[u]UNDERLINE[/u]<br>" +
                "[s]STRIKETHROUGH[/s]<br>" +
                "[size=14pt]Changed font size[/size]<br>" +
                "[color=#ffffff]Changed font color[/color]";

            var converter = new BBConverter(
                "<strong>BOLD</strong><br>" +
                "<em>ITALIC</em><br>" +
                "<span class=\"bbc_u\">UNDERLINE</span><br>" +
                "<del>STRIKETHROUGH</del><br>" +
                "<span style=\"font-size: 14pt;\" class=\"bbc_size\">Changed font size</span><br>" +
                "<span style=\"color: #ffffff;\" class=\"bbc_color\">Changed font color</span>");


            var actual = converter.EverythingFromHTML();


            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_Convert_Inside_A_Deeply_Nested_Input()
        {
            var expected =
                "[color=#FFFFFF]" +
                    "[size=14pt]" +
                        "[b]Hi![/b]<br>" +
                        "[i]Lorem [u]ipsum[/u] (...).[/i]<br>" +
                        "[s]My TODO List[/s]<br>" +
                    "[/size]" +
                "[/color]";

            var converter = new BBConverter(
                "<span style=\"color: #FFFFFF;\" class=\"bbc_color\">" +
                    "<span style=\"font-size: 14pt;\" class=\"bbc_size\">" +
                        "<strong>Hi!</strong><br>" +
                        "<em>Lorem <span class=\"bbc_u\">ipsum</span> (...).</em><br>" +
                        "<del>My TODO List</del><br>" +
                    "</span>" +
                "</span>");


            var actual = converter.EverythingFromHTML();


            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_Convert_Strong_Tag()
        {
            var expected = "[b]Damn![/b]";
            var converter = new BBConverter("<strong>Damn!</strong>");


            var actual = converter.EverythingFromHTML();


            Assert.That(actual, Is.Not.Null, "actual");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Can_Convert_Nested_Strong_Tag()
        {
            var expected = "[b]Damn! What the [b]hell?[/b][/b]";
            var converter = new BBConverter("<strong>Damn! What the <strong>hell?</strong></strong>");


            var actual = converter.EverythingFromHTML();


            Assert.That(actual, Is.Not.Null, "actual");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Can_Convert_Smileys()
        {
            var expected = ":) Szia :)";
            var converter = new BBConverter("<img src=\"http://metin2hungary.dev/Smileys/default/smiley.gif\" alt=\":)\" title=\"Mosolyog\" class=\"smiley\"> Szia <img src=\"http://metin2hungary.dev/Smileys/default/smiley.gif\" alt=\":)\" title=\"Mosolyog\" class=\"smiley\">");


            var actual = converter.EverythingFromHTML();


            Assert.That(actual, Is.Not.Null, "actual");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Can_Convert_Smiley()
        {
            var expected = "Hi ;)";
            var converter = new BBConverter("Hi <img src=\"http://metin2hungary.dev/Smileys/default/wink.gif\" alt=\";)\" title=\"Kacsint\" class=\"smiley\">");


            var actual = converter.EverythingFromHTML();


            Assert.That(actual, Is.Not.Null, "actual");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Can_Convert_Em_Tag()
        {
            var expected = "[i]Damn![/i]";
            var converter = new BBConverter("<em>Damn!</em>");


            var actual = converter.EverythingFromHTML();


            Assert.That(actual, Is.Not.Null, "actual");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Can_Convert_Nested_Em_Tag()
        {
            var expected = "[i]Damn! What the [i]hell?[/i][/i]";
            var converter = new BBConverter("<em>Damn! What the <em>hell?</em></em>");


            var actual = converter.EverythingFromHTML();


            Assert.That(actual, Is.Not.Null, "actual");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Can_Convert_Strikethrought_Tag()
        {
            var expected = "[s]Damn![/s]";
            var converter = new BBConverter("<del>Damn!</del>");


            var actual = converter.EverythingFromHTML();


            Assert.That(actual, Is.Not.Null, "actual");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Can_Convert_Nested_Strikethrought_Tag()
        {
            var expected = "[s]Damn! What the [s]hell?[/s][/s]";
            var converter = new BBConverter("<del>Damn! What the <del>hell?</del></del>");


            var actual = converter.EverythingFromHTML();


            Assert.That(actual, Is.Not.Null, "actual");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Can_Convert_Color_Tag_Definied_With_Letters()
        {
            var expected = "[color=blue]<b>Welcome!</b>[/color]";
            var converter = new BBConverter("<span style=\"color: blue;\" class=\"bbc_color\"><b>Welcome!</b></span>");


            var actual = converter.EverythingFromHTML();


            Assert.That(actual, Is.Not.Null, "actual");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Can_Convert_Color_Tag_Definied_With_RGB()
        {
            var expected = "[color=#ffffff]<b>Welcome!</b>[/color]";
            var converter = new BBConverter("<span style=\"color: #ffffff;\" class=\"bbc_color\"><b>Welcome!</b></span>");


            var actual = converter.EverythingFromHTML();


            Assert.That(actual, Is.Not.Null, "actual");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Can_Convert_Size_Tag()
        {
            var expected = "[size=12pt]Damn![/size]";
            var converter = new BBConverter("<span style=\"font-size: 12px\" class=\"bbc_size\">Damn!</span>");


            var actual = converter.EverythingFromHTML();


            Assert.That(actual, Is.Not.Null, "actual");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Can_Convert_Nested_Size_Tag()
        {
            var expected = "[size=12pt]Damn! What the [size=13pt]hell?[/size][/size]";
            var converter = new BBConverter("<span style=\"font-size: 12px\" class=\"bbc_size\">Damn! What the <span style=\"font-size: 13px\" class=\"bbc_size\">hell?</span></span>");


            var actual = converter.EverythingFromHTML();


            Assert.That(actual, Is.Not.Null, "actual");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Can_Convert_Underline_Tag()
        {
            var expected = "[u]Damn![/u]";
            var converter = new BBConverter("<span class=\"bbc_u\">Damn!</span>");


            var actual = converter.EverythingFromHTML();


            Assert.That(actual, Is.Not.Null, "actual");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Can_Convert_Nested_Underline_Tag()
        {
            var expected = "[u]Damn! What the [u]hell?[/u][/u]";
            var converter = new BBConverter("<span style=\"font-size: 12px\" class=\"bbc_u\">Damn! What the <span class=\"bbc_u\">hell?</span></span>");


            var actual = converter.EverythingFromHTML();


            Assert.That(actual, Is.Not.Null, "actual");
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
