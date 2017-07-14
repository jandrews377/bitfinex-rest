using System;

namespace Bitfinex.Models
{
    public interface ITicker
    {
        /// <summary>
        /// Flash Return Rate - average of all fixed rate funding over the last hour
        /// </summary>
        double FlashReturnRate { get; set; }

        /// <summary>
        /// Bid period covered in days
        /// </summary>
        int BidPeriod { get; set; }

        /// <summary>
        /// Ask period covered in days
        /// </summary>
        int AskPeriod { get; set; }

        string Symbol { get; set; }

        /// <summary>
        /// Price of last highest bid
        /// </summary>
        double Bid { get; set; }

        /// <summary>
        /// Size of the last highest bid
        /// </summary>
        double BidSize { get; set; }

        /// <summary>
        /// Price of last lowest ask
        /// </summary>
        double Ask { get; set; }

        /// <summary>
        /// Size of the last lowest ask
        /// </summary>
        double AskSize { get; set; }

        /// <summary>
        /// Amount that the last price has changed since yesterday
        /// </summary>
        double DailyChange { get; set; }

        /// <summary>
        /// Amount that the price has changed expressed in percentage terms
        /// </summary>
        double DailyChangePercent { get; set; }

        /// <summary>
        /// Price of the last trade
        /// </summary>
        double LastPrice { get; set; }

        /// <summary>
        /// Daily volume
        /// </summary>
        double Volume { get; set; }


        /// <summary>
        /// Daily high
        /// </summary>
        double High { get; set; }

        /// <summary>
        /// Daily low
        /// </summary>
        double Low { get; set; }
    }

    public class TradingTicker : Ticker, ITicker
    {
        [Obsolete]
        public double FlashReturnRate { get; set; }

        [Obsolete]
        public int BidPeriod { get; set; }

        [Obsolete]
        public int AskPeriod { get; set; }
    }

    public class FundingTicker : Ticker, ITicker
    {
        /// <summary>
        /// Flash Return Rate - average of all fixed rate funding over the last hour
        /// </summary>
        public double FlashReturnRate { get; set; }

        /// <summary>
        /// Bid period covered in days
        /// </summary>
        public int BidPeriod { get; set; }

        /// <summary>
        /// Ask period covered in days
        /// </summary>
        public int AskPeriod { get; set; }
    }

    public class Ticker
    {
        public string Symbol { get; set; }

        /// <summary>
        /// Price of last highest bid
        /// </summary>
        public double Bid { get; set; }

        /// <summary>
        /// Size of the last highest bid
        /// </summary>
        public double BidSize { get; set; }

        /// <summary>
        /// Price of last lowest ask
        /// </summary>
        public double Ask { get; set; }

        /// <summary>
        /// Size of the last lowest ask
        /// </summary>
        public double AskSize { get; set; }

        /// <summary>
        /// Amount that the last price has changed since yesterday
        /// </summary>
        public double DailyChange { get; set; }

        /// <summary>
        /// Amount that the price has changed expressed in percentage terms
        /// </summary>
        public double DailyChangePercent { get; set; }

        /// <summary>
        /// Price of the last trade
        /// </summary>
        public double LastPrice { get; set; }

        /// <summary>
        /// Daily volume
        /// </summary>
        public double Volume { get; set; }

        /// <summary>
        /// Daily high
        /// </summary>
        public double High { get; set; }

        /// <summary>
        /// Daily low
        /// </summary>
        public double Low { get; set; }
    }
}
