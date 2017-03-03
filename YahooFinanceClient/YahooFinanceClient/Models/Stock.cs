namespace YahooFinanceClient.Models
{
    public class Stock
    {
        public PricingData PricingData { get; set; }

        public VolumeData VolumeData { get; set; }

        public AverageData AverageData { get; set; }

        public DividendData DividendData { get; set; }

        public RatioData RatioData { get; set; }
    }
}
