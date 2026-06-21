using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Models;
using CryptoMarket.SDK.Params;
using CryptoMarket.SDK.Rest;
using CryptoMarket.SDK.Websocket;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace CryptoMarket.Tests.SDK
{
    public class TestRestClientMarketData
    {
        ICryptoMarketRestClient client = new CryptoMarketRestClientImpl();
        public virtual void TestGetAllCurrencies()
        {
            Dictionary<string, Currency> currencies = client.GetCurrencies(null, null);
            Assert.True(currencies.Count > 0);
            
            foreach (var currency in currencies) Checker.CheckCurrency.Invoke(currency.Value);
        }

        public virtual void TestGet2Currencies()
        {
            IList<string> currencyIds = ["EOS", "eth"];
            Dictionary<string, Currency> currencies = client.GetCurrencies(currencyIds, null);
            Assert.True(currencies.Count == 2);

            foreach (var currency in currencies) Checker.CheckCurrency.Invoke(currency.Value);
        }

        public virtual void TestGetCurrency()
        {
            Currency curr = client.GetCurrency("EOS");
            Checker.CheckCurrency.Invoke(curr);
        }

        public virtual void TestGetAllSymbols()
        {
            Dictionary<string, Symbol> symbols = client.GetSymbols(null);
            Assert.True(symbols.Count > 0);

            foreach (var symbol in symbols) Checker.CheckSymbol.Invoke(symbol.Value);
        }

        public virtual void TestGetASymbol()
        {
            IList<string> symbolIds = new List<string>(["EOSETH"]);
            Dictionary<string, Symbol> symbols = client.GetSymbols(symbolIds);
            Assert.True(symbols.Count == 1);

            foreach (var symbol in symbols) Checker.CheckSymbol.Invoke(symbol.Value);
        }

        public virtual void TestGet2Symbols()
        {
            IList<string> symbolIds = ["EOSETH", "ETHBTC"];
            Dictionary<string, Symbol> symbols = client.GetSymbols(symbolIds);
            Assert.True(symbols.Count == 2);

            foreach (var symbol in symbols) Checker.CheckSymbol.Invoke(symbol.Value);
        }

        public virtual void TestGetSymbol()
        {
            Symbol symbol = new() { Type = "EOSETH" };
            Checker.CheckSymbol.Invoke(symbol);
        }

        public virtual void TestGetAllTickers()
        {
            Dictionary<string, Ticker> tickers = client.GetTickers(null);
            Assert.True(tickers.Count > 0);

            foreach (var ticker in tickers) Checker.CheckTicker.Invoke(ticker.Value);
        }

        public virtual void TestGet2Tickers()
        {
            IList<string> symbolIds = ["EOSETH", "ETHBTC"];
            Dictionary<string, Ticker> tickers = client.GetTickers(symbolIds);
            Assert.True(tickers.Count == 2);

            foreach (var ticker in tickers) Checker.CheckTicker.Invoke(ticker.Value);
        }

        public virtual void TestGetAllPrices()
        {
            Dictionary<string, Price> prices = client.GetPrices("ETH", null);
            Assert.True(prices.Count > 2);

            foreach (var price in prices) Checker.CheckPrice.Invoke(price.Value);
        }

        public virtual void TestGetPrice()
        {
            Dictionary<string, Price> prices = client.GetPrices("ETH", "XLM");
            Assert.True(prices.Count == 1);

            foreach (var price in prices) Checker.CheckPrice.Invoke(price.Value);
        }

        public virtual void TestGetAllPricesHistory()
        {
            Dictionary<string, PriceHistory> prices = client.GetPricesHistory("ETH", null, null, null, null, null, null);
            Assert.True(prices.Count > 2);

            foreach (var price in prices) Checker.CheckPriceHistory.Invoke(price.Value);
        }

        public virtual void TestGetSomePricesHistory()
        {
            Dictionary<string, PriceHistory> prices = client.GetPricesHistory("ETH", "XLM", null, null, 3, null, null);
            Assert.True(prices.Count == 1);

            foreach (var price in prices) Checker.CheckPriceHistory.Invoke(price.Value);
        }

        public virtual void TestGetTickerPrice()
        {
            IList<string> symbols = ["EOSETH", "ETHBTC"];
            Dictionary<string, TickerPrice> prices = client.GetTickerLastPrices(symbols);
            Assert.True(prices.Count > 1);

            foreach (var price in prices) Checker.CheckTickerPrice.Invoke(price.Value);
        }

        public virtual void TestGetTickerPriceOfSymbol()
        {
            TickerPrice price = new () { Price = "EOSETH" };
            Checker.CheckTickerPrice.Invoke(price);
        }

        public virtual void GetTrades()
        {
            IList<string> symbols = ["EOSETH", "ETHBTC"];
            Dictionary<string, IList<PublicTrade>> trades = client.GetTrades(symbols, null, null, null, null, "2");
            Assert.True(trades.Keys.Count == 2);

            foreach (var trade in trades) Assert.True(trade.Value.Count == 2);
            foreach (var trade in trades.Values.SelectMany(_ => _)) Checker.CheckPublicTrade.Invoke(trade);
        }

        public virtual void GetTradesSortByIdWithLimit()
        {
            Dictionary<string, IList<PublicTrade>> trades = client.GetTrades(["EOSETH"], null, SortBy.ID, null, "1632334875", "2");
            
            foreach (var trade in trades) Assert.True(trade.Value.Count == 2);
        }

        public virtual void GetOrderbooks()
        {
            IList<string> symbols = ["EOSETH", "ETHBTC"];
            Dictionary<string, OrderBook> orderbooks = client.GetOrderBooks(symbols, 5);
            Assert.True(orderbooks.Keys.Count == 2);

            foreach (var orderbook in orderbooks) Checker.CheckOB.Invoke(orderbook.Value);
        }

        public virtual void GetOneOrderbook()
        {
            IList<string> symbols = new List<string>(["EOSETH"]);
            OrderBook orderbook = client.GetOrderBooks(symbols, 5)["EOSETH"];
            Checker.CheckOB.Invoke(orderbook);
        }

        public virtual void GetOrderbook()
        {
            OrderBook orderbook = client.GetOrderBookBySymbol("EOSETH", 3);
            Checker.CheckOB.Invoke(orderbook);
        }

        public virtual void GetCandles()
        {
            IList<string> symbols = new List<string>(["EOSETH"]);
            Dictionary<string, IList<Candle>> candles = client.GetCandles(symbols, Period._4_HOURS, Sort.ASC, null, null, null);
            Assert.True(candles.Keys.Count == 1);
            
            foreach (var candle in candles.SelectMany(_ => _.Value)) Checker.CheckCandle.Invoke(candle);
        }

        public virtual void GetCandlesBySymbol()
        {
            var candles = client.GetCandlesBySymbol("EOSETH", Period._4_HOURS, Sort.ASC, null, null, null, null);

            foreach (var candle in candles) Checker.CheckCandle.Invoke(candle);
        }

        public virtual void GetConvertedCandles()
        {
            var symbols = new List<string>(["EOSETH", "CROETH", "CROBTC"]);
            var targetCurrency = "BTC";
            var convertedCandles = client.GetConvertedCandles(targetCurrency, symbols, Period._4_HOURS, Sort.ASC, null, null, null);
            Assert.Equal(targetCurrency, convertedCandles.TargetCurrency);
            Assert.True(convertedCandles.Data.Keys.Count == 3);
            
            foreach (var candle in convertedCandles.Data.Values.SelectMany(_ => _)) Checker.CheckCandle.Invoke(candle);
        }

        public virtual void GetConvertedCandlesBySymbol()
        {
            var targetCurrency = "BTC";
            var convertedCandles = client.GetConvertedCandlesBySymbol(targetCurrency, "EOSETH", Period._4_HOURS, Sort.ASC, null, null, null, null);
            Assert.Equal(targetCurrency, convertedCandles.TargetCurrency);
            
            foreach (var candle in convertedCandles.Data) Checker.CheckCandle.Invoke(candle);
        }
    }
}