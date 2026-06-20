using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Models;
using CryptoMarket.SDK.Params;

namespace CryptoMarket.SDK.Websocket
{
    public interface ICryptoMarketWSWalletClient : ICryptoMarketWS
    {
        void SubscribeToTransactions(Action<Transaction, NotificationType> notificationAction, Action<bool, CryptoMarketSDKException> resultAction);
        void UnsubscribeToTransactions(Action<bool, CryptoMarketSDKException> resultAction);
        void SubscribeToWalletBalances(Action<IList<Balance>, NotificationType> notificationAction, Action<bool, CryptoMarketSDKException> resultAction);
        void UnsubscribeToWalletBalances(Action<bool, CryptoMarketSDKException> resultAction);
        void GetWalletBalances(Action<IList<Balance>, CryptoMarketSDKException> resultAction);
        void GetWalletBalanceByCurrency(string currency, Action<Balance, CryptoMarketSDKException> resultAction);
        void GetWalletBalanceOfCurrency(string currency, Action<Balance, CryptoMarketSDKException> resultAction);
        void GetWalletBalance(string currency, Action<Balance, CryptoMarketSDKException> resultAction);
        void GetTransactions(Action<IList<Transaction>, CryptoMarketSDKException> resultAction, IList<TransactionType> types, IList<TransactionSubtype> subtypes, IList<TransactionStatus> statuses, IList<string> currencies, IList<string> transactionIds, Sort sort, OrderBy orderBy, string from, string till, int idFrom, int idTill, int limit, int offset, bool groupTransactions);
        void GetTransactions(Action<IList<Transaction>, CryptoMarketSDKException> resultAction, ParamsBuilder paramsBuilder);
    }
}