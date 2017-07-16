using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bitfinex.Models
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

    public class TradeSymbol
    {
        private const string Prefix = "t";

        private Symbol _symbol { get; }

        public string Value => Prefix + _symbol;

        public static explicit operator TradeSymbol(Symbol symbol)
        {
            return new TradeSymbol(symbol);
        }

        public TradeSymbol(Symbol symbol)
        {
            _symbol = symbol;
        }

        public override string ToString()
        {
            return Prefix + _symbol;
        }
    }


    public enum SortDirection
    {
        OldestToNewest = 1, NewestToOldest = -1
    }

    public class TimeFrame
    {
        public string Value { get; set; }

        public static TimeFrame Minute => new TimeFrame("1m");
        public static TimeFrame Minute5 => new TimeFrame("5m");
        public static TimeFrame Minute15 => new TimeFrame("15m");
        public static TimeFrame Minute30 => new TimeFrame("30m");
        public static TimeFrame Hour => new TimeFrame("1h");
        public static TimeFrame Hour3 => new TimeFrame("3h");
        public static TimeFrame Hour6 => new TimeFrame("6h");
        public static TimeFrame Hour12 => new TimeFrame("12h");
        public static TimeFrame Day => new TimeFrame("1D");
        public static TimeFrame Week => new TimeFrame("7D");
        public static TimeFrame Fortnight => new TimeFrame("14D");
        public static TimeFrame Month => new TimeFrame("1M");

        private TimeFrame(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }

    public class Section
    {
        public string Value { get; set; }

        public static Section Last => new Section("last");
        public static Section Historical => new Section("hist");

        private Section(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
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

            if ((string)array[0] == "error")
            {

                return new BitfinexException
                {
                    ErrorCode = (int)array[1],
                    Message = (string)array[2]
                };
            }

            return null;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
