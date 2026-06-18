using Java.Io;
using Java.Util;
using Java.Util.Function;
using Cryptomarket.SDK;
using Cryptomarket.SDK.Exceptions;
using Cryptomarket.SDK.Websocket.Interceptors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.SDK.Websocket.AccountType;
using static Cryptomarket.SDK.Websocket.ContingencyType;
using static Cryptomarket.SDK.Websocket.Depth;
using static Cryptomarket.SDK.Websocket.IdentifyBy;
using static Cryptomarket.SDK.Websocket.NotificationType;
using static Cryptomarket.SDK.Websocket.OBSpeed;
using static Cryptomarket.SDK.Websocket.OrderBy;
using static Cryptomarket.SDK.Websocket.OrderStatus;
using static Cryptomarket.SDK.Websocket.OrderType;
using static Cryptomarket.SDK.Websocket.Period;
using static Cryptomarket.SDK.Websocket.PriceSpeed;
using static Cryptomarket.SDK.Websocket.ReportType;
using static Cryptomarket.SDK.Websocket.Side;
using static Cryptomarket.SDK.Websocket.Sort;
using static Cryptomarket.SDK.Websocket.SortBy;
using static Cryptomarket.SDK.Websocket.SubAccountStatus;
using static Cryptomarket.SDK.Websocket.SubAccountTransferType;
using static Cryptomarket.SDK.Websocket.SubscriptionMode;
using static Cryptomarket.SDK.Websocket.TickerSpeed;
using static Cryptomarket.SDK.Websocket.TimeInForce;
using static Cryptomarket.SDK.Websocket.TransactionStatus;
using static Cryptomarket.SDK.Websocket.TransactionSubtype;
using static Cryptomarket.SDK.Websocket.TransactionType;
using static Cryptomarket.SDK.Websocket.UseOffchain;
using static Cryptomarket.SDK.Websocket.HttpMethod;

namespace Cryptomarket.SDK.Websocket
{
    public class AuthClient : ClientBase
    {
        private string apiSecret;
        private string apiKey;
        private int window;
        private Action afterAuth = () => { };
        private Action authOnConnect = () =>
        {
            Authenticate((success, exception) =>
            {
                if (exception != null)
                {
                    GetOnFailure().Accept(exception);
                    return;
                }

                if (!success)
                {
                    GetOnFailure().Accept(new CryptomarketSDKException("authorization failed: unsuccessful authorization request"));
                }

                afterAuth.Invoke();
            });
        };
        public AuthClient(string url, string apiKey, string apiSecret, int window) : base(url)
        {
            this.apiKey = apiKey;
            this.apiSecret = apiSecret;
            this.window = window;
            base.OnConnect(authOnConnect);
        }

        public override void OnConnect(Action onConnect)
        {
            afterAuth = onConnect;
        }

        public AuthClient(string url, string apiKey, string apiSecret) : this(url, apiKey, apiSecret, 0) { }
        public virtual void Authenticate(Action<bool, CryptomarketSDKException> resultBiConsumer)
        {
            Dictionary<string, object> @params = [];
            long timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            string strTimestamp = string.Format("{0:D9}", timestamp);
            @params.Add("type", "HS256");
            @params.Add("api_key", apiKey);
            @params.Add("timestamp", timestamp);
            string toSign = strTimestamp;
            if (window != 0)
            {
                @params.Add("window", window);
                toSign += window.ToString();
            }

            @params.Add("signature", HMAC.Sign(apiSecret, toSign));
            Interceptor interceptor = (resultBiConsumer == null) ? null : InterceptorFactory.NewOfWSResponseObject<bool>(resultBiConsumer);
            SendById("login", @params, interceptor);
        }
    }
}