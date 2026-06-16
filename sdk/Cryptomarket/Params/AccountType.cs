using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.Params.AccountType;

namespace Cryptomarket.Params
{
    /// <summary>
    /// Account type
    /// </summary>
    public enum AccountType
    {
        /// <summary>
        /// Account type wallet
        /// </summary>
        // /**
        //  * Account type wallet
        //  */
        // WALLET("wallet")
        WALLET,
        /// <summary>
        /// Account type spot
        /// </summary>
        // /**
        //  * Account type spot
        //  */
        // SPOT("spot")
        SPOT 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private AccountType(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}