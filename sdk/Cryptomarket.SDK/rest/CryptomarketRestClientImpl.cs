using Java.Io;
using Java.Util;
using Org.Apache.Http.Impl.Client;
using Org.Jetbrains.Annotations;
using Com.Cryptomarket.Params;
using Cryptomarket.SDK;
using Cryptomarket.SDK.Exceptions;
using Cryptomarket.SDK.Models;
using Cryptomarket.SDK.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.SDK.Rest.AccountType;
using static Cryptomarket.SDK.Rest.ContingencyType;
using static Cryptomarket.SDK.Rest.Depth;
using static Cryptomarket.SDK.Rest.IdentifyBy;
using static Cryptomarket.SDK.Rest.NotificationType;
using static Cryptomarket.SDK.Rest.OBSpeed;
using static Cryptomarket.SDK.Rest.OrderBy;
using static Cryptomarket.SDK.Rest.OrderStatus;
using static Cryptomarket.SDK.Rest.OrderType;
using static Cryptomarket.SDK.Rest.Period;
using static Cryptomarket.SDK.Rest.PriceSpeed;
using static Cryptomarket.SDK.Rest.ReportType;
using static Cryptomarket.SDK.Rest.Side;
using static Cryptomarket.SDK.Rest.Sort;
using static Cryptomarket.SDK.Rest.SortBy;
using static Cryptomarket.SDK.Rest.SubAccountStatus;
using static Cryptomarket.SDK.Rest.SubAccountTransferType;
using static Cryptomarket.SDK.Rest.SubscriptionMode;
using static Cryptomarket.SDK.Rest.TickerSpeed;
using static Cryptomarket.SDK.Rest.TimeInForce;
using static Cryptomarket.SDK.Rest.TransactionStatus;
using static Cryptomarket.SDK.Rest.TransactionSubtype;
using static Cryptomarket.SDK.Rest.TransactionType;
using static Cryptomarket.SDK.Rest.UseOffchain;

namespace Cryptomarket.SDK.Rest
{
    public class CryptomarketRestClientImpl : CryptomarketRestClient
    {
        CloseableHttpClient httpClient;
        Adapter adapter = new Adapter();
        public CryptomarketRestClientImpl(string apiKey, string apiSecret) : this(apiKey, apiSecret, HttpClients.CreateDefault())
        {
        }

        public CryptomarketRestClientImpl(string apiKey, string apiSecret, org.apache.http.impl.client.CloseableHttpClient client)
        {
            string url = "https://api.exchange.cryptomkt.com";
            string apiVersion = "/api/3/";
            httpClient = new HttpClientImpl(client, url, apiVersion, apiKey, apiSecret);
        }

        public CryptomarketRestClientImpl() : this("", "")
        {
        }

        public CryptomarketRestClientImpl(org.apache.http.impl.client.CloseableHttpClient client) : this("", "", client)
        {
        }

        public virtual void ChangeCredentials(string apiKey, string apiSecret)
        {
            httpClient.ChangeCredentials(apiKey, apiSecret);
        }

        public virtual void ChangeWindow(int window)
        {
            httpClient.ChangeWindow(window);
        }

        // PUBLIC
        public virtual Dictionary<string, Currency> GetCurrencies(IList<string> currencies, string preferredNetwork)
        {
            Dictionary<string, string> params = new ParamsBuilder().Currencies(currencies).PreferredNetwork(preferredNetwork).Build();
            string jsonResponse = httpClient.PublicGet("public/currency", @params);
            return adapter.MapFromJson(jsonResponse, typeof(Currency));
        }

        public virtual Currency GetCurrency(string currency)
        {
            string jsonResponse = httpClient.PublicGet(String.Format("public/currency/%s", currency), null);
            return adapter.ObjectFromJson(jsonResponse, typeof(Currency));
        }

        public virtual Dictionary<string, Symbol> GetSymbols(IList<string> symbols)
        {
            Dictionary<string, string> params = new ParamsBuilder().Symbols(symbols).Build();
            string jsonResponse = httpClient.PublicGet("public/symbol", @params);
            return adapter.MapFromJson(jsonResponse, typeof(Symbol));
        }

        public virtual Symbol GetSymbol(string symbol)
        {
            string jsonResponse = httpClient.PublicGet(String.Format("public/symbol/%s", symbol), null);
            return adapter.ObjectFromJson(jsonResponse, typeof(Symbol));
        }

        public virtual Dictionary<string, Ticker> GetTickers(IList<string> symbols)
        {
            Dictionary<string, string> params = new ParamsBuilder().Symbols(symbols).Build();
            string jsonResponse = httpClient.PublicGet("public/ticker", @params);
            return adapter.MapFromJson(jsonResponse, typeof(Ticker));
        }

        public virtual Ticker GetTicker(string symbol)
        {
            string jsonResponse = httpClient.PublicGet(String.Format("public/ticker/%s", symbol), null);
            return adapter.ObjectFromJson(jsonResponse, typeof(Ticker));
        }

        public virtual Ticker GetTickerBySymbol(string symbol)
        {
            return GetTicker(symbol);
        }

        public virtual Ticker GetTickerOfSymbol(string symbol)
        {
            return GetTicker(symbol);
        }

        public virtual Dictionary<string, Price> GetPrices(string to, string from)
        {
            return GetPrices(new ParamsBuilder().To(to).From(from));
        }

        public virtual Dictionary<string, Price> GetPrices(ParamsBuilder paramsBuilder)
        {
            paramsBuilder.CheckRequired(Arrays.AsList(ArgNames.TO));
            string jsonResponse = httpClient.PublicGet("public/price/rate", paramsBuilder.Build());
            return adapter.MapFromJson(jsonResponse, typeof(Price));
        }

        public virtual Dictionary<string, PriceHistory> GetPricesHistory(string to, string from, string until, string since, int limit, Period period, Sort sort)
        {
            return GetPricesHistory(new ParamsBuilder().To(to).From(from).Until(until).Since(since).Limit(limit).Period(period).Sort(sort));
        }

        public virtual Dictionary<string, PriceHistory> GetPricesHistory(ParamsBuilder paramsBuilder)
        {
            paramsBuilder.CheckRequired(Arrays.AsList(ArgNames.TO));
            string jsonResponse = httpClient.PublicGet("public/price/history", paramsBuilder.Build());
            return adapter.MapFromJson(jsonResponse, typeof(PriceHistory));
        }

        public virtual Dictionary<string, TickerPrice> GetTickerLastPrices(IList<string> symbols)
        {
            Dictionary<string, string> params = new ParamsBuilder().Symbols(symbols).Build();
            string jsonResponse = httpClient.PublicGet("public/price/ticker", @params);
            return adapter.MapFromJson(jsonResponse, typeof(TickerPrice));
        }

        public virtual TickerPrice GetTickerLastPriceBySymbol(string symbol)
        {
            string jsonResponse = httpClient.PublicGet(String.Format("public/price/ticker/%s", symbol), null);
            return adapter.ObjectFromJson(jsonResponse, typeof(TickerPrice));
        }

        public virtual TickerPrice GetTickerLastPriceOfSymbol(string symbol)
        {
            return GetTickerLastPriceBySymbol(symbol);
        }

        public virtual TickerPrice GetTickerLastPrice(string symbol)
        {
            return GetTickerLastPriceBySymbol(symbol);
        }

        public virtual Dictionary<string, IList<PublicTrade>> GetTrades(IList<string> symbols, Sort sort, SortBy by, string from, string till, string limit)
        {
            return GetTrades(new ParamsBuilder().Symbols(symbols).Sort(sort).From(from).Till(till).Limit(limit).By(by));
        }

        public virtual Dictionary<string, IList<PublicTrade>> GetTrades(ParamsBuilder paramsBuilder)
        {
            string jsonResponse = httpClient.PublicGet("public/trades", paramsBuilder.Build());
            return adapter.ListMapFromJson(jsonResponse, typeof(PublicTrade));
        }

        public virtual IList<PublicTrade> GetTradesBySymbol(string symbol, Sort sort, SortBy by, string from, string till, int limit, int offset)
        {
            return GetTradesBySymbol(new ParamsBuilder().Symbol(symbol).Sort(sort).By(by).From(from).Till(till).Limit(limit).Offset(offset));
        }

        public virtual IList<PublicTrade> GetTradesBySymbol(ParamsBuilder paramsBuilder)
        {
            paramsBuilder.CheckRequired(Arrays.AsList(ArgNames.SYMBOL));
            string symbol = (string)paramsBuilder.Remove(ArgNames.SYMBOL);
            string jsonResponse = httpClient.PublicGet(String.Format("public/trades/%s", symbol), paramsBuilder.Build());
            return adapter.ListFromJson(jsonResponse, typeof(PublicTrade));
        }

        public virtual IList<PublicTrade> GetTradesOfSymbol(ParamsBuilder paramsBuilder)
        {
            return GetTradesBySymbol(paramsBuilder);
        }

        public virtual Dictionary<string, OrderBook> GetOrderBooks(IList<string> symbols, int depth)
        {
            return GetOrderBooks(new ParamsBuilder().Symbols(symbols).Depth(depth));
        }

        public virtual Dictionary<string, OrderBook> GetOrderBooks(ParamsBuilder paramsBuilder)
        {
            string jsonResponse = httpClient.PublicGet("public/orderbook", paramsBuilder.Build());
            return adapter.MapFromJson(jsonResponse, typeof(OrderBook));
        }

        public virtual OrderBook GetOrderBookBySymbol(string symbol, int depth)
        {
            return GetOrderBookBySymbol(new ParamsBuilder().Symbol(symbol).Depth(depth));
        }

        public virtual OrderBook GetOrderBookOfSymbol(ParamsBuilder paramsBuilder)
        {
            return GetOrderBookBySymbol(paramsBuilder);
        }

        public virtual OrderBook GetOrderBook(ParamsBuilder paramsBuilder)
        {
            return GetOrderBookBySymbol(paramsBuilder);
        }

        public virtual OrderBook GetOrderBookBySymbol(ParamsBuilder paramsBuilder)
        {
            paramsBuilder.CheckRequired(Arrays.AsList(ArgNames.SYMBOL));
            string symbol = (string)paramsBuilder.Remove(ArgNames.SYMBOL);
            string jsonResponse = httpClient.PublicGet(String.Format("public/orderbook/%s", symbol), paramsBuilder.Build());
            return adapter.ObjectFromJson(jsonResponse, typeof(OrderBook));
        }

        public virtual OrderBook GetOrderBookVolumeBySymbol(string symbol, int volume)
        {
            return GetOrderBookVolumeBySymbol(new ParamsBuilder().Symbol(symbol).Volume(volume));
        }

        public virtual OrderBook GetOrderBookVolumeBySymbol(ParamsBuilder paramsBuilder)
        {
            paramsBuilder.CheckRequired(Arrays.AsList(ArgNames.SYMBOL, ArgNames.VOLUME));
            string symbol = (string)paramsBuilder.Remove(ArgNames.SYMBOL);
            string jsonResponse = httpClient.PublicGet(String.Format("public/orderbook/%s", symbol), paramsBuilder.Build());
            return adapter.ObjectFromJson(jsonResponse, typeof(OrderBook));
        }

        public virtual OrderBook GetOrderBookVolumeOfSymbol(ParamsBuilder paramsBuilder)
        {
            return GetOrderBookVolumeBySymbol(paramsBuilder);
        }

        public virtual OrderBook GetOrderBookVolume(ParamsBuilder paramsBuilder)
        {
            return GetOrderBookVolumeBySymbol(paramsBuilder);
        }

        public virtual Dictionary<string, IList<Candle>> GetCandles(IList<string> symbols, Period period, Sort sort, string from, string till, int limit)
        {
            return GetCandles(new ParamsBuilder().Symbols(symbols).Period(period).Sort(sort).From(from).Till(till).Limit(limit));
        }

        public virtual Dictionary<string, IList<Candle>> GetCandles(ParamsBuilder paramsBuilder)
        {
            string jsonResponse = httpClient.PublicGet("public/candles", paramsBuilder.Build());
            return adapter.ListMapFromJson(jsonResponse, typeof(Candle));
        }

        public virtual IList<Candle> GetCandlesBySymbol(string symbol, Period period, Sort sort, string from, string till, int limit, int offset)
        {
            return GetCandlesBySymbol(new ParamsBuilder().Symbol(symbol).Period(period).Sort(sort).From(from).Till(till).Limit(limit).Offset(offset));
        }

        public virtual IList<Candle> GetCandlesBySymbol(ParamsBuilder paramsBuilder)
        {
            paramsBuilder.CheckRequired(Arrays.AsList(ArgNames.SYMBOL));
            string symbol = (string)paramsBuilder.Remove(ArgNames.SYMBOL);
            string jsonResponse = httpClient.PublicGet(String.Format("public/candles/%s", symbol), paramsBuilder.Build());
            return adapter.ListFromJson(jsonResponse, typeof(Candle));
        }

        public virtual IList<Candle> GetCandlesOfSymbol(ParamsBuilder paramsBuilder)
        {
            return GetCandlesBySymbol(paramsBuilder);
        }

        public virtual ConvertedCandles GetConvertedCandles(string targetCurrency, IList<string> symbols, Period period, Sort sort, string from, string till, int limit)
        {
            return GetConvertedCandles(new ParamsBuilder().TargetCurrency(targetCurrency).Symbols(symbols).Period(period).Sort(sort).From(from).Till(till).Limit(limit));
        }

        public virtual ConvertedCandles GetConvertedCandles(ParamsBuilder paramsBuilder)
        {
            paramsBuilder.CheckRequired(Arrays.AsList(ArgNames.TARGET_CURRENCY));
            string jsonResponse = httpClient.PublicGet("public/converted/candles", paramsBuilder.Build());
            return adapter.ObjectFromJson(jsonResponse, typeof(ConvertedCandles));
        }

        public virtual ConvertedCandlesBySymbol GetConvertedCandlesBySymbol(string targetCurrency, string symbol, Period period, Sort sort, string from, string till, int limit, int offset)
        {
            return GetConvertedCandlesBySymbol(new ParamsBuilder().TargetCurrency(targetCurrency).Symbol(symbol).Period(period).Sort(sort).From(from).Till(till).Limit(limit).Offset(offset));
        }

        public virtual ConvertedCandlesBySymbol GetConvertedCandlesBySymbol(ParamsBuilder paramsBuilder)
        {
            paramsBuilder.CheckRequired(Arrays.AsList(ArgNames.TARGET_CURRENCY, ArgNames.SYMBOL));
            string symbol = (string)paramsBuilder.Remove(ArgNames.SYMBOL);
            string jsonResponse = httpClient.PublicGet(String.Format("public/converted/candles/%s", symbol), paramsBuilder.Build());
            return adapter.ObjectFromJson(jsonResponse, typeof(ConvertedCandlesBySymbol));
        }

        public virtual ConvertedCandlesBySymbol GetConvertedCandlesOfSymbol(ParamsBuilder paramsBuilder)
        {
            return GetConvertedCandlesBySymbol(paramsBuilder);
        }

        // SPOT TRADING
        public virtual IList<Balance> GetSpotTradingBalances()
        {
            string jsonResponse = httpClient.Get("spot/balance", null);
            return adapter.ListFromJson(jsonResponse, typeof(Balance));
        }

        public virtual Balance GetSpotTradingBalanceByCurrency(string currency)
        {
            string jsonResponse = httpClient.Get(String.Format("spot/balance/%s", currency), null);
            Balance balance = adapter.ObjectFromJson(jsonResponse, typeof(Balance));
            balance.SetCurrency(currency);
            return balance;
        }

        public virtual Balance GetSpotTradingBalanceOfCurrency(string currency)
        {
            return GetSpotTradingBalanceByCurrency(currency);
        }

        public virtual Balance GetSpotTradingBalance(string currency)
        {
            return GetSpotTradingBalanceByCurrency(currency);
        }

        public virtual IList<Order> GetAllActiveSpotOrders(string symbol)
        {
            Dictionary<string, string> params = new ParamsBuilder().Symbol(symbol).Build();
            string jsonResponse = httpClient.Get("spot/order", @params);
            return adapter.ListFromJson(jsonResponse, typeof(Order));
        }

        public virtual Order GetActiveSpotOrder(string clientOrderId)
        {
            string jsonResponse = httpClient.Get(String.Format("spot/order/%s", clientOrderId), null);
            return adapter.ObjectFromJson(jsonResponse, typeof(Order));
        }

        public virtual Order CreateSpotOrder(string symbol, Side side, string quantity, string clientOrderId, OrderType orderType, string price, string stopPrice, TimeInForce timeInForce, string expireTime, bool strictValidate, bool postOnly, string takeRate, string makeRate)
        {
            return CreateSpotOrder(new ParamsBuilder().Symbol(symbol).Side(side).Quantity(quantity).ClientOrderId(clientOrderId).OrderType(orderType).Price(price).StopPrice(stopPrice).TimeInForce(timeInForce).ExpireTime(expireTime).StrictValidate(strictValidate).PostOnly(postOnly).TakeRate(takeRate).MakeRate(makeRate));
        }

        public virtual Order CreateSpotOrder(ParamsBuilder paramsBuilder)
        {
            string payload = adapter.MapStrStrToJson(paramsBuilder.BuildObjectMap());
            string jsonResponse = httpClient.Post("spot/order", payload);
            return adapter.ObjectFromJson(jsonResponse, typeof(Order));
        }

        public virtual Order CreateSpotOrder(OrderBuilder orderBuilder)
        {
            string payload = adapter.ObjectToJson(orderBuilder, typeof(OrderBuilder));
            string jsonResponse = httpClient.Post("spot/order", payload);
            return adapter.ObjectFromJson(jsonResponse, typeof(Order));
        }

        public virtual IList<Order> CreateSpotOrderList(ContingencyType contingencyType, IList<OrderBuilder> orders, string orderListId)
        {
            OrderListRequest oderListRequest = new OrderListRequest(contingencyType, orderListId, orders);
            string payload = adapter.ObjectToJson(oderListRequest, typeof(OrderListRequest));
            string jsonResponse = httpClient.Post("spot/order/list", payload);
            return adapter.ListFromJson(jsonResponse, typeof(Order));
        }

        public virtual Order ReplaceSpotOrder(string clientOrderId, string newClientOrderId, string quantity, string price, string stopPrice, bool strictValidate)
        {
            return ReplaceSpotOrder(new ParamsBuilder().NewClientOrderId(newClientOrderId).Quantity(quantity).Price(price).StopPrice(stopPrice).StrictValidate(strictValidate));
        }

        public virtual Order ReplaceSpotOrder(ParamsBuilder paramsBuilder)
        {
            paramsBuilder.CheckRequired(Arrays.AsList(ArgNames.CLIENT_ORDER_ID, ArgNames.NEW_CLIENT_ORDER_ID, ArgNames.QUANTITY));
            string clientOrderId = (string)paramsBuilder.Remove(ArgNames.CLIENT_ORDER_ID);
            string jsonResponse = httpClient.Patch(String.Format("spot/order/%s", clientOrderId), paramsBuilder.Build());
            return adapter.ObjectFromJson(jsonResponse, typeof(Order));
        }

        public virtual IList<Order> CancelAllSpotOrders()
        {
            string jsonResponse = httpClient.Delete("spot/order", null);
            return adapter.ListFromJson(jsonResponse, typeof(Order));
        }

        public virtual Order CancelSpotOrder(string clientOrderId)
        {
            string jsonResponse = httpClient.Delete(String.Format("spot/order/%s", clientOrderId), null);
            return adapter.ObjectFromJson(jsonResponse, typeof(Order));
        }

        public virtual IList<Commission> GetAllTradingCommissions()
        {
            string jsonResponse = httpClient.Get("spot/fee", null);
            return adapter.ListFromJson(jsonResponse, typeof(Commission));
        }

        public virtual IList<Commission> GetTradingCommissions()
        {
            return GetAllTradingCommissions();
        }

        public virtual Commission GetTradingCommission(string symbol)
        {
            string jsonResponse = httpClient.Get(String.Format("spot/fee/%s", symbol), null);
            Commission commission = adapter.ObjectFromJson(jsonResponse, typeof(Commission));
            commission.SetSymbol(symbol);
            return commission;
        }

        public virtual Commission GetTradingCommissionOfCurrency(string symbol)
        {
            return GetTradingCommission(symbol);
        }

        public virtual Commission GetTradingCommissionByCurrency(string symbol)
        {
            return GetTradingCommission(symbol);
        }

        // TRADING HISTORY
        public virtual IList<Order> GetSpotOrderHistory(string clientOrderId, string symbol, Sort sort, SortBy by, string from, string till, int limit, int offset)
        {
            return GetSpotOrderHistory(new ParamsBuilder().ClientOrderId(clientOrderId).Symbol(symbol).Sort(sort).By(by).From(from).Till(till).Limit(limit).Offset(offset));
        }

        public virtual IList<Order> GetSpotOrderHistory(ParamsBuilder paramsBuilder)
        {
            string jsonResponse = httpClient.Get("spot/history/order", paramsBuilder.Build());
            return adapter.ListFromJson(jsonResponse, typeof(Order));
        }

        public virtual IList<Trade> GetSpotTradesHistory(string orderId, string symbol, Sort sort, SortBy by, string from, string till, int limit, int offset)
        {
            return GetSpotTradesHistory(new ParamsBuilder().OrderId(orderId).Symbol(symbol).Sort(sort).By(by).From(from).Till(till).Limit(limit).Offset(offset));
        }

        public virtual IList<Trade> GetSpotTradesHistory(ParamsBuilder paramsBuilder)
        {
            string jsonResponse = httpClient.Get("spot/history/trade", paramsBuilder.Build());
            return adapter.ListFromJson(jsonResponse, typeof(Trade));
        }

        // WALLET MANAGEMENT
        public virtual IList<Balance> GetWalletBalances()
        {
            string jsonResponse = httpClient.Get("wallet/balance", null);
            return adapter.ListFromJson(jsonResponse, typeof(Balance));
        }

        public virtual Balance GetWalletBalanceByCurrency(string currency)
        {
            string jsonResponse = httpClient.Get(String.Format("wallet/balance/%s", currency), null);
            return adapter.ObjectFromJson(jsonResponse, typeof(Balance));
        }

        public virtual Balance GetWalletBalanceOfCurrency(string currency)
        {
            return GetWalletBalanceByCurrency(currency);
        }

        public virtual Balance GetWalletBalance(string currency)
        {
            return GetWalletBalanceByCurrency(currency);
        }

        public virtual IList<WhitelistedAddress> GetWhitelistedAddresses()
        {
            string jsonResponse = httpClient.Get("wallet/crypto/address/white-list", null);
            return adapter.ListFromJson(jsonResponse, typeof(WhitelistedAddress));
        }

        public virtual IList<Address> GetDepositCryptoAddresses(string currency, string networkCode)
        {
            Dictionary<string, string> params = new ParamsBuilder().Currency(currency).NetworkCode(networkCode).Build();
            string jsonResponse = httpClient.Get("wallet/crypto/address", @params);
            return adapter.ListFromJson(jsonResponse, typeof(Address));
        }

        public virtual Address CreateDepositCryptoAddress(string currency, string networkCode)
        {
            Dictionary<string, string> params = new ParamsBuilder().Currency(currency).NetworkCode(networkCode).Build();
            string jsonResponse = httpClient.Post("wallet/crypto/address", @params);
            return adapter.ObjectFromJson(jsonResponse, typeof(Address));
        }

        public virtual Address CreateDepositCryptoAddressOfCurrency(string currency, string networkCode)
        {
            return CreateDepositCryptoAddress(currency, networkCode);
        }

        public virtual Address CreateDepositCryptoAddressByCurrency(string currency, string networkCode)
        {
            return CreateDepositCryptoAddress(currency, networkCode);
        }

        public virtual IList<Address> GetLast10DepositCryptoAddresses(string currency, string networkCode)
        {
            Dictionary<string, string> params = new ParamsBuilder().Currency(currency).NetworkCode(networkCode).Build();
            string jsonResponse = httpClient.Get("wallet/crypto/address/recent-deposit", @params);
            return adapter.ListFromJson(jsonResponse, typeof(Address));
        }

        public virtual IList<Address> GetLast10WithdrawalCryptoAddresses(string currency, string networkCode)
        {
            Dictionary<string, string> params = new ParamsBuilder().Currency(currency).NetworkCode(networkCode).Build();
            string jsonResponse = httpClient.Get("wallet/crypto/address/recent-withdraw", @params);
            return adapter.ListFromJson(jsonResponse, typeof(Address));
        }

        public virtual string WithdrawCrypto(string currency, string amount, string address, string networkCode, string paymentId, bool includeFee, bool autoCommit, UseOffchain useOffchain, string publicComment)
        {
            return WithdrawCrypto(new ParamsBuilder().Currency(currency).Amount(amount).Address(address).NetworkCode(networkCode).PaymentId(paymentId).IncludeFee(includeFee).AutoCommit(autoCommit).UseOffchain(useOffchain).PublicComment(publicComment));
        }

        public virtual string WithdrawCrypto(ParamsBuilder paramsBuilder)
        {
            paramsBuilder.CheckRequired(Arrays.AsList(ArgNames.CURRENCY, ArgNames.AMOUNT, ArgNames.ADDRESS));
            WithdrawRequest request = new WithdrawRequest(paramsBuilder);
            string payload = adapter.ObjectToJson(request, typeof(WithdrawRequest));
            string jsonResponse = httpClient.Post("wallet/crypto/withdraw", payload);
            return adapter.ObjectFromJsonValue(jsonResponse, "id", typeof(string));
        }

        public virtual bool WithdrawCryptoCommit(string transactionId)
        {
            string jsonResponse = httpClient.Put(String.Format("wallet/crypto/withdraw/%s", transactionId), null);
            return adapter.ObjectFromJsonValue(jsonResponse, "result", typeof(bool));
        }

        public virtual bool WithdrawCryptoRollback(string transactionId)
        {
            string jsonResponse = httpClient.Delete(String.Format("wallet/crypto/withdraw/%s", transactionId), null);
            return adapter.ObjectFromJsonValue(jsonResponse, "result", typeof(bool));
        }

        public virtual string GetEstimateWithdrawalFee(string currency, string amount, string networkCode)
        {
            return GetEstimateWithdrawalFee(new ParamsBuilder().Currency(currency).NetworkCode(networkCode).Amount(amount));
        }

        public virtual string GetEstimateWithdrawalFee(ParamsBuilder paramsBuilder)
        {
            paramsBuilder.CheckRequired(Arrays.AsList(ArgNames.CURRENCY, ArgNames.AMOUNT));
            string jsonResponse = httpClient.Get("wallet/crypto/fee/estimate", paramsBuilder.Build());
            return adapter.ObjectFromJsonValue(jsonResponse, "fee", typeof(string));
        }

        public virtual IList<Fee> GetEstimateWithdrawalFees(IList<FeeRequest> feeRequests)
        {
            var payload = adapter.ListToJson(feeRequests, typeof(FeeRequest));
            string jsonResponse = httpClient.Post("wallet/crypto/fees/estimate", payload);
            return adapter.ListFromJson(jsonResponse, typeof(Fee));
        }

        public virtual IList<Fee> GetBulkEstimateWithdrawalFees(IList<FeeRequest> feeRequests)
        {
            var payload = adapter.ListToJson(feeRequests, typeof(FeeRequest));
            string jsonResponse = httpClient.Post("wallet/crypto/fee/estimate/bulk", payload);
            return adapter.ListFromJson(jsonResponse, typeof(Fee));
        }

        public virtual string GetWithdrawalFeesHash()
        {
            string jsonResponse = httpClient.Get("wallet/crypto/fee/withdraw/hash", null);
            return adapter.ObjectFromJsonValue(jsonResponse, "hash", typeof(string));
        }

        // @Override
        // public String getEstimateDepositFee(String currency, String amount, String
        // networkCode)
        // throws CryptomarketSDKException {
        // return getEstimateDepositFee(new ParamsBuilder()
        // .currency(currency)
        // .networkCode(networkCode)
        // .amount(amount));
        // }
        // @Override
        // public String getEstimateDepositFee(ParamsBuilder paramsBuilder) throws
        // CryptomarketSDKException {
        // paramsBuilder.checkRequired(Arrays.asList(
        // ArgNames.CURRENCY,
        // ArgNames.AMOUNT));
        // String jsonResponse = httpClient.get(
        // "wallet/crypto/fee/deposit/estimate",
        // paramsBuilder.build());
        // return adapter.objectFromJsonValue(jsonResponse, "fee", String.class);
        // }
        // @Override
        // public List<Fee> getBulkEstimateDepositFees(List<FeeRequest> feeRequests)
        // throws CryptomarketSDKException {
        // var payload = adapter.listToJson(feeRequests, FeeRequest.class);
        // String jsonResponse = httpClient.post(
        // "wallet/crypto/fee/deposit/estimate/bulk",
        // payload);
        // return adapter.listFromJson(jsonResponse, Fee.class);
        // }
        public virtual IList<string> ConvertBetweenCurrencies(string fromCurrency, string toCurrency, string amount)
        {
            return ConvertBetweenCurrencies(new ParamsBuilder().FromCurrency(fromCurrency).ToCurrency(toCurrency).Amount(amount));
        }

        public virtual IList<string> ConvertBetweenCurrencies(ParamsBuilder paramsBuilder)
        {
            paramsBuilder.CheckRequired(Arrays.AsList(ArgNames.FROM_CURRENCY, ArgNames.TO_CURRENCY, ArgNames.AMOUNT));
            string jsonResponse = httpClient.Post("wallet/convert", paramsBuilder.Build());
            return adapter.ListFromJsonValue(jsonResponse, "result", typeof(string));
        }

        public virtual bool CheckCryptoAddressBelongsToCurrentAccount(string address)
        {
            Dictionary<string, string> params = new ParamsBuilder().Address(address).Build();
            string jsonResponse = httpClient.Get("wallet/crypto/address/check-mine", @params);
            return adapter.ObjectFromJsonValue(jsonResponse, "result", typeof(bool));
        }

        public virtual string TransferBetweenWalletAndExchange(string currency, string amount, AccountType source, AccountType destination)
        {
            return TransferBetweenWalletAndExchange(new ParamsBuilder().Currency(currency).Amount(amount).Source(source).Destination(destination));
        }

        public virtual string TransferBetweenWalletAndExchange(ParamsBuilder paramsBuilder)
        {
            paramsBuilder.CheckRequired(Arrays.AsList(ArgNames.CURRENCY, ArgNames.AMOUNT, ArgNames.SOURCE, ArgNames.DESTINATION));
            string jsonResponse = httpClient.Post("wallet/transfer", paramsBuilder.Build());
            IList<string> response = adapter.ListFromJson(jsonResponse, typeof(string));
            if (response.Count != 1)
                throw new CryptomarketSDKException("Invalid response format: " + response.ToString());
            return response[0];
        }

        public virtual string TransferMoneyToAnotherUser(string currency, string amount, IdentifyBy by, string identifier, string publicComment)
        {
            return TransferMoneyToAnotherUser(new ParamsBuilder().Currency(currency).Amount(amount).IdentifyBy(by).PublicComment(publicComment).Identifier(identifier));
        }

        public virtual string TransferMoneyToAnotherUser(ParamsBuilder paramsBuilder)
        {
            paramsBuilder.CheckRequired(Arrays.AsList(ArgNames.CURRENCY, ArgNames.AMOUNT, ArgNames.BY, ArgNames.IDENTIFIER));
            string jsonResponse = httpClient.Post("wallet/internal/withdraw", paramsBuilder.Build());
            return adapter.ObjectFromJsonValue(jsonResponse, "result", typeof(string));
        }

        public virtual IList<Transaction> GetTransactionHistory(IList<string> transactionIds, IList<string> currencies, IList<string> networks, IList<TransactionType> types, IList<TransactionSubtype> subtypes, IList<TransactionStatus> statuses, Sort sort, OrderBy orderBy, string from, string till, int idFrom, int idTill, int limit, int offset, bool asGroupTransactions)
        {
            return GetTransactionHistory(new ParamsBuilder().TransactionIds(transactionIds).Currencies(currencies).Networks(networks).Types(types).Subtypes(subtypes).Statuses(statuses).Sort(sort).OrderBy(orderBy).From(from).Till(till).IdFrom(idFrom).IdTill(idTill).Limit(limit).Offset(offset).GroupTransactions(asGroupTransactions));
        }

        public virtual IList<Transaction> GetTransactionHistory(ParamsBuilder paramsBuilder)
        {
            string jsonResponse = httpClient.Get("wallet/transactions", paramsBuilder.Build());
            return adapter.ListFromJson(jsonResponse, typeof(Transaction));
        }

        public virtual Transaction GetTransaction(string transactionId)
        {
            string jsonResponse = httpClient.Get(String.Format("wallet/transactions/%s", transactionId), null);
            return adapter.ObjectFromJson(jsonResponse, typeof(Transaction));
        }

        public virtual bool CheckIfOffchainIsAvailable(string currency, string address, string paymentId)
        {
            return CheckIfOffchainIsAvailable(new ParamsBuilder().Currency(currency).Address(address).PaymentId(paymentId));
        }

        public virtual bool CheckIfOffchainIsAvailable(ParamsBuilder paramsBuilder)
        {
            paramsBuilder.CheckRequired(Arrays.AsList(ArgNames.CURRENCY, ArgNames.ADDRESS));
            string jsonResponse = httpClient.Post("wallet/crypto/check-offchain-available", paramsBuilder.Build());
            return adapter.ObjectFromJsonValue(jsonResponse, "result", typeof(bool));
        }

        public virtual IList<AmountLock> GetAmountLocks(string currency, bool active, int limit, int offset)
        {
            return GetAmountLocks(new ParamsBuilder().Currency(currency).Active(active).Limit(limit).Offset(offset));
        }

        public virtual IList<AmountLock> GetAmountLocks(ParamsBuilder paramsBuilder)
        {
            string jsonResponse = httpClient.Get("wallet/airdrops", paramsBuilder.Build());
            return adapter.ListFromJson(jsonResponse, typeof(AmountLock));
        }

        public virtual IList<SubAccount> GetSubAccountList()
        {
            string jsonResponse = httpClient.Get("sub-account", null);
            return adapter.ListFromJson(jsonResponse, typeof(SubAccount));
        }

        public virtual SubAccount GetSubAccount(string subAccountId)
        {
            Dictionary<string, string> params = new ParamsBuilder().SubAccountId(subAccountId).Build();
            string jsonResponse = httpClient.Get("sub-account", @params);
            IList<SubAccount> subAccounts = adapter.ListFromJson(jsonResponse, typeof(SubAccount));
            if (subAccounts.Count < 1)
            {
                throw new CryptomarketSDKException("SubAccount not found");
            }

            if (subAccounts.Count > 1)
            {
                throw new CryptomarketSDKException("Too many sub-accounts");
            }

            return subAccounts[0];
        }

        public virtual bool FreezeSubAccount(IList<string> subAccountIds)
        {
            ParamsBuilder params = new ParamsBuilder().SubAccountIds(subAccountIds);
            string jsonResponse = httpClient.Get("sub-account/freeze", @params.Build());
            return adapter.ObjectFromJsonValue(jsonResponse, "result", typeof(bool));
        }

        public virtual bool ActivateSubAccount(IList<string> subAccountIds)
        {
            ParamsBuilder params = new ParamsBuilder().SubAccountIds(subAccountIds);
            string jsonResponse = httpClient.Get("sub-account/activate", @params.Build());
            return adapter.ObjectFromJsonValue(jsonResponse, "result", typeof(bool));
        }

        public virtual string TransferFunds(string subAccountId, string amount, string currency, SubAccountTransferType transferType)
        {
            ParamsBuilder params = new ParamsBuilder().SubAccountId(subAccountId).Amount(amount).Currency(currency).TransferType(transferType);
            string jsonResponse = httpClient.Get("sub-account/transfer", @params.Build());
            return adapter.ObjectFromJsonValue(jsonResponse, "result", typeof(string));
        }

        public virtual string TransferToSuperAccount(string amount, string currency)
        {
            ParamsBuilder params = new ParamsBuilder().Amount(amount).Currency(currency);
            string jsonResponse = httpClient.Get("sub-account/transfer/sub-to-super", @params.Build());
            return adapter.ObjectFromJsonValue(jsonResponse, "result", typeof(string));
        }

        public virtual string TransferToAnotherSubAccount(string subAccountId, string amount, string currency)
        {
            ParamsBuilder params = new ParamsBuilder().SubAccountId(subAccountId).Amount(amount).Currency(currency);
            string jsonResponse = httpClient.Get("sub-account/transfer/sub-to-sub", @params.Build());
            return adapter.ObjectFromJsonValue(jsonResponse, "result", typeof(string));
        }

        public virtual IList<SubAccountSettings> GetACLSettings(IList<string> subAccountIds)
        {
            ParamsBuilder params = new ParamsBuilder().SubAccountIds(subAccountIds);
            string jsonResponse = httpClient.Get("sub-account/acl", @params.Build());
            return adapter.ListFromJson(jsonResponse, typeof(SubAccountSettings));
        }

        public virtual IList<SubAccountSettings> ChangeACLSettings(IList<string> subAccountIds, SubAccountSettings settings)
        {
            ParamsBuilder params = new ParamsBuilder().SubAccountIds(subAccountIds).DepositAddressGenerationEnabled(settings.IsDepositAddressGenerationEnabled()).WithdrawEnabled(settings.IsWithdrawEnabled()).CreatedAt(settings.GetCreatedAt()).Description(settings.GetDescription()).UpdatedAt(settings.GetUpdatedAt());
            string jsonResponse = httpClient.Get("sub-account/acl", @params.Build());
            return adapter.ListFromJson(jsonResponse, typeof(SubAccountSettings));
        }

        public virtual SubAccountBalances GetSubAccountBalance(string subAccountId)
        {
            string jsonResponse = httpClient.Get(String.Format("sub-account/balance/%s", subAccountId), null);
            return adapter.ObjectFromJson(jsonResponse, typeof(SubAccountBalances));
        }

        public virtual string GetSubAccountCryptoAddress(string subAccountId, string currency, string networkCode)
        {
            ParamsBuilder params = new ParamsBuilder().NetworkCode(networkCode);
            string jsonResponse = httpClient.Get(String.Format("sub-account/address/%s/%s", subAccountId, currency), @params.Build());
             class  Address { string  address ;  }
            Address address = adapter.ObjectFromJsonValue(jsonResponse, "result", typeof(Address));
            return address.address;
        }

        public virtual void Dispose()
        {
            httpClient.Dispose();
        }
    }
}