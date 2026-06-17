using Java.Io;
using Java.Util;
using Java.Util.Function;
using Com.Cryptomarket.SDK.Params;
using Cryptomarket.SDK;
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
    public class CryptomarketWSMarketDataClientImpl : ClientBase, CryptomarketWSMarketDataClient
    {
        OrderbookCache OBCache = new OrderbookCache();
        protected Adapter adapter = new Adapter();
        public CryptomarketWSMarketDataClientImpl() : base("wss://api.exchange.cryptomkt.com/api/3/ws/public")
        {
        }

        public override void Handle(string json)
        {
            WSJsonResponse response = adapter.ObjectFromJson(json, typeof(WSJsonResponse));
            if (response.GetChannel() != null)
            {
                HandleNotification(response);
            }
            else if (response.GetId() != null)
            {
                HandleResponse(response);
            }
            else
            {
            }
        }

        protected override void HandleNotification(WSJsonResponse response)
        {
            string key = BuildKey(response);
            Interceptor interceptor = interceptorCache.GetSubscriptionInterceptor(key);
            if (interceptor != null)
            {
                interceptor.MakeCall(response);
            }
            else
            {
            }
        }

        private void SubscriptionByChannel(string channel, Dictionary<string, object> @params, Interceptor feedInterceptor, Interceptor resultInterceptor)
        {
            string key = BuildKey(channel, @params);
            interceptorCache.StoreSubscriptionInterceptor(key, feedInterceptor);
            Payload payload = new Payload("subscribe", channel, @params);
            if (resultInterceptor != null)
            {
                int id = interceptorCache.SaveInterceptor(resultInterceptor);
                payload.id = id;
            }

            string json = payloadAdapter.ToJson(payload);
            websocket.Send(json);
        }

        protected override string BuildKey(string channel, Dictionary<string, object> @params)
        {
            string key = @params.ContainsKey(ArgNames.TARGET_CURRENCY) ? channel + (string)@params[ArgNames.TARGET_CURRENCY] : channel;
            return key;
        }

        private string BuildKey(WSJsonResponse response)
        {
            string channel = response.GetChannel();
            string targetCurrency = response.GetTargetCurrency();
            return targetCurrency != null ? channel + targetCurrency : channel;
        }

        private void MakeSubscriptionWithInterceptors<T>(string channel, ParamsBuilder @params, Class<T> cls, BiConsumer<Dictionary<string, T>, NotificationType> notificationBiConsumer, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor interceptor = InterceptorFactory.NewOfChanneledWSResponse(notificationBiConsumer, cls);
            Interceptor resultInterceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfSubscriptionResponse(resultBiConsumer);
            SubscriptionByChannel(channel, @params.BuildObjectMap(), interceptor, resultInterceptor);
        }

        private void MakeSubscriptionWithListInterceptors<T>(string channel, ParamsBuilder @params, Class<T> cls, BiConsumer<Dictionary<string, IList<T>>, NotificationType> notificationBiConsumer, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            Interceptor interceptor = InterceptorFactory.NewMapStringListOfChanneledWSResponseObject(notificationBiConsumer, cls);
            Interceptor resultInterceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfSubscriptionResponse(resultBiConsumer);
            SubscriptionByChannel(channel, @params.BuildObjectMap(), interceptor, resultInterceptor);
        }

        // PUBLIC METHODS
        public override void SubscribeToTrades(BiConsumer<Dictionary<string, IList<WSPublicTrade>>, NotificationType> notificationBiConsumer, IList<string> symbols, int limit, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder params = new ParamsBuilder().SymbolList(symbols).Limit(limit);
            string channel = "trades";
            MakeSubscriptionWithListInterceptors(channel, @params, typeof(WSPublicTrade), notificationBiConsumer, resultBiConsumer);
        }

        public override void SubscribeToCandles(BiConsumer<Dictionary<string, IList<WSCandle>>, NotificationType> notificationBiConsumer, Period period, IList<string> symbols, int limit, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder params = new ParamsBuilder().SymbolList(symbols).Limit(limit);
            string channel = String.Format("candles/%s", period);
            MakeSubscriptionWithListInterceptors(channel, @params, typeof(WSCandle), notificationBiConsumer, resultBiConsumer);
        }

        public override void SubscribeToConvertedCandles(BiConsumer<Dictionary<string, IList<WSCandle>>, NotificationType> notificationBiConsumer, string targetCurrency, Period period, IList<string> symbols, int limit, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder params = new ParamsBuilder().TargetCurrency(targetCurrency).SymbolList(symbols).Limit(limit);
            string channel = String.Format("converted/candles/%s", period);
            MakeSubscriptionWithListInterceptors(channel, @params, typeof(WSCandle), notificationBiConsumer, resultBiConsumer);
        }

        public override void SubscribeToPriceRates(BiConsumer<Dictionary<string, WSPriceRate>, NotificationType> notificationBiConsumer, PriceSpeed speed, string targetCurrency, IList<string> currencies, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder params = new ParamsBuilder().CurrencyListOrAsterisc(currencies).TargetCurrency(targetCurrency);
            string channel = String.Format("price/rate/%s", speed);
            MakeSubscriptionWithInterceptors(channel, @params, typeof(WSPriceRate), notificationBiConsumer, resultBiConsumer);
        }

        public override void SubscribeToPriceRatesInBatches(BiConsumer<Dictionary<string, WSPriceRate>, NotificationType> notificationBiConsumer, PriceSpeed speed, string targetCurrency, IList<string> currencies, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder params = new ParamsBuilder().CurrencyListOrAsterisc(currencies).TargetCurrency(targetCurrency);
            string channel = String.Format("price/rate/%s/batches", speed);
            MakeSubscriptionWithInterceptors(channel, @params, typeof(WSPriceRate), notificationBiConsumer, resultBiConsumer);
        }

        public override void SubscribeToMiniTicker(BiConsumer<Dictionary<string, WSCandle>, NotificationType> notificationBiConsumer, TickerSpeed speed, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder params = new ParamsBuilder().SymbolListOrAsteric(symbols);
            string channel = String.Format("ticker/price/%s", speed);
            MakeSubscriptionWithInterceptors(channel, @params, typeof(WSCandle), notificationBiConsumer, resultBiConsumer);
        }

        public override void SubscribeToMiniTickerInBatches(BiConsumer<Dictionary<string, WSCandle>, NotificationType> notificationBiConsumer, TickerSpeed speed, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder params = new ParamsBuilder().SymbolListOrAsteric(symbols);
            string channel = String.Format("ticker/price/%s/batch", speed);
            MakeSubscriptionWithInterceptors(channel, @params, typeof(WSCandle), notificationBiConsumer, resultBiConsumer);
        }

        public override void SubscribeToTicker(BiConsumer<Dictionary<string, WSTicker>, NotificationType> notificationBiConsumer, TickerSpeed speed, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder params = new ParamsBuilder().SymbolListOrAsteric(symbols);
            string channel = String.Format("ticker/%s", speed);
            MakeSubscriptionWithInterceptors(channel, @params, typeof(WSTicker), notificationBiConsumer, resultBiConsumer);
        }

        public override void SubscribeToTickerInBatches(BiConsumer<Dictionary<string, WSTicker>, NotificationType> notificationBiConsumer, TickerSpeed speed, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder params = new ParamsBuilder().SymbolListOrAsteric(symbols);
            string channel = String.Format("ticker/%s/batch", speed);
            MakeSubscriptionWithInterceptors(channel, @params, typeof(WSTicker), notificationBiConsumer, resultBiConsumer);
        }

        public override void SubscribeToFullOrderBook(BiConsumer<Dictionary<string, WSOrderBook>, NotificationType> notificationBiConsumer, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder params = new ParamsBuilder().SymbolList(symbols);
            string channel = "orderbook/full";
            MakeSubscriptionWithInterceptors(channel, @params, typeof(WSOrderBook), notificationBiConsumer, resultBiConsumer);
        }

        public override void SubscribeToPartialOrderBook(BiConsumer<Dictionary<string, WSOrderBook>, NotificationType> notificationBiConsumer, Depth depth, OBSpeed speed, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder params = new ParamsBuilder().SymbolListOrAsteric(symbols);
            string channel = String.Format("orderbook/%s/%s", depth, speed);
            MakeSubscriptionWithInterceptors(channel, @params, typeof(WSOrderBook), notificationBiConsumer, resultBiConsumer);
        }

        public override void SubscribeToPartialOrderBookInBatches(BiConsumer<Dictionary<string, WSOrderBook>, NotificationType> notificationBiConsumer, Depth depth, OBSpeed speed, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder params = new ParamsBuilder().SymbolListOrAsteric(symbols);
            string channel = String.Format("orderbook/%s/%s/batch", depth, speed);
            MakeSubscriptionWithInterceptors(channel, @params, typeof(WSOrderBook), notificationBiConsumer, resultBiConsumer);
        }

        public override void SubscribeToTopOfOrderBook(BiConsumer<Dictionary<string, WSOrderBookTop>, NotificationType> notificationBiConsumer, OBSpeed speed, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder params = new ParamsBuilder().SymbolListOrAsteric(symbols);
            string channel = String.Format("orderbook/top/%s", speed);
            MakeSubscriptionWithInterceptors(channel, @params, typeof(WSOrderBookTop), notificationBiConsumer, resultBiConsumer);
        }

        public override void SubscribeToTopOfOrderBookInBatches(BiConsumer<Dictionary<string, WSOrderBookTop>, NotificationType> notificationBiConsumer, OBSpeed speed, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            ParamsBuilder params = new ParamsBuilder().SymbolListOrAsteric(symbols);
            string channel = String.Format("orderbook/top/%s/batch", speed);
            MakeSubscriptionWithInterceptors(channel, @params, typeof(WSOrderBookTop), notificationBiConsumer, resultBiConsumer);
        }
    }
}