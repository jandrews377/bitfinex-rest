using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bitfinex.JsonConverters;
using Bitfinex.Models;
using Newtonsoft.Json;
using RestSharp;
using static System.String;

namespace Bitfinex
{
    public class BitfinexRestClient
    {
        private RestClient _client;

        private string _baseUrl = "https://api.bitfinex.com/v2";

        public string BaseUrl
        {
            get => _baseUrl;
            set
            {
                _baseUrl = value;
                _client = new RestClient(_baseUrl);
            }
        }

        public CancellationToken CancellationToken { get; set; }

        public BitfinexRestClient()
        {
            _client = new RestClient(BaseUrl);
            CancellationToken = new CancellationTokenSource().Token;
        }

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
            var tickers = await GetTickersAsync(new[] {symbol});
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

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records</param>
        /// <param name="start">Millisecond start time</param>
        /// <param name="end">Millisecond end time</param>
        /// <param name="sortDirection"></param>
        /// <returns>List of trades</returns>
        public List<ITrade> GetTrades(string symbol, int? limit = null, int? start = null, int? end = null, SortDirection? sortDirection = null)
        {
            return GetTradesAsync(symbol, limit, start, end, sortDirection).Result;
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
        public async Task<List<ITrade>> GetTradesAsync(string symbol, int? limit = null, int? start = null, int? end = null, SortDirection? sortDirection = null)
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


        /// <summary>
        /// Retrieve state of the Bitfinex order book. It is provided on a price aggregated basis, with customizable precision.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="precision">Level of price aggregation (P0, P1, P2, P3, R0)</param>
        /// <param name="len">Number of price points</param>
        /// <returns>List of books</returns>
        public List<IBook> GetBooks(string symbol, Precision precision, int? len = null)
        {
            return GetBooksAsync(symbol, precision, len).Result;
        }

        /// <summary>
        /// Retrieve state of the Bitfinex order book. It is provided on a price aggregated basis, with customizable precision.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="precision">Level of price aggregation (P0, P1, P2, P3, R0)</param>
        /// <param name="len">Number of price points</param>
        /// <returns>List of books</returns>
        public async Task<List<IBook>> GetBooksAsync(string symbol, Precision precision, int? len = null)
        {
            var url = $"book/{symbol}/{precision}";
            if (len.GetValueOrDefault() != 0) url = url + "?len=" + len;

            var request = new RestRequest(url, Method.GET);

            var response = await GetResponseAsync(request, CancellationToken);

            return (List<IBook>) DeserializeObject<List<IBook>>(response.Content, new BooksResultConverter());
        }

        /// <summary>
        /// Get statistics about the requested pair.
        /// </summary>
        /// <param name="key">Allowed values: "funding.size", "credits.size", "credits.size.sym", "pos.size"</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="side">Available values: "long", "short"</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <param name="sortDirection">Default new > old</param>
        /// <returns>List of MTS and Value stats for the requested pair</returns>
        public List<Stat> GetStats(Key key, Symbol symbol, Side side, Section section, SortDirection? sortDirection = null)
        {
            return GetStatsAsync(key, symbol, side, section, sortDirection).Result;
        }

        /// <summary>
        /// Get statistics about the requested pair.
        /// </summary>
        /// <param name="key">Allowed values: "funding.size", "credits.size", "credits.size.sym", "pos.size"</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="side">Available values: "long", "short"</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <param name="sortDirection">Default new > old</param>
        /// <returns>List of MTS and Value stats for the requested pair</returns>
        public async Task<List<Stat>> GetStatsAsync(Key key, Symbol symbol, Side side, Section section, SortDirection? sortDirection = null)
        {
            var size = TimeFrame.Minute;

            var url = $"stats1/{key}:{size}:{(TradeSymbol)symbol}:{side}/{section}";
            if (sortDirection != null) url = url + "?sort=" + (int)sortDirection;

            var request = new RestRequest(url, Method.GET);

            var response = await GetResponseAsync(request, CancellationToken);

            // We could have recieved a single stat.
            try
            {
                var stat = (Stat) DeserializeObject<Stat>(response.Content, new StatResultConverter());
                if (stat != null) return new List<Stat>() {stat};
            }
            catch (Exception)
            {
                // ignored
            }

            return (List<Stat>)DeserializeObject<List<Stat>>(response.Content, new StatsResultConverter());
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
        public List<Candle> GetCandles(TimeFrame timeframe, Symbol symbol, Section section, int? limit = null, int? start = null, int? end = null, SortDirection? sortDirection =null)
        {
            // TO-DO: The spec says that the start and end are string. We are handling as ints.

            return GetCandlesAsync(timeframe, symbol, section, limit, start, end, sortDirection).Result;
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
        public async Task<List<Candle>> GetCandlesAsync(TimeFrame timeframe, Symbol symbol, Section section, int? limit = null, int? start = null, int? end = null, SortDirection? sortDirection = null)
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


        #region private
        /// <summary>
        /// Deserializes JSON to the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        private static object DeserializeObject<T>(string json, JsonConverter converter)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json, converter);
            }
            catch (JsonReaderException ex)
            {
                throw new Exception("Error deserializing response", ex);
            }
        }

        /// <summary>
        /// Issue our request. Check our response for an exception as Bitfinex returns Status: OK even when an exception is returned.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task<IRestResponse> GetResponseAsync(IRestRequest request, CancellationToken token)
        {
            var response = await _client.ExecuteTaskAsync(request, token);
            if (!IsNullOrEmpty(response.ErrorMessage)) throw new Exception(response.ErrorMessage);

            BitfinexException exception = null;
            try
            {
                exception = JsonConvert.DeserializeObject<BitfinexException>(response.Content, new ExceptionResultConverter());
            }
            catch (Exception)
            {
                // ignored
            }

            if (exception != null) throw new Exception($"({exception.ErrorCode}) {exception.Message}");

            return response;
        }
        #endregion
    }
}
