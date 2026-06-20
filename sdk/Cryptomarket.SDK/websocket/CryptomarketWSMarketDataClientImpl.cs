using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Models;
using CryptoMarket.SDK.Params;
using CryptoMarket.SDK.Websocket.Interceptors;

using System.Text.Json;

namespace CryptoMarket.SDK.Websocket
{
    public class CryptoMarketWSMarketDataClientImpl : ClientBase, ICryptoMarketWSMarketDataClient
    {
        private OrderbookCache OBCache = new OrderbookCache();

        public CryptoMarketWSMarketDataClientImpl() : base("wss://api.exchange.cryptomkt.com/api/3/ws/public") { }

        public override void Handle(string json)
        {
            WSJsonResponse response = JsonSerializer.Deserialize<WSJsonResponse>(json);

            if (response.Channel != null)
                HandleNotification(response);
            else if (response.Id != null)
                HandleResponse(response);
            else { }
        }

        protected override void HandleNotification(WSJsonResponse response)
        {
            string key = BuildKey(response);
            
            interceptorCache
                .GetSubscriptionInterceptor(key)?
                .MakeCall(response);
        }
        protected override string BuildKey(string channel, Dictionary<string, object> @params)
        {
            string key = @params.ContainsKey(ArgNames.TARGET_CURRENCY) ? channel + (string)@params[ArgNames.TARGET_CURRENCY] : channel;
            return key;
        }

        private string BuildKey(WSJsonResponse response)
        {
            string channel = response.Channel;
            string targetCurrency = response.TargetCurrency;
            return targetCurrency != null ? channel + targetCurrency : channel;
        }

        private void SubscriptionByChannel(string channel, Dictionary<string, object> @params, Interceptor feedInterceptor, Interceptor resultInterceptor)
        {
            string key = BuildKey(channel, @params);
            interceptorCache.StoreSubscriptionInterceptor(key, feedInterceptor);
            
            Payload payload = new ("subscribe", channel, @params);
            if (resultInterceptor != null)
            {
                int id = interceptorCache.SaveInterceptor(resultInterceptor);
                payload.Id = id;
            }

            string json = JsonSerializer.Serialize(payload);

            websocket.Send(json);
        }
        private void MakeSubscriptionWithInterceptors<T>(string channel, ParamsBuilder @params, Action<Dictionary<string, T>, NotificationType> notificationAction, Action<IList<string>, CryptoMarketSDKException> resultAction)
        {
            Interceptor interceptor = InterceptorFactory.NewOfChanneledWSResponse<T>(notificationAction);
            Interceptor resultInterceptor = InterceptorFactory.NewOfSubscriptionResponse(resultAction);
            
            SubscriptionByChannel(channel, @params.BuildObjectMap(), interceptor, resultInterceptor);
        }
        private void MakeSubscriptionWithListInterceptors<T>(string channel, ParamsBuilder @params, Action<Dictionary<string, IList<T>>, NotificationType> notificationAction, Action<IList<string>, CryptoMarketSDKException> resultAction)
        {
            Interceptor interceptor = InterceptorFactory.NewMapStringListOfChanneledWSResponseObject<T>(notificationAction);
            Interceptor resultInterceptor = InterceptorFactory.NewOfSubscriptionResponse(resultAction);
            
            SubscriptionByChannel(channel, @params.BuildObjectMap(), interceptor, resultInterceptor);
        }

        public void SubscribeToTrades(Action<Dictionary<string, IList<WSPublicTrade>>, NotificationType> notificationAction, IList<string> symbols, int limit, Action<IList<string>, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder @params = new ParamsBuilder().SymbolList(symbols).Limit(limit);
            string channel = "trades";
            
            MakeSubscriptionWithListInterceptors<WSPublicTrade>(channel, @params, notificationAction, resultAction);
        }
        public void SubscribeToCandles(Action<Dictionary<string, IList<WSCandle>>, NotificationType> notificationAction, Period period, IList<string> symbols, int limit, Action<IList<string>, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder @params = new ParamsBuilder().SymbolList(symbols).Limit(limit);
            string channel = string.Format("candles/{0}", period);
            
            MakeSubscriptionWithListInterceptors<WSCandle>(channel, @params, notificationAction, resultAction);
        }
        public void SubscribeToConvertedCandles(Action<Dictionary<string, IList<WSCandle>>, NotificationType> notificationAction, string targetCurrency, Period period, IList<string> symbols, int limit, Action<IList<string>, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder @params = new ParamsBuilder().TargetCurrency(targetCurrency).SymbolList(symbols).Limit(limit);
            string channel = string.Format("converted/candles/{0}", period);
            
            MakeSubscriptionWithListInterceptors<WSCandle>(channel, @params, notificationAction, resultAction);
        }
        public void SubscribeToPriceRates(Action<Dictionary<string, WSPriceRate>, NotificationType> notificationAction, PriceSpeed speed, string targetCurrency, IList<string> currencies, Action<IList<string>, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder @params = new ParamsBuilder().CurrencyListOrAsterisc(currencies).TargetCurrency(targetCurrency);
            string channel = string.Format("price/rate/{0}", speed);
            
            MakeSubscriptionWithInterceptors<WSPriceRate>(channel, @params, notificationAction, resultAction);
        }
        public void SubscribeToPriceRatesInBatches(Action<Dictionary<string, WSPriceRate>, NotificationType> notificationAction, PriceSpeed speed, string targetCurrency, IList<string> currencies, Action<IList<string>, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder @params = new ParamsBuilder().CurrencyListOrAsterisc(currencies).TargetCurrency(targetCurrency);
            string channel = string.Format("price/rate/{0}/batches", speed);
            
            MakeSubscriptionWithInterceptors<WSPriceRate>(channel, @params, notificationAction, resultAction);
        }
        public void SubscribeToMiniTicker(Action<Dictionary<string, WSCandle>, NotificationType> notificationAction, TickerSpeed speed, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder @params = new ParamsBuilder().SymbolListOrAsteric(symbols);
            string channel = string.Format("ticker/price/{0}", speed);
            
            MakeSubscriptionWithInterceptors<WSCandle>(channel, @params, notificationAction, resultAction);
        }
        public void SubscribeToMiniTickerInBatches(Action<Dictionary<string, WSCandle>, NotificationType> notificationAction, TickerSpeed speed, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder @params = new ParamsBuilder().SymbolListOrAsteric(symbols);
            string channel = string.Format("ticker/price/{0}/batch", speed);
            
            MakeSubscriptionWithInterceptors<WSCandle>(channel, @params, notificationAction, resultAction);
        }
        public void SubscribeToTicker(Action<Dictionary<string, WSTicker>, NotificationType> notificationAction, TickerSpeed speed, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder @params = new ParamsBuilder().SymbolListOrAsteric(symbols);
            string channel = string.Format("ticker/{0}", speed);
            
            MakeSubscriptionWithInterceptors<WSTicker>(channel, @params, notificationAction, resultAction);
        }
        public void SubscribeToTickerInBatches(Action<Dictionary<string, WSTicker>, NotificationType> notificationAction, TickerSpeed speed, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder @params = new ParamsBuilder().SymbolListOrAsteric(symbols);
            string channel = string.Format("ticker/{0}/batch", speed);
            
            MakeSubscriptionWithInterceptors<WSTicker>(channel, @params, notificationAction, resultAction);
        }
        public void SubscribeToFullOrderBook(Action<Dictionary<string, WSOrderBook>, NotificationType> notificationAction, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder @params = new ParamsBuilder().SymbolList(symbols);
            string channel = "orderbook/full";
            
            MakeSubscriptionWithInterceptors<WSOrderBook>(channel, @params, notificationAction, resultAction);
        }
        public void SubscribeToPartialOrderBook(Action<Dictionary<string, WSOrderBook>, NotificationType> notificationAction, Depth depth, OBSpeed speed, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder @params = new ParamsBuilder().SymbolListOrAsteric(symbols);
            string channel = string.Format("orderbook/{0}/{1}", depth, speed);
            
            MakeSubscriptionWithInterceptors<WSOrderBook>(channel, @params, notificationAction, resultAction);
        }
        public void SubscribeToPartialOrderBookInBatches(Action<Dictionary<string, WSOrderBook>, NotificationType> notificationAction, Depth depth, OBSpeed speed, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder @params = new ParamsBuilder().SymbolListOrAsteric(symbols);
            string channel = string.Format("orderbook/{0}/{0}/batch", depth, speed);
            
            MakeSubscriptionWithInterceptors<WSOrderBook>(channel, @params, notificationAction, resultAction);
        }
        public void SubscribeToTopOfOrderBook(Action<Dictionary<string, WSOrderBookTop>, NotificationType> notificationAction, OBSpeed speed, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder @params = new ParamsBuilder().SymbolListOrAsteric(symbols);
            string channel = string.Format("orderbook/top/{0}", speed);
            
            MakeSubscriptionWithInterceptors<WSOrderBookTop>(channel, @params, notificationAction, resultAction);
        }
        public void SubscribeToTopOfOrderBookInBatches(Action<Dictionary<string, WSOrderBookTop>, NotificationType> notificationAction, OBSpeed speed, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction)
        {
            ParamsBuilder @params = new ParamsBuilder().SymbolListOrAsteric(symbols);
            string channel = string.Format("orderbook/top/{0}/batch", speed);
            
            MakeSubscriptionWithInterceptors<WSOrderBookTop>(channel, @params, notificationAction, resultAction);
        }
    }
}