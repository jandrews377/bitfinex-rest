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
        public List<ITrade> GetTrades(string symbol, int limit, int start, int end, SortDirection sortDirection)
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
        /// <param name="sortDirection">default new > old</param>
        /// <returns>List of trades</returns>
        public async Task<List<ITrade>> GetTradesAsync(string symbol, int limit, int start, int end, SortDirection sortDirection)
        {
            var parameters = new List<string>();
            if (limit != 0) parameters.Add("limit=" + limit);
            if (start != 0) parameters.Add("start=" + start);
            if (end != 0) parameters.Add("end=" + end);
            parameters.Add("sort=" + (int) sortDirection);

            string url = $"trades/{symbol}/hist?" + Join("&", parameters.ToArray());
            var request = new RestRequest(url, Method.GET);

            var response = await GetResponseAsync(request, CancellationToken);

            return (List<ITrade>)DeserializeObject<List<ITrade>>(response.Content, new TradesResultConverter());
        }


        /// <summary>
        /// Retrieve state of the Bitfinex order book. It is provided on a price aggregated basis, with customizable precision.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="precision">Level of price aggregation (P0, P1, P2, P3, R0)</param>
        /// <param name="pricePoints">Number of price points</param>
        /// <returns>List of books</returns>
        public List<IBook> GetBooks(string symbol, Precision precision, int pricePoints)
        {
            return GetBooksAsync(symbol, precision, pricePoints).Result;
        }

        /// <summary>
        /// Retrieve state of the Bitfinex order book. It is provided on a price aggregated basis, with customizable precision.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="precision">Level of price aggregation (P0, P1, P2, P3, R0)</param>
        /// <param name="pricePoints">Number of price points</param>
        /// <returns>List of books</returns>
        public async Task<List<IBook>> GetBooksAsync(string symbol, Precision precision, int pricePoints)
        {
            var url = $"book/{symbol}/{precision}";
            if (pricePoints != 0) url = url + "?len=" + pricePoints;

            var request = new RestRequest(url, Method.GET);

            var response = await GetResponseAsync(request, CancellationToken);

            return (List<IBook>) DeserializeObject<List<IBook>>(response.Content, new BooksResultConverter());
        }

        #region private
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

        private async Task<IRestResponse> GetResponseAsync(IRestRequest request, CancellationToken token)
        {
            var response = await _client.ExecuteTaskAsync(request, token);
            if (!IsNullOrEmpty(response.ErrorMessage)) throw new Exception(response.ErrorMessage);

            Common.BitfinexException exception = null;
            try
            {
                exception =
                    JsonConvert.DeserializeObject<Common.BitfinexException>(response.Content, new Common.ExceptionResultConverter());
            }
            catch(Exception) { }

            if (exception != null) throw new Exception($"({exception.ErrorCode}) {exception.Message}");

            return response;
        }
        #endregion
    }
}
