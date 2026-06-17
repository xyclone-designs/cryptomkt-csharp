using Java.Nio.Charset;
using Java.Util;
using Javax.Crypto;
using Javax.Crypto.Spec;
using Org.Apache.Commons.Codec.Binary;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.SDK.AccountType;
using static Cryptomarket.SDK.ContingencyType;
using static Cryptomarket.SDK.Depth;
using static Cryptomarket.SDK.IdentifyBy;
using static Cryptomarket.SDK.NotificationType;
using static Cryptomarket.SDK.OBSpeed;
using static Cryptomarket.SDK.OrderBy;
using static Cryptomarket.SDK.OrderStatus;
using static Cryptomarket.SDK.OrderType;
using static Cryptomarket.SDK.Period;
using static Cryptomarket.SDK.PriceSpeed;
using static Cryptomarket.SDK.ReportType;
using static Cryptomarket.SDK.Side;
using static Cryptomarket.SDK.Sort;
using static Cryptomarket.SDK.SortBy;
using static Cryptomarket.SDK.SubAccountStatus;
using static Cryptomarket.SDK.SubAccountTransferType;
using static Cryptomarket.SDK.SubscriptionMode;
using static Cryptomarket.SDK.TickerSpeed;
using static Cryptomarket.SDK.TimeInForce;
using static Cryptomarket.SDK.TransactionStatus;
using static Cryptomarket.SDK.TransactionSubtype;
using static Cryptomarket.SDK.TransactionType;
using static Cryptomarket.SDK.UseOffchain;

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

        public virtual string GetCredential(string method, string body, string url)
        {
            string timestamp = String.Format("%d", System.CurrentTimeMillis());
            string message = new StringBuffer().Append(method).Append(url).Append((method.Equals("GET") && body != null) ? "?" : "").Append((body != null) ? body : "").Append(timestamp).Append(window != 0 ? window : "").ToString();
            try
            {
                string signature = HMAC.Sign(this.apiSecret, message);
                string signed = new StringBuffer().Append(this.apiKey).Append(":").Append(signature).Append(":").Append(timestamp).Append(window != 0 ? ":" : "").Append(window != 0 ? window : "").ToString();
                byte[] strBytes = signed.GetBytes(charset);
                string authStr = Base64.GetEncoder().EncodeToString(strBytes).Trim();
                return "HS256 " + authStr;
            }
            catch (Exception e)
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