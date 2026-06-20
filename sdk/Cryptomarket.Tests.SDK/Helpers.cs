using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Params;

namespace CryptoMarket.Tests.SDK
{
    public class Helpers
    {
        public class FailChecker
        {
            public string? ErrMsg { get; set; }

            public virtual void Fail(string errMsg)
            {
                ErrMsg = errMsg;
            }
            public virtual bool Failed()
            {
                return ErrMsg is not null;
            }
        }

        public static void Sleep(int seconds)
        {
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(seconds));
            }
            catch (ThreadInterruptedException)
            {
                // Fail();
            }
        }
        public static Action<T, NotificationType> Checker<T>(FailChecker failChecker, Action<T> checker)
        {
            return (data, notificationType) =>
            {
                if (notificationType == NotificationType.PARSE_ERROR)
                {
                    failChecker.Fail("failed to parse notification");
                    return;
                }

                try
                {
                    checker.Invoke(data);
                }
                catch (InvalidOperationException e)
                {
                    failChecker.Fail(e.Message);
                }
            };
        }
        public static Action<T, CryptoMarketSDKException> ObjectAndExceptionChecker<T>(FailChecker failChecker, Action<T> checker)
        {
            return (data, error) =>
            {
                if (error != null)
                {
                    failChecker.Fail(error.Message);
                }

                try
                {
                    checker.Invoke(data);
                }
                catch (InvalidOperationException e)
                {
                    failChecker.Fail(e.Message);
                }
            };
        }
        public static Action<IList<T>, CryptoMarketSDKException> ListAndExceptionChecker<T>(FailChecker failChecker, Action<T> checker)
        {
            return (data, error) =>
            {
                if (error != null)
                {
                    failChecker.Fail(error.Message);
                }

                try
                {
                    foreach (var d in data) checker.Invoke(d);
                }
                catch (InvalidOperationException e)
                {
                    failChecker.Fail(e.Message);
                }
            };
        }
        public static Action<IList<T>, NotificationType> NotificationListChecker<T>(FailChecker failChecker, Action<T> checker)
        {
            return (data, notificationType) =>
            {
                if (notificationType == NotificationType.PARSE_ERROR)
                {
                    failChecker.Fail("invalid notification type");
                    return;
                }

                try
                {
                    foreach (var d in data) checker.Invoke(d);
                }
                catch (InvalidOperationException e)
                {
                    failChecker.Fail(e.Message);
                }
            };
        }
        public static Action<Dictionary<string, T>, NotificationType> NotificationMapChecker<T>(FailChecker failChecker, Action<T> checker)
        {
            return (data, notificationType) =>
            {
                if (notificationType == NotificationType.PARSE_ERROR)
                {
                    failChecker.Fail("invalid notification type");
                    return;
                }

                try
                {
                    foreach (var d in data) checker.Invoke(d.Value);
                }
                catch (InvalidOperationException e)
                {
                    failChecker.Fail(e.Message);
                }
            };
        }
        public static Action<Dictionary<string, IList<T>>, NotificationType> NotificationMapListChecker<T>(FailChecker failChecker, Action<T> checker)
        {
            return (data, notificationType) =>
            {
                if (notificationType == NotificationType.PARSE_ERROR)
                {
                    failChecker.Fail("invalid notification type");
                    return;
                }

                try
                {
                    foreach (var d in data.SelectMany(_ => _.Value)) checker.Invoke(d);
                }
                catch (InvalidOperationException e)
                {
                    failChecker.Fail(e.Message);
                }
            };
        }
    }
}