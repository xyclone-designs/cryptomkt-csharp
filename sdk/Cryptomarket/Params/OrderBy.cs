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

namespace Cryptomarket.Params
{
    /// <summary>
    /// Param to sort by
    /// </summary>
    public enum OrderBy
    {
        /// <summary>
        /// sort by creation date
        /// </summary>
        // /**
        //  * sort by creation date
        //  */
        // CREATED_AT("created_at")
        CREATED_AT,
        /// <summary>
        /// sort by id
        /// </summary>
        // /**
        //  * sort by id
        //  */
        // ID("id")
        ID,
        /// <summary>
        /// sort by update date
        /// </summary>
        // /**
        //  * sort by update date
        //  */
        // UPDATE_AT("updated_at")
        UPDATE_AT,
        /// <summary>
        /// sort by last activity
        /// </summary>
        // /**
        //  * sort by last activity
        //  */
        // LAST_ACTIVITY_AT("last_activity_at")
        LAST_ACTIVITY_AT 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private OrderBy(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}