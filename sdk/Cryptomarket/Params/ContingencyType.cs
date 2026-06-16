using Com.Squareup.Moshi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.Params.AccountType;
using static Cryptomarket.Params.ContingencyType;

namespace Cryptomarket.Params
{
    /// <summary>
    /// Contingency type
    /// </summary>
    public enum ContingencyType
    {
        /// <summary>
        /// Contingency type all or none
        /// </summary>
        // /**
        //  * Contingency type all or none
        //  */
        // @Json(name = "allOrNone")
        // ALL_OR_NONE("allOrNone")
        ALL_OR_NONE,
        /// <summary>
        /// Contingency type one cancel other
        /// </summary>
        // /**
        //  * Contingency type one cancel other
        //  */
        // @Json(name = "oneCancelOther")
        // ONE_CANCEL_OTHER("oneCancelOther")
        ONE_CANCEL_OTHER,
        /// <summary>
        /// Contingency type one trigger other
        /// </summary>
        // /**
        //  * Contingency type one trigger other
        //  */
        // @Json(name = "oneTriggerOther")
        // ONE_TRIGGER_OTHER("oneTriggerOther")
        ONE_TRIGGER_OTHER,
        /// <summary>
        /// Contingency type one trigger one cancel other
        /// </summary>
        // /**
        //  * Contingency type one trigger one cancel other
        //  */
        // @Json(name = "oneTriggerOneCancelOther")
        // ONE_TRIGGER_ONE_CANCEL_OTHER("oneTriggerOneCancelOther")
        ONE_TRIGGER_ONE_CANCEL_OTHER 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private ContingencyType(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}