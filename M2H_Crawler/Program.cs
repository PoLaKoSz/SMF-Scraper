using M2H_Crawler.Themes.Metin2HungaryNet;
using M2H_Crawler.Workers;
using System.IO;

namespace M2H_Crawler
{
	class Program
	{
		static void Main(string[] args)
        {
            var sourceCode = File.ReadAllText(@"../../../M2H_Crawler_Tests\bin\Debug\StaticResource\Metin2Hungary.net\Board\BlackStorm\2018_04_25_NonAuthenticated.html");
            var      board = new BoardWorker(sourceCode, new BlackStormTheme());

            board.GetChildrenBoards();
        }
    }
}
