using Machine.Fakes;
using Machine.Specifications;
using System;
using YahooFinanceClient.Models;
using YahooFinanceClient.WebClient;

namespace YahooFinanceClient.Specs.CsvParser
{
    public class CsvParserSpecs : WithSubject<YahooFinanceClient.CsvParser.CsvParser>
    {
        public class when_retrieving_a_stock
        {
            static Stock result;

            Establish context = () =>
            {
                The<IWebClient>().WhenToldTo(p => p.DownloadFile("AAPL", "abb2b3pokjj5k4j6k5w"))
                    .Return("136.66,136.61,130.0,132.0,136.53,135.91,145.91,138.91,131.91,115.91,-66.7%,+45.5%,115.91-130.01");

                The<IWebClient>().WhenToldTo(p => p.DownloadFile("AAPL", "va5b6k3a2"))
                    .Return("100000,120,130,130000,145000");

                The<IWebClient>().WhenToldTo(p => p.DownloadFile("AAPL", "ghl1m3m4t8"))
                    .Return("136.8,122.2,141.4,136.6,178.8,133.3");

                The<IWebClient>().WhenToldTo(p => p.DownloadFile("AAPL", "ydr1q"))
                    .Return("12.1,10.4,\"2/7/2017\",\"2/16/2017\"");
            };

            Because of = () =>
                result = Subject.RetrieveStock("AAPL");

            It should_have_correct_pricing_data = () =>
            {
                result.PricingData.Ask.ShouldEqual(136.66M);
                result.PricingData.Bid.ShouldEqual(136.61M);
                result.PricingData.AskRealTime.ShouldEqual(130.0M);
                result.PricingData.BidRealTime.ShouldEqual(132.0M);
                result.PricingData.PreviousClose.ShouldEqual(136.53M);
                result.PricingData.Open.ShouldEqual(135.91M);
                result.PricingData.FiftyTwoWeekHigh.ShouldEqual(145.91M);
                result.PricingData.FiftyTwoWeekLow.ShouldEqual(138.91M);
                result.PricingData.FiftyTwoWeekLowChange.ShouldEqual(131.91M);
                result.PricingData.FiftyTwoWeekHighChange.ShouldEqual(115.91M);
                result.PricingData.FiftyTwoWeekLowChangePercent.ShouldEqual(-66.7M);
                result.PricingData.FiftyTwoWeekHighChangePercent.ShouldEqual(45.5M);
                result.PricingData.FiftyTwoWeekRange.ShouldEqual("115.91-130.01");
            };

            It should_have_correct_volume_data = () =>
            {
                result.VolumeData.CurrentVolume.ShouldEqual(100000M);
                result.VolumeData.AskSize.ShouldEqual(120M);
                result.VolumeData.BidSize.ShouldEqual(130M);
                result.VolumeData.LastTradeSize.ShouldEqual(130000);
                result.VolumeData.AverageDailyVolume.ShouldEqual(145000M);
            };

            It should_have_correct_averages_data = () =>
            {
                result.AverageData.DayHigh.ShouldEqual(136.8M);
                result.AverageData.DayLow.ShouldEqual(122.2M);
                result.AverageData.LastTradePrice.ShouldEqual(141.4M);
                result.AverageData.FiftyDayMovingAverage.ShouldEqual(136.6M);
                result.AverageData.TwoHundredDayMovingAverage.ShouldEqual(178.8M);
                result.AverageData.OneYearTargetPrice.ShouldEqual(133.3M);
            };

            It should_have_correct_dividend_data = () =>
            {
                result.DividendData.DividendYield.ShouldEqual(12.1M);
                result.DividendData.DividendPerShare.ShouldEqual(10.4M);
                result.DividendData.DividendPayDate.ShouldEqual(new DateTime(2017, 2, 7));
                result.DividendData.ExDividendDate.ShouldEqual(new DateTime(2017, 2, 16));
            };
        }

        public class when_retrieving_a_stock_with_null_values
        {
            static Stock result;

            Establish context = () =>
            {
                The<IWebClient>().WhenToldTo(p => p.DownloadFile("AAPL", "abb2b3pokjj5k4j6k5w"))
                    .Return("136.66,N/A,N/A,N/A,N/A,135.91,N/A,N/A,N/A,N/A,N/A,N/A,N/A");

                The<IWebClient>().WhenToldTo(p => p.DownloadFile("AAPL", "va5b6k3a2"))
                    .Return("130000,N/A,N/A,N/A,N/A");

                The<IWebClient>().WhenToldTo(p => p.DownloadFile("AAPL", "ghl1m3m4t8"))
                    .Return("N/A,N/A,N/A,N/A,N/A,N/A");

                The<IWebClient>().WhenToldTo(p => p.DownloadFile("AAPL", "ydr1q"))
                    .Return("N/A,N/A,N/A,N/A");
            };

            Because of = () =>
                result = Subject.RetrieveStock("AAPL");

            It should_have_correct_pricing_data = () =>
            {
                result.PricingData.Ask.ShouldEqual(136.66M);
                result.PricingData.Bid.ShouldBeNull();
                result.PricingData.AskRealTime.ShouldBeNull();
                result.PricingData.BidRealTime.ShouldBeNull();
                result.PricingData.PreviousClose.ShouldBeNull();
                result.PricingData.Open.ShouldEqual(135.91M);
            };

            It should_have_correct_volume_data = () =>
            {
                result.VolumeData.CurrentVolume.ShouldEqual(130000M);
                result.VolumeData.AskSize.ShouldBeNull();
                result.VolumeData.BidSize.ShouldBeNull();
                result.VolumeData.LastTradeSize.ShouldBeNull();
                result.VolumeData.AverageDailyVolume.ShouldBeNull();
                result.PricingData.FiftyTwoWeekHigh.ShouldBeNull();
                result.PricingData.FiftyTwoWeekLow.ShouldBeNull();
                result.PricingData.FiftyTwoWeekLowChange.ShouldBeNull();
                result.PricingData.FiftyTwoWeekHighChange.ShouldBeNull();
                result.PricingData.FiftyTwoWeekLowChangePercent.ShouldBeNull();
                result.PricingData.FiftyTwoWeekHighChangePercent.ShouldBeNull();
                result.PricingData.FiftyTwoWeekRange.ShouldEqual("N/A");
            };

            It should_have_correct_averages_data = () =>
            {
                result.AverageData.DayHigh.ShouldBeNull();
                result.AverageData.DayLow.ShouldBeNull();
                result.AverageData.LastTradePrice.ShouldBeNull();
                result.AverageData.FiftyDayMovingAverage.ShouldBeNull();
                result.AverageData.TwoHundredDayMovingAverage.ShouldBeNull();
                result.AverageData.OneYearTargetPrice.ShouldBeNull();
            };

            It should_have_correct_dividend_data = () =>
            {
                result.DividendData.DividendYield.ShouldBeNull();
                result.DividendData.DividendPerShare.ShouldBeNull();
                result.DividendData.DividendPayDate.ShouldBeNull();
                result.DividendData.ExDividendDate.ShouldBeNull();
            };
        }
    }
}
