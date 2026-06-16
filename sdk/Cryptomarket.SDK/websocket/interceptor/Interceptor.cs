using Cryptomarket.SDK;
using Cryptomarket.SDK.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.SDK.Websocket.Interceptor.AccountType;
using static Cryptomarket.SDK.Websocket.Interceptor.ContingencyType;
using static Cryptomarket.SDK.Websocket.Interceptor.Depth;
using static Cryptomarket.SDK.Websocket.Interceptor.IdentifyBy;
using static Cryptomarket.SDK.Websocket.Interceptor.NotificationType;
using static Cryptomarket.SDK.Websocket.Interceptor.OBSpeed;
using static Cryptomarket.SDK.Websocket.Interceptor.OrderBy;
using static Cryptomarket.SDK.Websocket.Interceptor.OrderStatus;
using static Cryptomarket.SDK.Websocket.Interceptor.OrderType;
using static Cryptomarket.SDK.Websocket.Interceptor.Period;
using static Cryptomarket.SDK.Websocket.Interceptor.PriceSpeed;
using static Cryptomarket.SDK.Websocket.Interceptor.ReportType;
using static Cryptomarket.SDK.Websocket.Interceptor.Side;
using static Cryptomarket.SDK.Websocket.Interceptor.Sort;
using static Cryptomarket.SDK.Websocket.Interceptor.SortBy;
using static Cryptomarket.SDK.Websocket.Interceptor.SubAccountStatus;
using static Cryptomarket.SDK.Websocket.Interceptor.SubAccountTransferType;
using static Cryptomarket.SDK.Websocket.Interceptor.SubscriptionMode;
using static Cryptomarket.SDK.Websocket.Interceptor.TickerSpeed;
using static Cryptomarket.SDK.Websocket.Interceptor.TimeInForce;
using static Cryptomarket.SDK.Websocket.Interceptor.TransactionStatus;
using static Cryptomarket.SDK.Websocket.Interceptor.TransactionSubtype;
using static Cryptomarket.SDK.Websocket.Interceptor.TransactionType;
using static Cryptomarket.SDK.Websocket.Interceptor.UseOffchain;
using static Cryptomarket.SDK.Websocket.Interceptor.HttpMethod;
using static Cryptomarket.SDK.Websocket.Interceptor.OrderBookState;

namespace Cryptomarket.SDK.Websocket.Interceptor
{
    public abstract class Interceptor
    {
        public Adapter adapter = new Adapter();
        public virtual void MakeCall(WSJsonResponse response)
        {
        }

        public virtual void MakeCall(OrderBook orderBook)
        {
        }

        public virtual void MakeCall(ErrorBody error)
        {
        }
    }
}