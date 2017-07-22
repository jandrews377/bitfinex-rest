# Bitfinex REST API Version 2.0 Client ![Build status](https://jandrews377.visualstudio.com/_apis/public/build/definitions/bc4a1ea7-aece-4253-8177-8346d98a9c22/1/badge)

This is a C# implementation of the Bitfinex REST API Version 2.0 (BETA) found here:

https://bitfinex.readme.io/v2/docs/getting-started 

At this stage it is an ALPHA state. Only the Public Endpoint (https://bitfinex.readme.io/v2/docs/rest-public)  has been implemented. In the coming weeks the Authenticated Endpoint (https://bitfinex.readme.io/v2/docs/rest-auth) will be added.

### License: Apache License 2.0

### Features

* Easy installation using [NuGet](https://www.nuget.org/packages/Bitfinex)
* Synchronous and Asynchronous methods

```csharp
var client = new BitfinexRestClient();
var tickers = client.GetTickers(new string[] { "tBTCUSD", "tLTCUSD", "fUS" });

foreach (var ticker in tickers)
{
	var output = new StringBuilder();
	output.AppendLine($"FlashReturnRate: {ticker.FlashReturnRate}");
	output.AppendLine($"BidPeriod: {ticker.BidPeriod}");
	output.AppendLine($"AskPeriod: {ticker.AskPeriod}");
	output.AppendLine($"Symbol: {ticker.Symbol}");
	output.AppendLine($"Bid: {ticker.Bid}");
	output.AppendLine($"BidSize: {ticker.BidSize}");
	output.AppendLine($"Ask: {ticker.Ask}");
	output.AppendLine($"AskSize: {ticker.AskSize}");
	output.AppendLine($"DailyChange: {ticker.DailyChange}");
	output.AppendLine($"DailyChangePercent: {ticker.DailyChangePercent}");
	output.AppendLine($"LastPrice: {ticker.LastPrice}");
	output.AppendLine($"Volume: {ticker.Volume}");
	output.AppendLine($"High: {ticker.High}");
	output.AppendLine($"Low: {ticker.Low}");

	Console.WriteLine(output);
}
```
 
Donations gratefully accepted.
Bitcoin: 1NPee1eCWQqmsQwqatdfpgogDrfuwqUZhQ
Ethereum: 0x04f11eefc870ce139954a94cfbf75bdcaf4ede40
