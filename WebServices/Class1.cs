using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using HtmlAgilityPack;

namespace WebServices
{
    public interface IURLParser
    {
    }

    public class URLParser : IURLParser
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

    public interface IUrlParser
    {
    }

    public class AmazonParser : IUrlParser
    {
        private HtmlDocument _htmlDocument;
        private string PriceId = "//span[@class='a-size-medium a-color-price offer-price a-text-normal']";
        private string ProductNameId = "productTitle";

        public AmazonParser(URLParser parser, string url)
        {
            _htmlDocument = new HtmlDocument();
            _htmlDocument.LoadHtml(parser.ParseWebPage(url));
        }

        public string GetProductName()
        {
            var node = _htmlDocument.GetElementbyId(ProductNameId);
            if (node != null)
                return HtmlEntity.DeEntitize(node.InnerText);
            return null;
        }

        public string GetProductPrice()
        {
            return ParsePriceTag(1);
        }

        private string ParsePriceTag(int parameterPosition)
        {
            var innerText = _htmlDocument.DocumentNode.SelectSingleNode(PriceId).InnerText;
            return HtmlEntity.DeEntitize(innerText.Split(' ')[parameterPosition]);
        }

        public string GetProductPicture()
        {
            return string.Empty;

        }

        public string GetProductCurrency()
        {
            return ParsePriceTag(0);
        }
    }
}
