using Java.Util;
using Java.Util.Function;
using Com.Cryptomarket.Params;
using Cryptomarket.SDK.Exceptions;
using Cryptomarket.SDK.Models;
using Org.Jetbrains.Annotations;
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
    public interface CryptomarketWSSpotTradingClient : CryptomarketWS
    {
        void SubscribeToReports(BiConsumer<IList<Report>, NotificationType> notificationBiConsumer, BiConsumer<bool, CryptomarketSDKException> resultBiConsumer);
        void UnsubscribeToReports(BiConsumer<bool, CryptomarketSDKException> resultBiConsumer);
        void SubscribeToSpotBalances(SubscriptionMode mode, BiConsumer<IList<Balance>, NotificationType> notificationBiconsumer, BiConsumer<bool, CryptomarketSDKException> resultBiConsumer);
        void UnsubscribeToSpotBalances(BiConsumer<bool, CryptomarketSDKException> resultBiConsumer);
        void GetAllActiveOrders(BiConsumer<IList<Report>, CryptomarketSDKException> resultBiConsumer);
        void CreateSpotOrder(string symbol, Side side, string quantity, string clientOrderId, OrderType orderType, string price, string stopPrice, TimeInForce timeInForce, string expireTime, bool strictValidate, bool postOnly, string takeRate, string makeRate, BiConsumer<Report, CryptomarketSDKException> resultBiConsumer);
        void CreateSpotOrder(ParamsBuilder paramsBuilder, BiConsumer<Report, CryptomarketSDKException> resultBiConsumer);
        void CreateSpotOrderList(ContingencyType contingencyType, IList<OrderBuilder> orders, string orderListId, BiConsumer<Report, CryptomarketSDKException> resultBiConsumer);
        void CancelSpotOrder(string clientOrderId, BiConsumer<Report, CryptomarketSDKException> resultBiConsumer);
        void ReplaceSpotOrder(string clientOrderId, string newClientOrderId, string quantity, string price, string stopPrice, bool strictValidate, BiConsumer<Report, CryptomarketSDKException> resultBiConsumer);
        void CancelAllSpotOrders(BiConsumer<IList<Report>, CryptomarketSDKException> resultBiConsumer);
        void GetSpotTradingBalances(BiConsumer<IList<Balance>, CryptomarketSDKException> resultBiConsumer);
        void GetSpotTradingBalanceOfCurrency(string currency, BiConsumer<Balance, CryptomarketSDKException> resultBiConsumer);
        void GetSpotTradingBalanceByCurrency(string currency, BiConsumer<Balance, CryptomarketSDKException> resultBiConsumer);
        void GetSpotTradingBalance(string currency, BiConsumer<Balance, CryptomarketSDKException> resultBiConsumer);
        void GetSpotCommissions(BiConsumer<IList<Commission>, CryptomarketSDKException> resultBiConsumer);
        void GetSpotCommissionOfSymbol(string symbol, BiConsumer<Commission, CryptomarketSDKException> resultBiConsumer);
        void GetSpotCommissionBySymbol(string symbol, BiConsumer<Commission, CryptomarketSDKException> resultBiConsumer);
        void GetSpotCommission(string symbol, BiConsumer<Commission, CryptomarketSDKException> resultBiConsumer);
    }
}