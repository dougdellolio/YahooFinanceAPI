namespace YahooFinanceClient.WebClient
{
    public interface IWebClient
    {
        string DownloadFile(string stock, string variable);
    }
}
