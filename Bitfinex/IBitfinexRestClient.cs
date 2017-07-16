using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bitfinex.Models;

namespace Bitfinex
{
    public interface IBitfinexRestClient
    {
        /// <summary>
        /// Get charting candle info
        /// </summary>
        /// <param name="timeframe">Available values: '1m', '5m', '15m', '30m', '1h', '3h', '6h', '12h', '1D', '7D', '14D', '1M'</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <returns>A list of candle information</returns>
        List<Candle> GetCandles(TimeFrame timeframe, Symbol symbol, Section section);

        /// <summary>
        /// Get charting candle info
        /// </summary>
        /// <param name="timeframe">Available values: '1m', '5m', '15m', '30m', '1h', '3h', '6h', '12h', '1D', '7D', '14D', '1M'</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <param name="limit">Number of candles requested</param>
        /// <returns>A list of candle information</returns>
        List<Candle> GetCandles(TimeFrame timeframe, Symbol symbol, Section section, int limit);

        /// <summary>
        /// Get charting candle info
        /// </summary>
        /// <param name="timeframe">Available values: '1m', '5m', '15m', '30m', '1h', '3h', '6h', '12h', '1D', '7D', '14D', '1M'</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <param name="limit">Number of candles requested</param>
        /// <param name="start">Filter start (ms)</param>
        /// <returns>A list of candle information</returns>
        List<Candle> GetCandles(TimeFrame timeframe, Symbol symbol, Section section, int limit, int start);

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
        List<Candle> GetCandles(TimeFrame timeframe, Symbol symbol, Section section, int limit, int start, int end);

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
        List<Candle> GetCandles(TimeFrame timeframe, Symbol symbol, Section section, int limit, int start, int end, SortDirection sortDirection);

        /// <summary>
        /// Get charting candle info
        /// </summary>
        /// <param name="timeframe">Available values: '1m', '5m', '15m', '30m', '1h', '3h', '6h', '12h', '1D', '7D', '14D', '1M'</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <returns>A list of candle information</returns>
        Task<List<Candle>> GetCandlesAsync(TimeFrame timeframe, Symbol symbol, Section section);

        /// <summary>
        /// Get charting candle info
        /// </summary>
        /// <param name="timeframe">Available values: '1m', '5m', '15m', '30m', '1h', '3h', '6h', '12h', '1D', '7D', '14D', '1M'</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <param name="limit">Number of candles requested</param>
        /// <returns>A list of candle information</returns>
        Task<List<Candle>> GetCandlesAsync(TimeFrame timeframe, Symbol symbol, Section section, int limit);

        /// <summary>
        /// Get charting candle info
        /// </summary>
        /// <param name="timeframe">Available values: '1m', '5m', '15m', '30m', '1h', '3h', '6h', '12h', '1D', '7D', '14D', '1M'</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <param name="limit">Number of candles requested</param>
        /// <param name="start">Filter start (ms)</param>
        /// <returns>A list of candle information</returns>
        Task<List<Candle>> GetCandlesAsync(TimeFrame timeframe, Symbol symbol, Section section, int limit, int start);

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
        Task<List<Candle>> GetCandlesAsync(TimeFrame timeframe, Symbol symbol, Section section, int limit, int start, int end);

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
        Task<List<Candle>> GetCandlesAsync(TimeFrame timeframe, Symbol symbol, Section section, int limit, int start, int end, SortDirection sortDirection);

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <returns>List of trades</returns>
        List<ITrade> GetTrades(string symbol);

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records</param>
        /// <returns>List of trades</returns>
        List<ITrade> GetTrades(string symbol, int limit);

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records</param>
        /// <param name="start">Millisecond start time</param>
        /// <returns>List of trades</returns>
        List<ITrade> GetTrades(string symbol, int limit, int start);

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records</param>
        /// <param name="start">Millisecond start time</param>
        /// <param name="end">Millisecond end time</param>
        /// <returns>List of trades</returns>
        List<ITrade> GetTrades(string symbol, int limit, int start, int end);

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records</param>
        /// <param name="start">Millisecond start time</param>
        /// <param name="end">Millisecond end time</param>
        /// <param name="sortDirection"></param>
        /// <returns>List of trades</returns>
        List<ITrade> GetTrades(string symbol, int limit, int start, int end, SortDirection sortDirection);

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <returns>List of trades</returns>
        Task<List<ITrade>> GetTradesAsync(string symbol);

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records (default 120)</param>
        /// <returns>List of trades</returns>
        Task<List<ITrade>> GetTradesAsync(string symbol, int limit);

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records (default 120)</param>
        /// <param name="start">Millisecond start time (default 0)</param>
        /// <returns>List of trades</returns>
        Task<List<ITrade>> GetTradesAsync(string symbol, int limit, int start);

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records (default 120)</param>
        /// <param name="start">Millisecond start time (default 0)</param>
        /// <param name="end">Millisecond end time (default 0)</param>
        /// <returns>List of trades</returns>
        Task<List<ITrade>> GetTradesAsync(string symbol, int limit, int start, int end);

        /// <summary>
        /// Get pertinent details of trades, such as price, size and time.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="limit">Number of records (default 120)</param>
        /// <param name="start">Millisecond start time (default 0)</param>
        /// <param name="end">Millisecond end time (default 0)</param>
        /// <param name="sortDirection">Default new > old</param>
        /// <returns>List of trades</returns>
        Task<List<ITrade>> GetTradesAsync(string symbol, int limit, int start, int end, SortDirection sortDirection);

        string BaseUrl { get; set; }
        CancellationToken CancellationToken { get; set; }

        /// <summary>
        /// Get a high-level overview of the specified symbol. It shows you the current best bid and ask, as well as the last trade price. It also includes information such as daily volume and how much the price has moved over the last day.
        /// </summary>
        /// <param name="symbol">A symbol (eg BTCUSD) prefixed with either t (for Trading) or f (for Funding). eg tBTCUSD</param>
        /// <returns>Ticker</returns>
        ITicker GetTicker(string symbol);

        /// <summary>
        /// Get a high-level overview of the specified symbols. It shows you the current best bid and ask, as well as the last trade price. It also includes information such as daily volume and how much the price has moved over the last day.
        /// </summary>
        /// <param name="symbols">A list of symbols (eg BTCUSD) prefixed with either t (for Trading) or f (for Funding). eg tBTCUSD</param>
        /// <returns>List of tickers</returns>
        List<ITicker> GetTickers(string[] symbols);

        /// <summary>
        /// Get a high-level overview of the specified symbol. It shows you the current best bid and ask, as well as the last trade price. It also includes information such as daily volume and how much the price has moved over the last day.
        /// </summary>
        /// <param name="symbol">A symbol (eg BTCUSD) prefixed with either t (for Trading) or f (for Funding). eg tBTCUSD</param>
        /// <returns>Ticker</returns>
        Task<ITicker> GetTickerAsync(string symbol);

        /// <summary>
        /// Get a high-level overview of the specified symbols. It shows you the current best bid and ask, as well as the last trade price. It also includes information such as daily volume and how much the price has moved over the last day.
        /// </summary>
        /// <param name="symbols">A list of symbols (eg BTCUSD) prefixed with either t (for Trading) or f (for Funding). eg tBTCUSD</param>
        /// <returns>List of tickers</returns>
        Task<List<ITicker>> GetTickersAsync(string[] symbols);

        /// <summary>
        /// Get statistics about the requested pair.
        /// </summary>
        /// <param name="key">Allowed values: "funding.size", "credits.size", "credits.size.sym", "pos.size"</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="side">Available values: "long", "short"</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <returns>List of MTS and Value stats for the requested pair</returns>
        List<Stat> GetStats(Key key, Symbol symbol, Side side, Section section);

        /// <summary>
        /// Get statistics about the requested pair.
        /// </summary>
        /// <param name="key">Allowed values: "funding.size", "credits.size", "credits.size.sym", "pos.size"</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="side">Available values: "long", "short"</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <param name="sortDirection">Default new > old</param>
        /// <returns>List of MTS and Value stats for the requested pair</returns>
        List<Stat> GetStats(Key key, Symbol symbol, Side side, Section section, SortDirection sortDirection);

        /// <summary>
        /// Get statistics about the requested pair.
        /// </summary>
        /// <param name="key">Allowed values: "funding.size", "credits.size", "credits.size.sym", "pos.size"</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="side">Available values: "long", "short"</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <returns>List of MTS and Value stats for the requested pair</returns>
        Task<List<Stat>> GetStatsAsync(Key key, Symbol symbol, Side side, Section section);

        /// <summary>
        /// Get statistics about the requested pair.
        /// </summary>
        /// <param name="key">Allowed values: "funding.size", "credits.size", "credits.size.sym", "pos.size"</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="side">Available values: "long", "short"</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <param name="sortDirection">Default new > old</param>
        /// <returns>List of MTS and Value stats for the requested pair</returns>
        Task<List<Stat>> GetStatsAsync(Key key, Symbol symbol, Side side, Section section, SortDirection sortDirection);

        /// <summary>
        /// Retrieve state of the Bitfinex order book. It is provided on a price aggregated basis, with customizable precision.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="precision">Level of price aggregation (P0, P1, P2, P3, R0)</param>
        /// <returns>List of books</returns>
        List<IBook> GetBooks(string symbol, Precision precision);

        /// <summary>
        /// Retrieve state of the Bitfinex order book. It is provided on a price aggregated basis, with customizable precision.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="precision">Level of price aggregation (P0, P1, P2, P3, R0)</param>
        /// <param name="len">Number of price points</param>
        /// <returns>List of books</returns>
        List<IBook> GetBooks(string symbol, Precision precision, int len);

        /// <summary>
        /// Retrieve state of the Bitfinex order book. It is provided on a price aggregated basis, with customizable precision.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="precision">Level of price aggregation (P0, P1, P2, P3, R0)</param>
        /// <returns>List of books</returns>
        Task<List<IBook>> GetBooksAsync(string symbol, Precision precision);

        /// <summary>
        /// Retrieve state of the Bitfinex order book. It is provided on a price aggregated basis, with customizable precision.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="precision">Level of price aggregation (P0, P1, P2, P3, R0)</param>
        /// <param name="len">Number of price points</param>
        /// <returns>List of books</returns>
        Task<List<IBook>> GetBooksAsync(string symbol, Precision precision, int len);
    }
}