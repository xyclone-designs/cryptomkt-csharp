
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