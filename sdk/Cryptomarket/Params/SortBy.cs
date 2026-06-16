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

namespace Cryptomarket.Params
{
    /// <summary>
    /// Param to sort by
    /// </summary>
    public enum SortBy
    {
        /// <summary>
        /// sort by timestamp
        /// </summary>
        // /**
        //  * sort by timestamp
        //  */
        // TIMESTAMP("timestamp")
        TIMESTAMP,
        /// <summary>
        /// sort by id
        /// </summary>
        // /**
        //  * sort by id
        //  */
        // ID("id")
        ID,
        /// <summary>
        /// sort by datetime
        /// </summary>
        // /**
        //  * sort by datetime
        //  */
        // DATETIME("created_at")
        DATETIME 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private SortBy(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}