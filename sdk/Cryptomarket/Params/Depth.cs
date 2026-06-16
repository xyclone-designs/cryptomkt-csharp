using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.Params.AccountType;
using static Cryptomarket.Params.ContingencyType;
using static Cryptomarket.Params.Depth;

namespace Cryptomarket.Params
{
    /// <summary>
    /// Orderbook depth
    /// </summary>
    public enum Depth
    {
        /// <summary>
        /// 5 prices of depth
        /// </summary>
        // /**
        //  * 5 prices of depth
        //  */
        // _5("D5")
        _5,
        /// <summary>
        /// 10 prices of depth
        /// </summary>
        // /**
        //  * 10 prices of depth
        //  */
        // _10("D10")
        _10,
        /// <summary>
        /// 20 prices of depth
        /// </summary>
        // /**
        //  * 20 prices of depth
        //  */
        // _20("D20")
        _20 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private Depth(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}