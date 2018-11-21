using PoLaKoSz.SMF.Scraper.Parsers;
using System;
using System.Globalization;

namespace PoLaKoSz.SMF.Scraper.Models
{
    public class ForumSettings
    {
        internal string DateFormat { get; }
        internal CultureInfo Culture { get; }
        internal ISmfTheme Theme { get; }
        internal Uri RootURL { get; }
        internal IUrlParser UrlParser { get; }
        public string CustomHomePageURL { internal get; set; }



        public ForumSettings(ISmfTheme theme, Uri rootURL)
            : this(theme, rootURL, new EqualSignUrlParser()) { }

        public ForumSettings(ISmfTheme theme, Uri rootURL, IUrlParser urlType)
        {
            DateFormat = "yyyy-MM-dd, HH:mm::ss";
            Culture    = new CultureInfo("hu-HU");
            Theme = theme;
            RootURL = rootURL;
            UrlParser = urlType;
            CustomHomePageURL = "";
        }
    }
}
