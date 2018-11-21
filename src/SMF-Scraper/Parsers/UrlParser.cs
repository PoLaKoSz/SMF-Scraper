using System;
using System.Text.RegularExpressions;

namespace PoLaKoSz.SMF.Scraper.Parsers
{
    public class CommaUrlParser : IUrlParser
    {
        public char Separator { get; }



        public CommaUrlParser()
        {
            Separator = ',';
        }



        public int FromURL(string url, string paramName)
        {
            var match = Regex.Match(url, $@"(?<={paramName},)\d+");

            if (match.Success)
                return int.Parse(match.Value);

            throw new FormatException($"{url} not contains {paramName} or not a comma seperated url!");
        }
    }

    public class EqualSignUrlParser : IUrlParser
    {
        public char Separator { get; }



        public EqualSignUrlParser()
        {
            Separator = '=';
        }



        public int FromURL(string url, string paramName)
        {
            var match = Regex.Match(url, $@"(?<={paramName}=)\d+");

            if (match.Success)
                return int.Parse(match.Value);

            throw new FormatException($"{url} not contains {paramName} or not an equal sign seperated url!");
        }
    }

    public interface IUrlParser
    {
        char Separator { get; }

        int FromURL(string url, string paramName);
    }
}
