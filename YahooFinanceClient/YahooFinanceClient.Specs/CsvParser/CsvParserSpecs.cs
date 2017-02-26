using Machine.Fakes;
using Machine.Specifications;
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
                    .Return("136.66,136.61,130.0,132.0,136.53,135.91,145.91,138.91,131.91,115.91,138.91,131.91,115.91-130.01");

                The<IWebClient>().WhenToldTo(p => p.DownloadFile("AAPL", "va5b6k3a2"))
                    .Return("100000, 120, 130, 130000, 145000");
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
                result.PricingData.FiftyTwoWeekLowChangePercent.ShouldEqual(138.91M);
                result.PricingData.FiftyTwoWeekHighChangePercent.ShouldEqual(131.91M);
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
        }

        public class when_retrieving_a_stock_with_null_values
        {
            static Stock result;

            Establish context = () =>
            {
                The<IWebClient>().WhenToldTo(p => p.DownloadFile("AAPL", "abb2b3pokjj5k4j6k5w")).Return("136.66,N/A,N/A,N/A,N/A,135.91,N/A,N/A,N/A,N/A,N/A,N/A,N/A");
                The<IWebClient>().WhenToldTo(p => p.DownloadFile("AAPL", "va5b6k3a2")).Return("130000,N/A,N/A,N/A,N/A");
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
        }
    }
}
