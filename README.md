# YahooFinanceAPI

C# Client Library used to interact with the Yahoo Finance API

<h1>How to Install</h1>

`PM> Install-Package YahooFinanceClient`

<h1>What is Provided?</h1>

This library provides some methods that should make it easy to communicate with the Yahoo Finance API

|          Pricing Data         | Dividend Data      | Volume Data          | Average Data           |
|:-----------------------------:|--------------------|----------------------|------------------------|
| Ask                           | Dividend Yield     | Volume               | Day Low                |
| Bid                           | Dividend per Share | Ask Size             | Day High               |
| Ask Realtime                  | Dividend Pay Date  | Bid Size             | Last Trade Price       |
| Bid Realtime                  | Ex-Dividend Date   | Last Trade Size      | 50 Day Moving Average  |
| Previous Close                |                    | Average Daily Volume | 200 Day Moving Average |
| Open                          |                    |                      | One Year Target Price  |
| 52 Week High                  |                    |                      |                        |
| 52 Week Low                   |                    |                      |                        |
| 52 Week Low Change            |                    |                      |                        |
| 52 Week High Change           |                    |                      |                        |
| 52 Week Low Change (Percent)  |                    |                      |                        |
| 52 Week High Change (Percent) |                    |                      |                        |
| 52 Week Range                 |                    |                      |                        |

<h1>Examples</h1>

````
var yahooFinanceClient = new YahooFinance();
var apple = yahooFinanceClient.RetrieveStock("AAPL");

Console.WriteLine($"Ask Price is {apple.PricingData.Ask}");
Console.WriteLine($"Bid Price is {apple.PricingData.Bid}");
Console.WriteLine($"Open Price is {apple.PricingData.Open}");
Console.WriteLine($"Previous Close is {apple.PricingData.PreviousClose}");
````

````
var yahooFinanceClient = new YahooFinance();
var apple = yahooFinanceClient.RetrieveStock("AAPL");

Console.WriteLine($"Volume is {apple.VolumeData.CurrentVolume}");
Console.WriteLine($"Ask Size is {apple.VolumeData.AskSize}");
Console.WriteLine($"Bid Size is {apple.VolumeData.BidSize}");
Console.WriteLine($"Last Trade Size is {apple.VolumeData.LastTradeSize}");
Console.WriteLine($"Average Daily Volume is {apple.VolumeData.AverageDailyVolume}");
````            
