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

Console.WriteLine($"Ask Price is {apple.Pricing.Ask}");
Console.WriteLine($"Bid Price is {apple.Pricing.Bid}");
Console.WriteLine($"Open Price is {apple.Pricing.Open}");
Console.WriteLine($"Previous Close is {apple.Pricing.PreviousClose}");
````

````
var yahooFinanceClient = new YahooFinance();
var apple = yahooFinanceClient.RetrieveStock("AAPL");

Console.WriteLine($"Volume is {apple.Volume.Volume}");
Console.WriteLine($"Ask Size is {apple.Volume.AskSize}");
Console.WriteLine($"Bid Size is {apple.Volume.BidSize}");
Console.WriteLine($"Last Trade Size is {apple.Volume.LastTradeSize}");
Console.WriteLine($"Average Daily Volume is {apple.Volume.AverageDailyVolume}");
````            
