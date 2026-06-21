using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Models;

using CryptoMarket.SDK.Params;

namespace CryptoMarket.SDK.Websocket
{
    public interface ICryptoMarketWSMarketDataClient : ICryptoMarketWS
    {
        void SubscribeToTrades(Action<Dictionary<string, IList<WSPublicTrade>>, NotificationType> notificationAction, IList<string> symbols, int? limit, Action<IList<string>, CryptoMarketSDKException> resultAction);
        void SubscribeToCandles(Action<Dictionary<string, IList<WSCandle>>, NotificationType> notificationAction, Period period, IList<string> symbols, int? limit, Action<IList<string>, CryptoMarketSDKException> resultAction);
        void SubscribeToConvertedCandles(Action<Dictionary<string, IList<WSCandle>>, NotificationType> notificationAction, string targetCurrency, Period period, IList<string> symbols, int? limit, Action<IList<string>, CryptoMarketSDKException> resultAction);
        void SubscribeToPriceRates(Action<Dictionary<string, WSPriceRate>, NotificationType> notificationAction, PriceSpeed speed, string targetCurrency, IList<string> currencies, Action<IList<string>, CryptoMarketSDKException> resultAction);
        void SubscribeToPriceRatesInBatches(Action<Dictionary<string, WSPriceRate>, NotificationType> notificationAction, PriceSpeed speed, string targetCurrency, IList<string> currencies, Action<IList<string>, CryptoMarketSDKException> resultAction);
        void SubscribeToMiniTicker(Action<Dictionary<string, WSCandle>, NotificationType> notificationAction, TickerSpeed speed, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction);
        void SubscribeToMiniTickerInBatches(Action<Dictionary<string, WSCandle>, NotificationType> notificationAction, TickerSpeed speed, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction);
        void SubscribeToTicker(Action<Dictionary<string, WSTicker>, NotificationType> notificationAction, TickerSpeed speed, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction);
        void SubscribeToTickerInBatches(Action<Dictionary<string, WSTicker>, NotificationType> notificationAction, TickerSpeed speed, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction);
        void SubscribeToFullOrderBook(Action<Dictionary<string, WSOrderBook>, NotificationType> notificationAction, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction);
        void SubscribeToPartialOrderBook(Action<Dictionary<string, WSOrderBook>, NotificationType> notificationAction, Depth depth, OBSpeed speed, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction);
        void SubscribeToPartialOrderBookInBatches(Action<Dictionary<string, WSOrderBook>, NotificationType> notificationAction, Depth depth, OBSpeed speed, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction);
        void SubscribeToTopOfOrderBook(Action<Dictionary<string, WSOrderBookTop>, NotificationType> notificationAction, OBSpeed speed, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction);
        void SubscribeToTopOfOrderBookInBatches(Action<Dictionary<string, WSOrderBookTop>, NotificationType> notificationAction, OBSpeed speed, IList<string> symbols, Action<IList<string>, CryptoMarketSDKException> resultAction);
    }
}