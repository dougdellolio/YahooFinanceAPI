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
            var pricingData = RetrievePricingData(ticker);
            var volumeData = RetrieveVolumeData(ticker);

            return new Stock 
            {
                PricingData = pricingData,
                VolumeData = volumeData
            };
        }

        private PricingData RetrievePricingData(string ticker)
        {
            var stockData = webClient.DownloadFile(ticker, "abb2b3po");

            var splitData = stockData.Split(',');

            return new PricingData
            {
                Ask = CleanData(splitData[0]),
                Bid = CleanData(splitData[1]),
                AskRealTime = CleanData(splitData[2]),
                BidRealTime = CleanData(splitData[3]),
                PreviousClose = CleanData(splitData[4]),
                Open = CleanData(splitData[5]),
            };
        }

        private VolumeData RetrieveVolumeData(string ticker)
        {
            var stockData = webClient.DownloadFile(ticker, "va5b6k3a2");

            var splitData = stockData.Split(',');

            return new VolumeData
            {
                CurrentVolume = CleanData(splitData[0]),
                AskSize= CleanData(splitData[1]),
                BidSize = CleanData(splitData[2]),
                LastTradeSize = CleanData(splitData[3]),
                AverageDailyVolume = CleanData(splitData[4]),
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
