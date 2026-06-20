
namespace CryptoMarket.SDK.Websocket
{
    public interface ICryptoMarketWS : IDisposable
    {
        void Connect();
        
        Action<Exception> OnFailure { get; set; }
        Action<string> OnClose { get; set; }
        Action OnConnect { get; set; }
    }
}