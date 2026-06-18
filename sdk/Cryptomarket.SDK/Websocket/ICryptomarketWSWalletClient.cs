using Cryptomarket.SDK.Exceptions;
using Cryptomarket.SDK.Models;
using Cryptomarket.SDK.Params;

namespace Cryptomarket.SDK.Websocket
{
    public interface ICryptomarketWSWalletClient : ICryptomarketWS
    {
        void SubscribeToTransactions(Action<Transaction, NotificationType> notificationAction, Action<bool, CryptomarketSDKException> resultAction);
        void UnsubscribeToTransactions(Action<bool, CryptomarketSDKException> resultAction);
        void SubscribeToWalletBalances(Action<IList<Balance>, NotificationType> notificationAction, Action<bool, CryptomarketSDKException> resultAction);
        void UnsubscribeToWalletBalances(Action<bool, CryptomarketSDKException> resultAction);
        void GetWalletBalances(Action<IList<Balance>, CryptomarketSDKException> resultAction);
        void GetWalletBalanceByCurrency(string currency, Action<Balance, CryptomarketSDKException> resultAction);
        void GetWalletBalanceOfCurrency(string currency, Action<Balance, CryptomarketSDKException> resultAction);
        void GetWalletBalance(string currency, Action<Balance, CryptomarketSDKException> resultAction);
        void GetTransactions(Action<IList<Transaction>, CryptomarketSDKException> resultAction, IList<TransactionType> types, IList<TransactionSubtype> subtypes, IList<TransactionStatus> statuses, IList<string> currencies, IList<string> transactionIds, Sort sort, OrderBy orderBy, string from, string till, int idFrom, int idTill, int limit, int offset, bool groupTransactions);
        void GetTransactions(Action<IList<Transaction>, CryptomarketSDKException> resultAction, ParamsBuilder paramsBuilder);
    }
}