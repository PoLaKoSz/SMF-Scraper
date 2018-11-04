using System;
using System.Collections.Generic;

namespace PoLaKoSz.SMF.Scraper.Models
{
    public interface IWebpage
    {
        Uri URL { get; }


        void Download();
        List<IWebpage> NextWebpages();
    }
}
