using System.Collections.Generic;
using System.Threading.Tasks;
using Bitfinex.JsonConverters;
using Bitfinex.Models;
using RestSharp;
using static System.String;
using System;

namespace Bitfinex
{
    // All our Trade methods.

    public partial class BitfinexRestClient
    {
        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <returns>List of trades</returns>
        public List<ITrade> GetTrades(string symbol)
        {
            return getTradesAsync(symbol).Result;
        }

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records</param>
        /// <returns>List of trades</returns>
        public List<ITrade> GetTrades(string symbol, int limit)
        {
            return getTradesAsync(symbol, limit).Result;
        }

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records</param>
        /// <param name="start">Millisecond start time</param>
        /// <returns>List of trades</returns>
        public List<ITrade> GetTrades(string symbol, int limit, long start)
        {
            return getTradesAsync(symbol, limit, start).Result;
        }

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records</param>
        /// <param name="start">Millisecond start time</param>
        /// <param name="end">Millisecond end time</param>
        /// <returns>List of trades</returns>
        public List<ITrade> GetTrades(string symbol, int limit, long start, long end)
        {
            return getTradesAsync(symbol, limit, start, end).Result;
        }

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records</param>
        /// <param name="start">Millisecond start time</param>
        /// <param name="end">Millisecond end time</param>
        /// <param name="sortDirection"></param>
        /// <returns>List of trades</returns>
        public List<ITrade> GetTrades(string symbol, int limit, long start, long end, SortDirection sortDirection)
        {
            return getTradesAsync(symbol, limit, start, end, sortDirection).Result;
        }

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <returns>List of trades</returns>
        public async Task<List<ITrade>> GetTradesAsync(string symbol)
        {
            return await getTradesAsync(symbol);
        }

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records (default 120)</param>
        /// <returns>List of trades</returns>
        public async Task<List<ITrade>> GetTradesAsync(string symbol, int limit)
        {
            return await getTradesAsync(symbol, limit);
        }

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records (default 120)</param>
        /// <param name="start">Millisecond start time (default 0)</param>
        /// <returns>List of trades</returns>
        public async Task<List<ITrade>> GetTradesAsync(string symbol, int limit, long start)
        {
            return await getTradesAsync(symbol, limit, start);
        }

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records (default 120)</param>
        /// <param name="start">Millisecond start time (default 0)</param>
        /// <param name="end">Millisecond end time (default 0)</param>
        /// <returns>List of trades</returns>
        public async Task<List<ITrade>> GetTradesAsync(string symbol, int limit, long start, long end)
        {
            return await getTradesAsync(symbol, limit, start, end);
        }

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records (default 120)</param>
        /// <param name="start">Millisecond start time (default 0)</param>
        /// <param name="end">Millisecond end time (default 0)</param>
        /// <param name="sortDirection">Default new > old</param>
        /// <returns>List of trades</returns>
        public async Task<List<ITrade>> GetTradesAsync(string symbol, int limit, long start, long end, SortDirection sortDirection)
        {
            return await getTradesAsync(symbol, limit, start, end, sortDirection);
        }

        private async Task<List<ITrade>> getTradesAsync(string symbol, int? limit = null, long? start = null, long? end = null, SortDirection? sortDirection = null)
        {
            var parameters = new List<string>();
            if (limit.GetValueOrDefault() != 0) parameters.Add("limit=" + limit);
            if (start.GetValueOrDefault() != 0) parameters.Add("start=" + start);
            if (end.GetValueOrDefault() != 0) parameters.Add("end=" + end);
            if (sortDirection != null) parameters.Add("sort=" + (int)sortDirection);

            string url = $"trades/{symbol}/hist";
            if (parameters.Count > 0) url = url + "?" + Join("&", parameters.ToArray());

            var request = new RestRequest(url, Method.GET);

            var response = await GetResponseAsync(request, CancellationToken);

            return (List<ITrade>)DeserializeObject<List<ITrade>>(response.Content, new TradesResultConverter());
        }

    }
}
