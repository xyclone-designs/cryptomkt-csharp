
namespace Cryptomarket.SDK.Websocket.Interceptors
{
    public class InterceptorCache
    {
        private readonly Dictionary<string, Interceptor> subscriptionInterceptors = [];
        private readonly Dictionary<string, RecallableIntercaptor> interceptors = [];
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
            
            interceptors.Add(id.ToString(), new RecallableIntercaptor(interceptor, callCount));

            return id;
        }

        public virtual Interceptor? GetInterceptor(int id)
        {
            var recallableInterceptor = interceptors[id.ToString()];

            if (recallableInterceptor == null)
                return null;

            var interceptor = recallableInterceptor.GetInterceptor();

            if (recallableInterceptor.DoneRecalling())
                subscriptionInterceptors.Remove(id.ToString());

            return interceptor;
        }

        public virtual void StoreSubscriptionInterceptor(string key, Interceptor interceptor)
        {
            subscriptionInterceptors.Add(key, interceptor);
        }

        public virtual Interceptor? GetSubscriptionInterceptor(string key)
        {
            if (!subscriptionInterceptors.TryGetValue(key, out Interceptor? value))
                return null;

            return value;
        }

        public virtual void DeleteSubscriptionInterceptor(string key)
        {
            subscriptionInterceptors.Remove(key);
        }
    }
}