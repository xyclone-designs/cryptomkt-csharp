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

namespace Cryptomarket.Params
{
    /// <summary>
    /// Period
    /// </summary>
    public enum Period
    {
        /// <summary>
        /// one minute
        /// </summary>
        // /**
        //  * one minute
        //  */
        // _1_MINUTES("M1")
        _1_MINUTES,
        /// <summary>
        /// 3 minutes
        /// </summary>
        // /**
        //  * 3 minutes
        //  */
        // _3_MINUTES("M3")
        _3_MINUTES,
        /// <summary>
        /// 5 minutes
        /// </summary>
        // /**
        //  * 5 minutes
        //  */
        // _5_MINUTES("M5")
        _5_MINUTES,
        /// <summary>
        /// 15 minutes
        /// </summary>
        // /**
        //  * 15 minutes
        //  */
        // _15_MINUTES("M15")
        _15_MINUTES,
        /// <summary>
        /// 30 minutes
        /// </summary>
        // /**
        //  * 30 minutes
        //  */
        // _30_MINUTES("M30")
        _30_MINUTES,
        /// <summary>
        /// 1 hour
        /// </summary>
        // /**
        //  * 1 hour
        //  */
        // _1_HOURS("1H")
        _1_HOURS,
        /// <summary>
        /// 4 hours
        /// </summary>
        // /**
        //  * 4 hours
        //  */
        // _4_HOURS("4H")
        _4_HOURS,
        /// <summary>
        /// 1 day
        /// </summary>
        // /**
        //  * 1 day
        //  */
        // _1_DAYS("1D")
        _1_DAYS,
        /// <summary>
        /// 7 days
        /// </summary>
        // /**
        //  * 7 days
        //  */
        // _7_DAYS("7D")
        _7_DAYS,
        /// <summary>
        /// 1 month
        /// </summary>
        // /**
        //  * 1 month
        //  */
        // _1_MONTHS("1M")
        _1_MONTHS 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private Period(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}