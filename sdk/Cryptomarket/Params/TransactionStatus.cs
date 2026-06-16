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

namespace Cryptomarket.Params
{
    /// <summary>
    /// transaction status
    /// </summary>
    public enum TransactionStatus
    {
        /// <summary>
        /// created
        /// </summary>
        // /**
        //  * created
        //  */
        // CREATED("CREATED")
        CREATED,
        /// <summary>
        /// pending
        /// </summary>
        // /**
        //  * pending
        //  */
        // PENDING("PENDING")
        PENDING,
        /// <summary>
        /// failed
        /// </summary>
        // /**
        //  * failed
        //  */
        // FAILED("FAILED")
        FAILED,
        /// <summary>
        /// rolled back
        /// </summary>
        // /**
        //  * rolled back
        //  */
        // ROLLED_BACK("ROLLED_BACK")
        ROLLED_BACK,
        /// <summary>
        /// success
        /// </summary>
        // /**
        //  * success
        //  */
        // SUCCESS("SUCCESS")
        SUCCESS 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private TransactionStatus(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}