namespace Bitfinex.Models
{
    public class Key
    {
        public string Value { get; set; }

        public static Key TotalOpenPosition => new Key("pos.size");

        public static Key TotalActiveFunding => new Key("funding.size");
        public static Key ActiveFundingUsedInPositions => new Key("credits.size");
        public static Key ActiveFundingUsedInPositionsPerTradingSymbol => new Key("credits.size.sym");

        private Key(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }

    public class Side
    {
        public string Value { get; set; }

        public static Side Long => new Side("long");
        public static Side Short => new Side("short");

        private Side(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }

    public class Stat
    {
        /// <summary>
        /// Millisecond timestamp
        /// </summary>
        public decimal MTS { get; set; }

        /// <summary>
        /// Total amount
        /// </summary>
        public double Value { get; set; }
    }
}
