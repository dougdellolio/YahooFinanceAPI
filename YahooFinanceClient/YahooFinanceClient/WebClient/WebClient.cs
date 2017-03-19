using System.Threading.Tasks;

namespace YahooFinanceClient.WebClient
{
    public class WebClient : IWebClient
    {
        private const string url = "http://finance.yahoo.com/d/quotes.csv?s=";

        public async Task<string> DownloadFile(string stock, string variable)
        {
            string result;

            using (var webClient = new System.Net.WebClient())
            {
                result = await webClient.DownloadStringTaskAsync(url + stock + "&f=" + variable);
            }

            return result;
        }
    }
}
