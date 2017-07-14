using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bitfinex.Models
{
    public class Common
    {
        public enum Symbol
        {
            BTCUSD,
            LTCUSD,
            LTCBTC,
            ETHUSD,
            ETHBTC,
            ETCBTC,
            ETCUSD,
            BFXUSD,
            BFXBTC,
            RRTUSD,
            RRTBTC,
            ZECUSD,
            ZECBTC
        }

        public class BitfinexException
        {
            public int ErrorCode { get; set; }
            public string Message { get; set; }
        }

        public class ExceptionResultConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(BitfinexException);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                JsonSerializer serializer)
            {
                JArray array = JArray.Load(reader);

                if ((string) array[0] == "error")
                {

                    return new BitfinexException
                    {
                        ErrorCode = (int) array[1],
                        Message = (string) array[2]
                    };
                }

                return null;
            }

            public override bool CanWrite
            {
                get { return false; }
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    }
}
