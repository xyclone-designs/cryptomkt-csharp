
namespace CryptoMarket.SDK.Websocket.Interceptors
{
    public class RecallableIntercaptor(Interceptor interceptor, int callCount = 1)
    {
        private Interceptor Interceptor { get; } = interceptor;
        private int CallCount { get; set; } = callCount;

        public virtual Interceptor? GetInterceptor()
        {
            if (CallCount < 1)
                return null;

            CallCount--;
            return Interceptor;
        }

        public virtual bool DoneRecalling()
        {
            return CallCount < 1;
        }
    }
}