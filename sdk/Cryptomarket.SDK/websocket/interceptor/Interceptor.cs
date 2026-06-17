using Cryptomarket.SDK.Models;

namespace Cryptomarket.SDK.Websocket.Interceptor
{
    public abstract class Interceptor
    {
        public Adapter Adapter { get; } = new();

        public virtual void MakeCall(WSJsonResponse response) { }
        public virtual void MakeCall(OrderBook orderBook) { }
        public virtual void MakeCall(ErrorBody error) { }
    }
}