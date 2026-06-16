using Java.Io;
using Java.Util;
using Java.Util.Function;
using Com.Cryptomarket.Params;
using Cryptomarket.SDK.Exceptions;
using Cryptomarket.SDK.Models;
using Cryptomarket.SDK.Websocket.Interceptor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.SDK.Websocket.AccountType;
using static Cryptomarket.SDK.Websocket.ContingencyType;
using static Cryptomarket.SDK.Websocket.Depth;
using static Cryptomarket.SDK.Websocket.IdentifyBy;
using static Cryptomarket.SDK.Websocket.NotificationType;
using static Cryptomarket.SDK.Websocket.OBSpeed;
using static Cryptomarket.SDK.Websocket.OrderBy;
using static Cryptomarket.SDK.Websocket.OrderStatus;
using static Cryptomarket.SDK.Websocket.OrderType;
using static Cryptomarket.SDK.Websocket.Period;
using static Cryptomarket.SDK.Websocket.PriceSpeed;
using static Cryptomarket.SDK.Websocket.ReportType;
using static Cryptomarket.SDK.Websocket.Side;
using static Cryptomarket.SDK.Websocket.Sort;
using static Cryptomarket.SDK.Websocket.SortBy;
using static Cryptomarket.SDK.Websocket.SubAccountStatus;
using static Cryptomarket.SDK.Websocket.SubAccountTransferType;
using static Cryptomarket.SDK.Websocket.SubscriptionMode;
using static Cryptomarket.SDK.Websocket.TickerSpeed;
using static Cryptomarket.SDK.Websocket.TimeInForce;
using static Cryptomarket.SDK.Websocket.TransactionStatus;
using static Cryptomarket.SDK.Websocket.TransactionSubtype;
using static Cryptomarket.SDK.Websocket.TransactionType;
using static Cryptomarket.SDK.Websocket.UseOffchain;
using static Cryptomarket.SDK.Websocket.HttpMethod;

namespace Cryptomarket.SDK.Websocket
{
    public class CryptomarketWSWalletClientImpl : AuthClient, CryptomarketWSWalletClient
    {
        public CryptomarketWSWalletClientImpl(string apiKey, string apiSecret, int window) : base("wss://api.exchange.cryptomkt.com/api/3/ws/wallet", apiKey, apiSecret, window)
        {
            Dictionary<string, string> subsKeys = this.GetSubscritpionKeys();

            // transactions
            subsKeys.Put("subscribe_transactions", "transactions");
            subsKeys.Put("unsubscribe_transactions", "transactions");
            subsKeys.Put("transaction_update", "transactions");

            // balance
            subsKeys.Put("subscribe_wallet_balances", "balance");
            subsKeys.Put("unsubscribe_wallet_balances", "balance");
            subsKeys.Put("wallet_balances", "balance");
            subsKeys.Put("wallet_balance_update", "balance");
        }

        public CryptomarketWSWalletClientImpl(string apiKey, string apiSecret) : this(apiKey, apiSecret, 0)
        {
        }

        public override void SubscribeToTransactions(BiConsumer<Transaction, NotificationType> notificationBiConsumer, BiConsumer<bool, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor interceptor = new AnonymousInterceptor(this);
            Interceptor resultInterceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseObject(resultBiConsumer, typeof(bool));
            SendSubscription("subscribe_transactions", null, interceptor, resultInterceptor);
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
                    notificationBiConsumer.Accept(transaction, NotificationType.UPDATE);
                }
                catch (ParseException e)
                {
                    notificationBiConsumer.Accept(null, NotificationType.PARSE_ERROR);
                }
            }
        }

        public override void UnsubscribeToTransactions(BiConsumer<bool, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseObject(resultBiConsumer, typeof(bool));
            SendUnsubscription("unsubscribe_transactions", null, interceptor);
        }

        public override void SubscribeToWalletBalances(BiConsumer<IList<Balance>, NotificationType> notificationBiConsumer, BiConsumer<bool, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor interceptor = new AnonymousInterceptor1(this);
            Interceptor resultInterceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseObject(resultBiConsumer, typeof(bool));
            SendSubscription("subscribe_wallet_balances", null, interceptor, resultInterceptor);
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
                        notificationBiConsumer.Accept(balances, NotificationType.SNAPSHOT);
                    }
                    else if (response.GetMethod().Equals("wallet_balance_update"))
                    {
                        Balance balance = adapter.ObjectFromValue(response.GetParams(), typeof(Balance));
                        notificationBiConsumer.Accept(Arrays.AsList(balance), NotificationType.UPDATE);
                    }
                }
                catch (ParseException e)
                {
                    notificationBiConsumer.Accept(null, NotificationType.PARSE_ERROR);
                }
            }
        }

        public override void UnsubscribeToWalletBalances(BiConsumer<bool, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseObject(resultBiConsumer, typeof(bool));
            SendUnsubscription("unsubscribe_wallet_balances", null, interceptor);
        }

        public override void GetWalletBalances(BiConsumer<IList<Balance>, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseList(resultBiConsumer, typeof(Balance));
            SendById("wallet_balances", null, interceptor);
        }

        public override void GetWalletBalanceByCurrency(string currency, BiConsumer<Balance, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder().Currency(currency);
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseObject(resultBiConsumer, typeof(Balance));
            SendById("wallet_balance", paramsBuilder.BuildObjectMap(), interceptor);
        }

        public override void GetWalletBalanceOfCurrency(string currency, BiConsumer<Balance, CryptomarketSDKException> resultBiConsumer)
        {
            GetWalletBalanceByCurrency(currency, resultBiConsumer);
        }

        public override void GetWalletBalance(string currency, BiConsumer<Balance, CryptomarketSDKException> resultBiConsumer)
        {
            GetWalletBalanceByCurrency(currency, resultBiConsumer);
        }

        public override void GetTransactions(BiConsumer<IList<Transaction>, CryptomarketSDKException> resultBiConsumer, IList<TransactionType> types, IList<TransactionSubtype> subtypes, IList<TransactionStatus> statuses, IList<string> currencies, IList<string> transactionIds, Sort sort, OrderBy orderBy, string from, string till, int idFrom, int idTill, int limit, int offset, bool groupTransactions)
        {
            GetTransactions(resultBiConsumer, new ParamsBuilder().Types(types).Subtypes(subtypes).Statuses(statuses).Currencies(currencies).TransactionIds(transactionIds).Sort(sort).OrderBy(orderBy).From(from).Till(till).IdFrom(idFrom).IdTill(idTill).Limit(limit).Offset(offset).GroupTransactions(groupTransactions));
        }

        public override void GetTransactions(BiConsumer<IList<Transaction>, CryptomarketSDKException> resultBiConsumer, ParamsBuilder paramsBuilder)
        {
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseList(resultBiConsumer, typeof(Transaction));
            SendById("get_transactions", (paramsBuilder == null) ? null : paramsBuilder.BuildObjectMap(), interceptor);
        }
    }
}