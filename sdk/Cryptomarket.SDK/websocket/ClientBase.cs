using Java.Io;
using Java.Util;
using Java.Util.Function;
using Cryptomarket.SDK;
using Cryptomarket.SDK.Exceptions;
using Cryptomarket.SDK.Models;
using Cryptomarket.SDK.Websocket.Interceptor;
using Com.Squareup.Moshi;
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
    public class ClientBase : WSHandler
    {
        InterceptorCache interceptorCache = new InterceptorCache();
        OrderbookCache OBCache = new OrderbookCache();
        public Adapter adapter = new Adapter();
        protected WebSocketConnection websocket;
        private Dictionary<string, string> subscriptionKeys;
        protected Runnable onConnectR = () =>
        {
        };
        private Consumer<string> onCloseC = (reason) =>
        {
        };
        private Consumer<Exception> onFailureC = (exception) =>
        {
        };
        class Payload
        {
            string method;
            string channel;
            Dictionary<string, object> params;
            int id;
            public Payload(string method, Dictionary<string, object> @params)
            {
                this.method = method;
                this.@params = @params;
            }

            public Payload(string method, string channel, Dictionary<string, object> @params)
            {
                this.method = method;
                this.channel = channel;
                this.@params = @params;
            }
        }

        JsonAdapter<Payload> payloadAdapter;
        protected ClientBase(string url)
        {
            Moshi moshi = new Builder().Build();
            payloadAdapter = moshi.Adapter(typeof(Payload));
            this.subscriptionKeys = new HashMap<string, string>();
            websocket = new WebSocketConnection(this, url);
        }

        protected virtual Dictionary<string, string> GetSubscritpionKeys()
        {
            return this.subscriptionKeys;
        }

        protected virtual void SendSubscription(string method, Dictionary<string, object> @params, Interceptor feedInterceptor, Interceptor resultInterceptor)
        {
            string key = BuildKey(method, @params);
            interceptorCache.StoreSubscriptionInterceptor(key, feedInterceptor);
            SendById(method, @params, resultInterceptor);
        }

        protected virtual void SendUnsubscription(string method, Dictionary<string, object> @params, Interceptor interceptor)
        {
            string key = BuildKey(method, @params);
            interceptorCache.DeleteSubscriptionInterceptor(key);
            SendById(method, @params, interceptor);
        }

        protected virtual void SendById(string method, Dictionary<string, object> @params, Interceptor interceptor)
        {
            SendById(method, @params, interceptor, 1);
        }

        protected virtual void SendById(string method, Dictionary<string, object> @params, Interceptor interceptor, int callCount)
        {
            Payload payload = new Payload(method, @params);
            if (interceptor != null)
            {
                int id = interceptorCache.SaveInterceptor(interceptor, callCount);
                payload.id = id;
            }

            string json = payloadAdapter.ToJson(payload);
            websocket.Send(json);
        }

        public virtual void Handle(string json)
        {
            WSJsonResponse response = adapter.ObjectFromJson(json, typeof(WSJsonResponse));
            if (response.GetId() != null)
            {
                HandleResponse(response);
            }
            else if (response.GetMethod() != null)
            {
                HandleNotification(response);
            }
        }

        protected virtual void HandleNotification(WSJsonResponse response)
        {
            string key = BuildKey(response.GetMethod());
            Interceptor interceptor = interceptorCache.GetSubscriptionInterceptor(key);
            if (interceptor != null)
                interceptor.MakeCall(response);
        }

        protected virtual void HandleResponse(WSJsonResponse response)
        {
            var interceptor = interceptorCache.GetInterceptor(response.GetId());
            if (interceptor.IsEmpty())
            {
                return;
            }

            interceptor.Get().MakeCall(response);
        }

        protected virtual string BuildKey(string method)
        {
            if (subscriptionKeys.ContainsKey(method))
            {
                return this.subscriptionKeys[method];
            }

            return "suscription";
        }

        protected virtual string BuildKey(string method, Dictionary<string, object> @params)
        {
            return BuildKey(method);
        }

        public virtual void Dispose()
        {
            websocket.Dispose();
        }

        public virtual void Connect()
        {
            websocket.Run();
        }

        public virtual void OnConnect(Runnable onConnect)
        {
            this.onConnectR = onConnect;
        }

        public virtual Runnable GetOnConnect()
        {
            return onConnectR;
        }

        public virtual void OnClose(Consumer<string> onClose)
        {
            this.onCloseC = onClose;
        }

        public virtual Consumer<string> GetOnClose()
        {
            return onCloseC;
        }

        public virtual void OnFailure(Consumer<Exception> onFailure)
        {
            this.onFailureC = onFailure;
        }

        public virtual Consumer<Exception> GetOnFailure()
        {
            return onFailureC;
        }
    }
}