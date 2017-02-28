using System;
using YahooFinanceClient.WebClient;
using YahooFinanceClient.Models;
using System.Globalization;

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
            var averagesData = RetrieveAverageData(ticker);
            var dividendData = RetrieveDividendData(ticker);

            return new Stock
            {
                PricingData = pricingData,
                VolumeData = volumeData,
                AverageData = averagesData,
                DividendData = dividendData
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
                FiftyTwoWeekLowChangePercent = CleanPercent(splitData[10]),
                FiftyTwoWeekHighChangePercent = CleanPercent(splitData[11]),
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
                AskSize = CleanData(splitData[1]),
                BidSize = CleanData(splitData[2]),
                LastTradeSize = CleanData(splitData[3]),
                AverageDailyVolume = CleanData(splitData[4]),
            };
        }

        private AverageData RetrieveAverageData(string ticker)
        {
            var stockData = webClient.DownloadFile(ticker, "ghl1m3m4t8");

            var splitData = stockData.Split(',');

            return new AverageData
            {
                DayHigh = CleanData(splitData[0]),
                DayLow = CleanData(splitData[1]),
                LastTradePrice = CleanData(splitData[2]),
                FiftyDayMovingAverage = CleanData(splitData[3]),
                TwoHundredDayMovingAverage = CleanData(splitData[4]),
                OneYearTargetPrice = CleanData(splitData[5])
            };
        }

        private DividendData RetrieveDividendData(string ticker)
        {
            var stockData = webClient.DownloadFile(ticker, "ydr1q");

            var splitData = stockData.Split(',');

            return new DividendData
            {
                DividendYield = CleanData(splitData[0]),
                DividendPerShare = CleanData(splitData[1]),
                DividendPayDate = ParseDate(splitData[2]),
                ExDividendDate = ParseDate(splitData[3])
            };
        }

        private DateTime? ParseDate(string data)
        {
            if (data == "N/A")
            {
                return null;
            }

            return DateTime.Parse(data);
        }

        private decimal? CleanData(string data)
        {
            if (data == "N/A")
            {
                return null;
            }

            return Convert.ToDecimal(data);
        }

        private decimal? CleanPercent(string data)
        {
            if (data == "N/A")
            {
                return null;
            }

            var direction = data.ToCharArray()[0];
            var number = data.Substring(1, data.Length - 2);

            if (direction == '-')
            {
                return -Convert.ToDecimal(number);
            }

            return Convert.ToDecimal(number);
        }
    }
}
