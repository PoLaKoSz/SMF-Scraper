using System;
using System.Collections.Generic;

namespace M2H_Crawler.Models
{
    public interface IWebpage
    {
        Uri URL { get; }


        void Download();
        List<IWebpage> NextWebpages();
    }
}
