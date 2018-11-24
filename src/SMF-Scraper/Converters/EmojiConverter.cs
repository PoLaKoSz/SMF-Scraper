﻿using HtmlAgilityPack;

namespace PoLaKoSz.SMF.Scraper.Converters
{
    public class EmojiConverter : BBConverterBase
    {
        public override ICoinverter Clone()
        {
            return new EmojiConverter();
        }


        public override string BBCode(HtmlNode htmlNode)
        {
            return htmlNode.Attributes["alt"].Value;
        }

        public override string HtmlTag()
        {
            return "img[@class='smiley']";
        }
    }
}
