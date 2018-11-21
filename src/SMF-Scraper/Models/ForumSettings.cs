using System;
using System.Globalization;

namespace PoLaKoSz.SMF.Scraper.Models
{
    public class ForumSettings
    {
        public string DateFormat { get; set; }
        public CultureInfo Culture { get; set; }
        public ISmfTheme Theme { get; }
        public Uri RootURL { get; }



        public ForumSettings(ISmfTheme theme, Uri rootURL)
        {
            DateFormat = "yyyy-MM-dd, HH:mm::ss";
            Culture    = new CultureInfo("hu-HU");
            Theme = theme;
            RootURL = rootURL;
        }
    }
}
