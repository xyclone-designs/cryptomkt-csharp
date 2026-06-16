using Com.Squareup.Moshi;
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

namespace Cryptomarket.Params
{
    /// <summary>
    /// side
    /// </summary>
    public enum Side
    {
        /// <summary>
        /// buy
        /// </summary>
        // /**
        //  * buy
        //  */
        // @Json(name = "buy")
        // BUY("buy")
        BUY,
        /// <summary>
        /// sell
        /// </summary>
        // /**
        //  * sell
        //  */
        // @Json(name = "sell")
        // SELL("sell")
        SELL 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private Side(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}