
namespace Cryptomarket.SDK.Websocket
{
    public interface IWSHandler : ICryptomarketWS
    {
        void Handle(string json);
    }
}