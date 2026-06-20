using System.Text;
using System.Text.Json;

using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Models;

namespace CryptoMarket.SDK.Rest
{
    public class HttpClientImpl : ICloseableHttpClient
    {
        private static readonly string APPLICATION_JSON = "application/json";
        private static readonly string USER_AGENT = "cryptomarket/csharp";
        private static readonly string APPLICATION_X_WWW_FORM_URLENCODED = "application/x-www-form-urlencoded";

        private readonly string url;
        private readonly string apiVersion;
        private readonly HttpClient client;
        private HMAC hmac;

        public HttpClientImpl(string url, string apiVersion, string apiKey, string apiSecret)
            : this(url, apiVersion, apiKey, apiSecret, 0) { }

        public HttpClientImpl(HttpClient client, string url, string apiVersion, string apiKey, string apiSecret)
            : this(client, url, apiVersion, apiKey, apiSecret, 0) { }

        public HttpClientImpl(string url, string apiVersion, string apiKey, string apiSecret, int window)
        {
            this.client = new HttpClient();
            this.hmac = new HMAC(apiKey, apiSecret, window);
            this.url = url;
            this.apiVersion = apiVersion;
        }

        public HttpClientImpl(HttpClient client, string url, string apiVersion, string apiKey, string apiSecret, int window)
        {
            this.client = client;
            this.hmac = new HMAC(apiKey, apiSecret, window);
            this.url = url;
            this.apiVersion = apiVersion;
        }

        public virtual void ChangeCredentials(string apiKey, string apiSecret)
        {
            this.hmac = new HMAC(apiKey, apiSecret, hmac.GetWindow());
        }

        public virtual void ChangeWindow(int window)
        {
            this.hmac = new HMAC(hmac.GetApiKey(), hmac.GetApiSecret(), window);
        }

        public virtual void Dispose()
        {
            client.Dispose();
        }

        public virtual string PublicGet(string endpoint, Dictionary<string, string> @params)
        {
            Uri uri;
            try
            {
                uri = BuildUriWithParams(url + apiVersion + endpoint, @params, sorted: false);
            }
            catch (UriFormatException e)
            {
                throw new CryptoMarketSDKException("Failed to build the uri", e);
            }

            using var request = new HttpRequestMessage(HttpMethod.Get, uri);
            AddCommonHeaders(request);
            return MakeRequest(request);
        }

        public virtual string Get(string endpoint, Dictionary<string, string> @params)
        {
            Uri uri = BuildUri(endpoint, @params);

            using var request = new HttpRequestMessage(HttpMethod.Get, uri);
            string query = uri.Query.TrimStart('?');
            string credential = hmac.GetCredential(HttpMethod.Get.Method, query, uri.AbsolutePath);
            request.Headers.TryAddWithoutValidation("Authorization", credential);
            AddCommonHeaders(request);
            return MakeRequest(request);
        }

        private Uri BuildUri(string endpoint, Dictionary<string, string> @params)
        {
            try
            {
                return BuildUriWithParams(url + apiVersion + endpoint, @params, sorted: true);
            }
            catch (UriFormatException e)
            {
                throw new CryptoMarketSDKException("Failed to build the uri", e);
            }
        }

        private Uri BuildUriWithParams(string baseUrl, Dictionary<string, string> @params, bool sorted)
        {
            if (@params == null || @params.Count == 0)
                return new Uri(baseUrl);

            IEnumerable<KeyValuePair<string, string>> entries = sorted
                ? @params.OrderBy(e => e.Key)
                : (IEnumerable<KeyValuePair<string, string>>)@params;

            var query = string.Join("&", entries.Select(e =>
                Uri.EscapeDataString(e.Key) + "=" + Uri.EscapeDataString(e.Value)));

            return new Uri(baseUrl + "?" + query);
        }

        public virtual string Post(string endpoint, Dictionary<string, string> payload)
        {
            string strPayload = "";
            if (payload != null)
                strPayload = System.Text.Json.JsonSerializer.Serialize(payload);
            return Post(endpoint, strPayload);
        }

        public virtual string Post(string endpoint, string payload)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, url + apiVersion + endpoint);
            AddCommonHeaders(request);

            if (!string.IsNullOrEmpty(payload))
            {
                request.Content = new StringContent(payload, Encoding.UTF8, APPLICATION_JSON);
            }

            string credential = hmac.GetCredential(HttpMethod.Post.Method, payload ?? "", apiVersion + endpoint);
            request.Headers.TryAddWithoutValidation("Authorization", credential);
            return MakeRequest(request);
        }

        public virtual string Put(string endpoint, Dictionary<string, string> @params)
        {
            using var request = new HttpRequestMessage(HttpMethod.Put, url + apiVersion + endpoint);
            AddCommonHeaders(request);

            string body = "";
            if (@params != null)
            {
                body = ToUrlEncodedString(@params);
                request.Content = new StringContent(body, Encoding.UTF8, APPLICATION_X_WWW_FORM_URLENCODED);
            }

            string credential = hmac.GetCredential(HttpMethod.Put.Method, body, apiVersion + endpoint);
            request.Headers.TryAddWithoutValidation("Authorization", credential);
            request.Headers.Accept.ParseAdd(APPLICATION_JSON);
            return MakeRequest(request);
        }

        public virtual string Patch(string endpoint, Dictionary<string, string> @params)
        {
            using var request = new HttpRequestMessage(new HttpMethod("PATCH"), url + apiVersion + endpoint);
            AddCommonHeaders(request);

            string body = "";
            if (@params != null)
            {
                body = ToUrlEncodedString(@params);
                request.Content = new StringContent(body, Encoding.UTF8, APPLICATION_X_WWW_FORM_URLENCODED);
            }

            string credential = hmac.GetCredential("PATCH", body, apiVersion + endpoint);
            request.Headers.TryAddWithoutValidation("Authorization", credential);
            request.Headers.Accept.ParseAdd(APPLICATION_JSON);
            return MakeRequest(request);
        }

        public virtual string Delete(string endpoint, Dictionary<string, string> @params)
        {
            using var request = new HttpRequestMessage(HttpMethod.Delete, url + apiVersion + endpoint);
            AddCommonHeaders(request);

            string body = "";
            if (@params != null)
            {
                body = ToUrlEncodedString(@params);
                request.Content = new StringContent(body, Encoding.UTF8, APPLICATION_X_WWW_FORM_URLENCODED);
            }

            string credential = hmac.GetCredential("DELETE", body, apiVersion + endpoint);
            request.Headers.TryAddWithoutValidation("Authorization", credential);
            request.Headers.Accept.ParseAdd(APPLICATION_JSON);
            return MakeRequest(request);
        }

        private string ToUrlEncodedString(Dictionary<string, string> @params)
        {
            return string.Join("&", @params.Select(e =>
                Uri.EscapeDataString(e.Key) + "=" + Uri.EscapeDataString(e.Value)));
        }

        private void AddCommonHeaders(HttpRequestMessage request)
        {
            request.Headers.Connection.ParseAdd("Keep-Alive");
            request.Headers.UserAgent.ParseAdd(USER_AGENT);
        }

        private string MakeRequest(HttpRequestMessage request)
        {
            HttpResponseMessage response;
            string responseBody;
            bool isSuccessful;

            try
            {
                response = client.SendAsync(request).GetAwaiter().GetResult();
            }
            catch (Exception err)
            {
                throw new CryptoMarketSDKException("Couldn't make the call", err);
            }

            try
            {
                responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                isSuccessful = response.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception err)
            {
                throw new CryptoMarketSDKException("Couldn't parse the response body", err);
            }
            finally
            {
                response.Dispose();
            }

            if (isSuccessful)
                return responseBody;

            try
            {
                ErrorResponse errorResponse = JsonSerializer.Deserialize<ErrorResponse>(responseBody);
                ErrorBody errorBody = errorResponse.Error;
                throw new CryptoMarketAPIException(errorBody);
            }
            catch (CryptoMarketAPIException)
            {
                throw;
            }
            catch (Exception err)
            {
                throw new CryptoMarketSDKException("Couldn't parse the error: " + responseBody, err);
            }
        }
    }
}