using System;
using System.Collections.Generic;

namespace Cryptomarket.Params
{
    /// <summary>
    /// Use offchain
    /// </summary>
    public enum UseOffchain
    {
        /// <summary>
        /// never
        /// </summary>
        // /**
        //  * never
        //  */
        // NEVER("never")
        NEVER,
        /// <summary>
        /// optionally
        /// </summary>
        // /**
        //  * optionally
        //  */
        // OPTIONALLY("optionally")
        OPTIONALLY,
        /// <summary>
        /// reuquired
        /// </summary>
        // /**
        //  * reuquired
        //  */
        // REQUIRED("required")
        REQUIRED 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private UseOffchain(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}