# Yahoo Finance API Client Library

C# Client Library used to interact with the Yahoo Finance API

[![yahoofinanceapi MyGet Build Status](https://www.myget.org/BuildSource/Badge/yahoofinanceapi?identifier=38997d9d-f6c0-4fd6-8f10-caa8cc0eb323)](https://www.myget.org/)

<h1>How to Install</h1>

`PM> Install-Package YahooFinanceClient`

<h1>What is Provided?</h1>

This library provides some methods that should make it easy to communicate with the Yahoo Finance API

| Pricing Data                  | Dividend Data      | Volume Data          | Average Data           | Ratio Data                        |
|-------------------------------|--------------------|----------------------|------------------------|-----------------------------------|
| Ask                           | Dividend Yield     | Volume               | Day Low                | Earnings per Share                |
| Bid                           | Dividend per Share | Ask Size             | Day High               | EPS Estimate Current Year         |
| Ask Realtime                  | Dividend Pay Date  | Bid Size             | Last Trade Price       | EPS Estimate Next Year            |
| Bid Realtime                  | Ex-Dividend Date   | Last Trade Size      | 50 Day Moving Average  | EPS Estimate Next Quarter         |
| Previous Close                |                    | Average Daily Volume | 200 Day Moving Average | Book Value                        |
| Open                          |                    |                      | One Year Target Price  | EBITDA                            |
| 52 Week High                  |                    |                      |                        | Price / Sales                     |
| 52 Week Low                   |                    |                      |                        | Price / Book                      |
| 52 Week Low Change            |                    |                      |                        | P/E Ratio                         |
| 52 Week High Change           |                    |                      |                        | P/E Ratio (Realtime)              |
| 52 Week Low Change (Percent)  |                    |                      |                        | PEG Ratio                         |
| 52 Week High Change (Percent) |                    |                      |                        | Price / EPS Estimate Current Year |
| 52 Week Range                 |                    |                      |                        | Price / EPS Estimate Next Year    |
|                               |                    |                      |                        | Short Ratio                       |

<h1>Examples</h1>

````
var yahooFinanceClient = new YahooFinance.YahooFinance();
var apple = yahooFinanceClient.RetrieveStock("AAPL");

Console.WriteLine($"Ask Price is {apple.PricingData.Ask}");
Console.WriteLine($"Bid Price is {apple.PricingData.Bid}");
Console.WriteLine($"Open Price is {apple.PricingData.Open}");
Console.WriteLine($"Previous Close is {apple.PricingData.PreviousClose}");
````

````
var yahooFinanceClient = new YahooFinance.YahooFinance();
var apple = yahooFinanceClient.RetrieveStock("AAPL");

Console.WriteLine($"Volume is {apple.VolumeData.CurrentVolume}");
Console.WriteLine($"Ask Size is {apple.VolumeData.AskSize}");
Console.WriteLine($"Bid Size is {apple.VolumeData.BidSize}");
Console.WriteLine($"Last Trade Size is {apple.VolumeData.LastTradeSize}");
Console.WriteLine($"Average Daily Volume is {apple.VolumeData.AverageDailyVolume}");
````            
