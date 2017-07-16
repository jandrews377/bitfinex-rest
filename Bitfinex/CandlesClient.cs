using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bitfinex.JsonConverters;
using Bitfinex.Models;
using RestSharp;
using static System.String;

namespace Bitfinex
{
    // All our Stats methods.

    public partial class BitfinexRestClient
    {
        /// <summary>
        /// Get charting candle info
        /// </summary>
        /// <param name="timeframe">Available values: '1m', '5m', '15m', '30m', '1h', '3h', '6h', '12h', '1D', '7D', '14D', '1M'</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <returns>A list of candle information</returns>
        public List<Candle> GetCandles(TimeFrame timeframe, Symbol symbol, Section section)
        {
            return getCandlesAsync(timeframe, symbol, section).Result;
        }

        /// <summary>
        /// Get charting candle info
        /// </summary>
        /// <param name="timeframe">Available values: '1m', '5m', '15m', '30m', '1h', '3h', '6h', '12h', '1D', '7D', '14D', '1M'</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <param name="limit">Number of candles requested</param>
        /// <returns>A list of candle information</returns>
        public List<Candle> GetCandles(TimeFrame timeframe, Symbol symbol, Section section, int limit)
        {
            return getCandlesAsync(timeframe, symbol, section, limit).Result;
        }

        /// <summary>
        /// Get charting candle info
        /// </summary>
        /// <param name="timeframe">Available values: '1m', '5m', '15m', '30m', '1h', '3h', '6h', '12h', '1D', '7D', '14D', '1M'</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <param name="limit">Number of candles requested</param>
        /// <param name="start">Filter start (ms)</param>
        /// <returns>A list of candle information</returns>
        public List<Candle> GetCandles(TimeFrame timeframe, Symbol symbol, Section section, int limit, int start)
        {
            return getCandlesAsync(timeframe, symbol, section, limit, start).Result;
        }

        /// <summary>
        /// Get charting candle info
        /// </summary>
        /// <param name="timeframe">Available values: '1m', '5m', '15m', '30m', '1h', '3h', '6h', '12h', '1D', '7D', '14D', '1M'</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <param name="limit">Number of candles requested</param>
        /// <param name="start">Filter start (ms)</param>
        /// <param name="end">Filter end (ms)</param>
        /// <returns>A list of candle information</returns>
        public List<Candle> GetCandles(TimeFrame timeframe, Symbol symbol, Section section, int limit, int start, int end)
        {
            return getCandlesAsync(timeframe, symbol, section, limit, start, end).Result;
        }

        /// <summary>
        /// Get charting candle info
        /// </summary>
        /// <param name="timeframe">Available values: '1m', '5m', '15m', '30m', '1h', '3h', '6h', '12h', '1D', '7D', '14D', '1M'</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <param name="limit">Number of candles requested</param>
        /// <param name="start">Filter start (ms)</param>
        /// <param name="end">Filter end (ms)</param>
        /// <param name="sortDirection">Default new > old</param>
        /// <returns>A list of candle information</returns>
        public List<Candle> GetCandles(TimeFrame timeframe, Symbol symbol, Section section, int limit, int start, int end, SortDirection sortDirection)
        {
            // TO-DO: The spec says that the start and end are string. We are handling as ints.

            return getCandlesAsync(timeframe, symbol, section, limit, start, end, sortDirection).Result;
        }

        /// <summary>
        /// Get charting candle info
        /// </summary>
        /// <param name="timeframe">Available values: '1m', '5m', '15m', '30m', '1h', '3h', '6h', '12h', '1D', '7D', '14D', '1M'</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <returns>A list of candle information</returns>
        public async Task<List<Candle>> GetCandlesAsync(TimeFrame timeframe, Symbol symbol, Section section)
        {
            return await getCandlesAsync(timeframe, symbol, section);
        }

        /// <summary>
        /// Get charting candle info
        /// </summary>
        /// <param name="timeframe">Available values: '1m', '5m', '15m', '30m', '1h', '3h', '6h', '12h', '1D', '7D', '14D', '1M'</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <param name="limit">Number of candles requested</param>
        /// <returns>A list of candle information</returns>
        public async Task<List<Candle>> GetCandlesAsync(TimeFrame timeframe, Symbol symbol, Section section, int limit)
        {
            return await getCandlesAsync(timeframe, symbol, section, limit);
        }

        /// <summary>
        /// Get charting candle info
        /// </summary>
        /// <param name="timeframe">Available values: '1m', '5m', '15m', '30m', '1h', '3h', '6h', '12h', '1D', '7D', '14D', '1M'</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <param name="limit">Number of candles requested</param>
        /// <param name="start">Filter start (ms)</param>
        /// <returns>A list of candle information</returns>
        public async Task<List<Candle>> GetCandlesAsync(TimeFrame timeframe, Symbol symbol, Section section, int limit, int start)
        {
            return await getCandlesAsync(timeframe, symbol, section, limit, start);
        }

        /// <summary>
        /// Get charting candle info
        /// </summary>
        /// <param name="timeframe">Available values: '1m', '5m', '15m', '30m', '1h', '3h', '6h', '12h', '1D', '7D', '14D', '1M'</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <param name="limit">Number of candles requested</param>
        /// <param name="start">Filter start (ms)</param>
        /// <param name="end">Filter end (ms)</param>
        /// <returns>A list of candle information</returns>
        public async Task<List<Candle>> GetCandlesAsync(TimeFrame timeframe, Symbol symbol, Section section, int limit, int start, int end)
        {
            return await getCandlesAsync(timeframe, symbol, section, limit, start, end);
        }

        /// <summary>
        /// Get charting candle info
        /// </summary>
        /// <param name="timeframe">Available values: '1m', '5m', '15m', '30m', '1h', '3h', '6h', '12h', '1D', '7D', '14D', '1M'</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <param name="limit">Number of candles requested</param>
        /// <param name="start">Filter start (ms)</param>
        /// <param name="end">Filter end (ms)</param>
        /// <param name="sortDirection">Default new > old</param>
        /// <returns>A list of candle information</returns>
        public async Task<List<Candle>> GetCandlesAsync(TimeFrame timeframe, Symbol symbol, Section section, int limit, int start, int end, SortDirection sortDirection)
        {
            return await getCandlesAsync(timeframe, symbol, section, limit, start, end, sortDirection);
        }

        private async Task<List<Candle>> getCandlesAsync(TimeFrame timeframe, Symbol symbol, Section section, int? limit = null, int? start = null, int? end = null, SortDirection? sortDirection = null)
        {
            var parameters = new List<string>();
            if (limit.GetValueOrDefault() != 0) parameters.Add("limit=" + limit);
            if (start.GetValueOrDefault() != 0) parameters.Add("start=" + start);
            if (end.GetValueOrDefault() != 0) parameters.Add("end=" + end);
            if (sortDirection != null) parameters.Add("sort=" + (int)sortDirection);

            string url = $"candles/trade:{timeframe}:{(TradeSymbol)symbol}/{section}";
            if (parameters.Count > 0) url = url + "?" + Join("&", parameters.ToArray());

            var request = new RestRequest(url, Method.GET);

            var response = await GetResponseAsync(request, CancellationToken);

            // We could have recieved a single candle.
            try
            {
                var candle = (Candle)DeserializeObject<Candle>(response.Content, new CandleResultConverter());
                if (candle != null) return new List<Candle>() { candle };
            }
            catch (Exception)
            {
                // ignored
            }

            return (List<Candle>)DeserializeObject<List<Candle>>(response.Content, new CandlesResultConverter());
        }
    }
}