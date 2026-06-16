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

namespace Cryptomarket.Params
{
    /// <summary>
    /// Subscription mode
    /// </summary>
    public enum SubscriptionMode
    {
        /// <summary>
        /// updates
        /// </summary>
        // /**
        //  * updates
        //  */
        // UPDATES("updates")
        UPDATES,
        /// <summary>
        /// batches
        /// </summary>
        // /**
        //  * batches
        //  */
        // BATCHES("batches")
        BATCHES 

        // --------------------
        // TODO enum body members
        // public final String label;
        // private SubscriptionMode(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}