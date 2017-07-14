using System;

namespace Bitfinex.Models
{
    public enum SortDirection
    {
        OldNew = 1,  NewOld = -1
    }

    public interface ITrade
    {
        decimal ID { get; set; }

        /// <summary>
        /// Millisecond time stamp
        /// </summary>
        decimal MTS { get; set; }

        /// <summary>
        /// How much was bought (positive) or sold (negative)
        /// </summary>
        double Amount { get; set; }

        /// <summary>
        /// Price at which the trade was executed
        /// </summary>
        double Price { get; set; }

        /// <summary>
        /// Rate at which funding transaction occurred
        /// </summary>
        double Rate { get; set; }

        /// <summary>
        /// Amount of time the funding transaction was for
        /// </summary>
        int Period { get; set; }
    }

    public class Trade
    {
        public decimal ID { get; set; }

        /// <summary>
        /// Millisecond time stamp
        /// </summary>
        public decimal MTS { get; set; }

        /// <summary>
        /// How much was bought (positive) or sold (negative)
        /// </summary>
        public double Amount { get; set; }
    }

    public class TradingTrade : Trade, ITrade
    {
        /// <summary>
        /// Price at which the trade was executed
        /// </summary>
        public double Price { get; set; }

        [Obsolete]
        public double Rate { get; set; }

        [Obsolete]
        public int Period { get; set; }
    }

    public class FundingTrade : Trade, ITrade
    {
        /// <summary>
        /// Rate at which funding transaction occurred
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// Amount of time the funding transaction was for
        /// </summary>
        public int Period { get; set; }

        [Obsolete]
        public double Price { get; set; }
    }
}