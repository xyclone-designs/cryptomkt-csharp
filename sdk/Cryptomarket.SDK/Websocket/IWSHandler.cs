
namespace CryptoMarket.SDK.Websocket
{
    public interface IWSHandler : ICryptoMarketWS
    {
        void Handle(string json);
    }
}