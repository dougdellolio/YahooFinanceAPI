using YahooFinanceClient.CsvParser;
using YahooFinanceClient.Models;
using YahooFinanceClient.WebClient;

namespace YahooFinance
{
    public class YahooFinance
    {
        private readonly IWebClient webClient;

        private readonly ICsvParser csvParser;
        
        public YahooFinance()
        {
            webClient = new WebClient();
            csvParser = new CsvParser(webClient);
        }

        public Stock RetrieveStock(string ticker)
        {
            return csvParser.RetrieveStock(ticker);
        }
    }
}
