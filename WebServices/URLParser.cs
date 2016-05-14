using System.Net;

namespace WebServices
{
    public class UrlParser : IURLParser
    {
        private string _url;
        public string ParseWebPage(string url)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }
    }
}