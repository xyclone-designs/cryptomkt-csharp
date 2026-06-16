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

namespace Cryptomarket.Params
{
    /// <summary>
    /// Order book speed
    /// </summary>
    public enum OBSpeed
    {
        /// <summary>
        /// Speed of 100 miliseconds
        /// </summary>
        // /**
        //  * Speed of 100 miliseconds
        //  */
        // _100_MILISECONDS("100ms")
        _100_MILISECONDS,
        /// <summary>
        /// Speed of 500 miliseconds
        /// </summary>
        // /**
        //  * Speed of 500 miliseconds
        //  */
        // _500_MILISECONDS("500ms")
        _500_MILISECONDS,
        /// <summary>
        /// Speed of 1000 miliseconds
        /// </summary>
        // /**
        //  * Speed of 1000 miliseconds
        //  */
        // _1000_MILISECONDS("1000ms")
        _1000_MILISECONDS 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private OBSpeed(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}