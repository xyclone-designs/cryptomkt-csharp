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

namespace Cryptomarket.Params
{
    /// <summary>
    /// Report type
    /// </summary>
    public enum ReportType
    {
        /// <summary>
        /// status
        /// </summary>
        // /**
        //  * status
        //  */
        // STATUS("status")
        STATUS,
        /// <summary>
        /// new
        /// </summary>
        // /**
        //  * new
        //  */
        // NEW("new")
        NEW,
        /// <summary>
        /// suspended
        /// </summary>
        // /**
        //  * suspended
        //  */
        // SUSPENDED("suspended")
        SUSPENDED,
        /// <summary>
        /// canceled
        /// </summary>
        // /**
        //  * canceled
        //  */
        // CANCELED("canceled")
        CANCELED,
        /// <summary>
        /// rejected
        /// </summary>
        // /**
        //  * rejected
        //  */
        // REJECTED("rejected")
        REJECTED,
        /// <summary>
        /// expired
        /// </summary>
        // /**
        //  * expired
        //  */
        // EXPIRED("expired")
        EXPIRED,
        /// <summary>
        /// replaced
        /// </summary>
        // /**
        //  * replaced
        //  */
        // REPLACED("replaced")
        REPLACED,
        /// <summary>
        /// trade
        /// </summary>
        // /**
        //  * trade
        //  */
        // TRADE("trade")
        TRADE 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private ReportType(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}