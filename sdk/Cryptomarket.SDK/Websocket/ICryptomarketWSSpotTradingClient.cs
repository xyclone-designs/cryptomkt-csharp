using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Models;

using CryptoMarket.SDK.Params;

namespace CryptoMarket.SDK.Websocket
{
    public interface ICryptoMarketWSSpotTradingClient : ICryptoMarketWS
    {
        void SubscribeToReports(Action<IList<Report>, NotificationType> notificationAction, Action<bool, CryptoMarketSDKException> resultAction);
        void UnsubscribeToReports(Action<bool, CryptoMarketSDKException> resultAction);
        void SubscribeToSpotBalances(SubscriptionMode mode, Action<IList<Balance>, NotificationType> notificationBiconsumer, Action<bool, CryptoMarketSDKException> resultAction);
        void UnsubscribeToSpotBalances(Action<bool, CryptoMarketSDKException> resultAction);
        void GetAllActiveOrders(Action<IList<Report>, CryptoMarketSDKException> resultAction);
        void CreateSpotOrder(string symbol, Side side, string quantity, string clientOrderId, OrderType orderType, string price, string stopPrice, TimeInForce timeInForce, string expireTime, bool strictValidate, bool postOnly, string takeRate, string makeRate, Action<Report, CryptoMarketSDKException> resultAction);
        void CreateSpotOrder(ParamsBuilder paramsBuilder, Action<Report, CryptoMarketSDKException> resultAction);
        void CreateSpotOrderList(ContingencyType contingencyType, IList<OrderBuilder> orders, string orderListId, Action<Report, CryptoMarketSDKException> resultAction);
        void CancelSpotOrder(string clientOrderId, Action<Report, CryptoMarketSDKException> resultAction);
        void ReplaceSpotOrder(string clientOrderId, string newClientOrderId, string quantity, string price, string stopPrice, bool? strictValidate, Action<Report, CryptoMarketSDKException> resultAction);
        void CancelAllSpotOrders(Action<IList<Report>, CryptoMarketSDKException> resultAction);
        void GetSpotTradingBalances(Action<IList<Balance>, CryptoMarketSDKException> resultAction);
        void GetSpotTradingBalanceOfCurrency(string currency, Action<Balance, CryptoMarketSDKException> resultAction);
        void GetSpotTradingBalanceByCurrency(string currency, Action<Balance, CryptoMarketSDKException> resultAction);
        void GetSpotTradingBalance(string currency, Action<Balance, CryptoMarketSDKException> resultAction);
        void GetSpotCommissions(Action<IList<Commission>, CryptoMarketSDKException> resultAction);
        void GetSpotCommissionOfSymbol(string symbol, Action<Commission, CryptoMarketSDKException> resultAction);
        void GetSpotCommissionBySymbol(string symbol, Action<Commission, CryptoMarketSDKException> resultAction);
        void GetSpotCommission(string symbol, Action<Commission, CryptoMarketSDKException> resultAction);
    }
}