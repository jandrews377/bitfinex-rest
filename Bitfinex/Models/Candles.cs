using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitfinex.Models
{
    public class Candle
    {
        /// <summary>
        /// Millisecond timestamp
        /// </summary>
        public decimal MTS { get; set; }

        /// <summary>
        /// First execution during the time frame
        /// </summary>
        public double Open { get; set; }

        /// <summary>
        /// Last execution during the time frame
        /// </summary>
        public double Close { get; set; }

        /// <summary>
        /// Highest execution during the time frame
        /// </summary>
        public double High { get; set; }

        /// <summary>
        /// Lowest execution during the timeframe
        /// </summary>
        public double Low { get; set; }

        /// <summary>
        /// Quantity of symbol traded within the timeframe
        /// </summary>
        public double Volume { get; set; }
    }
}
