using Java.Util;
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
    public class InterceptorCache
    {
        private Dictionary<string, Interceptor> subscriptionInterceptors = new HashMap<string, Interceptor>();
        private Dictionary<string, RecallableIntercaptor> interceptors = new HashMap<string, RecallableIntercaptor>();
        private int nextId = 1;
        private int GetNextId()
        {
            int next = nextId;
            nextId++;
            if (nextId <= 0)
                nextId = 1;
            return next;
        }

        public virtual int SaveInterceptor(Interceptor interceptor)
        {
            return SaveInterceptor(interceptor, 1);
        }

        public virtual int SaveInterceptor(Interceptor interceptor, int callCount)
        {
            int id = GetNextId();
            interceptors.Put(id.ToString(), new RecallableIntercaptor(interceptor, callCount));
            return id;
        }

        public virtual Optional<Interceptor> GetInterceptor(int id)
        {
            var recallableInterceptor = interceptors[id.ToString()];
            if (recallableInterceptor == null)
            {
                return Optional.Empty();
            }

            var interceptor = recallableInterceptor.GetInterceptor();
            if (recallableInterceptor.DoneRecalling())
            {
                subscriptionInterceptors.Remove(id.ToString());
            }

            return interceptor;
        }

        public virtual void StoreSubscriptionInterceptor(string key, Interceptor interceptor)
        {
            this.subscriptionInterceptors.Put(key, interceptor);
        }

        public virtual Interceptor GetSubscriptionInterceptor(string key)
        {
            if (!this.subscriptionInterceptors.ContainsKey(key))
                return null;
            return this.subscriptionInterceptors[key];
        }

        public virtual void DeleteSubscriptionInterceptor(string key)
        {
            this.subscriptionInterceptors.Remove(key);
        }
    }
}