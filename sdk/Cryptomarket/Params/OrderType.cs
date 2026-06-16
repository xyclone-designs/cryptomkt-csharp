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

namespace Cryptomarket.Params
{
    /// <summary>
    /// Type of order
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// Order type limit
        /// </summary>
        // /**
        //  * Order type limit
        //  */
        // LIMIT("limit")
        LIMIT,
        /// <summary>
        /// Order type market
        /// </summary>
        // /**
        //  * Order type market
        //  */
        // MARKET("market")
        MARKET,
        /// <summary>
        /// Order type stop limit
        /// </summary>
        // /**
        //  * Order type stop limit
        //  */
        // STOP_LIMIT("stopLimit")
        STOP_LIMIT,
        /// <summary>
        /// Order type stop market
        /// </summary>
        // /**
        //  * Order type stop market
        //  */
        // STOP_MARKET("stopMarket")
        STOP_MARKET,
        /// <summary>
        /// Order type take profit limit
        /// </summary>
        // /**
        //  * Order type take profit limit
        //  */
        // TAKE_PROFIT_LIMIT("takeProfitLimit")
        TAKE_PROFIT_LIMIT,
        /// <summary>
        /// Order type take profit market
        /// </summary>
        // /**
        //  * Order type take profit market
        //  */
        // TAKE_PROFIT_MARKET("takeProfitMarket")
        TAKE_PROFIT_MARKET 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private OrderType(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}