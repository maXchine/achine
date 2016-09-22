using System.Net;
using System.Text;
using System.Xml;
using Achine.Common.Text;
using Achine.Common.Xml;

namespace Achine.Common.Net {

    public static class HttpRequest {

        public static XmlDocument Request(string url, string host = "", string method = "GET") {

            var request = (HttpWebRequest) WebRequest.Create(url);

            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.86 Safari/537.36";
            request.KeepAlive = true;
            request.Method = method;

            if (host.NonEmpty())
                request.Host = host;

            using (var response = request.GetResponse()) {
                using (var stream = response.GetResponseStream()) {
                    return stream == null ? null : stream.ToXml();
                }
            }
        }

        public static string GetHtml(string url)
        {
            var webClient = new WebClient {Credentials = CredentialCache.DefaultCredentials};
            var data = webClient.DownloadData(url);
            return Encoding.UTF8.GetString(data);
        }

    }


}
