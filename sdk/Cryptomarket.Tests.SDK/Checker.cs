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
            var fields = new List<string> { obj.FullName, obj.PrecisionTransfer };

            foreach (var network in obj.Networks) CheckNetwork.Invoke(network);

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public static readonly Action<Network> CheckNetwork = obj =>
        {
            var fields = new List<string> { obj.Code, obj.Network_ };

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public static readonly Action<Symbol> CheckSymbol = obj =>
        {
            var fields = new List<string> { obj.Type, obj.BaseCurrency, obj.QuoteCurrency, obj.Status, obj.QuantityIncrement, obj.TickSize, obj.TakeRate, obj.MakeRate, obj.FeeCurrency };

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public static readonly Action<Ticker> CheckTicker = obj =>
        {
            var fields = new List<string> { obj.High, obj.Low, obj.Volume, obj.VolumeQuote, obj.Timestamp };

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public static readonly Action<WSTicker> CheckWSTicker = obj =>
        {
            var fields = new List<string> { obj.Open, obj.Close, obj.High, obj.Low, obj.BestAsk, obj.BestAskQuantity, obj.BestBid, obj.BestBidQuantity, obj.VolumeBase, obj.VolumeQuote, obj.Timestamp.ToString() };

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public static readonly Action<WSOrderBook> CheckWSOrderBook = obj =>
        {
            var fields = new List<string> { obj.Timestamp.ToString(), obj.Sequence.ToString() };

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public static readonly Action<WSOrderBookTop> CheckWSOrderBookTop = obj =>
        {
            var fields = new List<string> { obj.Timestamp.ToString(), obj.BestAsk, obj.BestAskQuantity, obj.BestBid, obj.BestBidQuantity };

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public static readonly Action<Price> CheckPrice = obj =>
        {
            var fields = new List<string> { obj.Timestamp, };
        };
        public readonly static Action<TickerPrice> CheckTickerPrice = obj =>
        {
            List<String> fields = [ obj.Timestamp, obj.Price];

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<PriceHistory> CheckPriceHistory = obj =>
        {
            List<String> fields = [ obj.Currency];

            foreach (var field in fields) CheckString.Invoke(field);
            foreach (var history in obj.History) CheckHistoryPoint.Invoke(history);
        };
        public readonly static Action<HistoryPoint> CheckHistoryPoint = obj =>
        {
            List<String> fields = [ obj.Timestamp, obj.Open, obj.Close, obj.Max, obj.Min];

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<PublicTrade> CheckPublicTrade = obj =>
        {
            List<String> fields = [ obj.Price, obj.Quantity, obj.Side, obj.Timestamp];

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<WSPublicTrade> CheckWSPublicTrade = obj =>
        {
            List<String> fields = [ obj.Price, obj.Quantity, obj.Side, obj.Id.ToString(), obj.Timestamp.ToString()];

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<OrderbookLevel> CheckOBLevel = obj =>
        {
            List<String> fields = [ obj.Price, obj.Amount];

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<OrderBook> CheckOB = obj =>
        {
            List<String> fields = [ obj.Timestamp];

            foreach (var field in fields) CheckString.Invoke(field);

            foreach (var ask in obj.Ask) CheckOBLevel.Invoke(ask);
            foreach (var bid in obj.Bid) CheckOBLevel.Invoke(bid);
        };
        public readonly static Action<Candle> CheckCandle = obj =>
        {
            List<String> fields = [ obj.Timestamp, obj.Open, obj.Close, obj.Min, obj.Max, obj.Volume, obj.VolumeQuote];

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<WSCandle> CheckWSCandle = obj =>
        {
            List<String> fields = [ obj.Open, obj.Close, obj.High, obj.Low, obj.VolumeBase, obj.VolumeQuote ];

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<WSPriceRate> CheckWSPriceRate = obj =>
        {
            List<String> fields = [obj.Timestamp.ToString(), obj.Rate];

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<Balance> CheckBalance = obj =>
        {
            List<String> fields = [ obj.Currency, obj.Available, obj.Reserved];

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<Address> CheckAddress = obj =>
        {
            List<String> fields = [ obj.Currency, obj.Address_ ];

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<Order> CheckOrder = obj =>
        {
            List<String> fields = [ obj.Id, obj.ClientOrderId, obj.Symbol, obj.Side.ToString(), obj.Status.ToString(), obj.Type.ToString(), obj.TimeInForce.ToString(), obj.Quantity, obj.Price, obj.QuantityCumulative, obj.CreatedAt, obj.UpdatedAt];

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<Trade> CheckTrade = obj =>
        {
            List<String> fields = [ obj.OrderId, obj.ClientOrderId, obj.Symbol, obj.Side.ToString(), obj.Quantity, obj.Price, obj.Fee, obj.Timestamp];

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<Transaction> CheckTransaction = obj =>
        {
            List<String> fields = [ obj.Status.ToString(), obj.Type.ToString(), obj.Subtype.ToString(), obj.CreatedAt, obj.LastActivityAt, obj.CommitRisk.ToString(), obj.UpdatedAt ];

            foreach (var field in fields) CheckString.Invoke(field);
            
            if (obj.Id == 0)
                Assert.Fail("0==id");
        };
        public readonly static Action<NativeTransaction> CheckNativeTransaction = obj =>
        {
            List<String> fields = [ obj.Id, obj.Currency, obj.Amount];

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<Commission> CheckCommission = obj =>
        {
            List<String> fields = [ obj.Symbol, obj.MakeRate, obj.TakeRate];

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<Report> CheckReport = obj =>
        {
            List<String> fields = [ obj.Id, obj.ClientOrderId, obj.Symbol, obj.Side.ToString(), obj.Status.ToString(), obj.Type.ToString(), obj.TimeInForce, obj.Quantity, obj.QuantityCumulative, obj.Price, obj.CreatedAt, obj.UpdatedAt, obj.ReportType.ToString()];
            
            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<SubAccount> CheckSubAccount = obj =>
        {
            List<String> fields = [ obj.SubAccountId, obj.Email, obj.Status.ToString()];

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<SubAccountSettings> CheckSubAccountSettings = obj =>
        {
            List<String> fields = [ obj.SubAccountId, obj.DepositAddressGenerationEnabled.ToString(), obj.Description, obj.CreatedAt, obj.UpdatedAt];

            foreach (var field in fields) CheckString.Invoke(field);
        };
        public readonly static Action<Fee> CheckFee = obj =>
        {
            List<String> fields = [ obj.Fee_, obj.NetworkFee, obj.Currency, obj.Amount ];

            foreach (var field in fields) CheckString.Invoke(field);
        };
    }
}