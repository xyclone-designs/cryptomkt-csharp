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

namespace Cryptomarket.Params
{
    /// <summary>
    /// Price speed
    /// </summary>
    public enum PriceSpeed
    {
        /// <summary>
        /// 1 second
        /// </summary>
        // /**
        //  * 1 second
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
        // private PriceSpeed(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}