using System.Threading.Tasks;

namespace YahooFinanceClient.WebClient
{
    public interface IWebClient
    {
        Task<string> DownloadFile(string stock, string variable);
    }
}
