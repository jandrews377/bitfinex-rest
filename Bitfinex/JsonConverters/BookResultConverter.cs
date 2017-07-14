using System;
using System.Collections.Generic;
using Bitfinex.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bitfinex.JsonConverters
{
    public class BooksResultConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<IBook>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);

            var results = new List<IBook>();

            foreach (var item in array)
            {
                var Book = JsonConvert.DeserializeObject<IBook>(item.ToString(), new BookResultConverter());
                results.Add(Book);
            }

            return results;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanWrite => false;
    }

    public class BookResultConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IBook);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);

            if (array.Count == 3) return JArrayToTradingBook(array);
            if (array.Count == 4) return JArrayToFundingBook(array);

            return null;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        private TradingBook JArrayToTradingBook(JArray array)
        {
            return new TradingBook
            {
                Price = (double)array[0],
                Count = (int)array[1],
                Amount = (double)array[2]
            };           
        }

        private FundingBook JArrayToFundingBook(JArray array)
        {
            return new FundingBook
            {
                Rate = (double)array[0],
                Period = (int)array[1],
                Count = (int)array[2],
                Amount = (double)array[3]
            };
        }
    }
}
