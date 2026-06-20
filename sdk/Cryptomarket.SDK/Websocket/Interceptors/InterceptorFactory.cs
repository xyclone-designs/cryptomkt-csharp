using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Models;
using CryptoMarket.SDK.Params;
using System.Text.Json;

namespace CryptoMarket.SDK.Websocket.Interceptors
{
    public class InterceptorFactory
    {
        public static Interceptor NewOfWSResponseObject<T>(Action<T?, CryptoMarketSDKException?> resultAction)
        {
            return new InterceptorOfWSResponseObject<T>(resultAction);
        }
        public static Interceptor NewMapStringListOfChanneledWSResponseObject<T>(Action<Dictionary<string, IList<T>>?, NotificationType> notificationAction)
        {
            return new InterceptorOfStringListChanneledWSResponseObject<T>(notificationAction);
        }
        public static Interceptor NewOfChanneledWSResponse<T>(Action<Dictionary<string, T>?, NotificationType> notificationAction)
        {
            return new InterceptorOfChanneledWSResponse<T>(notificationAction);
        }
        public static Interceptor NewOfWSResponseList<T>(Action<IList<T>?, CryptoMarketSDKException?> resultAction)
        {
            return new InterceptorOfWSResponseList<T>(resultAction);
        }
        public static Interceptor NewOfSubscriptionResponse(Action<IList<string>?, CryptoMarketSDKException?> resultAction)
        {
            return new InterceptorOfSubscriptionResponse(resultAction);
        }

        private sealed class InterceptorOfWSResponseObject<T>(Action<T?, CryptoMarketSDKException?> resultAction) : Interceptor
        {
            private readonly Action<T?, CryptoMarketSDKException?> ResultAction = resultAction;

            public override void MakeCall(WSJsonResponse response)
            {
                if (response.Error is ErrorBody error)
                {
                    ResultAction.Invoke(default, new CryptoMarketAPIException(error));
                    return;
                }

                T result;

                try
                {
                    result = (T)(response.Result ?? throw new ParseException("Result is null"));
                }
                catch (ParseException e)
                {
                    ResultAction.Invoke(default, e);
                    return;
                }

                ResultAction.Invoke(result, null);
            }
        }

        private sealed class InterceptorOfStringListChanneledWSResponseObject<T>(Action<Dictionary<string, IList<T>>?, NotificationType> notificationAction) : Interceptor
        {
            private readonly Action<Dictionary<string, IList<T>>?, NotificationType> NotificationAction = notificationAction;

            public override void MakeCall(WSJsonResponse response)
            {
                try
                {
                    if (response.Snapshot != null)
                    {
                        Dictionary<string, IList<T>> data = (Dictionary<string, IList<T>>)response.Snapshot;
                        NotificationAction.Invoke(data, NotificationType.SNAPSHOT);
                    }
                    else if (response.Update != null)
                    {
                        Dictionary<string, IList<T>> data = (Dictionary<string, IList<T>>)response.Update;
                        NotificationAction.Invoke(data, NotificationType.UPDATE);
                    }
                    else
                    {
                        Dictionary<string, IList<T>> data = (Dictionary<string, IList<T>>)(response.Data ?? throw new ParseException("Data is null"));
                        NotificationAction.Invoke(data, NotificationType.DATA);
                    }
                }
                catch (ParseException)
                {
                    NotificationAction.Invoke(null, NotificationType.PARSE_ERROR);
                }
            }
        }

        private sealed class InterceptorOfChanneledWSResponse<T>(Action<Dictionary<string, T>?, NotificationType> notificationAction) : Interceptor
        {
            private readonly Action<Dictionary<string, T>?, NotificationType> NotificationAction = notificationAction;

            public override void MakeCall(WSJsonResponse response)
            {
                try
                {
                    if (response.Snapshot != null)
                    {
                        Dictionary<string, T> data = (Dictionary<string, T>)response.Snapshot;
                        NotificationAction.Invoke(data, NotificationType.SNAPSHOT);
                    }
                    else if (response.Update != null)
                    {
                        Dictionary<string, T> data = (Dictionary<string, T>)response.Update;
                        NotificationAction.Invoke(data, NotificationType.UPDATE);
                    }
                    else
                    {
                        Dictionary<string, T> data = (Dictionary<string, T>)(response.Data ?? throw new ParseException("Data is null"));
                        NotificationAction.Invoke(data, NotificationType.DATA);
                    }
                }
                catch (ParseException)
                {
                    NotificationAction.Invoke(null, NotificationType.PARSE_ERROR);
                }
            }
        }

        private sealed class InterceptorOfWSResponseList<T>(Action<IList<T>?, CryptoMarketSDKException?> resultAction) : Interceptor
        {
            private readonly Action<IList<T>?, CryptoMarketSDKException?> ResultAction = resultAction;

            public override void MakeCall(WSJsonResponse response)
            {
                if (response.Error is ErrorBody error)
                {
                    ResultAction.Invoke(null, new CryptoMarketAPIException(error));
                    return;
                }

                IList<T> result;

                try
                {
                    result = (IList<T>)(response.Result ?? throw new ParseException("Result is null"));
                }
                catch (ParseException e)
                {
                    ResultAction.Invoke(null, e);
                    return;
                }

                ResultAction.Invoke(result, null);
            }
        }

        private sealed class InterceptorOfSubscriptionResponse(Action<IList<string>?, CryptoMarketSDKException?> resultAction) : Interceptor
        {
            private readonly Action<IList<string>?, CryptoMarketSDKException?> ResultAction = resultAction;

            public override void MakeCall(WSJsonResponse response)
            {
                if (response.Error is ErrorBody error)
                {
                    ResultAction.Invoke(null, new CryptoMarketAPIException(error));
                    return;
                }

                IList<string> result;

                try
                {
                    result = (IList<string>)(response.Result ?? throw new ParseException("Result is null"));
                    // result = (IList<string>)(response.Result ?? throw new ParseException("Result is null"))["subscriptions"];
                }
                catch (ParseException e)
                {
                    ResultAction.Invoke(null, e);
                    return;
                }

                ResultAction.Invoke(result, null);
            }
        }
    }
}