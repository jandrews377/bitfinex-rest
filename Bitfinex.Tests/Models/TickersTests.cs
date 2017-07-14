using System.Collections.Generic;
using Bitfinex.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Bitfinex.Tests.Models
{
    [TestClass]
    public class TickersTests
    {
  
        [TestMethod]
        public void TickerDeserializeTest1()
        {
            //GET: https://api.bitfinex.com/v2/tickers?symbols=tETHBTC

            string json = "[ \"tETHBTC\", 0.1386, 0.58674268, 0.1391, 89.87488593, -0.00099, -0.0071, 0.13899, 87521.10872248, 0.14331, 0.12951 ]";

            var ticker = JsonConvert.DeserializeObject<ITicker>(json, new TickerResultConverter());

            Assert.AreEqual("ETHBTC", ticker.Symbol);
            Assert.AreEqual(0.1386, ticker.Bid);
            Assert.AreEqual(0.58674268, ticker.BidSize);
            Assert.AreEqual(0.1391, ticker.Ask);
            Assert.AreEqual(89.87488593, ticker.AskSize);
            Assert.AreEqual(-0.00099, ticker.DailyChange);
            Assert.AreEqual(-0.0071, ticker.DailyChangePercent);
            Assert.AreEqual(0.13899, ticker.LastPrice);
            Assert.AreEqual(87521.10872248, ticker.Volume);
            Assert.AreEqual(0.14331, ticker.High);
            Assert.AreEqual(0.12951, ticker.Low);

        }

        [TestMethod]
        public void TickerDeserializeTest2()
        {
            //GET: https://api.bitfinex.com/v2/tickers?symbols=fUSD

            string json = "[ \"fUSD\", 0.00171431, 0.00156, 30, 998501.81496333, 0.0015, 2, 183396.25235139, -0.0001294, -0.0767, 0.0015586, 55302424.0576984, 0, 0 ]";

            var ticker = JsonConvert.DeserializeObject<ITicker>(json, new TickerResultConverter());

            Assert.AreEqual("USD", ticker.Symbol);
            Assert.AreEqual(0.00171431, ticker.FlashReturnRate);
            Assert.AreEqual(0.00156, ticker.Bid);
            Assert.AreEqual(30, ticker.BidPeriod);
            Assert.AreEqual(998501.81496333, ticker.BidSize);
            Assert.AreEqual(0.0015, ticker.Ask);
            Assert.AreEqual(2, ticker.AskPeriod);
            Assert.AreEqual(183396.25235139, ticker.AskSize);
            Assert.AreEqual(-0.0001294, ticker.DailyChange);
            Assert.AreEqual(-0.0767, ticker.DailyChangePercent);
            Assert.AreEqual(0.0015586, ticker.LastPrice);
            Assert.AreEqual(55302424.0576984, ticker.Volume);
            Assert.AreEqual(0, ticker.High);
            Assert.AreEqual(0, ticker.Low);
        }

        [TestMethod]
        public void TickerDeserializeTest3()
        {
            //GET: https://api.bitfinex.com/v2/tickers?symbols=tBTCUSD,fUSD

            string json = "[ [ \"tBTCUSD\", 2367, 0.5569, 2367.7, 1.34457976, 88.8, 0.039, 2367.7, 52265.08783943, 2397, 2046 ]," +
                          " [\"fUSD\", 0.00170975, 0.00145, 30, 1527.14753183, 0.00149, 2, 183396.25235139, -0.00015242, -0.0915, 0.00151348, 55001789.95285199, 0, 0 ] ]";

            var tickers = JsonConvert.DeserializeObject<List<ITicker>>(json, new TickersResultConverter());

            Assert.AreEqual(2, tickers.Count);

        }

        [TestMethod]
        public void TickerClientTest()
        {
            var client = new BitfinexRestClient();
            var ticker = client.GetTicker("tBTCUSD");

            Assert.AreEqual("BTCUSD", ticker.Symbol);
        }
    }
}
