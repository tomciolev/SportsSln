namespace SportsStore.Infrastructure
{
    public static class UrlExtensions
    {
        //pathandquery extension method operates on HttpRequest class,
        //method generates a URL that the browser will be returned to
        //after the cart has been updated
        public static string PathAndQuery(this HttpRequest request) =>
        request.QueryString.HasValue
        ? $"{request.Path}{request.QueryString}"
        : request.Path.ToString();
    }
}
