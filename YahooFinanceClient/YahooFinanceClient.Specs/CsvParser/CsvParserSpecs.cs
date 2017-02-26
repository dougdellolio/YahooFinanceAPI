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
                The<IWebClient>().WhenToldTo(p => p.DownloadFile("AAPL", "abb2b3po")).Return("136.66,136.61,130.0,132.0,136.53,135.91");

            Because of = () =>
                result = Subject.RetrieveStock("AAPL");

            It should_have_correct_pricing = () =>
            {
                result.Pricing.Ask.ShouldEqual(136.66M);
                result.Pricing.Bid.ShouldEqual(136.61M);
                result.Pricing.AskRealTime.ShouldEqual(130.0M);
                result.Pricing.BidRealTime.ShouldEqual(132.0M);
                result.Pricing.PreviousClose.ShouldEqual(136.53M);
                result.Pricing.Open.ShouldEqual(135.91M);
            };
        }

        public class when_retrieving_a_stock_with_null_values
        {
            static Stock result;

            Establish context = () =>
                The<IWebClient>().WhenToldTo(p => p.DownloadFile("AAPL", "abb2b3po")).Return("136.66,N/A,N/A,N/A,N/A,135.91");

            Because of = () =>
                result = Subject.RetrieveStock("AAPL");

            It should_have_correct_pricing = () =>
            {
                result.Pricing.Ask.ShouldEqual(136.66M);
                result.Pricing.Bid.ShouldBeNull();
                result.Pricing.AskRealTime.ShouldBeNull();
                result.Pricing.BidRealTime.ShouldBeNull();
                result.Pricing.PreviousClose.ShouldBeNull();
                result.Pricing.Open.ShouldEqual(135.91M);
            };
        }
    }
}
