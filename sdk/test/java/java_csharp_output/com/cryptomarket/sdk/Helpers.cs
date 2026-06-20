using Org.Junit.Assert;
using Java.Util;
using Java.Util.Concurrent;
using Java.Util.Function;
using Com.Cryptomarket.Params;
using Com.Cryptomarket.Sdk.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Com.Cryptomarket.Sdk
{
    public class Helpers
    {
        public static void Sleep(int seconds)
        {
            try
            {
                TimeUnit.SECONDS.Sleep(seconds);
            }
            catch (InterruptedException e)
            {
                Fail();
            }
        }

        public class FailChecker
        {
            private Optional<string> errMsg = Optional.Empty();
            public virtual void Fail(string errMsg)
            {
                this.errMsg = Optional.Of(errMsg);
            }

            public virtual bool Failed()
            {
                return errMsg.IsPresent();
            }

            public virtual Optional<string> GetErrMsg()
            {
                return errMsg;
            }
        }

        public static BiConsumer<T, NotificationType> Checker<T>(FailChecker failChecker, Consumer<T> checker)
        {
            return (data, notificationType) =>
            {
                if (notificationType.IsError())
                {
                    failChecker.Fail("failed to parse notification");
                    return;
                }

                try
                {
                    checker.Accept(data);
                }
                catch (InvalidOperationException e)
                {
                    failChecker.Fail(e.GetMessage());
                }
            };
        }

        public static BiConsumer<T, CryptomarketSDKException> ObjectAndExceptionChecker<T>(FailChecker failChecker, Consumer<T> checker)
        {
            return (data, error) =>
            {
                if (error != null)
                {
                    failChecker.Fail(error.GetMessage());
                }

                try
                {
                    checker.Accept(data);
                }
                catch (InvalidOperationException e)
                {
                    failChecker.Fail(e.GetMessage());
                }
            };
        }

        public static BiConsumer<IList<T>, CryptomarketSDKException> ListAndExceptionChecker<T>(FailChecker failChecker, Consumer<T> checker)
        {
            return (data, error) =>
            {
                if (error != null)
                {
                    failChecker.Fail(error.GetMessage());
                }

                try
                {
                    data.ForEach((v) => checker.Accept(v));
                }
                catch (InvalidOperationException e)
                {
                    failChecker.Fail(e.GetMessage());
                }
            };
        }

        public static BiConsumer<IList<T>, NotificationType> NotificationListChecker<T>(FailChecker failChecker, Consumer<T> checker)
        {
            return (data, notificationType) =>
            {
                if (notificationType.IsError())
                {
                    failChecker.Fail("invalid notification type");
                    return;
                }

                try
                {
                    data.ForEach((v) => checker.Accept(v));
                }
                catch (InvalidOperationException e)
                {
                    failChecker.Fail(e.GetMessage());
                }
            };
        }

        public static BiConsumer<Dictionary<string, T>, NotificationType> NotificationMapChecker<T>(FailChecker failChecker, Consumer<T> checker)
        {
            return (data, notificationType) =>
            {
                if (notificationType.IsError())
                {
                    failChecker.Fail("invalid notification type");
                    return;
                }

                try
                {
                    data.ForEach((k, v) => checker.Accept(v));
                }
                catch (InvalidOperationException e)
                {
                    failChecker.Fail(e.GetMessage());
                }
            };
        }

        public static BiConsumer<Dictionary<string, IList<T>>, NotificationType> NotificationMapListChecker<T>(FailChecker failChecker, Consumer<T> checker)
        {
            return (data, notificationType) =>
            {
                if (notificationType.IsError())
                {
                    failChecker.Fail("invalid notification type");
                    return;
                }

                try
                {
                    data.ForEach((k, v) => v.ForEach(checker));
                }
                catch (InvalidOperationException e)
                {
                    failChecker.Fail(e.GetMessage());
                }
            };
        }
    }
}