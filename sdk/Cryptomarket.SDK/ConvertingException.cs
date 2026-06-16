using Java.Io;
using Cryptomarket.SDK.Exceptions;
using Com.Squareup.Moshi;
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
    /// Converts exceptions
    /// </summary>
    public class ConvertingException
    {
        public static R JsonDataToParse<T, R>(Throwing.Specific.Function<T, R, JsonDataException> fn, T arg)
        {
            try
            {
                return fn.Apply(arg);
            }
            catch (JsonDataException e)
            {
                throw new ParseException("unable to parse", e);
            }
        }

        public static R AssertionToParse<T, R>(Throwing.Specific.Function<T, R, AssertionError> fn, T arg)
        {
            try
            {
                return fn.Apply(arg);
            }
            catch (InvalidOperationException e)
            {
                throw new ParseException("unable to parse", e);
            }
        }

        public static R JsonDataAndAssertionToParse<T, R>(Throwing.Specific.Function2<T, R, JsonDataException, AssertionError> fn, T arg)
        {
            try
            {
                return fn.Apply(arg);
            }
            catch (JsonDataException e)
            {
                throw new ParseException("unable to parse", e);
            }
            catch (InvalidOperationException e)
            {
                throw new ParseException("unable to parse", e);
            }
        }

        public static R IoAndJsonDataAndAssertionToParse<T, R>(Throwing.Specific.Function3<T, R, JsonDataException, AssertionError, IOException> fn, T arg)
        {
            try
            {
                return fn.Apply(arg);
            }
            catch (JsonDataException e)
            {
                throw new ParseException("unable to parse", e);
            }
            catch (InvalidOperationException e)
            {
                throw new ParseException("unable to parse", e);
            }
            catch (IOException e)
            {
                throw new ParseException("unable to parse", e);
            }
        }

        public static R IoToParse<T, R>(Throwing.Specific.Function<T, R, IOException> fn, T arg)
        {
            try
            {
                return fn.Apply(arg);
            }
            catch (IOException e)
            {
                throw new ParseException("unable to parse", e);
            }
        }
    }
}