namespace YahooFinanceClient.Models
{
    public class RatioData
    {
        public decimal? EarningsPerShare { get; set; }

        public decimal? EPSEstimateCurrentYear { get; set; }

        public decimal? EPSEstimateNextYear { get; set; }

        public decimal? EPSEstimateNextQuarter { get; set; }

        public decimal? BookValue { get; set; }

        public string EBITDA { get; set; }
    }
}
