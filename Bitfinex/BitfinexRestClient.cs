using System;
using System.Threading;
using System.Threading.Tasks;
using Bitfinex.Models;
using Newtonsoft.Json;
using RestSharp;
using static System.String;

namespace Bitfinex
{
    public partial class BitfinexRestClient : IBitfinexRestClient
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
