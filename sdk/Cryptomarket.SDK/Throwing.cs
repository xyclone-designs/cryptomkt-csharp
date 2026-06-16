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
    /// Variations on the standard functional interfaces which throw Exception.
    /// </summary>
    public interface Throwing
    {
        public class Specific
        {
            public interface Runnable<E>
            {
                void Run();
            }

            public interface Supplier<T, E>
            {
                T Get();
            }

            public interface Consumer<T, E>
            {
                void Accept(T t);
            }

            public interface Function<T, R, E>
            {
                R Apply(T t);
            }

            public interface Function2<T, R, E, F>
            {
                R Apply(T t);
            }

            public interface Function3<T, R, E, F, G>
            {
                R Apply(T t);
            }

            public interface Predicate<T, E>
            {
                bool Test(T t);
            }

            public interface BiConsumer<T, U, E>
            {
                void Accept(T t, U u);
            }

            public interface BiFunction<T, U, R, E>
            {
                R Apply(T t, U u);
            }

            public interface BiPredicate<T, U, E>
            {
                bool Accept(T t, U u);
            }
        }

        public class Runnable : Runnable<Exception>
        {
        }

        public class Supplier<T> : Supplier<T, Exception>
        {
        }

        public class Consumer<T> : Consumer<T, Exception>
        {
        }

        public class Function<T, R> : Function<T, R, Exception>
        {
        }

        public class Predicate<T> : Predicate<T, Exception>
        {
        }

        public class BiConsumer<T, U> : BiConsumer<T, U, Exception>
        {
        }

        public class BiFunction<T, U, R> : BiFunction<T, U, R, Exception>
        {
        }

        public class BiPredicate<T, U> : BiPredicate<T, U, Exception>
        {
        }
    }
}