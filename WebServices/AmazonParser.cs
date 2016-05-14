using HtmlAgilityPack;

namespace WebServices
{
    public class AmazonParser : IWebSiteCatalogParser
    {
        private HtmlDocument _htmlDocument;
        private const string bookPriceId = "//span[@class='a-size-medium a-color-price offer-price a-text-normal']";
        private const string ProductNameId = "productTitle";
        private const string GenericPriceId = "priceblock_ourprice";

        public AmazonParser(UrlParser parser, string url)
        {
            _htmlDocument = new HtmlDocument();
            _htmlDocument.LoadHtml(parser.ParseWebPage(url));
        }

        public string GetProductName()
        {
            var node = _htmlDocument.GetElementbyId(ProductNameId);
            if (node != null)
                return HtmlEntity.DeEntitize(node.InnerText).Trim();
            return null;
        }

        public string GetProductPrice()
        {
            return ParsePriceTag(1);
        }

        private string ParsePriceTag(int parameterPosition)
        {
            string innerText = null;
            var node = _htmlDocument.GetElementbyId(GenericPriceId);
            if (node != null)
                innerText = node.InnerText;
            else
            {
                node = _htmlDocument.DocumentNode.SelectSingleNode(bookPriceId);
                if (node != null)
                    innerText = node.InnerText;
            }
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