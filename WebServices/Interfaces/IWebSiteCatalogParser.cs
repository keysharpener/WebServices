namespace WebServices
{
    public interface IWebSiteCatalogParser
    {
        string GetProductName();
        string GetProductPrice();
        string GetProductPicture();
        string GetProductCurrency();
    }
}