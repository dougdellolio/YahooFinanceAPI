namespace YahooFinanceClient.WebClient
{
    public class WebClient : IWebClient
    {
        private const string url = "http://finance.yahoo.com/d/quotes.csv?s=";

        public string DownloadFile(string stock, string variable)
        {
            string csvData;

            using (var web = new System.Net.WebClient())
            {
                csvData = web.DownloadString(url + stock + "&f=" + variable);
            }

            return csvData;
        }
    }
}
