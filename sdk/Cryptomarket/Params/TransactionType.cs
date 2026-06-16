using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.Params.AccountType;
using static Cryptomarket.Params.ContingencyType;
using static Cryptomarket.Params.Depth;
using static Cryptomarket.Params.IdentifyBy;
using static Cryptomarket.Params.NotificationType;
using static Cryptomarket.Params.OBSpeed;
using static Cryptomarket.Params.OrderBy;
using static Cryptomarket.Params.OrderStatus;
using static Cryptomarket.Params.OrderType;
using static Cryptomarket.Params.Period;
using static Cryptomarket.Params.PriceSpeed;
using static Cryptomarket.Params.ReportType;
using static Cryptomarket.Params.Side;
using static Cryptomarket.Params.Sort;
using static Cryptomarket.Params.SortBy;
using static Cryptomarket.Params.SubAccountStatus;
using static Cryptomarket.Params.SubAccountTransferType;
using static Cryptomarket.Params.SubscriptionMode;
using static Cryptomarket.Params.TickerSpeed;
using static Cryptomarket.Params.TimeInForce;
using static Cryptomarket.Params.TransactionStatus;
using static Cryptomarket.Params.TransactionSubtype;
using static Cryptomarket.Params.TransactionType;

namespace Cryptomarket.Params
{
    /// <summary>
    /// transaction type
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// deposit
        /// </summary>
        DEPOSIT,
        /// <summary>
        /// withdraw
        /// </summary>
        WITHDRAW,
        /// <summary>
        /// transfer
        /// </summary>
        TRANSFER,
        /// <summary>
        /// swap
        /// </summary>
        SWAP
    }
}