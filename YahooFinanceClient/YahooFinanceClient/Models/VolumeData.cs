namespace YahooFinanceClient.Models
{
    public class VolumeData
    {
        public decimal? CurrentVolume { get; set; }

        public decimal? AskSize { get; set; }

        public decimal? BidSize { get; set; }

        public decimal? LastTradeSize { get; set; }

        public decimal? AverageDailyVolume { get; set; }
    }
}
