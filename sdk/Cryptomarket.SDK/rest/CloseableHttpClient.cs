using Java.Io;
using Java.Util;
using Cryptomarket.SDK.Exceptions;
using Org.Jetbrains.Annotations;
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
    public interface CloseableHttpClient : Closeable
    {
        void ChangeCredentials(string apiKey, string apiSecret);
        void ChangeWindow(int window);
        string PublicGet(string endpoint, Dictionary<string, string> @params);
        string Get(string endpoint, Dictionary<string, string> @params);
        string Post(string endpoint, string payload);
        string Post(string endpoint, Dictionary<string, string> payload);
        string Put(string endpoint, Dictionary<string, string> @params);
        string Patch(string endpoint, Dictionary<string, string> @params);
        string Delete(string endpoint, Dictionary<string, string> @params);
    }
}