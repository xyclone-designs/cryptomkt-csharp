using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Models;
using CryptoMarket.SDK.Websocket.Interceptors;
using CryptoMarket.SDK.Params;

namespace CryptoMarket.SDK.Websocket
{
    public class CryptoMarketWSSpotTradingClientImpl : AuthClient, ICryptoMarketWSSpotTradingClient
    {
        public CryptoMarketWSSpotTradingClientImpl(string apiKey, string apiSecret) : this(apiKey, apiSecret, 0) { }
        public CryptoMarketWSSpotTradingClientImpl(string apiKey, string apiSecret, int window) : base("wss://api.exchange.cryptomkt.com/api/3/ws/trading", apiKey, apiSecret, window)
        {
            SubscritpionKeys.Add("spot_subscribe", "reports");
            SubscritpionKeys.Add("spot_unsubscribe", "reports");
            SubscritpionKeys.Add("spot_orders", "reports");
            SubscritpionKeys.Add("spot_order", "reports");
            SubscritpionKeys.Add("spot_balance_subscribe", "balances");
            SubscritpionKeys.Add("spot_balance_unsubscribe", "balances");
            SubscritpionKeys.Add("spot_balance", "balances");
        }
        
        public void SubscribeToReports(Action<IList<Report>, NotificationType> notificationAction, Action<bool, CryptoMarketSDKException> resultAction)
        {
            Interceptor feedInterceptor = new AnonymousInterceptor(notificationAction);
            Interceptor resultInterceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);

            SendSubscription("spot_subscribe", null, feedInterceptor, resultInterceptor);
        }
        public void SubscribeToSpotBalances(SubscriptionMode mode, Action<IList<Balance>, NotificationType> notificationAction, Action<bool, CryptoMarketSDKException> resultAction)
        {
            Interceptor interceptor = new AnonymousInterceptor1(notificationAction);
            Interceptor resultInterceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            ParamsBuilder @params = new ParamsBuilder().SubcriptionMode(mode);
            
            SendSubscription("spot_balance_subscribe", @params.BuildObjectMap(), interceptor, resultInterceptor);
        }
        public void UnsubscribeToReports(Action<bool, CryptoMarketSDKException> resultAction)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            
            SendUnsubscription("spot_unsubscribe", null, interceptor);
        }
        public void UnsubscribeToSpotBalances(Action<bool, CryptoMarketSDKException> resultAction)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);

            // harcoded params needed for a valid unsubscription, independent of real
            // subscription type.
            ParamsBuilder @params = new ParamsBuilder().SubcriptionMode(SubscriptionMode.UPDATES);
            
            SendUnsubscription("spot_balance_unsubscribe", @params.BuildObjectMap(), interceptor);
        }

        public void GetAllActiveOrders(Action<IList<Report>, CryptoMarketSDKException> resultAction)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseList<Report>(resultAction);
            
            SendById("spot_get_orders", null, interceptor);
        }
        public void CreateSpotOrder(string symbol, Side side, string quantity, string clientOrderId, OrderType orderType, string price, string stopPrice, TimeInForce timeInForce, string expireTime, bool strictValidate, bool postOnly, string takeRate, string makeRate, Action<Report, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder().Symbol(symbol).Side(side).Quantity(quantity).ClientOrderId(clientOrderId).OrderType(orderType).Price(price).StopPrice(stopPrice).TimeInForce(timeInForce).ExpireTime(expireTime).StrictValidate(strictValidate).PostOnly(postOnly).TakeRate(takeRate).MakeRate(makeRate);
            
            CreateSpotOrder(paramsBuilder, resultAction);
        }
        public void CreateSpotOrder(ParamsBuilder paramsBuilder, Action<Report, CryptoMarketSDKException> resultAction)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            
            SendById("spot_new_order", paramsBuilder.BuildObjectMap(), interceptor);
        }
        public void CreateSpotOrderList(ContingencyType contingencyType, IList<OrderBuilder> orders, string orderListId, Action<Report, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder @params = new ParamsBuilder().OrderListId(orderListId).ContingencyType(contingencyType).OrderList(orders);
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            
            SendById("spot_new_order_list", @params.BuildObjectMap(), interceptor, orders.Count);
        }
        public void CancelSpotOrder(string clientOrderId, Action<Report, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder @params = new ParamsBuilder().ClientOrderId(clientOrderId);
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            
            SendById("spot_cancel_order", @params.BuildObjectMap(), interceptor);
        }
        public void ReplaceSpotOrder(string clientOrderId, string newClientOrderId, string quantity, string price, string stopPrice, bool? strictValidate, Action<Report, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder().ClientOrderId(clientOrderId).NewClientOrderId(newClientOrderId).Quantity(quantity).Price(price).StopPrice(stopPrice).StrictValidate(strictValidate ?? default);
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            
            SendById("spot_replace_order", paramsBuilder.BuildObjectMap(), interceptor);
        }
        public void CancelAllSpotOrders(Action<IList<Report>, CryptoMarketSDKException> resultAction)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseList(resultAction);
            
            SendById("spot_cancel_orders", null, interceptor);
        }
        public void GetSpotTradingBalances(Action<IList<Balance>, CryptoMarketSDKException> resultAction)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseList(resultAction);
            
            SendById("spot_balances", null, interceptor);
        }
        public void GetSpotTradingBalanceOfCurrency(string currency, Action<Balance, CryptoMarketSDKException> resultAction)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            ParamsBuilder paramsBuilder = new ParamsBuilder().Currency(currency);
            
            SendById("spot_balance", paramsBuilder.BuildObjectMap(), interceptor);
        }
        public void GetSpotTradingBalanceByCurrency(string currency, Action<Balance, CryptoMarketSDKException> resultAction)
        {
            GetSpotTradingBalanceOfCurrency(currency, resultAction);
        }
        public void GetSpotTradingBalance(string currency, Action<Balance, CryptoMarketSDKException> resultAction)
        {
            GetSpotTradingBalanceOfCurrency(currency, resultAction);
        }
        public void GetSpotCommissions(Action<IList<Commission>, CryptoMarketSDKException> resultAction)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseList(resultAction);
            
            SendById("spot_fees", null, interceptor);
        }
        public void GetSpotCommissionOfSymbol(string symbol, Action<Commission, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder().Symbol(symbol);
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseObject(resultAction);
            
            SendById("spot_fee", paramsBuilder.BuildObjectMap(), interceptor);
        }
        public void GetSpotCommissionBySymbol(string symbol, Action<Commission, CryptoMarketSDKException> resultAction)
        {
            GetSpotCommissionOfSymbol(symbol, resultAction);
        }
        public void GetSpotCommission(string symbol, Action<Commission, CryptoMarketSDKException> resultAction)
        {
            GetSpotCommissionOfSymbol(symbol, resultAction);
        }

        private sealed class AnonymousInterceptor(Action<IList<Report>, NotificationType> notificationAction) : Interceptor
        {
            private readonly Action<IList<Report>, NotificationType> NotificationAction = notificationAction;

            public override void MakeCall(WSJsonResponse response)
            {
                if (response.Method == "spot_orders")
                {
                    try
                    {
                        if (response.Parameters is IList<Report> reports)
                            NotificationAction.Invoke(reports, NotificationType.SNAPSHOT);
                    }
                    catch (ParseException) { }
                }
                else if (response.Method == "spot_order")
                {
                    try
                    {
                        Report report = response.Parameters as Report;

                        NotificationAction.Invoke([report], NotificationType.UPDATE);
                    }
                    catch (ParseException) { }
                }
            }
        }
        private sealed class AnonymousInterceptor1(Action<IList<Balance>, NotificationType> notificationAction) : Interceptor
        {
            private readonly Action<IList<Balance>, NotificationType> NotificationAction = notificationAction;

            public override void MakeCall(WSJsonResponse response)
            {
                try
                {
                    IList<Balance> balances = response.Parameters as IList<Balance>;
                    NotificationAction.Invoke(balances, NotificationType.DATA);
                }
                catch (ParseException)
                {
                    NotificationAction.Invoke(null, NotificationType.PARSE_ERROR);
                }
            }
        }
    }
}