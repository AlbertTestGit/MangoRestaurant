namespace Mango.Web;

public static class SD
{
    public static string ProductAPIBase { get; set; }

    enum ApiType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}