using System;
using WebServices;

namespace AmazonURLParser
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			NewMethod ();

		}

		static void NewMethod ()
		{
			var parser = ParseAmazonURLInfo ();
			DisplayAmazonURLInfo (parser);
			NewMethod ();
		}

		static AmazonParser ParseAmazonURLInfo ()
		{
			Console.WriteLine ("Please input the URL you want to test");
			var url = Console.ReadLine ();
			var urlParser = new UrlParser ();
			var amazonParser = new AmazonParser (urlParser, url);
			return amazonParser;
		}

		static void DisplayAmazonURLInfo (AmazonParser amazonParser)
		{
			Console.WriteLine(string.Format("{0}, {1} {2}", amazonParser.GetProductName(), amazonParser.GetProductPrice(), amazonParser.GetProductCurrency()));
		}
	}
}
