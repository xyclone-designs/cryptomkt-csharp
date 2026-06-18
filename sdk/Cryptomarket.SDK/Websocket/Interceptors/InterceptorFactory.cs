using Cryptomarket.SDK.Exceptions;
using Cryptomarket.SDK.Models;
using Cryptomarket.SDK.Params;

namespace Cryptomarket.SDK.Websocket.Interceptors
{
    public class InterceptorFactory
    {
        public static Interceptor NewOfWSResponseObject<T>(Action<T?, CryptomarketSDKException?> resultAction)
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
        public static Interceptor NewOfWSResponseList<T>(Action<IList<T>?, CryptomarketSDKException?> resultAction)
        {
            return new InterceptorOfWSResponseList<T>(resultAction);
        }
        public static Interceptor NewOfSubscriptionResponse(Action<IList<string>?, CryptomarketSDKException?> resultAction)
        {
            return new InterceptorOfSubscriptionResponse(resultAction);
        }

        private sealed class InterceptorOfWSResponseObject<T>(Action<T?, CryptomarketSDKException?> resultAction) : Interceptor
        {
            private readonly Action<T?, CryptomarketSDKException?> ResultAction = resultAction;

            public override void MakeCall(WSJsonResponse response)
            {
                if (response.Error is ErrorBody error)
                {
                    ResultAction.Invoke(default, new CryptomarketAPIException(error));
                    return;
                }

                T result;

                try
                {
                    result = Adapter.ObjectFromValue<T>(response.Result ?? throw new ParseException("Result is null"));
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
                        Dictionary<string, IList<T>> data = Adapter.ListMapFromObject<T>(response.Snapshot);
                        NotificationAction.Invoke(data, NotificationType.SNAPSHOT);
                    }
                    else if (response.Update != null)
                    {
                        Dictionary<string, IList<T>> data = Adapter.ListMapFromObject<T>(response.Update);
                        NotificationAction.Invoke(data, NotificationType.UPDATE);
                    }
                    else
                    {
                        Dictionary<string, IList<T>> data = Adapter.ListMapFromObject<T>(response.Data ?? throw new ParseException("Data is null"));
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
                        Dictionary<string, T> data = Adapter.MapFromValue<T>(response.Snapshot);
                        NotificationAction.Invoke(data, NotificationType.SNAPSHOT);
                    }
                    else if (response.Update != null)
                    {
                        Dictionary<string, T> data = Adapter.MapFromValue<T>(response.Update);
                        NotificationAction.Invoke(data, NotificationType.UPDATE);
                    }
                    else
                    {
                        Dictionary<string, T> data = Adapter.MapFromValue<T>(response.Data ?? throw new ParseException("Data is null"));
                        NotificationAction.Invoke(data, NotificationType.DATA);
                    }
                }
                catch (ParseException)
                {
                    NotificationAction.Invoke(null, NotificationType.PARSE_ERROR);
                }
            }
        }

        private sealed class InterceptorOfWSResponseList<T>(Action<IList<T>?, CryptomarketSDKException?> resultAction) : Interceptor
        {
            private readonly Action<IList<T>?, CryptomarketSDKException?> ResultAction = resultAction;

            public override void MakeCall(WSJsonResponse response)
            {
                if (response.Error is ErrorBody error)
                {
                    ResultAction.Invoke(null, new CryptomarketAPIException(error));
                    return;
                }

                IList<T> result;

                try
                {
                    result = Adapter.ListFromValue<T>(response.Result ?? throw new ParseException("Result is null"));
                }
                catch (ParseException e)
                {
                    ResultAction.Invoke(null, e);
                    return;
                }

                ResultAction.Invoke(result, null);
            }
        }

        private sealed class InterceptorOfSubscriptionResponse(Action<IList<string>?, CryptomarketSDKException?> resultAction) : Interceptor
        {
            private readonly Action<IList<string>?, CryptomarketSDKException?> ResultAction = resultAction;

            public override void MakeCall(WSJsonResponse response)
            {
                if (response.Error is ErrorBody error)
                {
                    ResultAction.Invoke(null, new CryptomarketAPIException(error));
                    return;
                }

                IList<string> result;

                try
                {
                    result = Adapter.StringlistFromStringMap(response.Result ?? throw new ParseException("Result is null"), "subscriptions");
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