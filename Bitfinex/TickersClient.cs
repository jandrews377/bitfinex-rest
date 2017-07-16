using System.Collections.Generic;
using System.Threading.Tasks;
using Bitfinex.JsonConverters;
using Bitfinex.Models;
using RestSharp;
using static System.String;

namespace Bitfinex
{
    // All our Ticker methods.

    public partial class BitfinexRestClient
    {
        /// <summary>
        /// Get a high-level overview of the specified symbol. It shows you the current best bid and ask, as well as the last trade price. It also includes information such as daily volume and how much the price has moved over the last day.
        /// </summary>
        /// <param name="symbol">A symbol (eg BTCUSD) prefixed with either t (for Trading) or f (for Funding). eg tBTCUSD</param>
        /// <returns>Ticker</returns>
        public ITicker GetTicker(string symbol)
        {
            return GetTickerAsync(symbol).Result;
        }

        /// <summary>
        /// Get a high-level overview of the specified symbols. It shows you the current best bid and ask, as well as the last trade price. It also includes information such as daily volume and how much the price has moved over the last day.
        /// </summary>
        /// <param name="symbols">A list of symbols (eg BTCUSD) prefixed with either t (for Trading) or f (for Funding). eg tBTCUSD</param>
        /// <returns>List of tickers</returns>
        public List<ITicker> GetTickers(string[] symbols)
        {
            return GetTickersAsync(symbols).Result;
        }

        /// <summary>
        /// Get a high-level overview of the specified symbol. It shows you the current best bid and ask, as well as the last trade price. It also includes information such as daily volume and how much the price has moved over the last day.
        /// </summary>
        /// <param name="symbol">A symbol (eg BTCUSD) prefixed with either t (for Trading) or f (for Funding). eg tBTCUSD</param>
        /// <returns>Ticker</returns>
        public async Task<ITicker> GetTickerAsync(string symbol)
        {
            var tickers = await GetTickersAsync(new[] { symbol });
            return tickers[0];
        }

        /// <summary>
        /// Get a high-level overview of the specified symbols. It shows you the current best bid and ask, as well as the last trade price. It also includes information such as daily volume and how much the price has moved over the last day.
        /// </summary>
        /// <param name="symbols">A list of symbols (eg BTCUSD) prefixed with either t (for Trading) or f (for Funding). eg tBTCUSD</param>
        /// <returns>List of tickers</returns>
        public async Task<List<ITicker>> GetTickersAsync(string[] symbols)
        {
            var symbolsString = Join(",", symbols);

            string url = $"tickers?symbols={symbolsString}";
            var request = new RestRequest(url, Method.GET);

            var response = await GetResponseAsync(request, CancellationToken);

            return (List<ITicker>)DeserializeObject<List<ITicker>>(response.Content, new TickersResultConverter());
        }
    }
}
