using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PoLaKoSz.SMF.Scraper.Converters
{
    public class BBConverter
    {
        private HtmlDocument _htmlDocument;
        private List<BBConverterBase> _convertTasks;
        private List<ICoinverter> _nodes;



        public BBConverter(string sourceCode)
        {
            _htmlDocument = new HtmlDocument();
            _htmlDocument.LoadHtml(sourceCode);

            _convertTasks = new List<BBConverterBase>();
            _nodes = new List<ICoinverter>();
        }



        public string EverythingFromHTML()
        {
            return
                 Emojis()
                .BoldText()
                .Emojis()
                .ItalicText()
                .StrikethroughtText()
                .TextColor()
                .TextSize()
                .UnderlinedText()
                    .FromHTML();
        }


        private BBConverter Emojis()
        {
            _convertTasks.Add(new EmojiConverter());

            return this;
        }

        private BBConverter BoldText()
        {
            _convertTasks.Add(new BoldStyleConverter());

            return this;
        }

        private BBConverter ItalicText()
        {
            _convertTasks.Add(new ItalicTextConverter());

            return this;
        }

        private BBConverter StrikethroughtText()
        {
            _convertTasks.Add(new StrikethroughTextConverter());

            return this;
        }

        private BBConverter TextColor()
        {
            _convertTasks.Add(new TextColorConverter());

            return this;
        }

        private BBConverter TextSize()
        {
            _convertTasks.Add(new TextSizeConverter());

            return this;
        }

        private BBConverter UnderlinedText()
        {
            _convertTasks.Add(new UnderlineTextConverter());

            return this;
        }

        private string FromHTML()
        {
            foreach (var task in _convertTasks)
            {
                _nodes.AddRange(GetAffectedNodes(task));
            }

            _nodes = _nodes.OrderByDescending(node => node.Deepness).ToList();

            foreach (var node in _nodes)
            {
                ReplaceThisNode(node);
            }

            SaveChanges();

            return _htmlDocument.DocumentNode.OuterHtml;
        }

        private List<ICoinverter> GetAffectedNodes(BBConverterBase converter)
        {
            var nodes = new List<ICoinverter>();

            var htmlNodes = _htmlDocument.DocumentNode.SelectNodes($"//{converter.HtmlTag()}") ?? Enumerable.Empty<HtmlNode>();

            foreach (HtmlNode htmlNode in htmlNodes.Reverse())
            {
                var node = converter.Clone();

                node.Deepness = htmlNode.XPath.Split('/').Length;
                node.XPath = htmlNode.XPath;

                nodes.Add(node);
            }

            return nodes;
        }

        private void ReplaceThisNode(ICoinverter node)
        {
            var oldNode = _htmlDocument.DocumentNode.SelectSingleNode(node.XPath);

            // This is only a hostfix, because this is not a well designed
            //  BBCode parser (yet)
            if (node.GetType() == typeof(EmojiConverter) && oldNode == null)
                return;

            var newNode = _htmlDocument.CreateTextNode(node.BBCode(oldNode));
            oldNode.ParentNode.ReplaceChild(newNode, oldNode);
        }

        private void SaveChanges()
        {
            using (StringWriter writer = new StringWriter())
            {
                _htmlDocument.Save(writer);
            }
        }
    }
}
