using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.Params.AccountType;
using static Cryptomarket.Params.ContingencyType;
using static Cryptomarket.Params.Depth;
using static Cryptomarket.Params.IdentifyBy;

namespace Cryptomarket.Params
{
    /// <summary>
    /// Identify user by
    /// </summary>
    public enum IdentifyBy
    {
        /// <summary>
        /// Identify by email
        /// </summary>
        // /**
        //  * Identify by email
        //  */
        // EMAIL("email")
        EMAIL,
        /// <summary>
        /// Identify by username
        /// </summary>
        // /**
        //  * Identify by username
        //  */
        // USERNAME("username")
        USERNAME 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private IdentifyBy(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}