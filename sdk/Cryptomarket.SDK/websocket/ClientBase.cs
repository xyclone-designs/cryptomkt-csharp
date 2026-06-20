using CryptoMarket.SDK.Models;
using CryptoMarket.SDK.Websocket.Interceptors;

using System.Text.Json;

namespace CryptoMarket.SDK.Websocket
{
    public class ClientBase : IWSHandler
    {
        protected InterceptorCache interceptorCache = new ();
        protected OrderbookCache OBCache = new ();
        protected WebSocketConnection websocket;
        protected Dictionary<string, string> subscriptionKeys;

        protected ClientBase(string url)
        {
            subscriptionKeys = [];
            websocket = new WebSocketConnection(this, url);
        }

        public virtual Action OnConnect { get; set; } = () => { };
        public virtual Action<string> OnClose { get; set; } = _ => { };
        public virtual Action<Exception> OnFailure { get; set; } = _ => { };

        protected virtual Dictionary<string, string> SubscritpionKeys { get; set; }

        public virtual async void Connect()
        {
            await websocket.RunAsync();
        }
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Handle(string json)
        {
            WSJsonResponse response = JsonSerializer.Deserialize<WSJsonResponse>(json);

            if (response.Id != null)
                HandleResponse(response);
            else if (response.Method != null)
                HandleNotification(response);
        }

        protected virtual string BuildKey(string method)
        {
            if (subscriptionKeys.TryGetValue(method, out string? value) && value is not null)
                return value;

            return "suscription";
        }
        protected virtual string BuildKey(string method, Dictionary<string, object> @params)
        {
            return BuildKey(method);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                websocket.Dispose();
            }
        }

        protected virtual void HandleNotification(WSJsonResponse response)
        {
            string key = BuildKey(response.Method);
            
            interceptorCache
                .GetSubscriptionInterceptor(key)?
                .MakeCall(response);
        }
        protected virtual void HandleResponse(WSJsonResponse response)
        {
            if (response.Id is null || interceptorCache.GetInterceptor(response.Id.Value) is not Interceptor interceptor)
                return;

            interceptor.MakeCall(response);
        }

        protected virtual void SendById(string method, Dictionary<string, object> @params, Interceptor interceptor)
        {
            SendById(method, @params, interceptor, 1);
        }
        protected virtual void SendById(string method, Dictionary<string, object> @params, Interceptor interceptor, int callCount)
        {
            Payload payload = new (method, @params);

            if (interceptor != null)
            {
                int id = interceptorCache.SaveInterceptor(interceptor, callCount);
                payload.Id = id;
            }

            string json = JsonSerializer.Serialize(payload);

            websocket.Send(json);
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

        internal class Payload
        {
            public int Id;
            public string Method;
            public string? Channel;
            public Dictionary<string, object> Params;

            public Payload(string method, Dictionary<string, object> @params)
            {
                Method = method;
                Params = @params;
            }
            public Payload(string method, string channel, Dictionary<string, object> @params)
            {
                Method = method;
                Channel = channel;
                Params = @params;
            }
        }
    }
}