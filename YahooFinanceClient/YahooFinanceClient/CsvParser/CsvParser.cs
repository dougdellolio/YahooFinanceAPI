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
            var stockData = webClient.DownloadFile(ticker, "abb2b3pokjj5k4j6k5w");

            var splitData = stockData.Split(',');

            return new PricingData
            {
                Ask = CleanData(splitData[0]),
                Bid = CleanData(splitData[1]),
                AskRealTime = CleanData(splitData[2]),
                BidRealTime = CleanData(splitData[3]),
                PreviousClose = CleanData(splitData[4]),
                Open = CleanData(splitData[5]),
                FiftyTwoWeekHigh = CleanData(splitData[6]),
                FiftyTwoWeekLow = CleanData(splitData[7]),
                FiftyTwoWeekLowChange = CleanData(splitData[8]),
                FiftyTwoWeekHighChange = CleanData(splitData[9]),
                FiftyTwoWeekLowChangePercent = CleanData(splitData[10]),
                FiftyTwoWeekHighChangePercent = CleanData(splitData[11]),
                FiftyTwoWeekRange = splitData[12],
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
