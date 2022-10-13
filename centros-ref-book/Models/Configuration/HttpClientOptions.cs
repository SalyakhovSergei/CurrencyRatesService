namespace centros_ref_book.Models.Configuration
{
    public class HttpClientOptions
    {
        public string BaseUrl { get; set; }
        public string AuthKeyHeaderName { get; set; }
        public string AuthKeyHeaderValue { get; set; }
        public int[] WaitAndRetryDelaysInSeconds { get; set; } = { 1, 3, 5 };
    }
}