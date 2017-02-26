using YahooFinanceClient.Models;

namespace YahooFinanceClient.CsvParser
{
    public interface ICsvParser
    {
        Stock RetrieveStock(string ticker);
    }
}
