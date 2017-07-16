using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bitfinex.JsonConverters;
using Bitfinex.Models;
using RestSharp;

namespace Bitfinex
{
    // All our Stats methods.

    public partial class BitfinexRestClient
    {
        /// <summary>
        /// Get statistics about the requested pair.
        /// </summary>
        /// <param name="key">Allowed values: "funding.size", "credits.size", "credits.size.sym", "pos.size"</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="side">Available values: "long", "short"</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <returns>List of MTS and Value stats for the requested pair</returns>
        public List<Stat> GetStats(Key key, Symbol symbol, Side side, Section section)
        {
            return getStatsAsync(key, symbol, side, section).Result;
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
        public List<Stat> GetStats(Key key, Symbol symbol, Side side, Section section, SortDirection sortDirection)
        {
            return getStatsAsync(key, symbol, side, section, sortDirection).Result;
        }

        /// <summary>
        /// Get statistics about the requested pair.
        /// </summary>
        /// <param name="key">Allowed values: "funding.size", "credits.size", "credits.size.sym", "pos.size"</param>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="side">Available values: "long", "short"</param>
        /// <param name="section">Available values: "last", "hist"</param>
        /// <returns>List of MTS and Value stats for the requested pair</returns>
        public async Task<List<Stat>> GetStatsAsync(Key key, Symbol symbol, Side side, Section section)
        {
            return await getStatsAsync(key, symbol, side, section);
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
        public async Task<List<Stat>> GetStatsAsync(Key key, Symbol symbol, Side side, Section section, SortDirection sortDirection)
        {
            return await getStatsAsync(key, symbol, side, section, sortDirection);
        }

        private async Task<List<Stat>> getStatsAsync(Key key, Symbol symbol, Side side, Section section, SortDirection? sortDirection = null)
        {
            var size = TimeFrame.Minute;

            var url = $"stats1/{key}:{size}:{(TradeSymbol)symbol}:{side}/{section}";
            if (sortDirection != null) url = url + "?sort=" + (int)sortDirection;

            var request = new RestRequest(url, Method.GET);

            var response = await GetResponseAsync(request, CancellationToken);

            // We could have recieved a single stat.
            try
            {
                var stat = (Stat)DeserializeObject<Stat>(response.Content, new StatResultConverter());
                if (stat != null) return new List<Stat>() { stat };
            }
            catch (Exception)
            {
                // ignored
            }

            return (List<Stat>)DeserializeObject<List<Stat>>(response.Content, new StatsResultConverter());
        }
    }
}
