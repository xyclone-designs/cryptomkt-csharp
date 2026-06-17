
namespace Cryptomarket.SDK.Rest
{
    public interface IAuthenticator
    {
        string GetCredential(string method, string body, string url);
    }
}