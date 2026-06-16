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
    public interface CryptomarketWSMarketDataClient : CryptomarketWS
    {
        void SubscribeToTrades(BiConsumer<Dictionary<string, IList<WSPublicTrade>>, NotificationType> notificationBiConsumer, IList<string> symbols, int limit, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer);
        void SubscribeToCandles(BiConsumer<Dictionary<string, IList<WSCandle>>, NotificationType> notificationBiConsumer, Period period, IList<string> symbols, int limit, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer);
        void SubscribeToConvertedCandles(BiConsumer<Dictionary<string, IList<WSCandle>>, NotificationType> notificationBiConsumer, string targetCurrency, Period period, IList<string> symbols, int limit, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer);
        void SubscribeToPriceRates(BiConsumer<Dictionary<string, WSPriceRate>, NotificationType> notificationBiConsumer, PriceSpeed speed, string targetCurrency, IList<string> currencies, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer);
        void SubscribeToPriceRatesInBatches(BiConsumer<Dictionary<string, WSPriceRate>, NotificationType> notificationBiConsumer, PriceSpeed speed, string targetCurrency, IList<string> currencies, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer);
        void SubscribeToMiniTicker(BiConsumer<Dictionary<string, WSCandle>, NotificationType> notificationBiConsumer, TickerSpeed speed, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer);
        void SubscribeToMiniTickerInBatches(BiConsumer<Dictionary<string, WSCandle>, NotificationType> notificationBiConsumer, TickerSpeed speed, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer);
        void SubscribeToTicker(BiConsumer<Dictionary<string, WSTicker>, NotificationType> notificationBiConsumer, TickerSpeed speed, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer);
        void SubscribeToTickerInBatches(BiConsumer<Dictionary<string, WSTicker>, NotificationType> notificationBiConsumer, TickerSpeed speed, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer);
        void SubscribeToFullOrderBook(BiConsumer<Dictionary<string, WSOrderBook>, NotificationType> notificationBiConsumer, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer);
        void SubscribeToPartialOrderBook(BiConsumer<Dictionary<string, WSOrderBook>, NotificationType> notificationBiConsumer, Depth depth, OBSpeed speed, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer);
        void SubscribeToPartialOrderBookInBatches(BiConsumer<Dictionary<string, WSOrderBook>, NotificationType> notificationBiConsumer, Depth depth, OBSpeed speed, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer);
        void SubscribeToTopOfOrderBook(BiConsumer<Dictionary<string, WSOrderBookTop>, NotificationType> notificationBiConsumer, OBSpeed speed, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer);
        void SubscribeToTopOfOrderBookInBatches(BiConsumer<Dictionary<string, WSOrderBookTop>, NotificationType> notificationBiConsumer, OBSpeed speed, IList<string> symbols, BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer);
    }
}