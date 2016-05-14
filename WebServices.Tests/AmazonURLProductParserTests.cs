using System;
using NFluent;
using NUnit.Framework;

namespace WebServices.Tests
{
    [TestFixture]
    public class AmazonURLProductParserTests
    {
        [TestCase("https://www.amazon.fr/test-exp%C3%A9rience-inou%C3%AFe-preuve-lapr%C3%A8s-vie/dp/2226319085/ref=sr_1_1?ie=UTF8&qid=1463219510&sr=8-1&keywords=test", "Le test : Une expérience inouïe, la preuve de l'après-vie ?", "19,50", "EUR")]
        [TestCase("https://www.amazon.fr/Microsoft-5C5-00066-Console-Xbox-500Go/dp/B016ZLYVKM/ref=sr_1_1?s=videogames&ie=UTF8&qid=1463246715&sr=1-1&keywords=xbox+one", "Console Xbox One 500Go", "299,00", "EUR")]
        [TestCase("https://www.amazon.fr/Congregation-Leprous/dp/B00VU7KYPI/ref=sr_1_1?s=music&ie=UTF8&qid=1463247200&sr=1-1&keywords=leprous+the+congregation", "The Congregation", "17,50", "EUR")]
        [TestCase("http://tinyurl.com/gr6q2k2", "The Congregation", "17,50", "EUR")]
        public void Should_return_product_amount_for_random_page(string productUrl, string expectedProductName, string expectedProductPrice, string expectedCurrency)
        {
            var urlParser = new URLParser();
            var amazonParser = new AmazonParser(urlParser, productUrl);
            Check.That(amazonParser.GetProductPrice()).Equals(expectedProductPrice);
            Check.That(amazonParser.GetProductCurrency().Equals(expectedCurrency));
            Check.That(amazonParser.GetProductName()).Equals(expectedProductName);
        }
    }
}
