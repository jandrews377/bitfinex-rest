using System;
using System.Collections.Generic;
using Bitfinex.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bitfinex.JsonConverters
{
    public class TradesResultConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<ITrade>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);

            var results = new List<ITrade>();

            foreach (var item in array)
            {
                var trade = JsonConvert.DeserializeObject<ITrade>(item.ToString(), new TradeResultConverter());
                results.Add(trade);
            }

            return results;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanWrite => false;
    }

    public class TradeResultConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ITrade);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);

            if (array.Count == 4) return JArrayToTradingTrade(array);
            if (array.Count == 5) return JArrayToFundingTrade(array);

            return null;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        private TradingTrade JArrayToTradingTrade(JArray array)
        {
            return new TradingTrade
            {
                ID = (decimal)array[0],
                MTS = (decimal)array[1],
                Amount = (double)array[2],
                Price = (double)array[3]
            };           
        }

        private FundingTrade JArrayToFundingTrade(JArray array)
        {
            // TO-DO: Confirm that the value for 'Period' that is returned is actually milliseconds.

            return new FundingTrade
            {
                ID = (decimal)array[0],
                MTS = (decimal)array[1],
                Amount = (double)array[2],
                Rate = (double)array[3],
                Period = new TimeSpan(0,0,0,0,(int)array[4])
            };
        }
    }
}
