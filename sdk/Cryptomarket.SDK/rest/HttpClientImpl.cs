using Java.Io;
using Java.Lang.Reflect;
using Java.Net;
using Java.Util;
using Org.Apache.Http;
using Org.Apache.Http.Client.Entity;
using Org.Apache.Http.Client.Methods;
using Org.Apache.Http.Client.Utils;
using Org.Apache.Http.Entity;
using Org.Apache.Http.Impl.Client;
using Org.Apache.Http.Message;
using Org.Apache.Http.Util;
using Org.Jetbrains.Annotations;
using Cryptomarket.SDK;
using Cryptomarket.SDK.Exceptions;
using Cryptomarket.SDK.Models;
using Com.Squareup.Moshi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.SDK.Rest.AccountType;
using static Cryptomarket.SDK.Rest.ContingencyType;
using static Cryptomarket.SDK.Rest.Depth;
using static Cryptomarket.SDK.Rest.IdentifyBy;
using static Cryptomarket.SDK.Rest.NotificationType;
using static Cryptomarket.SDK.Rest.OBSpeed;
using static Cryptomarket.SDK.Rest.OrderBy;
using static Cryptomarket.SDK.Rest.OrderStatus;
using static Cryptomarket.SDK.Rest.OrderType;
using static Cryptomarket.SDK.Rest.Period;
using static Cryptomarket.SDK.Rest.PriceSpeed;
using static Cryptomarket.SDK.Rest.ReportType;
using static Cryptomarket.SDK.Rest.Side;
using static Cryptomarket.SDK.Rest.Sort;
using static Cryptomarket.SDK.Rest.SortBy;
using static Cryptomarket.SDK.Rest.SubAccountStatus;
using static Cryptomarket.SDK.Rest.SubAccountTransferType;
using static Cryptomarket.SDK.Rest.SubscriptionMode;
using static Cryptomarket.SDK.Rest.TickerSpeed;
using static Cryptomarket.SDK.Rest.TimeInForce;
using static Cryptomarket.SDK.Rest.TransactionStatus;
using static Cryptomarket.SDK.Rest.TransactionSubtype;
using static Cryptomarket.SDK.Rest.TransactionType;
using static Cryptomarket.SDK.Rest.UseOffchain;

namespace Cryptomarket.SDK.Rest
{
    public class HttpClientImpl : CloseableHttpClient
    {
        private static readonly string APPLICATION_JSON = "application/json";
        private static readonly string USER_AGENT = "cryptomarket/java";
        private static readonly string APPLICATOIN_X_WWW_FORM_URLENCODED = "application/x-www-form-urlencoded";
        private readonly string url;
        private readonly string apiVersion;
        private readonly Moshi moshi = new Builder().Build();
        private readonly JsonAdapter<ErrorResponse> errorJsonAdapter = moshi.Adapter(typeof(ErrorResponse));
        private readonly ParameterizedType mapStringString = Types.NewParameterizedType(typeof(Dictionary), typeof(string), typeof(string));
        private readonly JsonAdapter<Dictionary<string, string>> mapStrStrJsonAdapter = moshi.Adapter(mapStringString);
        private readonly org.apache.http.impl.client.CloseableHttpClient client;
        private HMAC hmac;
        class HttpDeleteWithBody : HttpEntityEnclosingRequestBase
        {
            public static readonly string METHOD_NAME = "DELETE";
            public virtual string GetMethod()
            {
                return METHOD_NAME;
            }

            public HttpDeleteWithBody(string uri) : base()
            {
                SetURI(URI.Create(uri));
            }

            public HttpDeleteWithBody(URI uri) : base()
            {
                SetURI(uri);
            }

            public HttpDeleteWithBody() : base()
            {
            }
        }

        public HttpClientImpl(string url, string apiVersion, string apiKey, string apiSecret) : this(url, apiVersion, apiKey, apiSecret, 0)
        {
        }

        public HttpClientImpl(org.apache.http.impl.client.CloseableHttpClient client, string url, string apiVersion, string apiKey, string apiSecret) : this(client, url, apiVersion, apiKey, apiSecret, 0)
        {
        }

        public HttpClientImpl(string url, string apiVersion, string apiKey, string apiSecret, int window)
        {
            this.client = HttpClients.CreateDefault();
            this.hmac = new HMAC(apiKey, apiSecret, window);
            this.url = url;
            this.apiVersion = apiVersion;
        }

        public HttpClientImpl(org.apache.http.impl.client.CloseableHttpClient client, string url, string apiVersion, string apiKey, string apiSecret, int window)
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
            URI uri = null;
            try
            {
                URIBuilder uriBuilder = new URIBuilder(url + apiVersion + endpoint);
                if (@params != null)
                    @params.ForEach((key, val) => uriBuilder.AddParameter(key, val));
                uri = uriBuilder.Build();
            }
            catch (URISyntaxException e)
            {
                throw new CryptomarketSDKException("Failed to build the uri", e);
            }

            HttpGet httpGet = new HttpGet(uri);
            return MakeRequest(httpGet);
        }

        public virtual string Get(string endpoint, Dictionary<string, string> @params)
        {
            URI uri = BuildUri(endpoint, @params);
            HttpGet httpGet = new HttpGet(uri);
            new HttpPost(uri);
            string credential = hmac.GetCredential(HttpMethod.GET.ToString(), uri.GetQuery(), uri.GetPath());
            httpGet.SetHeader(HttpHeaders.AUTHORIZATION, credential);
            return MakeRequest(httpGet);
        }

        private URI BuildUri(string endpoint, Dictionary<string, string> @params)
        {
            try
            {
                URIBuilder uriBuilder = new URIBuilder(url + apiVersion + endpoint);
                if (@params != null)
                    @params.EntrySet().Stream().Sorted(Map.Entry.ComparingByKey()).ForEach((e) => uriBuilder.AddParameter(e.GetKey(), e.GetValue()));
                return uriBuilder.Build();
            }
            catch (URISyntaxException e)
            {
                throw new CryptomarketSDKException("Failed to build the uri", e);
            }
        }

        public virtual string Post(string endpoint, Dictionary<string, string> payload)
        {
            string strPayload = "";
            if (payload != null)
                strPayload = mapStrStrJsonAdapter.ToJson(payload);
            return Post(endpoint, strPayload);
        }

        public virtual string Post(string endpoint, string payload)
        {
            HttpPost httpPost = new HttpPost(url + apiVersion + endpoint);
            if (!payload.Equals(""))
            {
                httpPost.SetEntity(new StringEntity(payload, ContentType.APPLICATION_JSON));
                httpPost.SetHeader(HttpHeaders.CONTENT_TYPE, APPLICATION_JSON);
            }

            string credential = hmac.GetCredential(HttpMethod.POST.ToString(), payload, apiVersion + endpoint);
            httpPost.SetHeader(HttpHeaders.AUTHORIZATION, credential);
            return MakeRequest(httpPost);
        }

        public virtual string Put(string endpoint, Dictionary<string, string> @params)
        {
            HttpPut httpPut = new HttpPut(url + apiVersion + endpoint);
            UrlEncodedFormEntity entity = null;
            if (@params != null)
            {
                entity = ParamsToUrlEncodedEntity(@params);
                httpPut.SetEntity(entity);
            }

            AddAuthorizationHeader(httpPut, HttpMethod.PUT, endpoint, entity);
            httpPut.SetHeader(HttpHeaders.ACCEPT, APPLICATION_JSON);
            httpPut.SetHeader(HttpHeaders.CONTENT_TYPE, APPLICATOIN_X_WWW_FORM_URLENCODED);
            return MakeRequest(httpPut);
        }

        private HttpUriRequest AddAuthorizationHeader(HttpUriRequest request, HttpMethod method, string endpoint, HttpEntity entity)
        {
            string strEntity = EntityAsStr(entity);
            string credential = hmac.GetCredential(method.ToString(), strEntity, apiVersion + endpoint);
            request.SetHeader(HttpHeaders.AUTHORIZATION, credential);
            return request;
        }

        private string EntityAsStr(HttpEntity entity)
        {
            if (entity == null)
            {
                return "";
            }

            try
            {
                return EntityUtils.ToString(entity);
            }
            catch (ParseException e)
            {
                throw new CryptomarketSDKException("failed hmac authentication", e);
            }
            catch (IOException e)
            {
                throw new CryptomarketSDKException("failed hmac authentication", e);
            }
        }

        private UrlEncodedFormEntity ParamsToUrlEncodedEntity(Dictionary<string, string> @params)
        {
            IList<NameValuePair> form = new List();
            @params.ForEach((key, value) => form.Add(new BasicNameValuePair(key, value)));
            return new UrlEncodedFormEntity(form, Consts.UTF_8);
        }

        public virtual string Patch(string endpoint, Dictionary<string, string> @params)
        {
            HttpPatch httpPatch = new HttpPatch(url + apiVersion + endpoint);
            UrlEncodedFormEntity entity = null;
            if (@params != null)
            {
                entity = ParamsToUrlEncodedEntity(@params);
                httpPatch.SetEntity(entity);
            }

            try
            {
                string body = "";
                if (entity != null)
                    body = EntityUtils.ToString(entity);
                string credential = hmac.GetCredential("PATCH", body, apiVersion + endpoint);
                httpPatch.SetHeader(HttpHeaders.AUTHORIZATION, credential);
            }
            catch (Exception e)
            {
                throw new CryptomarketSDKException("failed hmac authentication", e);
            }

            httpPatch.SetHeader(HttpHeaders.ACCEPT, APPLICATION_JSON);
            httpPatch.SetHeader(HttpHeaders.CONTENT_TYPE, APPLICATOIN_X_WWW_FORM_URLENCODED);
            return MakeRequest(httpPatch);
        }

        public virtual string Delete(string endpoint, Dictionary<string, string> @params)
        {
            HttpDeleteWithBody httpDelete = new HttpDeleteWithBody(url + apiVersion + endpoint);
            UrlEncodedFormEntity entity = null;
            if (@params != null)
            {
                entity = ParamsToUrlEncodedEntity(@params);
                httpDelete.SetEntity(entity);
            }

            try
            {
                string body = "";
                if (entity != null)
                    body = EntityUtils.ToString(entity);
                string credential = hmac.GetCredential("DELETE", body, this.apiVersion + endpoint);
                httpDelete.SetHeader(HttpHeaders.AUTHORIZATION, credential);
            }
            catch (Exception e)
            {
                throw new CryptomarketSDKException("failed hmac authentication", e);
            }

            httpDelete.SetHeader(HttpHeaders.ACCEPT, APPLICATION_JSON);
            httpDelete.SetHeader(HttpHeaders.CONTENT_TYPE, APPLICATOIN_X_WWW_FORM_URLENCODED);
            return MakeRequest(httpDelete);
        }

        private string MakeRequest(HttpUriRequest request)
        {
            request.SetHeader(HttpHeaders.CONNECTION, "Keep-Alive");
            request.SetHeader(HttpHeaders.USER_AGENT, USER_AGENT);
            CloseableHttpResponse response;
            string responseBody;
            bool isSuccessful;
            try
            {
                response = client.Execute(request);
            }
            catch (IOException err)
            {
                throw new CryptomarketSDKException("Couldn't make the call", err);
            }

            try
            {
                responseBody = EntityUtils.ToString(response.GetEntity());
                isSuccessful = response.GetStatusLine().GetStatusCode() == 200;
            }
            catch (IOException err)
            {
                throw new CryptomarketSDKException("Couldn't parse the response body", err);
            }

            try
            {
                response.Dispose();
            }
            catch (IOException e)
            {
                throw new CryptomarketSDKException("unable to close api response. " + e.GetMessage(), e);
            }

            if (isSuccessful)
                return responseBody;
            try
            {
                ErrorResponse errorResponse = errorJsonAdapter.FromJson(responseBody);
                ErrorBody errorBody = errorResponse.GetError();
                throw new CryptomarketAPIException(errorBody);
            }
            catch (IOException err)
            {
                throw new CryptomarketSDKException("Couldn't parse the error: " + responseBody, err);
            }
        }
    }
}