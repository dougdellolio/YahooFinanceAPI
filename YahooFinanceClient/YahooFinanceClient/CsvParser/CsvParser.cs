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
                Ask = ConvertStringToDecimal(splitData[0]),
                Bid = ConvertStringToDecimal(splitData[1]),
                AskRealTime = ConvertStringToDecimal(splitData[2]),
                BidRealTime = ConvertStringToDecimal(splitData[3]),
                PreviousClose = ConvertStringToDecimal(splitData[4]),
                Open = ConvertStringToDecimal(splitData[5]),
                FiftyTwoWeekHigh = ConvertStringToDecimal(splitData[6]),
                FiftyTwoWeekLow = ConvertStringToDecimal(splitData[7]),
                FiftyTwoWeekLowChange = ConvertStringToDecimal(splitData[8]),
                FiftyTwoWeekHighChange = ConvertStringToDecimal(splitData[9]),
                FiftyTwoWeekLowChangePercent = ConvertStringToPercentDecimal(splitData[10]),
                FiftyTwoWeekHighChangePercent = ConvertStringToPercentDecimal(splitData[11]),
                FiftyTwoWeekRange = splitData[12],
            };
        }

        private VolumeData RetrieveVolumeData(string ticker)
        {
            var stockData = webClient.DownloadFile(ticker, "va5b6k3a2");

            var splitData = stockData.Split(',');

            return new VolumeData
            {
                CurrentVolume = ConvertStringToDecimal(splitData[0]),
                AskSize = ConvertStringToDecimal(splitData[1]),
                BidSize = ConvertStringToDecimal(splitData[2]),
                LastTradeSize = ConvertStringToDecimal(splitData[3]),
                AverageDailyVolume = ConvertStringToDecimal(splitData[4]),
            };
        }

        private AverageData RetrieveAverageData(string ticker)
        {
            var stockData = webClient.DownloadFile(ticker, "ghl1m3m4t8");

            var splitData = stockData.Split(',');

            return new AverageData
            {
                DayHigh = ConvertStringToDecimal(splitData[0]),
                DayLow = ConvertStringToDecimal(splitData[1]),
                LastTradePrice = ConvertStringToDecimal(splitData[2]),
                FiftyDayMovingAverage = ConvertStringToDecimal(splitData[3]),
                TwoHundredDayMovingAverage = ConvertStringToDecimal(splitData[4]),
                OneYearTargetPrice = ConvertStringToDecimal(splitData[5])
            };
        }

        private DividendData RetrieveDividendData(string ticker)
        {
            var stockData = webClient.DownloadFile(ticker, "ydr1q");

            var splitData = stockData.Split(',');

            return new DividendData
            {
                DividendYield = ConvertStringToDecimal(splitData[0]),
                DividendPerShare = ConvertStringToDecimal(splitData[1]),
                DividendPayDate = ConvertStringToDate(splitData[2]),
                ExDividendDate = ConvertStringToDate(splitData[3])
            };
        }

        private DateTime? ConvertStringToDate(string data)
        {
            if (data == "N/A\n")
            {
                return null;
            }

            var dateWithoutQuotes = data.Replace("\"", string.Empty);

            return DateTime.Parse(dateWithoutQuotes);
        }

        private decimal? ConvertStringToDecimal(string data)
        {
            if (data == "N/A")
            {
                return null;
            }

            return Convert.ToDecimal(data);
        }

        private decimal? ConvertStringToPercentDecimal(string data)
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
