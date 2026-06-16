using Java.Util;
using Java.Util.Function;
using Org.Jetbrains.Annotations;
using Com.Cryptomarket.Params;
using Cryptomarket.SDK.Exceptions;
using Cryptomarket.SDK.Models;
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
    public interface CryptomarketWSWalletClient : CryptomarketWS
    {
        void SubscribeToTransactions(BiConsumer<Transaction, NotificationType> notificationBiConsumer, BiConsumer<bool, CryptomarketSDKException> resultBiConsumer);
        void UnsubscribeToTransactions(BiConsumer<bool, CryptomarketSDKException> resultBiConsumer);
        void SubscribeToWalletBalances(BiConsumer<IList<Balance>, NotificationType> notificationBiConsumer, BiConsumer<bool, CryptomarketSDKException> resultBiConsumer);
        void UnsubscribeToWalletBalances(BiConsumer<bool, CryptomarketSDKException> resultBiConsumer);
        void GetWalletBalances(BiConsumer<IList<Balance>, CryptomarketSDKException> resultBiConsumer);
        void GetWalletBalanceByCurrency(string currency, BiConsumer<Balance, CryptomarketSDKException> resultBiConsumer);
        void GetWalletBalanceOfCurrency(string currency, BiConsumer<Balance, CryptomarketSDKException> resultBiConsumer);
        void GetWalletBalance(string currency, BiConsumer<Balance, CryptomarketSDKException> resultBiConsumer);
        void GetTransactions(BiConsumer<IList<Transaction>, CryptomarketSDKException> resultBiConsumer, IList<TransactionType> types, IList<TransactionSubtype> subtypes, IList<TransactionStatus> statuses, IList<string> currencies, IList<string> transactionIds, Sort sort, OrderBy orderBy, string from, string till, int idFrom, int idTill, int limit, int offset, bool groupTransactions);
        void GetTransactions(BiConsumer<IList<Transaction>, CryptomarketSDKException> resultBiConsumer, ParamsBuilder paramsBuilder);
    }
}