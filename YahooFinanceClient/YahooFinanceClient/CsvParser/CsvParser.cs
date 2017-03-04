using YahooFinanceClient.WebClient;
using YahooFinanceClient.Models;
using YahooFinanceClient.Conversion;

namespace YahooFinanceClient.CsvParser
{
    public class CsvParser : ICsvParser
    {
        private readonly IWebClient webClient;

        private readonly InputConverter inputConverter;

        public CsvParser(IWebClient webClient)
        {
            this.webClient = webClient;
            inputConverter = new InputConverter();
        }

        public Stock RetrieveStock(string ticker)
        {
            var pricingData = RetrievePricingData(ticker);
            var volumeData = RetrieveVolumeData(ticker);
            var averagesData = RetrieveAverageData(ticker);
            var dividendData = RetrieveDividendData(ticker);
            var ratioData = RetrieveRatioData(ticker);

            return new Stock
            {
                PricingData = pricingData,
                VolumeData = volumeData,
                AverageData = averagesData,
                DividendData = dividendData,
                RatioData = ratioData
            };
        }

        private string[] GetStockData(string ticker, string queryParameters)
        {
            var stockData = webClient.DownloadFile(ticker, queryParameters);
            return stockData.Split(',');
        }

        private PricingData RetrievePricingData(string ticker)
        {
            var stockData = GetStockData(ticker, "abb2b3pokjj5k4j6k5w");

            return new PricingData
            {
                Ask = inputConverter.ConvertStringToDecimal(stockData[0]),
                Bid = inputConverter.ConvertStringToDecimal(stockData[1]),
                AskRealTime = inputConverter.ConvertStringToDecimal(stockData[2]),
                BidRealTime = inputConverter.ConvertStringToDecimal(stockData[3]),
                PreviousClose = inputConverter.ConvertStringToDecimal(stockData[4]),
                Open = inputConverter.ConvertStringToDecimal(stockData[5]),
                FiftyTwoWeekHigh = inputConverter.ConvertStringToDecimal(stockData[6]),
                FiftyTwoWeekLow = inputConverter.ConvertStringToDecimal(stockData[7]),
                FiftyTwoWeekLowChange = inputConverter.ConvertStringToDecimal(stockData[8]),
                FiftyTwoWeekHighChange = inputConverter.ConvertStringToDecimal(stockData[9]),
                FiftyTwoWeekLowChangePercent = inputConverter.ConvertStringToPercentDecimal(stockData[10]),
                FiftyTwoWeekHighChangePercent = inputConverter.ConvertStringToPercentDecimal(stockData[11]),
                FiftyTwoWeekRange = inputConverter.CheckIfNotAvailable(stockData[12]),
            };
        }

        private VolumeData RetrieveVolumeData(string ticker)
        {
            var stockData = GetStockData(ticker, "va5b6k3a2");

            return new VolumeData
            {
                CurrentVolume = inputConverter.ConvertStringToDecimal(stockData[0]),
                AskSize = inputConverter.ConvertStringToDecimal(stockData[1]),
                BidSize = inputConverter.ConvertStringToDecimal(stockData[2]),
                LastTradeSize = inputConverter.ConvertStringToDecimal(stockData[3]),
                AverageDailyVolume = inputConverter.ConvertStringToDecimal(stockData[4]),
            };
        }

        private AverageData RetrieveAverageData(string ticker)
        {
            var stockData = GetStockData(ticker, "ghl1m3m4t8");

            return new AverageData
            {
                DayHigh = inputConverter.ConvertStringToDecimal(stockData[0]),
                DayLow = inputConverter.ConvertStringToDecimal(stockData[1]),
                LastTradePrice = inputConverter.ConvertStringToDecimal(stockData[2]),
                FiftyDayMovingAverage = inputConverter.ConvertStringToDecimal(stockData[3]),
                TwoHundredDayMovingAverage = inputConverter.ConvertStringToDecimal(stockData[4]),
                OneYearTargetPrice = inputConverter.ConvertStringToDecimal(stockData[5])
            };
        }

        private DividendData RetrieveDividendData(string ticker)
        {
            var stockData = GetStockData(ticker, "ydr1q");

            return new DividendData
            {
                DividendYield = inputConverter.ConvertStringToDecimal(stockData[0]),
                DividendPerShare = inputConverter.ConvertStringToDecimal(stockData[1]),
                DividendPayDate = inputConverter.ConvertStringToDate(stockData[2]),
                ExDividendDate = inputConverter.ConvertStringToDate(stockData[3])
            };
        }

        private RatioData RetrieveRatioData(string ticker)
        {
            var stockData = GetStockData(ticker, "ee7e8e9b4j4p5p6rr2r5r6r7s7");

            return new RatioData
            {
                EarningsPerShare = inputConverter.ConvertStringToDecimal(stockData[0]),
                EPSEstimateCurrentYear = inputConverter.ConvertStringToDecimal(stockData[1]),
                EPSEstimateNextYear = inputConverter.ConvertStringToDecimal(stockData[2]),
                EPSEstimateNextQuarter = inputConverter.ConvertStringToDecimal(stockData[3]),
                BookValue = inputConverter.ConvertStringToDecimal(stockData[4]),
                Ebitda = inputConverter.CheckIfNotAvailable(stockData[5]),
                PricePerSales = inputConverter.ConvertStringToDecimal(stockData[6]),
                PricePerBook = inputConverter.ConvertStringToDecimal(stockData[7]),
                PeRatio = inputConverter.ConvertStringToDecimal(stockData[8]),
                PeRatioRealTime= inputConverter.ConvertStringToDecimal(stockData[9]),
                PegRatio = inputConverter.ConvertStringToDecimal(stockData[10]),
                PricePerEpsEstimateCurrentYear= inputConverter.ConvertStringToDecimal(stockData[11]),
                PricePerEPSEstimateNextYear= inputConverter.ConvertStringToDecimal(stockData[12]),
                ShortRatio = inputConverter.ConvertStringToDecimal(stockData[13])
            };
        }
    }
}
