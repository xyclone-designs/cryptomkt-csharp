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

namespace Cryptomarket.Params
{
    /// <summary>
    /// Sub account status
    /// </summary>
    public enum SubAccountStatus
    {
        /// <summary>
        /// new
        /// </summary>
        // /**
        //  * new
        //  */
        // NEW("new")
        NEW,
        /// <summary>
        /// active
        /// </summary>
        // /**
        //  * active
        //  */
        // ACTIVE("active")
        ACTIVE,
        /// <summary>
        /// disabled
        /// </summary>
        // /**
        //  * disabled
        //  */
        // DISABLED("disabled")
        DISABLED 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private SubAccountStatus(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}