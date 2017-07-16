using System;

namespace Bitfinex.Models
{
    public enum Precision
    {
        P0, P1, P2, P3, R0
    }

    public interface IBook
    {
        /// <summary>
        /// Price level
        /// </summary>
        double Price { get; set; }

        /// <summary>
        /// Rate level
        /// </summary>
        double Rate { get; set; }

        /// <summary>
        /// Period level (Funding only)
        /// </summary>
        double Period { get; set; }

        /// <summary>
        /// Number of orders at that price level
        /// </summary>
        int Count { get; set; }

        /// <summary>
        /// Total amount available at that price level.
        /// </summary>
        double Amount { get; set; }
    }

    public class Book
    {
        /// <summary>
        /// Number of orders at that price level
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Total amount available at that price level.
        /// </summary>
        public double Amount { get; set; }
    }

    public class TradingBook : Book, IBook
    {
        /// <summary>
        /// Price level
        /// </summary>
        public double Price { get; set; }

        [Obsolete]
        public double Rate { get; set; }

        [Obsolete]
        public double Period { get; set; }
    }

    public class FundingBook : Book, IBook
    {
        /// <summary>
        /// Rate at which funding transaction occurred
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// Amount of time the funding transaction was for
        /// </summary>
        public double Period { get; set; }

        [Obsolete]
        public double Price { get; set; }
    }
}
