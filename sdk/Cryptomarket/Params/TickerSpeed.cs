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

namespace Cryptomarket.Params
{
    /// <summary>
    /// ticker speed
    /// </summary>
    public enum TickerSpeed
    {
        /// <summary>
        /// 1 seconds
        /// </summary>
        // /**
        //  * 1 seconds
        //  */
        // _1_SECONDS("1s")
        _1_SECONDS,
        /// <summary>
        /// 3 seconds
        /// </summary>
        // /**
        //  * 3 seconds
        //  */
        // _3_SECONDS("3s")
        _3_SECONDS 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private TickerSpeed(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}