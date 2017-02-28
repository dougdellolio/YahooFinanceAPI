namespace YahooFinanceClient.Models
{
    public class AverageData
    {
        public decimal? DayLow { get; set; }

        public decimal? DayHigh { get; set; }

        public decimal? LastTradePrice { get; set; }

        public decimal? FiftyDayMovingAverage { get; set; }

        public decimal? TwoHundredDayMovingAverage{ get; set; }

        public decimal? OneYearTargetPrice { get; set; }
    }
}
