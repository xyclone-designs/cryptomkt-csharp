using Com.Cryptomarket.Params;
using Com.Squareup.Moshi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.SDK.Models.Adapters.AccountType;
using static Cryptomarket.SDK.Models.Adapters.ContingencyType;
using static Cryptomarket.SDK.Models.Adapters.Depth;
using static Cryptomarket.SDK.Models.Adapters.IdentifyBy;
using static Cryptomarket.SDK.Models.Adapters.NotificationType;
using static Cryptomarket.SDK.Models.Adapters.OBSpeed;
using static Cryptomarket.SDK.Models.Adapters.OrderBy;
using static Cryptomarket.SDK.Models.Adapters.OrderStatus;
using static Cryptomarket.SDK.Models.Adapters.OrderType;
using static Cryptomarket.SDK.Models.Adapters.Period;
using static Cryptomarket.SDK.Models.Adapters.PriceSpeed;
using static Cryptomarket.SDK.Models.Adapters.ReportType;
using static Cryptomarket.SDK.Models.Adapters.Side;
using static Cryptomarket.SDK.Models.Adapters.Sort;
using static Cryptomarket.SDK.Models.Adapters.SortBy;
using static Cryptomarket.SDK.Models.Adapters.SubAccountStatus;
using static Cryptomarket.SDK.Models.Adapters.SubAccountTransferType;
using static Cryptomarket.SDK.Models.Adapters.SubscriptionMode;
using static Cryptomarket.SDK.Models.Adapters.TickerSpeed;
using static Cryptomarket.SDK.Models.Adapters.TimeInForce;
using static Cryptomarket.SDK.Models.Adapters.TransactionStatus;
using static Cryptomarket.SDK.Models.Adapters.TransactionSubtype;
using static Cryptomarket.SDK.Models.Adapters.TransactionType;
using static Cryptomarket.SDK.Models.Adapters.UseOffchain;
using static Cryptomarket.SDK.Models.Adapters.HttpMethod;
using static Cryptomarket.SDK.Models.Adapters.OrderBookState;

namespace Cryptomarket.SDK.Models.Adapters
{
    /// <summary>
    /// A moshi adapter for UseOffchain
    /// </summary>
    public class UseOffchainAdapter
    {
        virtual string ToJson(UseOffchain useOffchain)
        {
            return useOffchain.ToString();
        }
    }
}