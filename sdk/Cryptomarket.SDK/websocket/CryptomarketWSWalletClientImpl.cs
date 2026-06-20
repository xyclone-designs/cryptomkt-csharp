using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Models;
using CryptoMarket.SDK.Params;
using CryptoMarket.SDK.Websocket.Interceptors;

using System.Text.Json;

namespace CryptoMarket.SDK.Websocket
{
    public class CryptoMarketWSWalletClientImpl : AuthClient, ICryptoMarketWSWalletClient
    {
        public CryptoMarketWSWalletClientImpl(string apiKey, string apiSecret) : this(apiKey, apiSecret, 0) { }
        public CryptoMarketWSWalletClientImpl(string apiKey, string apiSecret, int window) : base("wss://api.exchange.cryptomkt.com/api/3/ws/wallet", apiKey, apiSecret, window)
        {
            // transactions
            SubscritpionKeys.Add("subscribe_transactions", "transactions");
            SubscritpionKeys.Add("unsubscribe_transactions", "transactions");
            SubscritpionKeys.Add("transaction_update", "transactions");

            // balance
            SubscritpionKeys.Add("subscribe_wallet_balances", "balance");
            SubscritpionKeys.Add("unsubscribe_wallet_balances", "balance");
            SubscritpionKeys.Add("wallet_balances", "balance");
            SubscritpionKeys.Add("wallet_balance_update", "balance");
        }

        public void GetWalletBalances(Action<IList<Balance>, CryptoMarketSDKException> resultAction)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseList(resultAction);
            SendById("wallet_balances", null, interceptor);
        }
        public void GetWalletBalance(string currency, Action<Balance, CryptoMarketSDKException> resultAction)
        {
            GetWalletBalanceByCurrency(currency, resultAction);
        }
        public void GetWalletBalanceByCurrency(string currency, Action<Balance, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder().Currency(currency);
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            SendById("wallet_balance", paramsBuilder.BuildObjectMap(), interceptor);
        }
        public void GetWalletBalanceOfCurrency(string currency, Action<Balance, CryptoMarketSDKException> resultAction)
        {
            GetWalletBalanceByCurrency(currency, resultAction);
        }
        public void GetTransactions(Action<IList<Transaction>, CryptoMarketSDKException> resultAction, IList<TransactionType> types, IList<TransactionSubtype> subtypes, IList<TransactionStatus> statuses, IList<string> currencies, IList<string> transactionIds, Sort sort, OrderBy orderBy, string from, string till, int idFrom, int idTill, int limit, int offset, bool groupTransactions)
        {
            GetTransactions(resultAction, new ParamsBuilder()
                .Types(types)
                .Subtypes(subtypes)
                .Statuses(statuses)
                .Currencies(currencies)
                .TransactionIds(transactionIds)
                .Sort(sort)
                .OrderBy(orderBy)
                .From(from)
                .Till(till)
                .IdFrom(idFrom)
                .IdTill(idTill)
                .Limit(limit)
                .Offset(offset)
                .GroupTransactions(groupTransactions));
        }
        public void GetTransactions(Action<IList<Transaction>, CryptoMarketSDKException> resultAction, ParamsBuilder paramsBuilder)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseList(resultAction);

            SendById("get_transactions", paramsBuilder.BuildObjectMap(), interceptor);
        }
        public void UnsubscribeToTransactions(Action<bool, CryptoMarketSDKException> resultAction)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            
            SendUnsubscription("unsubscribe_transactions", null, interceptor);
        }
        public void UnsubscribeToWalletBalances(Action<bool, CryptoMarketSDKException> resultAction)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            
            SendUnsubscription("unsubscribe_wallet_balances", null, interceptor);
        }
        public void SubscribeToTransactions(Action<Transaction, NotificationType> notificationAction, Action<bool, CryptoMarketSDKException> resultAction)
        {
            Interceptor interceptor = new AnonymousInterceptor(notificationAction);
            Interceptor resultInterceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            
            SendSubscription("subscribe_transactions", null, interceptor, resultInterceptor);
        }
        public void SubscribeToWalletBalances(Action<IList<Balance>, NotificationType> notificationAction, Action<bool, CryptoMarketSDKException> resultAction)
        {
            Interceptor interceptor = new AnonymousInterceptor1(notificationAction);
            Interceptor resultInterceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            
            SendSubscription("subscribe_wallet_balances", null, interceptor, resultInterceptor);
        }

        private sealed class AnonymousInterceptor(Action<Transaction?, NotificationType> notificationAction) : Interceptor
        {
            private readonly Action<Transaction?, NotificationType> NotificationAction = notificationAction;

            public override void MakeCall(WSJsonResponse response)
            {
                try
                {
                    Transaction transaction = response.Parameters as Transaction;
                    NotificationAction.Invoke(transaction, NotificationType.UPDATE);
                }
                catch (ParseException)
                {
                    NotificationAction.Invoke(null, NotificationType.PARSE_ERROR);
                }
            }
        }
        private sealed class AnonymousInterceptor1(Action<IList<Balance>?, NotificationType> notificationAction) : Interceptor
        {
            private readonly Action<IList<Balance>?, NotificationType> NotificationAction = notificationAction;

            public override void MakeCall(WSJsonResponse response)
            {
                try
                {
                    if (response.Method == "wallet_balances")
                    {
                        IList<Balance> balances = response.Parameters as IList<Balance>;
                        // IList<Balance> balances = JsonSerializer.Serialize<IList<Balance>>(response.Parameters);
                        NotificationAction.Invoke(balances, NotificationType.SNAPSHOT);
                    }
                    else if (response.Method == "wallet_balance_update")
                    {
                        Balance balance = response.Parameters as Balance;
                        //Balance balance = JsonSerializer.Deserialize<Balance>(response.Parameters);
                        NotificationAction.Invoke([balance], NotificationType.UPDATE);
                    }
                }
                catch (ParseException)
                {
                    NotificationAction.Invoke(null, NotificationType.PARSE_ERROR);
                }
            }
        }
    }
}