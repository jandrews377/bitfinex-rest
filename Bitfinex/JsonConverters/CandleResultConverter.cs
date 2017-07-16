using System;
using System.Collections.Generic;
using Bitfinex.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bitfinex.JsonConverters
{
    public class CandlesResultConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<Candle>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var array = JArray.Load(reader);

            var results = new List<Candle>();

            foreach (var item in array)
            {
                var candle = JsonConvert.DeserializeObject<Candle>(item.ToString(), new CandleResultConverter());
                results.Add(candle);
            }

            return results;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanWrite => false;
    }

    public class CandleResultConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Candle);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var array = JArray.Load(reader);

            return new Candle
            {
                MTS = (decimal)array[0],
                Open = (double)array[1],
                Close = (double)array[2],
                High = (double)array[3],
                Low = (double)array[4],
                Volume = (double)array[5]
            };
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
