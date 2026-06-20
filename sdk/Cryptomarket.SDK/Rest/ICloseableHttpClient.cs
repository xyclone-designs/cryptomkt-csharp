
namespace CryptoMarket.SDK.Rest
{
    public interface ICloseableHttpClient : IDisposable
    {
        void ChangeCredentials(string apiKey, string apiSecret);
        void ChangeWindow(int window);

        string PublicGet(string endpoint, Dictionary<string, string>? @params);
        string Get(string endpoint, Dictionary<string, string>? @params);
        string Post(string endpoint, string payload);
        string Post(string endpoint, Dictionary<string, string>? payload);
        string Put(string endpoint, Dictionary<string, string>? @params);
        string Patch(string endpoint, Dictionary<string, string>? @params);
        string Delete(string endpoint, Dictionary<string, string>? @params);
    }
}