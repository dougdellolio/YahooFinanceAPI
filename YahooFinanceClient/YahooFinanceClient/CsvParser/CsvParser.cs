using System;
using YahooFinanceClient.WebClient;
using YahooFinanceClient.Models;

namespace YahooFinanceClient.CsvParser
{
    public class CsvParser : ICsvParser
    {
        private readonly IWebClient webClient;

        public CsvParser(IWebClient webClient)
        {
            this.webClient = webClient;
        }

        public Stock RetrieveStock(string ticker)
        {
            var pricing = RetrievePricing(ticker);

            return new Stock 
            {
                Pricing = pricing
            };
        }

        private Pricing RetrievePricing(string ticker)
        {
            var stockData = webClient.DownloadFile(ticker, "abb2b3po");

            var splitData = stockData.Split(',');

            return new Pricing
            {
                Ask = CleanData(splitData[0]),
                Bid = CleanData(splitData[1]),
                AskRealTime = CleanData(splitData[2]),
                BidRealTime = CleanData(splitData[3]),
                PreviousClose = CleanData(splitData[4]),
                Open = CleanData(splitData[5]),
            };
        }

        private decimal? CleanData(string data)
        {
            if(data == "N/A")
            {
                return null;
            }

            return Convert.ToDecimal(data);
        }
    }
}
