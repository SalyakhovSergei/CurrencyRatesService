namespace centros_ref_book.Models.Configuration
{
    public class SearchAccountsOptions : BaseServiceOptions
    {
        public string HttpClientName { get; set; }
        public int ConsumingBatchSize { get; set; } = 100;
        public bool IsUseEPA { get; set; } = true;
        public string CurrencyRatesBaseURL { get; set; }
        public int MaxParallelism { get; set; }
        public string CurrencyRatesULXtykKey { get; set; }
        public int[] DelayMultipliers { get; set; } = { 1, 1, 2, 3, 5, 8, 13 };
        public int BaseUnitInMilliseconds { get; set; } = 100;
    }
}