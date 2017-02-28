using System;

namespace YahooFinanceClient.Models
{
    public class DividendData
    {
        public decimal? DividendYield { get; set; }

        public decimal? DividendPerShare { get; set; }

        public DateTime? DividendPayDate { get; set; }

        public DateTime? ExDividendDate { get; set; }
    }
}
