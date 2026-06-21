using CryptoMarket.SDK.Params;
using CryptoMarket.SDK.Websocket;

namespace CryptoMarket.Tests.SDK
{
    public class TestWSMarketDataClientSubs
    {
        ICryptoMarketWSMarketDataClient wsClient;
        bool authenticated = false;
        IList<string> symbols = ["EOSETH"];
        Helpers.FailChecker failChecker;
        public virtual void Before()
        {
            wsClient = new CryptoMarketWSMarketDataClientImpl();
            wsClient.Connect();
            failChecker = new Helpers.FailChecker();
            Helpers.Sleep(1);
        }

        public virtual void After()
        {
            wsClient.Dispose();
        }

        public virtual void TestTradesSubscription()
        {
            wsClient.SubscribeToTrades(Helpers.NotificationMapListChecker(failChecker, Checker.CheckWSPublicTrade), symbols, null, Helpers.ListAndExceptionChecker(failChecker, Checker.CheckString));
            Helpers.Sleep(30);
            Assert.False(failChecker.Failed());
        }

        public virtual void TestSubscribeToCandles()
        {
            symbols = ["EOSETH", "ETHBTC"];
            wsClient.SubscribeToCandles(Helpers.NotificationMapListChecker(failChecker, Checker.CheckWSCandle), Period._1_MINUTES, symbols, null, Helpers.ListAndExceptionChecker(failChecker, Checker.CheckString));
            Helpers.Sleep(30);
            Assert.False(failChecker.Failed());
        }

        public virtual void TestSubscribeToConvertedCandles()
        {
            symbols = ["EOSETH", "ETHBTC"];
            wsClient.SubscribeToConvertedCandles(Helpers.NotificationMapListChecker(failChecker, Checker.CheckWSCandle), "BTC", Period._1_MINUTES, symbols, null, Helpers.ListAndExceptionChecker(failChecker, Checker.CheckString));
            Helpers.Sleep(30);
            Assert.False(failChecker.Failed());
        }

        public virtual void TestSubscribeToPriceRates()
        {
            IList<string> currencies = ["BTC", "ETH"];
            wsClient.SubscribeToPriceRates(Helpers.NotificationMapChecker(failChecker, Checker.CheckWSPriceRate), PriceSpeed._1_SECONDS, "USDT", currencies, Helpers.ListAndExceptionChecker(failChecker, Checker.CheckString));
            Helpers.Sleep(30);
            Assert.False(failChecker.Failed());
        }

        public virtual void TestSubscribeToMiniTicker()
        {
            IList<string> symbols = ["EOSETH"];
            wsClient.SubscribeToMiniTicker(Helpers.NotificationMapChecker(failChecker, Checker.CheckWSCandle), TickerSpeed._1_SECONDS, symbols, Helpers.ListAndExceptionChecker(failChecker, Checker.CheckString));
            Helpers.Sleep(30);
            Assert.False(failChecker.Failed());
        }

        public virtual void TestSubscribeToTicker()
        {
            IList<string> symbols = ["EOSETH"];
            wsClient.SubscribeToTicker(Helpers.NotificationMapChecker(failChecker, Checker.CheckWSTicker), TickerSpeed._1_SECONDS, symbols, Helpers.ListAndExceptionChecker(failChecker, Checker.CheckString));
            Helpers.Sleep(30);
            Assert.False(failChecker.Failed());
        }

        public virtual void TestFullOrderbook()
        {
            IList<string> symbols = ["EOSETH"];
            wsClient.SubscribeToFullOrderBook(Helpers.NotificationMapChecker(failChecker, Checker.CheckWSOrderBook), symbols, Helpers.ListAndExceptionChecker(failChecker, Checker.CheckString));
            Helpers.Sleep(30);
            Assert.False(failChecker.Failed());
        }

        public virtual void TestPartialOrderbook()
        {
            IList<string> symbols = ["EOSETH"];
            wsClient.SubscribeToPartialOrderBook(Helpers.NotificationMapChecker(failChecker, Checker.CheckWSOrderBook), Depth._5, OBSpeed._500_MILISECONDS, symbols, Helpers.ListAndExceptionChecker(failChecker, Checker.CheckString));
            Helpers.Sleep(30);
            Assert.False(failChecker.Failed());
        }

        public virtual void TestOrderbookTop()
        {
            IList<string> symbols = ["EOSETH"];
            wsClient.SubscribeToTopOfOrderBook(Helpers.NotificationMapChecker(failChecker, Checker.CheckWSOrderBookTop), OBSpeed._500_MILISECONDS, symbols, Helpers.ListAndExceptionChecker(failChecker, Checker.CheckString));
            Helpers.Sleep(30);
            Assert.False(failChecker.Failed());
        }
    }
}