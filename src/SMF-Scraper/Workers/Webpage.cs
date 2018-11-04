using HtmlAgilityPack;
using PoLaKoSz.SMF.Scraper.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PoLaKoSz.SMF.Scraper.Workers
{
	public abstract class Webpage : IWebpage
	{
		public Uri URL { get; protected set; }
        protected string SourceCode { get; set; }
        public ISmfTheme Theme { get; private set; }



        public Webpage(string sourceCode, ISmfTheme websiteTheme)
        {
            SourceCode = sourceCode;
            Theme      = websiteTheme;
        }

        public Webpage(Uri webpageURL, ISmfTheme websiteTheme)
        {
            URL   = webpageURL;
            Theme = websiteTheme;
        }


        
        public void Download()
        {
            if (URL == null)
                throw new ArgumentNullException("URL");

            var client = new WebClient()
            {
                Encoding = Encoding.UTF8,
            };

            SourceCode = client
                .DownloadStringTaskAsync(URL)
                .Result;

            // Fix: Reference to undeclared entity 'nbsp'
            SourceCode = HtmlEntity.DeEntitize(SourceCode);
        }

        protected abstract List<IWebpage> Parse();

		public List<IWebpage> NextWebpages()
		{
            return Parse();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var webpage = (IWebpage)obj;

            if (URL != webpage.URL)
                return false;

            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
