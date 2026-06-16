using Java.Io;
using Java.Util.Concurrent;
using Cryptomarket.SDK.Exceptions;
using Okhttp3;
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
using static Cryptomarket.SDK.Websocket.OrderBookState;

namespace Cryptomarket.SDK.Websocket
{
    public class WebSocketConnection : WebSocketListener
    {
        WebSocket websocket;
        WSHandler handler;
        string url;
        public WebSocketConnection(WSHandler handler, string url)
        {
            this.handler = handler;
            this.url = url;
        }

        virtual void Run()
        {
            OkHttpClient client = new Builder().ReadTimeout(10, TimeUnit.SECONDS).Build();
            Request request = new Builder().Url(this.url).Build();
            websocket = client.NewWebSocket(request, this);
            client.Dispatcher().ExecutorService().Shutdown();
        }

        public override void OnOpen(WebSocket webSocket, Response response)
        {
            handler.GetOnConnect().Run();
        }

        public override void OnClosed(WebSocket webSocket, int code, string reason)
        {
            handler.GetOnClose().Accept(reason);
        }

        public override void OnMessage(WebSocket webSocket, string text)
        {
            try
            {
                handler.Handle(text);
            }
            catch (CryptomarketSDKException e)
            {
                e.PrintStackTrace();
            }
        }

        /// <summary>
        /// The peer ask for close to this socket
        /// </summary>
        public override void OnClosing(WebSocket webSocket, int code, string reason)
        {
            webSocket.Dispose(1000, null);
        }

        public override void OnFailure(WebSocket webSocket, Exception t, Response response)
        {
            handler.GetOnFailure().Accept(t);
        }

        public virtual void Send(string json)
        {
            websocket.Send(json);
        }

        /// <summary>
        /// this socket ask for close to the peer
        /// </summary>
        public virtual void Dispose()
        {
            websocket.Dispose(1000, null);
        }
    }
}