using System.IO;

namespace PoLaKoSz.SMF.Scraper.Tests.Integration
{
    internal abstract class TestClassBase
    {
        private static readonly string _rootDir;
        private readonly string _folderPath;



        static TestClassBase()
        {
            _rootDir = "StaticResource";
        }

        public TestClassBase(params string[] folderNames)
        {
            _folderPath = _rootDir;

            foreach (var subFolder in folderNames)
            {
                _folderPath = Path.Combine(_folderPath, subFolder);
            }
        }



        public string GetHtmlData(string fileName)
        {
            string path = Path.Combine(_folderPath, fileName + ".html");

            return File.ReadAllText(path);
        }
    }
}
