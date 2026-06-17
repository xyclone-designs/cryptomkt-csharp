using Cryptomarket.SDK.Exceptions;
using Cryptomarket.SDK.Models;

using Cryptomarket.SDK.Params;

namespace Cryptomarket.SDK.Websocket
{
    public interface ICryptomarketWSSpotTradingClient : ICryptomarketWS
    {
        void SubscribeToReports(Action<IList<Report>, NotificationType> notificationAction, Action<bool, CryptomarketSDKException> resultAction);
        void UnsubscribeToReports(Action<bool, CryptomarketSDKException> resultAction);
        void SubscribeToSpotBalances(SubscriptionMode mode, Action<IList<Balance>, NotificationType> notificationBiconsumer, Action<bool, CryptomarketSDKException> resultAction);
        void UnsubscribeToSpotBalances(Action<bool, CryptomarketSDKException> resultAction);
        void GetAllActiveOrders(Action<IList<Report>, CryptomarketSDKException> resultAction);
        void CreateSpotOrder(string symbol, Side side, string quantity, string clientOrderId, OrderType orderType, string price, string stopPrice, TimeInForce timeInForce, string expireTime, bool strictValidate, bool postOnly, string takeRate, string makeRate, Action<Report, CryptomarketSDKException> resultAction);
        void CreateSpotOrder(ParamsBuilder paramsBuilder, Action<Report, CryptomarketSDKException> resultAction);
        void CreateSpotOrderList(ContingencyType contingencyType, IList<OrderBuilder> orders, string orderListId, Action<Report, CryptomarketSDKException> resultAction);
        void CancelSpotOrder(string clientOrderId, Action<Report, CryptomarketSDKException> resultAction);
        void ReplaceSpotOrder(string clientOrderId, string newClientOrderId, string quantity, string price, string stopPrice, bool strictValidate, Action<Report, CryptomarketSDKException> resultAction);
        void CancelAllSpotOrders(Action<IList<Report>, CryptomarketSDKException> resultAction);
        void GetSpotTradingBalances(Action<IList<Balance>, CryptomarketSDKException> resultAction);
        void GetSpotTradingBalanceOfCurrency(string currency, Action<Balance, CryptomarketSDKException> resultAction);
        void GetSpotTradingBalanceByCurrency(string currency, Action<Balance, CryptomarketSDKException> resultAction);
        void GetSpotTradingBalance(string currency, Action<Balance, CryptomarketSDKException> resultAction);
        void GetSpotCommissions(Action<IList<Commission>, CryptomarketSDKException> resultAction);
        void GetSpotCommissionOfSymbol(string symbol, Action<Commission, CryptomarketSDKException> resultAction);
        void GetSpotCommissionBySymbol(string symbol, Action<Commission, CryptomarketSDKException> resultAction);
        void GetSpotCommission(string symbol, Action<Commission, CryptomarketSDKException> resultAction);
    }
}