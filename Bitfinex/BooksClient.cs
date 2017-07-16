using System.Collections.Generic;
using System.Threading.Tasks;
using Bitfinex.JsonConverters;
using Bitfinex.Models;
using RestSharp;

namespace Bitfinex
{
    // All our Books methods.

    public partial class BitfinexRestClient
    {
        /// <summary>
        /// Retrieve state of the Bitfinex order book. It is provided on a price aggregated basis, with customizable precision.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="precision">Level of price aggregation (P0, P1, P2, P3, R0)</param>
        /// <returns>List of books</returns>
        public List<IBook> GetBooks(string symbol, Precision precision)
        {
            return getBooksAsync(symbol, precision, null).Result;
        }

        /// <summary>
        /// Retrieve state of the Bitfinex order book. It is provided on a price aggregated basis, with customizable precision.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="precision">Level of price aggregation (P0, P1, P2, P3, R0)</param>
        /// <param name="len">Number of price points</param>
        /// <returns>List of books</returns>
        public List<IBook> GetBooks(string symbol, Precision precision, int len)
        {
            return getBooksAsync(symbol, precision, len).Result;
        }

        /// <summary>
        /// Retrieve state of the Bitfinex order book. It is provided on a price aggregated basis, with customizable precision.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="precision">Level of price aggregation (P0, P1, P2, P3, R0)</param>
        /// <returns>List of books</returns>
        public async Task<List<IBook>> GetBooksAsync(string symbol, Precision precision)
        {
            return await getBooksAsync(symbol, precision, null);
        }

        /// <summary>
        /// Retrieve state of the Bitfinex order book. It is provided on a price aggregated basis, with customizable precision.
        /// </summary>
        /// <param name="symbol">The symbol you want information about.</param>
        /// <param name="precision">Level of price aggregation (P0, P1, P2, P3, R0)</param>
        /// <param name="len">Number of price points</param>
        /// <returns>List of books</returns>
        public async Task<List<IBook>> GetBooksAsync(string symbol, Precision precision, int len)
        {
            return await getBooksAsync(symbol, precision, len);
        }

        private async Task<List<IBook>> getBooksAsync(string symbol, Precision precision, int? len)
        {
            var url = $"book/{symbol}/{precision}";
            if (len.GetValueOrDefault() != 0) url = url + "?len=" + len;

            var request = new RestRequest(url, Method.GET);

            var response = await GetResponseAsync(request, CancellationToken);

            return (List<IBook>)DeserializeObject<List<IBook>>(response.Content, new BooksResultConverter());
        }
    }
}