
namespace Cryptomarket.SDK.Websocket
{
    public interface ICryptomarketWS : IDisposable
    {
        void Connect();
        
        Action<Exception> OnFailure { get; set; }
        Action<string> OnClose { get; set; }
        Action OnConnect { get; set; }
    }
}