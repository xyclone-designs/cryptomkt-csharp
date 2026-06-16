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
    public class CryptomarketWSSpotTradingClientImpl : AuthClient, CryptomarketWSSpotTradingClient
    {
        public CryptomarketWSSpotTradingClientImpl(string apiKey, string apiSecret, int window) : base("wss://api.exchange.cryptomkt.com/api/3/ws/trading", apiKey, apiSecret, window)
        {
            Dictionary<string, string> subsKeys = this.GetSubscritpionKeys();

            // reports
            subsKeys.Put("spot_subscribe", "reports");
            subsKeys.Put("spot_unsubscribe", "reports");
            subsKeys.Put("spot_orders", "reports");
            subsKeys.Put("spot_order", "reports");
            subsKeys.Put("spot_balance_subscribe", "balances");
            subsKeys.Put("spot_balance_unsubscribe", "balances");
            subsKeys.Put("spot_balance", "balances");
        }

        public CryptomarketWSSpotTradingClientImpl(string apiKey, string apiSecret) : this(apiKey, apiSecret, 0)
        {
        }

        public override void SubscribeToReports(BiConsumer<IList<Report>, NotificationType> notificationBiConsumer, BiConsumer<bool, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor feedInterceptor = new AnonymousInterceptor(this);
            Interceptor resultInterceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseObject(resultBiConsumer, typeof(bool));
            SendSubscription("spot_subscribe", null, feedInterceptor, resultInterceptor);
        }

        private sealed class AnonymousInterceptor : Interceptor
        {
            public AnonymousInterceptor(CryptomarketWSSpotTradingClientImpl parent)
            {
                this.parent = parent;
            }

            private readonly CryptomarketWSSpotTradingClientImpl parent;
            public void MakeCall(WSJsonResponse response)
            {
                if (response.GetMethod().Equals("spot_orders"))
                {
                    try
                    {
                        IList<Report> reports = adapter.ListFromValue(response.GetParams(), typeof(Report));
                        if (reports != null)
                        {
                            notificationBiConsumer.Accept(reports, NotificationType.SNAPSHOT);
                        }
                    }
                    catch (ParseException e)
                    {
                    }
                }
                else if (response.GetMethod().Equals("spot_order"))
                {
                    try
                    {
                        Report report = adapter.ObjectFromValue(response.GetParams(), typeof(Report));
                        IList<Report> reports = new List<Report>();
                        reports.Add(report);
                        notificationBiConsumer.Accept(reports, NotificationType.UPDATE);
                    }
                    catch (ParseException e)
                    {
                    }
                }
            }
        }

        public override void UnsubscribeToReports(BiConsumer<bool, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseObject(resultBiConsumer, typeof(bool));
            SendUnsubscription("spot_unsubscribe", null, interceptor);
        }

        public override void SubscribeToSpotBalances(SubscriptionMode mode, BiConsumer<IList<Balance>, NotificationType> notificationBiConsumer, BiConsumer<bool, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor interceptor = new AnonymousInterceptor1(this);
            Interceptor resultInterceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseObject(resultBiConsumer, typeof(bool));
            ParamsBuilder params = new ParamsBuilder().SubcriptionMode(mode);
            SendSubscription("spot_balance_subscribe", @params.BuildObjectMap(), interceptor, resultInterceptor);
        }

        private sealed class AnonymousInterceptor1 : Interceptor
        {
            public AnonymousInterceptor1(CryptomarketWSSpotTradingClientImpl parent)
            {
                this.parent = parent;
            }

            private readonly CryptomarketWSSpotTradingClientImpl parent;
            public void MakeCall(WSJsonResponse response)
            {
                try
                {
                    IList<Balance> balances = adapter.ListFromValue(response.GetParams(), typeof(Balance));
                    notificationBiConsumer.Accept(balances, NotificationType.DATA);
                }
                catch (ParseException e)
                {
                    notificationBiConsumer.Accept(null, NotificationType.PARSE_ERROR);
                }
            }
        }

        public override void UnsubscribeToSpotBalances(BiConsumer<bool, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseObject(resultBiConsumer, typeof(bool));

            // harcoded params needed for a valid unsubscription, independent of real
            // subscription type.
            ParamsBuilder params = new ParamsBuilder().SubcriptionMode(SubscriptionMode.UPDATES);
            SendUnsubscription("spot_balance_unsubscribe", @params.BuildObjectMap(), interceptor);
        }

        public override void GetAllActiveOrders(BiConsumer<IList<Report>, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor interceptor = InterceptorFactory.NewOfWSResponseList(resultBiConsumer, typeof(Report));
            SendById("spot_get_orders", null, interceptor);
        }

        public override void CreateSpotOrder(string symbol, Side side, string quantity, string clientOrderId, OrderType orderType, string price, string stopPrice, TimeInForce timeInForce, string expireTime, bool strictValidate, bool postOnly, string takeRate, string makeRate, BiConsumer<Report, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder().Symbol(symbol).Side(side).Quantity(quantity).ClientOrderId(clientOrderId).OrderType(orderType).Price(price).StopPrice(stopPrice).TimeInForce(timeInForce).ExpireTime(expireTime).StrictValidate(strictValidate).PostOnly(postOnly).TakeRate(takeRate).MakeRate(makeRate);
            CreateSpotOrder(paramsBuilder, resultBiConsumer);
        }

        public override void CreateSpotOrder(ParamsBuilder paramsBuilder, BiConsumer<Report, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseObject(resultBiConsumer, typeof(Report));
            SendById("spot_new_order", paramsBuilder.BuildObjectMap(), interceptor);
        }

        public override void CreateSpotOrderList(ContingencyType contingencyType, IList<OrderBuilder> orders, string orderListId, BiConsumer<Report, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder params = new ParamsBuilder().OrderListId(orderListId).ContingencyType(contingencyType).OrderList(orders);
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseObject(resultBiConsumer, typeof(Report));
            SendById("spot_new_order_list", @params.BuildObjectMap(), interceptor, orders.Count);
        }

        public override void CancelSpotOrder(string clientOrderId, BiConsumer<Report, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder params = new ParamsBuilder().ClientOrderId(clientOrderId);
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseObject(resultBiConsumer, typeof(Report));
            SendById("spot_cancel_order", @params.BuildObjectMap(), interceptor);
        }

        public override void ReplaceSpotOrder(string clientOrderId, string newClientOrderId, string quantity, string price, string stopPrice, bool strictValidate, BiConsumer<Report, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder().ClientOrderId(clientOrderId).NewClientOrderId(newClientOrderId).Quantity(quantity).Price(price).StopPrice(stopPrice).StrictValidate(strictValidate);
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseObject(resultBiConsumer, typeof(Report));
            SendById("spot_replace_order", paramsBuilder.BuildObjectMap(), interceptor);
        }

        public override void CancelAllSpotOrders(BiConsumer<IList<Report>, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseList(resultBiConsumer, typeof(Report));
            SendById("spot_cancel_orders", null, interceptor);
        }

        public override void GetSpotTradingBalances(BiConsumer<IList<Balance>, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseList(resultBiConsumer, typeof(Balance));
            SendById("spot_balances", null, interceptor);
        }

        public override void GetSpotTradingBalanceOfCurrency(string currency, BiConsumer<Balance, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseObject(resultBiConsumer, typeof(Balance));
            ParamsBuilder paramsBuilder = new ParamsBuilder().Currency(currency);
            SendById("spot_balance", paramsBuilder.BuildObjectMap(), interceptor);
        }

        public override void GetSpotTradingBalanceByCurrency(string currency, BiConsumer<Balance, CryptomarketSDKException> resultBiConsumer)
        {
            GetSpotTradingBalanceOfCurrency(currency, resultBiConsumer);
        }

        public override void GetSpotTradingBalance(string currency, BiConsumer<Balance, CryptomarketSDKException> resultBiConsumer)
        {
            GetSpotTradingBalanceOfCurrency(currency, resultBiConsumer);
        }

        public override void GetSpotCommissions(BiConsumer<IList<Commission>, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseList(resultBiConsumer, typeof(Commission));
            SendById("spot_fees", null, interceptor);
        }

        public override void GetSpotCommissionOfSymbol(string symbol, BiConsumer<Commission, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder().Symbol(symbol);
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseObject(resultBiConsumer, typeof(Commission));
            SendById("spot_fee", paramsBuilder.BuildObjectMap(), interceptor);
        }

        public override void GetSpotCommissionBySymbol(string symbol, BiConsumer<Commission, CryptomarketSDKException> resultBiConsumer)
        {
            GetSpotCommissionOfSymbol(symbol, resultBiConsumer);
        }

        public override void GetSpotCommission(string symbol, BiConsumer<Commission, CryptomarketSDKException> resultBiConsumer)
        {
            GetSpotCommissionOfSymbol(symbol, resultBiConsumer);
        }
    }
}