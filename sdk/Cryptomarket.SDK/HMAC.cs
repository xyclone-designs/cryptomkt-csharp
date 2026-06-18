using Org.BouncyCastle.Utilities.Encoders;

using System.Text;

namespace Cryptomarket.SDK
{
    /// <summary>
    /// Generates the credential for authenticated communication with the server
    /// </summary>
    public class HMAC
    {
        private static string HMAC_SHA256 = "HmacSHA256";
        private static Charset charset = Charset.ForName("US-ASCII");
        // private static Charset charset = Charset.forName("UTF-8");
        private string apiSecret;
        private string apiKey;
        private int window;

        public HMAC(string apiKey, string apiSecret, int window)
        {
            this.apiKey = apiKey;
            this.apiSecret = apiSecret;
            this.window = window;
        }

        public virtual int GetWindow()
        {
            return window;
        }

        public virtual string GetApiSecret()
        {
            return apiSecret;
        }

        public virtual string GetApiKey()
        {
            return apiKey;
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
                .Append(window != 0 ? window : "")
            .ToString();

            try
            {
                string? signature = Sign(apiSecret, message);
                string signed = new StringBuilder()
                    .Append(apiKey)
                    .Append(':')
                    .Append(signature)
                    .Append(':')
                    .Append(timestamp)
                    .Append(window != 0 ? ":" : "")
                    .Append(window != 0 ? window : "")
                .ToString();
                byte[] strBytes = signed.GetBytes(charset);
                string authStr = Base64.ToBase64String(strBytes).Trim();
                return "HS256 " + authStr;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string? Sign(string key, string message)
        {
            SecretKeySpec keySpec = new SecretKeySpec(key.GetBytes(charset), HMAC_SHA256);
            Mac sha256Hmac;
            try
            {
                sha256Hmac = Mac.GetInstance(HMAC_SHA256);
                sha256Hmac.Init(keySpec);
                byte[] macData = sha256Hmac.DoFinal(message.GetBytes(charset));
                
                return Hex.ToHexString(macData);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}