using System.Globalization;

namespace SMF_Scraper.Models
{
    public class ForumSettings
    {
        public string DateFormat { get; private set; }
        public CultureInfo Culture { get; private set; }



        public ForumSettings()
        {
            DateFormat = "yyyy-MM-dd, HH:mm::ss";
            Culture    = new CultureInfo("hu-HU");
        }
    }
}
