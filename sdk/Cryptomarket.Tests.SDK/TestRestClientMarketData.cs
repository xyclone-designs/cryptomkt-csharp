using Org.Junit.Assert;
using Java.Util;
using CryptoMarket.Tests.SDK.Exceptions;
using CryptoMarket.Tests.SDK.Models;
using CryptoMarket.Tests.SDK.Rest;
using Com.CryptoMarket.Params;
using Org.Junit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CryptoMarket.Tests.SDK
{
    public class TestRestClientMarketData
    {
        CryptoMarketRestClient client = new CryptoMarketRestClientImpl();
        public virtual void TestGetAllCurrencies()
        {
            Dictionary<string, Currency> currencies = client.GetCurrencies(null, null);
            AssertTrue(currencies.Count > 0);
            currencies.Values().ForEach(Checker.checkCurrency);
        }

        public virtual void TestGet2Currencies()
        {
            IList<string> currencyIds = new List<string>(Arrays.AsList("EOS", "eth"));
            Dictionary<string, Currency> currencies = client.GetCurrencies(currencyIds, null);
            AssertTrue(currencies.Count == 2);
            currencies.Values().ForEach(Checker.checkCurrency);
        }

        public virtual void TestGetCurrency()
        {
            Currency curr = client.GetCurrency("EOS");
            Checker.checkCurrency.Invoke(curr);
        }

        public virtual void TestGetAllSymbols()
        {
            Dictionary<string, Symbol> symbols = client.GetSymbols(null);
            AssertTrue(symbols.Count > 0);
            symbols.Values().ForEach(Checker.checkSymbol);
        }

        public virtual void TestGetASymbol()
        {
            IList<string> symbolIds = new List<string>(Arrays.AsList("EOSETH"));
            Dictionary<string, Symbol> symbols = client.GetSymbols(symbolIds);
            AssertTrue(symbols.Count == 1);
            symbols.Values().ForEach(Checker.checkSymbol);
        }

        public virtual void TestGet2Symbols()
        {
            IList<string> symbolIds = new List<string>(Arrays.AsList("EOSETH", "ETHBTC"));
            Dictionary<string, Symbol> symbols = client.GetSymbols(symbolIds);
            AssertTrue(symbols.Count == 2);
            symbols.Values().ForEach(Checker.checkSymbol);
        }

        public virtual void TestGetSymbol()
        {
            Symbol symbol = client.GetSymbol("EOSETH");
            Checker.checkSymbol.Invoke(symbol);
        }

        public virtual void TestGetAllTickers()
        {
            Dictionary<string, Ticker> tickers = client.GetTickers(null);
            AssertTrue(tickers.Count > 0);
            tickers.Values().ForEach(Checker.checkTicker);
        }

        public virtual void TestGet2Tickers()
        {
            IList<string> symbolIds = new List<string>(Arrays.AsList("EOSETH", "ETHBTC"));
            Dictionary<string, Ticker> tickers = client.GetTickers(symbolIds);
            AssertTrue(tickers.Count == 2);
            tickers.Values().ForEach(Checker.checkTicker);
        }

        public virtual void TestGetAllPrices()
        {
            Dictionary<string, Price> prices = client.GetPrices("ETH", null);
            AssertTrue(prices.Count > 2);
            prices.Values().ForEach(Checker.checkPrice);
        }

        public virtual void TestGetPrice()
        {
            Dictionary<string, Price> prices = client.GetPrices("ETH", "XLM");
            AssertTrue(prices.Count == 1);
            prices.Values().ForEach(Checker.checkPrice);
        }

        public virtual void TestGetAllPricesHistory()
        {
            Dictionary<string, PriceHistory> prices = client.GetPricesHistory("ETH", null, null, null, null, null, null);
            AssertTrue(prices.Count > 2);
            prices.Values().ForEach(Checker.checkPriceHistory);
        }

        public virtual void TestGetSomePricesHistory()
        {
            Dictionary<string, PriceHistory> prices = client.GetPricesHistory("ETH", "XLM", null, null, 3, null, null);
            AssertTrue(prices.Count == 1);
            prices.Values().ForEach(Checker.checkPriceHistory);
        }

        public virtual void TestGetTickerPrice()
        {
            IList<string> symbols = new List<string>(Arrays.AsList("EOSETH", "ETHBTC"));
            Dictionary<string, TickerPrice> prices = client.GetTickerLastPrices(symbols);
            AssertTrue(prices.Count > 1);
            prices.Values().ForEach(Checker.checkTickerPrice);
        }

        public virtual void TestGetTickerPriceOfSymbol()
        {
            TickerPrice price = client.GetTickerLastPriceBySymbol("EOSETH");
            Checker.checkTickerPrice.Invoke(price);
        }

        public virtual void GetTrades()
        {
            IList<string> symbols = new List<string>(Arrays.AsList("EOSETH", "ETHBTC"));
            Dictionary<string, IList<PublicTrade>> trades = client.GetTrades(symbols, null, null, null, null, "2");
            AssertTrue(trades.KeySet().Count == 2);
            trades.ForEach((key, list) =>
            {
                AssertTrue(list.Count == 2);
            });
            trades.ForEach((key, tradeList) =>
            {
                tradeList.ForEach(Checker.checkPublicTrade);
            });
        }

        public virtual void GetTradesSortByIdWithLimit()
        {
            Dictionary<string, IList<PublicTrade>> trades = client.GetTrades(Arrays.AsList("EOSETH"), null, SortBy.ID, null, "1632334875", "2");
            trades.ForEach((key, list) =>
            {
                AssertTrue(list.Count == 2);
            });
        }

        public virtual void GetOrderbooks()
        {
            IList<string> symbols = new List<string>(Arrays.AsList("EOSETH", "ETHBTC"));
            Dictionary<string, OrderBook> orderbooks = client.GetOrderBooks(symbols, 5);
            AssertTrue(orderbooks.KeySet().Count == 2);
            orderbooks.ForEach((key, ob) =>
            {
                Checker.checkOB.Invoke(ob);
            });
        }

        public virtual void GetOneOrderbook()
        {
            IList<string> symbols = new List<string>(Arrays.AsList("EOSETH"));
            OrderBook orderbook = client.GetOrderBooks(symbols, 5)["EOSETH"];
            Checker.checkOB.Invoke(orderbook);
        }

        public virtual void GetOrderbook()
        {
            OrderBook orderbook = client.GetOrderBookBySymbol("EOSETH", 3);
            Checker.checkOB.Invoke(orderbook);
        }

        public virtual void GetCandles()
        {
            IList<string> symbols = new List<string>(Arrays.AsList("EOSETH"));
            Dictionary<string, IList<Candle>> candles = client.GetCandles(symbols, Period._4_HOURS, Sort.ASC, null, null, null);
            AssertTrue(candles.KeySet().Count == 1);
            candles.ForEach((key, candleList) =>
            {
                candleList.ForEach(Checker.checkCandle);
            });
        }

        public virtual void GetCandlesBySymbol()
        {
            var candles = client.GetCandlesBySymbol("EOSETH", Period._4_HOURS, Sort.ASC, null, null, null, null);
            candles.ForEach(Checker.checkCandle);
        }

        public virtual void GetConvertedCandles()
        {
            var symbols = new List<string>(Arrays.AsList("EOSETH", "CROETH", "CROBTC"));
            var targetCurrency = "BTC";
            var convertedCandles = client.GetConvertedCandles(targetCurrency, symbols, Period._4_HOURS, Sort.ASC, null, null, null);
            AssertEquals(targetCurrency, convertedCandles.GetTargetCurrency());
            AssertTrue(convertedCandles.GetData().KeySet().Count == 3);
            convertedCandles.GetData().ForEach((key, candleList) =>
            {
                candleList.ForEach(Checker.checkCandle);
            });
        }

        public virtual void GetConvertedCandlesBySymbol()
        {
            var targetCurrency = "BTC";
            var convertedCandles = client.GetConvertedCandlesBySymbol(targetCurrency, "EOSETH", Period._4_HOURS, Sort.ASC, null, null, null, null);
            AssertEquals(targetCurrency, convertedCandles.GetTargetCurrency());
            convertedCandles.GetData().ForEach(Checker.checkCandle);
        }
    }
}