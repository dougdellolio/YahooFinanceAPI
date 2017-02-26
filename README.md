# YahooFinanceAPI
C# Client Library used to interact with the Yahoo Finance API

<b>Finance Quotes API for Yahoo Finance (C#)</b>

This library provides some methods that should make it easy to communicate with the Yahoo Finance API

|     Pricing    | Dividends          | Volume               | Market                |
|:--------------:|--------------------|----------------------|-----------------------|
| Ask            | Dividend Yield     | Volume               | Information           |
| Bid            | Dividend per Share | Ask Size             | Market Capitilization |
| Ask Realtime   | Dividend Pay Date  | Bid Size             | Market Cap            |
| Bid Realtime   | Ex-Dividend Date   | Last Trade Size      | Float Shares          |
| Previous Close |                    | Average Daily Volume | Company Name          |
| Open           |                    |                      | Notes                 |
|                |                    |                      | Symbol                |
|                |                    |                      | Shares Owned          |
|                |                    |                      | Exchange              |
|                |                    |                      | Shares Outstanding    |

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
