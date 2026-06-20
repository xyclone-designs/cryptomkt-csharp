using Org.Junit.Assert;
using Java.Io;
using Java.Util;
using Com.CryptoMarket.Params;
using CryptoMarket.Tests.SDK.Helpers;
using CryptoMarket.Tests.SDK.Websocket;
using Org.Junit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CryptoMarket.Tests.SDK
{
    public class TestWSMarketDataClientSubs
    {
        CryptoMarketWSMarketDataClient wsClient;
        bool authenticated = false;
        IList<string> symbols = Arrays.AsList("EOSETH");
        FailChecker failChecker;
        public virtual void Before()
        {
            wsClient = new CryptoMarketWSMarketDataClientImpl();
            wsClient.Connect();
            failChecker = new FailChecker();
            Helpers.Sleep(1);
        }

        public virtual void After()
        {
            wsClient.Dispose();
        }

        public virtual void TestTradesSubscription()
        {
            wsClient.SubscribeToTrades(Helpers.NotificationMapListChecker(failChecker, Checker.checkWSPublicTrade), symbols, null, Helpers.ListAndExceptionChecker(failChecker, Checker.checkString));
            Helpers.Sleep(30);
            AssertFalse(failChecker.Failed());
        }

        public virtual void TestSubscribeToCandles()
        {
            symbols = Arrays.AsList("EOSETH", "ETHBTC");
            wsClient.SubscribeToCandles(Helpers.NotificationMapListChecker(failChecker, Checker.checkWSCandle), Period._1_MINUTES, symbols, null, Helpers.ListAndExceptionChecker(failChecker, Checker.checkString));
            Helpers.Sleep(30);
            AssertFalse(failChecker.Failed());
        }

        public virtual void TestSubscribeToConvertedCandles()
        {
            symbols = Arrays.AsList("EOSETH", "ETHBTC");
            wsClient.SubscribeToConvertedCandles(Helpers.NotificationMapListChecker(failChecker, Checker.checkWSCandle), "BTC", Period._1_MINUTES, symbols, null, Helpers.ListAndExceptionChecker(failChecker, Checker.checkString));
            Helpers.Sleep(30);
            AssertFalse(failChecker.Failed());
        }

        public virtual void TestSubscribeToPriceRates()
        {
            IList<string> currencies = Arrays.AsList("BTC", "ETH");
            wsClient.SubscribeToPriceRates(Helpers.NotificationMapChecker(failChecker, Checker.checkWSPriceRate), PriceSpeed._1_SECONDS, "USDT", currencies, Helpers.ListAndExceptionChecker(failChecker, Checker.checkString));
            Helpers.Sleep(30);
            AssertFalse(failChecker.Failed());
        }

        public virtual void TestSubscribeToMiniTicker()
        {
            IList<string> symbols = Arrays.AsList("EOSETH");
            wsClient.SubscribeToMiniTicker(Helpers.NotificationMapChecker(failChecker, Checker.checkWSCandle), TickerSpeed._1_SECONDS, symbols, Helpers.ListAndExceptionChecker(failChecker, Checker.checkString));
            Helpers.Sleep(30);
            AssertFalse(failChecker.Failed());
        }

        public virtual void TestSubscribeToTicker()
        {
            IList<string> symbols = Arrays.AsList("EOSETH");
            wsClient.SubscribeToTicker(Helpers.NotificationMapChecker(failChecker, Checker.checkWSTicker), TickerSpeed._1_SECONDS, symbols, Helpers.ListAndExceptionChecker(failChecker, Checker.checkString));
            Helpers.Sleep(30);
            AssertFalse(failChecker.Failed());
        }

        public virtual void TestFullOrderbook()
        {
            IList<string> symbols = Arrays.AsList("EOSETH");
            wsClient.SubscribeToFullOrderBook(Helpers.NotificationMapChecker(failChecker, Checker.checkWSOrderBook), symbols, Helpers.ListAndExceptionChecker(failChecker, Checker.checkString));
            Helpers.Sleep(30);
            AssertFalse(failChecker.Failed());
        }

        public virtual void TestPartialOrderbook()
        {
            IList<string> symbols = Arrays.AsList("EOSETH");
            wsClient.SubscribeToPartialOrderBook(Helpers.NotificationMapChecker(failChecker, Checker.checkWSOrderBook), Depth._5, OBSpeed._500_MILISECONDS, symbols, Helpers.ListAndExceptionChecker(failChecker, Checker.checkString));
            Helpers.Sleep(30);
            AssertFalse(failChecker.Failed());
        }

        public virtual void TestOrderbookTop()
        {
            IList<string> symbols = Arrays.AsList("EOSETH");
            wsClient.SubscribeToTopOfOrderBook(Helpers.NotificationMapChecker(failChecker, Checker.checkWSOrderBookTop), OBSpeed._500_MILISECONDS, symbols, Helpers.ListAndExceptionChecker(failChecker, Checker.checkString));
            Helpers.Sleep(30);
            AssertFalse(failChecker.Failed());
        }
    }
}