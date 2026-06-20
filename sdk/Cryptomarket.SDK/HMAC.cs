using Org.BouncyCastle.Utilities.Encoders;

using System.Security.Cryptography;
using System.Text;

namespace CryptoMarket.SDK
{
    /// <summary>
    /// Generates the credential for authenticated communication with the server
    /// </summary>
    public class HMAC(string apiKey, string apiSecret, int window)
    {
        private string ApiSecret = apiSecret;
        private string ApiKey = apiKey;
        private int Window = window;

        public virtual string GetApiKey()
        {
            return ApiKey;
        }
        public virtual string GetApiSecret()
        {
            return ApiSecret;
        }
        public virtual string? GetCredential(string method, string body, string url)
        {
            string timestamp = string.Format("{0:D9}", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
            string message = new StringBuilder()
                .Append(method)
                .Append(url)
                .Append((method.Equals("GET") && body != null) ? "?" : "")
                .Append(body ?? "")
                .Append(timestamp)
                .Append(Window != 0 ? Window : "")
            .ToString();

            try
            {
                string? signature = Sign(ApiSecret, message);
                string signed = new StringBuilder()
                    .Append(ApiKey)
                    .Append(':')
                    .Append(signature)
                    .Append(':')
                    .Append(timestamp)
                    .Append(Window != 0 ? ":" : "")
                    .Append(Window != 0 ? Window : "")
                .ToString();
                byte[] strBytes = Encoding.ASCII.GetBytes(signed);
                string authStr = Base64.ToBase64String(strBytes).Trim();
                return "HS256 " + authStr;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public virtual int GetWindow()
        {
            return Window;
        }
        public static string? Sign(string key, string message)
        {
            try
            {
                byte[] keyBytes = Encoding.ASCII.GetBytes(key);
                byte[] messageBytes = Encoding.ASCII.GetBytes(message);

                using HMACSHA256 hmac = new(keyBytes);
                byte[] macData = hmac.ComputeHash(messageBytes);

                return Convert.ToHexString(macData).ToLowerInvariant();
            }
            catch
            {
                return null;
            }
        }
    }
}