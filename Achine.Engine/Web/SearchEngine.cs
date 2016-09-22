using System.Collections.Generic;
using System.IO;
using System.Xml;
using Achine.Common.Net;

namespace Achine.Engine.Web {
    public static class SearchEngine
    {

        private static bool _stop;

        public static void SaveUnhandledQueue()
        {
            _stop = true;
        }

        public static void SaveImage(Stream stream) {

        }

        public static void AddSeedUrl(string seedUrl) {
            Urls.Enqueue(seedUrl);
        }

        private static readonly Queue<string> Urls = new Queue<string>();

        public static void StartUp(string seedUrl) {

            Urls.Enqueue(seedUrl);

            while (Urls.Count > 0)
            {
                if (_stop)
                    return;
                Excavate(Urls.Dequeue());
            }
        }

        private static void Excavate(string url) {
            var html = HttpRequest.Request(url);

            var xml = new XmlDocument();
        }

        private static void Analysis(XmlDocument html) {
            var aList = html.GetElementsByTagName("a");
            var imgList = html.GetElementsByTagName("img");
            foreach (XmlNode a in aList)
            {
                if (a.Attributes != null)
                {
                    var url = a.Attributes["href"];
                }
            }
        }
    }
}
