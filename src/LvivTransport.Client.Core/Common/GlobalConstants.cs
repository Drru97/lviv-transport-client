namespace LvivTransport.Client.Core.Common
{
    public static class GlobalConstants
    {
        public const string ClientVersion = "1";

        public const string BaseUrl = "https://lad.lviv.ua";

        public const string Json = "application/json";

        public const string Html = "text/html";

        public static readonly int[] RetriableStatuses = { 500, 502, 503, 504 };

        public const int RetryCount = 3;
    }
}
