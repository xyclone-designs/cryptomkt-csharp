using CryptoMarket.SDK.Models;

namespace CryptoMarket.Tests.SDK
{
    public static class Checker
    {
        public static readonly Action<bool> CheckBooleanTrue = b =>
        {
            if (!b) Assert.Fail("boolean not true");
        };

        public static readonly Action<string> CheckString = str =>
        {
            if (string.IsNullOrEmpty(str)) Assert.Fail(str);
        };

        public static readonly Action<Currency> CheckCurrency = obj =>
        {
            var fields = new List<string>
            {
                obj.FullName,
                obj.PrecisionTransfer
            };

            foreach (var network in obj.Networks) CheckNetwork.Invoke(network);

            fields.ForEach(f => CheckString(f));
        };

        public static readonly Action<Network> CheckNetwork = obj =>
        {
            var fields = new List<string>
            {
                obj.Code,
                obj.Network_
            };
            fields.ForEach(f => CheckString(f));
        };

        public static readonly Action<Symbol> CheckSymbol = obj =>
        {
            var fields = new List<string>
            {
                obj.Type,
                obj.BaseCurrency,
                obj.QuoteCurrency,
                obj.Status,
                obj.QuantityIncrement,
                obj.TickSize,
                obj.TakeRate,
                obj.MakeRate,
                obj.FeeCurrency
            };
            fields.ForEach(f => CheckString(f));
        };

        public static readonly Action<Ticker> CheckTicker = obj =>
        {
            var fields = new List<string>
            {
                obj.High,
                obj.Low,
                obj.Volume,
                obj.VolumeQuote,
                obj.Timestamp
            };
            fields.ForEach(f => CheckString(f));
        };

        public static readonly Action<WSTicker> CheckWSTicker = obj =>
        {
            var fields = new List<string>
            {
                obj.Open,
                obj.Close,
                obj.High,
                obj.Low,
                obj.BestAsk,
                obj.BestAskQuantity,
                obj.BestBid,
                obj.BestBidQuantity,
                obj.VolumeBase,
                obj.VolumeQuote,
                obj.Timestamp.ToString()
            };
            fields.ForEach(f => CheckString(f));
        };

        public static readonly Action<WSOrderBook> CheckWSOrderBook = obj =>
        {
            var fields = new List<string>
            {
                obj.Timestamp.ToString(),
                obj.Sequence.ToString()
            };
            fields.ForEach(f => CheckString(f));
        };

        public static readonly Action<WSOrderBookTop> CheckWSOrderBookTop = obj =>
        {
            var fields = new List<string>
            {
                obj.Timestamp.ToString(),
                obj.BestAsk,
                obj.BestAskQuantity,
                obj.BestBid,
                obj.BestBidQuantity
            };
            fields.ForEach(f => CheckString(f));
        };

        public static readonly Action<Price> CheckPrice = obj =>
        {
            var fields = new List<string>
            {
                obj.Timestamp,
            };
        };
    }
}