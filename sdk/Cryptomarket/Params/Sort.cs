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

namespace Cryptomarket.Params
{
    /// <summary>
    /// Sort direction of pagination, ASC for ascending, DESC for descending
    /// </summary>
    public enum Sort
    {
        /// <summary>
        /// Descending
        /// </summary>
        // /**
        //  * Descending
        //  */
        // DESC("DESC")
        DESC,
        /// <summary>
        /// Ascending
        /// </summary>
        // /**
        //  * Ascending
        //  */
        // ASC("ASC")
        ASC 

        // --------------------
        // TODO enum body members
        // public final String label;
        // private Sort(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}