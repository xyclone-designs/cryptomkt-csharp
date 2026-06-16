using Java.Util;
using Java.Util.Function;
using Com.Cryptomarket.Params;
using Cryptomarket.SDK.Exceptions;
using Cryptomarket.SDK.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.SDK.Websocket.Interceptor.AccountType;
using static Cryptomarket.SDK.Websocket.Interceptor.ContingencyType;
using static Cryptomarket.SDK.Websocket.Interceptor.Depth;
using static Cryptomarket.SDK.Websocket.Interceptor.IdentifyBy;
using static Cryptomarket.SDK.Websocket.Interceptor.NotificationType;
using static Cryptomarket.SDK.Websocket.Interceptor.OBSpeed;
using static Cryptomarket.SDK.Websocket.Interceptor.OrderBy;
using static Cryptomarket.SDK.Websocket.Interceptor.OrderStatus;
using static Cryptomarket.SDK.Websocket.Interceptor.OrderType;
using static Cryptomarket.SDK.Websocket.Interceptor.Period;
using static Cryptomarket.SDK.Websocket.Interceptor.PriceSpeed;
using static Cryptomarket.SDK.Websocket.Interceptor.ReportType;
using static Cryptomarket.SDK.Websocket.Interceptor.Side;
using static Cryptomarket.SDK.Websocket.Interceptor.Sort;
using static Cryptomarket.SDK.Websocket.Interceptor.SortBy;
using static Cryptomarket.SDK.Websocket.Interceptor.SubAccountStatus;
using static Cryptomarket.SDK.Websocket.Interceptor.SubAccountTransferType;
using static Cryptomarket.SDK.Websocket.Interceptor.SubscriptionMode;
using static Cryptomarket.SDK.Websocket.Interceptor.TickerSpeed;
using static Cryptomarket.SDK.Websocket.Interceptor.TimeInForce;
using static Cryptomarket.SDK.Websocket.Interceptor.TransactionStatus;
using static Cryptomarket.SDK.Websocket.Interceptor.TransactionSubtype;
using static Cryptomarket.SDK.Websocket.Interceptor.TransactionType;
using static Cryptomarket.SDK.Websocket.Interceptor.UseOffchain;
using static Cryptomarket.SDK.Websocket.Interceptor.HttpMethod;
using static Cryptomarket.SDK.Websocket.Interceptor.OrderBookState;

namespace Cryptomarket.SDK.Websocket.Interceptor
{
    public class InterceptorFactory
    {
        public static Interceptor NewOfWSResponseObject<T>(BiConsumer<T, CryptomarketSDKException> resultBiConsumer, Class<T> cls)
        {
            return new AnonymousInterceptor(this);
        }

        private sealed class AnonymousInterceptor : Interceptor
        {
            public AnonymousInterceptor(InterceptorFactory parent)
            {
                this.parent = parent;
            }

            private readonly InterceptorFactory parent;
            public void MakeCall(WSJsonResponse response)
            {
                ErrorBody error = response.GetError();
                if (error != null)
                {
                    resultBiConsumer.Accept(null, new CryptomarketAPIException(error));
                    return;
                }

                T result;
                try
                {
                    result = adapter.ObjectFromValue(response.GetResult(), cls);
                }
                catch (ParseException e)
                {
                    resultBiConsumer.Accept(null, e);
                    return;
                }

                resultBiConsumer.Accept(result, null);
            }
        }

        public static Interceptor NewMapStringListOfChanneledWSResponseObject<T>(BiConsumer<Dictionary<string, IList<T>>, NotificationType> notificationBiConsumer, Class<T> cls)
        {
            return new AnonymousInterceptor1(this);
        }

        private sealed class AnonymousInterceptor1 : Interceptor
        {
            public AnonymousInterceptor1(InterceptorFactory parent)
            {
                this.parent = parent;
            }

            private readonly InterceptorFactory parent;
            public void MakeCall(WSJsonResponse response)
            {
                try
                {
                    if (response.GetSnapshot() != null)
                    {
                        Dictionary<string, IList<T>> data = adapter.ListMapFromObject(response.GetSnapshot(), cls);
                        notificationBiConsumer.Accept(data, NotificationType.SNAPSHOT);
                    }
                    else if (response.GetUpdate() != null)
                    {
                        Dictionary<string, IList<T>> data = adapter.ListMapFromObject(response.GetUpdate(), cls);
                        notificationBiConsumer.Accept(data, NotificationType.UPDATE);
                    }
                    else
                    {
                        Dictionary<string, IList<T>> data = adapter.ListMapFromObject(response.GetData(), cls);
                        notificationBiConsumer.Accept(data, NotificationType.DATA);
                    }
                }
                catch (ParseException e)
                {
                    notificationBiConsumer.Accept(null, NotificationType.PARSE_ERROR);
                }
            }
        }

        public static Interceptor NewOfChanneledWSResponse<T>(BiConsumer<Dictionary<string, T>, NotificationType> notificationBiConsumer, Class<T> cls)
        {
            return new AnonymousInterceptor2(this);
        }

        private sealed class AnonymousInterceptor2 : Interceptor
        {
            public AnonymousInterceptor2(InterceptorFactory parent)
            {
                this.parent = parent;
            }

            private readonly InterceptorFactory parent;
            public void MakeCall(WSJsonResponse response)
            {
                try
                {
                    if (response.GetSnapshot() != null)
                    {
                        Dictionary<string, T> data = adapter.MapFromValue(response.GetSnapshot(), cls);
                        notificationBiConsumer.Accept(data, NotificationType.SNAPSHOT);
                    }
                    else if (response.GetUpdate() != null)
                    {
                        Dictionary<string, T> data = adapter.MapFromValue(response.GetUpdate(), cls);
                        notificationBiConsumer.Accept(data, NotificationType.UPDATE);
                    }
                    else
                    {
                        Dictionary<string, T> data = adapter.MapFromValue(response.GetData(), cls);
                        notificationBiConsumer.Accept(data, NotificationType.DATA);
                    }
                }
                catch (ParseException e)
                {
                    notificationBiConsumer.Accept(null, NotificationType.PARSE_ERROR);
                }
            }
        }

        public static Interceptor NewOfWSResponseList<T>(BiConsumer<IList<T>, CryptomarketSDKException> resultBiConsumer, Class<T> cls)
        {
            return new AnonymousInterceptor3(this);
        }

        private sealed class AnonymousInterceptor3 : Interceptor
        {
            public AnonymousInterceptor3(InterceptorFactory parent)
            {
                this.parent = parent;
            }

            private readonly InterceptorFactory parent;
            public void MakeCall(WSJsonResponse response)
            {
                ErrorBody error = response.GetError();
                if (error != null)
                {
                    resultBiConsumer.Accept(null, new CryptomarketAPIException(error));
                    return;
                }

                IList<T> result;
                try
                {
                    result = adapter.ListFromValue(response.GetResult(), cls);
                }
                catch (ParseException e)
                {
                    resultBiConsumer.Accept(null, e);
                    return;
                }

                resultBiConsumer.Accept(result, null);
            }
        }

        public static Interceptor NewOfSubscriptionResponse(BiConsumer<IList<string>, CryptomarketSDKException> resultBiConsumer)
        {
            return new AnonymousInterceptor4(this);
        }

        private sealed class AnonymousInterceptor4 : Interceptor
        {
            public AnonymousInterceptor4(InterceptorFactory parent)
            {
                this.parent = parent;
            }

            private readonly InterceptorFactory parent;
            public void MakeCall(WSJsonResponse response)
            {
                ErrorBody error = response.GetError();
                if (error != null)
                {
                    resultBiConsumer.Accept(null, new CryptomarketAPIException(error));
                    return;
                }

                IList<string> result;
                try
                {
                    result = adapter.StringlistFromStringMap(response.GetResult(), "subscriptions");
                }
                catch (ParseException e)
                {
                    resultBiConsumer.Accept(null, e);
                    return;
                }

                resultBiConsumer.Accept(result, null);
            }
        }
    }
}