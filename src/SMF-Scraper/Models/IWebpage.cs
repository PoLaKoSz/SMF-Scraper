using System;
using System.Collections.Generic;

namespace SMF_Scraper.Models
{
    public interface IWebpage
    {
        Uri URL { get; }


        void Download();
        List<IWebpage> NextWebpages();
    }
}
