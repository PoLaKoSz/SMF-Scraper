using HtmlAgilityPack;
using System.IO;
using System.Linq;

namespace M2H_Crawler.Converters
{
    public abstract class BBConverter
    {
        protected HtmlDocument HtmlDocument { get; private set; }



        public BBConverter(string sourceCode)
        {
            HtmlDocument = new HtmlDocument();
            HtmlDocument.LoadHtml(sourceCode);
        }


        
        /// <summary>
        /// Select every node with the given XPath and replace it accordin
        /// to the child class implementation
        /// </summary>
        /// <param name="xpathToTag"></param>
        protected void ReplaceThisTag(string xpathToTag)
        {
            var htmlNodes = HtmlDocument.DocumentNode.SelectNodes(xpathToTag) ?? Enumerable.Empty<HtmlNode>();

            foreach (HtmlNode htmlNode in htmlNodes)
            {
                var newNode = HtmlDocument.CreateTextNode(ReplaceToThis(htmlNode));
                htmlNode.ParentNode.ReplaceChild(newNode, htmlNode);
            }
        }

        /// <summary>
        /// Implementation what should the code do on the found XPath elements
        /// </summary>
        /// <param name="htmlNode"></param>
        /// <returns>This string will replace the found XPath element</returns>
        protected abstract string ReplaceToThis(HtmlNode htmlNode);

        /// <summary>
        /// Save the DOM changes to a string
        /// </summary>
        /// <returns></returns>
        protected string SaveChanges()
        {
            string result = "";
            using (StringWriter writer = new StringWriter())
            {
                HtmlDocument.Save(writer);
                result = writer.ToString();
            }

            return result;
        }
    }
}
