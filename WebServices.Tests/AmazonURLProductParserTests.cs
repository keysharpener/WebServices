using System;
using NFluent;
using NUnit.Framework;

namespace WebServices.Tests
{
    [TestFixture]
    public class AmazonURLProductParserTests
    {
        [Test]
        public void Should_return_product_name_for_random_page()
        {
            var productWebPage =
                @"https://www.amazon.fr/test-exp%C3%A9rience-inou%C3%AFe-preuve-lapr%C3%A8s-vie/dp/2226319085/ref=sr_1_1?ie=UTF8&qid=1463219510&sr=8-1&keywords=test";
            var urlParser = new URLParser();
            var amazonParser = new AmazonParser(urlParser, productWebPage);
            Check.That(amazonParser.GetProductName()).Equals("Le test : Une expérience inouïe, la preuve de l'après-vie ?");
        }

        [Test]
        public void Should_return_product_amount_for_random_page()
        {
            var productWebPage =
                @"https://www.amazon.fr/test-exp%C3%A9rience-inou%C3%AFe-preuve-lapr%C3%A8s-vie/dp/2226319085/ref=sr_1_1?ie=UTF8&qid=1463219510&sr=8-1&keywords=test";
            var urlParser = new URLParser();
            var amazonParser = new AmazonParser(urlParser, productWebPage);
            Console.WriteLine(amazonParser.GetProductPrice());
            Check.That(amazonParser.GetProductPrice()).Equals("19,50");
            Check.That(amazonParser.GetProductCurrency().Equals("EUR"));
        }
    }
}
