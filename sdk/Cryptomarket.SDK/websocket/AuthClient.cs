using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Websocket.Interceptors;

namespace CryptoMarket.SDK.Websocket
{
    public class AuthClient : ClientBase
    {
        private string apiSecret;
        private string apiKey;
        private int window;
        private Action AfterAuth 
        {
            set => OnConnect = value;
            get => OnConnect ??= () => { };
        }
        private Action AuthOnConnect 
        {
            get => field ??= () =>
            {
                Authenticate((success, exception) =>
                {
                    if (exception is not null)
                    {
                        OnFailure.Invoke(exception);
                        
                        return;
                    }

                    if (success is false)
                    {
                        OnFailure.Invoke(new CryptoMarketSDKException("authorization failed: unsuccessful authorization request"));
                    }
                });
            };
        }
        public AuthClient(string url, string apiKey, string apiSecret, int window) : base(url)
        {
            this.apiKey = apiKey;
            this.apiSecret = apiSecret;
            this.window = window;
            OnConnect = AuthOnConnect;
        }
        public AuthClient(string url, string apiKey, string apiSecret) : this(url, apiKey, apiSecret, 0) { }

        public virtual void Authenticate(Action<bool, CryptoMarketSDKException> resultAction)
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
            Interceptor interceptor = (resultAction == null) ? null : InterceptorFactory.NewOfWSResponseObject<bool>(resultAction);
            SendById("login", @params, interceptor);
        }
    }
}