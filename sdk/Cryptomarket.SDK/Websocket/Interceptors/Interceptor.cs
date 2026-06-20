using CryptoMarket.SDK.Models;

namespace CryptoMarket.SDK.Websocket.Interceptors
{
    public abstract class Interceptor
    {
        public virtual void MakeCall(WSJsonResponse response) { }
        public virtual void MakeCall(OrderBook orderBook) { }
        public virtual void MakeCall(ErrorBody error) { }
    }
}