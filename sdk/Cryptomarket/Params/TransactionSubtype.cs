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
using static Cryptomarket.Params.ReportType;
using static Cryptomarket.Params.Side;
using static Cryptomarket.Params.Sort;
using static Cryptomarket.Params.SortBy;
using static Cryptomarket.Params.SubAccountStatus;
using static Cryptomarket.Params.SubAccountTransferType;
using static Cryptomarket.Params.SubscriptionMode;
using static Cryptomarket.Params.TickerSpeed;
using static Cryptomarket.Params.TimeInForce;
using static Cryptomarket.Params.TransactionStatus;
using static Cryptomarket.Params.TransactionSubtype;

namespace Cryptomarket.Params
{
    /// <summary>
    /// transaction subtype
    /// </summary>
    public enum TransactionSubtype
    {
        /// <summary>
        /// unclassified
        /// </summary>
        // /**
        //  * unclassified
        //  */
        // UNCLASSIFIED("UNCLASSIFIED")
        UNCLASSIFIED,
        /// <summary>
        /// blockchain
        /// </summary>
        // /**
        //  * blockchain
        //  */
        // BLOCKCHAIN("BLOCKCHAIN")
        BLOCKCHAIN,
        /// <summary>
        /// affiliate
        /// </summary>
        // /**
        //  * affiliate
        //  */
        // AFFILIATE("AFFILIATE")
        AFFILIATE,
        /// <summary>
        /// offchain
        /// </summary>
        // /**
        //  * offchain
        //  */
        // OFFCHAIN("OFFCHAIN")
        OFFCHAIN,
        /// <summary>
        /// fiat
        /// </summary>
        // /**
        //  * fiat
        //  */
        // FIAT("FIAT")
        FIAT,
        /// <summary>
        /// sub account
        /// </summary>
        // /**
        //  * sub account
        //  */
        // SUB_ACCOUNT("SUB_ACCOUNT")
        SUB_ACCOUNT,
        /// <summary>
        /// wallet to spot
        /// </summary>
        // /**
        //  * wallet to spot
        //  */
        // WALLET_TO_SPOT("WALLET_TO_SPOT")
        WALLET_TO_SPOT,
        /// <summary>
        /// spot to wallet
        /// </summary>
        // /**
        //  * spot to wallet
        //  */
        // SPOT_TO_WALLET("SPOT_TO_WALLET")
        SPOT_TO_WALLET,
        /// <summary>
        /// chain switch from
        /// </summary>
        // /**
        //  * chain switch from
        //  */
        // CHAIN_SWITCH_FROM("CHAIN_SWITCH_FROM")
        CHAIN_SWITCH_FROM,
        /// <summary>
        /// chain switch to
        /// </summary>
        // /**
        //  * chain switch to
        //  */
        // CHAIN_SWITCH_TO("CHAIN_SWITCH_TO")
        CHAIN_SWITCH_TO,
        /// <summary>
        /// airdrop
        /// </summary>
        // /**
        //  * airdrop
        //  */
        // AIRDROP("AIRDROP")
        AIRDROP 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private TransactionSubtype(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}