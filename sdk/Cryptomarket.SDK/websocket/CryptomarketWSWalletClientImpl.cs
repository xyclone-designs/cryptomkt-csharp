using Cryptomarket.SDK.Exceptions;
using Cryptomarket.SDK.Models;
using Cryptomarket.SDK.Params;
using Cryptomarket.SDK.Websocket.Interceptors;

using Org.BouncyCastle.Utilities;

namespace Cryptomarket.SDK.Websocket
{
    public class CryptomarketWSWalletClientImpl : AuthClient, ICryptomarketWSWalletClient
    {
        public CryptomarketWSWalletClientImpl(string apiKey, string apiSecret) : this(apiKey, apiSecret, 0) { }
        public CryptomarketWSWalletClientImpl(string apiKey, string apiSecret, int window) : base("wss://api.exchange.cryptomkt.com/api/3/ws/wallet", apiKey, apiSecret, window)
        {
            Dictionary<string, string> subsKeys = this.GetSubscritpionKeys();

            // transactions
            subsKeys.Add("subscribe_transactions", "transactions");
            subsKeys.Add("unsubscribe_transactions", "transactions");
            subsKeys.Add("transaction_update", "transactions");

            // balance
            subsKeys.Add("subscribe_wallet_balances", "balance");
            subsKeys.Add("unsubscribe_wallet_balances", "balance");
            subsKeys.Add("wallet_balances", "balance");
            subsKeys.Add("wallet_balance_update", "balance");
        }

        public void GetWalletBalances(Action<IList<Balance>, CryptomarketSDKException> resultAction)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseList(resultAction);
            SendById("wallet_balances", null, interceptor);
        }
        public void GetWalletBalance(string currency, Action<Balance, CryptomarketSDKException> resultAction)
        {
            GetWalletBalanceByCurrency(currency, resultAction);
        }
        public void GetWalletBalanceByCurrency(string currency, Action<Balance, CryptomarketSDKException> resultAction)
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder().Currency(currency);
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            SendById("wallet_balance", paramsBuilder.BuildObjectMap(), interceptor);
        }
        public void GetWalletBalanceOfCurrency(string currency, Action<Balance, CryptomarketSDKException> resultAction)
        {
            GetWalletBalanceByCurrency(currency, resultAction);
        }
        public void GetTransactions(Action<IList<Transaction>, CryptomarketSDKException> resultAction, IList<TransactionType> types, IList<TransactionSubtype> subtypes, IList<TransactionStatus> statuses, IList<string> currencies, IList<string> transactionIds, Sort sort, OrderBy orderBy, string from, string till, int idFrom, int idTill, int limit, int offset, bool groupTransactions)
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
        public void GetTransactions(Action<IList<Transaction>, CryptomarketSDKException> resultAction, ParamsBuilder paramsBuilder)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseList(resultAction);

            SendById("get_transactions", paramsBuilder.BuildObjectMap(), interceptor);
        }
        public void UnsubscribeToTransactions(Action<bool, CryptomarketSDKException> resultAction)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            SendUnsubscription("unsubscribe_transactions", null, interceptor);
        }
        public void UnsubscribeToWalletBalances(Action<bool, CryptomarketSDKException> resultAction)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            SendUnsubscription("unsubscribe_wallet_balances", null, interceptor);
        }
        public void SubscribeToTransactions(Action<Transaction, NotificationType> notificationAction, Action<bool, CryptomarketSDKException> resultAction)
        {
            Interceptor interceptor = new AnonymousInterceptor(this);
            Interceptor resultInterceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            SendSubscription("subscribe_transactions", null, interceptor, resultInterceptor);
        }
        public void SubscribeToWalletBalances(Action<IList<Balance>, NotificationType> notificationAction, Action<bool, CryptomarketSDKException> resultAction)
        {
            Interceptor interceptor = new AnonymousInterceptor1(this);
            Interceptor resultInterceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            SendSubscription("subscribe_wallet_balances", null, interceptor, resultInterceptor);
        }

        private sealed class AnonymousInterceptor : Interceptor
        {
            public AnonymousInterceptor(CryptomarketWSWalletClientImpl parent)
            {
                this.parent = parent;
            }

            private readonly CryptomarketWSWalletClientImpl parent;
            public void MakeCall(WSJsonResponse response)
            {
                try
                {
                    Transaction transaction = adapter.ObjectFromValue(response.GetParams(), typeof(Transaction));
                    notificationAction.Accept(transaction, NotificationType.UPDATE);
                }
                catch (ParseException e)
                {
                    notificationAction.Accept(null, NotificationType.PARSE_ERROR);
                }
            }
        }
        private sealed class AnonymousInterceptor1 : Interceptor
        {
            public AnonymousInterceptor1(CryptomarketWSWalletClientImpl parent)
            {
                this.parent = parent;
            }

            private readonly CryptomarketWSWalletClientImpl parent;
            public void MakeCall(WSJsonResponse response)
            {
                try
                {
                    if (response.GetMethod().Equals("wallet_balances"))
                    {
                        IList<Balance> balances = adapter.ListFromValue(response.GetParams(), typeof(Balance));
                        notificationAction.Accept(balances, NotificationType.SNAPSHOT);
                    }
                    else if (response.GetMethod().Equals("wallet_balance_update"))
                    {
                        Balance balance = adapter.ObjectFromValue(response.GetParams(), typeof(Balance));
                        notificationAction.Accept(Arrays.AsList(balance), NotificationType.UPDATE);
                    }
                }
                catch (ParseException e)
                {
                    notificationAction.Accept(null, NotificationType.PARSE_ERROR);
                }
            }
        }
    }
}