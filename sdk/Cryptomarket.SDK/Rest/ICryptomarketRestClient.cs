using CryptoMarket.SDK.Models;
using CryptoMarket.SDK.Params;

namespace CryptoMarket.SDK.Rest
{
    /// <summary>
    /// Rest Client Interface for cryptomarket API V3.
    /// </summary>
    public interface ICryptoMarketRestClient : IDisposable
    {
        void ChangeCredentials(string apiKey, string apiSecret);
        void ChangeWindow(int window);
        /// PUBLIC CALLS///
        Currency GetCurrency(string currency);
        Dictionary<string, Currency> GetCurrencies(IList<string> currencies, string preferredNetwork);
        Symbol GetSymbol(string symbol);
        Dictionary<string, Symbol> GetSymbols(IList<string> symbols);
        
        Dictionary<string, Ticker> GetTickers(IList<string> symbols);
        
        Ticker GetTicker(string symbol);
        Ticker GetTickerBySymbol(string symbol);
        Ticker GetTickerOfSymbol(string symbol);
        Dictionary<string, Price> GetPrices(string to, string from);
        Dictionary<string, Price> GetPrices(ParamsBuilder paramsBuilder);
        Dictionary<string, PriceHistory> GetPricesHistory(string to, string from, string until, string since, int? limit, Period? period, Sort? sort);
        Dictionary<string, PriceHistory> GetPricesHistory(ParamsBuilder paramsBuilder);
        Dictionary<string, TickerPrice> GetTickerLastPrices(IList<string> symbols);
        TickerPrice GetTickerLastPriceBySymbol(string symbol);
        TickerPrice GetTickerLastPriceOfSymbol(string symbol);
        TickerPrice GetTickerLastPrice(string symbol);
        Dictionary<string, IList<PublicTrade>> GetTrades(IList<string> symbols, Sort? sort, SortBy? by, string from, string till, string limit);
        Dictionary<string, IList<PublicTrade>> GetTrades(ParamsBuilder paramsBuilder);
        IList<PublicTrade> GetTradesBySymbol(string symbol, Sort? sort, SortBy? by, string from, string till, int? limit, int? offset);
        IList<PublicTrade> GetTradesBySymbol(ParamsBuilder paramsBuilder);
        IList<PublicTrade> GetTradesOfSymbol(ParamsBuilder paramsBuilder);
        Dictionary<string, OrderBook> GetOrderBooks(IList<string> symbols, int depth);
        Dictionary<string, OrderBook> GetOrderBooks(ParamsBuilder paramsBuilder);
        OrderBook GetOrderBookBySymbol(string symbol, int depth);
        OrderBook GetOrderBookBySymbol(ParamsBuilder paramsBuilder);
        OrderBook GetOrderBookOfSymbol(ParamsBuilder paramsBuilder);
        OrderBook GetOrderBook(ParamsBuilder paramsBuilder);
        OrderBook GetOrderBookVolumeBySymbol(string symbol, int volume);
        OrderBook GetOrderBookVolumeBySymbol(ParamsBuilder paramsBuilder);
        OrderBook GetOrderBookVolumeOfSymbol(ParamsBuilder paramsBuilder);
        OrderBook GetOrderBookVolume(ParamsBuilder paramsBuilder);
        Dictionary<string, IList<Candle>> GetCandles(IList<string> symbols, Period? period, Sort? sort, string from, string till, int? limit);
        Dictionary<string, IList<Candle>> GetCandles(ParamsBuilder paramsBuilder);
        IList<Candle> GetCandlesBySymbol(string symbol, Period? period, Sort? sort, string from, string till, int? limit, int? offset);
        IList<Candle> GetCandlesBySymbol(ParamsBuilder paramsBuilder);
        IList<Candle> GetCandlesOfSymbol(ParamsBuilder paramsBuilder);
        ConvertedCandles GetConvertedCandles(string targetCurrency, IList<string> symbols, Period? period, Sort? sort, string from, string till, int? limit);
        ConvertedCandles GetConvertedCandles(ParamsBuilder paramsBuilder);
        ConvertedCandlesBySymbol GetConvertedCandlesBySymbol(string targetCurrency, string symbol, Period? period, Sort? sort, string from, string till, int? limit, int? offset);
        ConvertedCandlesBySymbol GetConvertedCandlesBySymbol(ParamsBuilder paramsBuilder);
        ConvertedCandlesBySymbol GetConvertedCandlesOfSymbol(ParamsBuilder paramsBuilder);
        /// AUTHENTICATED CALLS ///
        // SPOT TRADING
        IList<Balance> GetSpotTradingBalances();
        Balance GetSpotTradingBalanceByCurrency(string currency);
        Balance GetSpotTradingBalanceOfCurrency(string currency);
        Balance GetSpotTradingBalance(string currency);
        IList<Order> GetAllActiveSpotOrders(string symbol);
        Order GetActiveSpotOrder(string clientOrderId);
        Order CreateSpotOrder(string symbol, Side side, string quantity, string clientOrderId, OrderType orderType, string price, string stopPrice, TimeInForce timeInForce, string expireTime, bool strictValidate, bool postOnly, string takeRate, string makeRate);
        Order CreateSpotOrder(ParamsBuilder paramsBuilder);
        Order CreateSpotOrder(OrderBuilder orderBuilder);
        IList<Order> CreateSpotOrderList(ContingencyType contingencyType, IList<OrderBuilder> orders, string orderListId);
        Order ReplaceSpotOrder(string clientOrderId, string newClientOrderId, string quantity, string price, string stopPrice, bool strictValidate);
        Order ReplaceSpotOrder(ParamsBuilder paramsBuilder);
        IList<Order> CancelAllSpotOrders();
        Order CancelSpotOrder(string clientOrderId);
        IList<Commission> GetAllTradingCommissions();
        IList<Commission> GetTradingCommissions();
        Commission GetTradingCommission(string symbol);
        Commission GetTradingCommissionOfCurrency(string symbol);
        Commission GetTradingCommissionByCurrency(string symbol);
        // TRADING HISTORY
        IList<Order> GetSpotOrderHistory(string clientOrderId, string symbol, Sort? sort, SortBy? by, string from, string till, int? limit, int? offset);
        IList<Order> GetSpotOrderHistory(ParamsBuilder paramsBuilder);
        IList<Trade> GetSpotTradesHistory(string orderId, string symbol, Sort? sort, SortBy? by, string from, string till, int? limit, int? offset);
        IList<Trade> GetSpotTradesHistory(ParamsBuilder paramsBuilder);
        // WALLET MANAGEMENT
        IList<Balance> GetWalletBalances();
        Balance GetWalletBalanceByCurrency(string currency);
        Balance GetWalletBalanceOfCurrency(string currency);
        Balance GetWalletBalance(string currency);
        IList<WhitelistedAddress> GetWhitelistedAddresses();
        IList<Address> GetDepositCryptoAddresses(string currency, string networkCode);
        Address CreateDepositCryptoAddress(string currency, string networkCode);
        Address CreateDepositCryptoAddressOfCurrency(string currency, string networkCode);
        Address CreateDepositCryptoAddressByCurrency(string currency, string networkCode);
        IList<Address> GetLast10DepositCryptoAddresses(string currency, string networkCode);
        IList<Address> GetLast10WithdrawalCryptoAddresses(string currency, string networkCode);
        string WithdrawCrypto(string currency, string amount, string address, string networkCode, string paymentId, bool includeFee, bool autoCommit, UseOffchain useOffchain, string publicComment);
        string WithdrawCrypto(ParamsBuilder paramsBuilder);
        bool WithdrawCryptoCommit(string transactionId);
        bool WithdrawCryptoRollback(string transactionId);
        string GetEstimateWithdrawalFee(string currency, string amount, string networkCode);
        string GetEstimateWithdrawalFee(ParamsBuilder paramsBuilder);
        IList<Fee> GetEstimateWithdrawalFees(IList<FeeRequest> feeRequests);
        IList<Fee> GetBulkEstimateWithdrawalFees(IList<FeeRequest> feeRequests);
        string GetWithdrawalFeesHash();
        // public String getEstimateDepositFee(String currency, String amount, @Nullable
        // String networkCode) throws CryptoMarketSDKException;
        // public String getEstimateDepositFee(ParamsBuilder paramsBuilder) throws
        // CryptoMarketSDKException;
        // public List<Fee> getBulkEstimateDepositFees(List<FeeRequest> feeRequests)
        // throws CryptoMarketSDKException;
        IList<string> ConvertBetweenCurrencies(string fromCurrency, string toCurrency, string amount);
        IList<string> ConvertBetweenCurrencies(ParamsBuilder paramsBuilder);
        bool CheckCryptoAddressBelongsToCurrentAccount(string address);
        string TransferBetweenWalletAndExchange(string currency, string amount, AccountType source, AccountType destination);
        string TransferBetweenWalletAndExchange(ParamsBuilder paramsBuilder);
        string TransferMoneyToAnotherUser(string currency, string amount, IdentifyBy by, string identifier, string publicComment);
        string TransferMoneyToAnotherUser(ParamsBuilder paramsBuilder);
        IList<Transaction> GetTransactionHistory(IList<string> transactionIds, IList<string> currencies, IList<string> networks, IList<TransactionType> types, IList<TransactionSubtype> subtypes, IList<TransactionStatus> statuses, Sort? sort, OrderBy orderBy, string from, string till, int idFrom, int idTill, int? limit, int? offset, bool groupTransactions);
        IList<Transaction> GetTransactionHistory(ParamsBuilder paramsBuilder);
        Transaction GetTransaction(string transactionId);
        bool CheckIfOffchainIsAvailable(string currency, string address, string paymentId);
        bool CheckIfOffchainIsAvailable(ParamsBuilder paramsBuilder);
        IList<AmountLock> GetAmountLocks(string currency, bool active, int? limit, int? offset);
        IList<AmountLock> GetAmountLocks(ParamsBuilder paramsBuilder);
        // SUB ACOUNTS
        IList<SubAccount> GetSubAccountList();
        SubAccount GetSubAccount(string subAccountId);
        bool FreezeSubAccount(IList<string> subAccountIds);
        bool ActivateSubAccount(IList<string> subAccountIds);
        string TransferFunds(string subAccountId, string amount, string currency, SubAccountTransferType transferType);
        string TransferToSuperAccount(string amount, string currency);
        string TransferToAnotherSubAccount(string subAccountId, string amount, string currency);
        IList<SubAccountSettings> GetACLSettings(IList<string> subAccountIds);
        IList<SubAccountSettings> ChangeACLSettings(IList<string> subAccountIds, SubAccountSettings settings);
        SubAccountBalances GetSubAccountBalance(string subAccountId);
        string GetSubAccountCryptoAddress(string subAccountId, string currency, string networkCode);
    }
}