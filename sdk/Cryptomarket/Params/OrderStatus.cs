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

namespace Cryptomarket.Params
{
    /// <summary>
    /// Status of an order
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// New order
        /// </summary>
        // /**
        //  * New order
        //  */
        // NEW("new")
        NEW,
        /// <summary>
        /// Suspended order
        /// </summary>
        // /**
        //  * Suspended order
        //  */
        // SUSPENDED("suspended")
        SUSPENDED,
        /// <summary>
        /// Partially filled order
        /// </summary>
        // /**
        //  * Partially filled order
        //  */
        // PARTIALLY_FILLED("partiallyFilled")
        PARTIALLY_FILLED,
        /// <summary>
        /// Fully filled order
        /// </summary>
        // /**
        //  * Fully filled order
        //  */
        // FILLED("filled")
        FILLED,
        /// <summary>
        /// Canceled order
        /// </summary>
        // /**
        //  * Canceled order
        //  */
        // CANCELED("canceled")
        CANCELED,
        /// <summary>
        /// Expired order
        /// </summary>
        // /**
        //  * Expired order
        //  */
        // EXPIRED("expired")
        EXPIRED 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private OrderStatus(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}