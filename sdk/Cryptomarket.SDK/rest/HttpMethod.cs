using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.SDK.Rest.AccountType;
using static Cryptomarket.SDK.Rest.ContingencyType;
using static Cryptomarket.SDK.Rest.Depth;
using static Cryptomarket.SDK.Rest.IdentifyBy;
using static Cryptomarket.SDK.Rest.NotificationType;
using static Cryptomarket.SDK.Rest.OBSpeed;
using static Cryptomarket.SDK.Rest.OrderBy;
using static Cryptomarket.SDK.Rest.OrderStatus;
using static Cryptomarket.SDK.Rest.OrderType;
using static Cryptomarket.SDK.Rest.Period;
using static Cryptomarket.SDK.Rest.PriceSpeed;
using static Cryptomarket.SDK.Rest.ReportType;
using static Cryptomarket.SDK.Rest.Side;
using static Cryptomarket.SDK.Rest.Sort;
using static Cryptomarket.SDK.Rest.SortBy;
using static Cryptomarket.SDK.Rest.SubAccountStatus;
using static Cryptomarket.SDK.Rest.SubAccountTransferType;
using static Cryptomarket.SDK.Rest.SubscriptionMode;
using static Cryptomarket.SDK.Rest.TickerSpeed;
using static Cryptomarket.SDK.Rest.TimeInForce;
using static Cryptomarket.SDK.Rest.TransactionStatus;
using static Cryptomarket.SDK.Rest.TransactionSubtype;
using static Cryptomarket.SDK.Rest.TransactionType;
using static Cryptomarket.SDK.Rest.UseOffchain;
using static Cryptomarket.SDK.Rest.HttpMethod;

namespace Cryptomarket.SDK.Rest
{
    /// <summary>
    /// Htthp method
    /// </summary>
    public enum HttpMethod
    {
        /// <summary>
        /// Get
        /// </summary>
        // /**
        //  * Get
        //  */
        // GET("GET")
        GET,
        /// <summary>
        /// Put
        /// </summary>
        // /**
        //  * Put
        //  */
        // PUT("PUT")
        PUT,
        /// <summary>
        /// Post
        /// </summary>
        // /**
        //  * Post
        //  */
        // POST("POST")
        POST,
        /// <summary>
        /// Delete
        /// </summary>
        // /**
        //  * Delete
        //  */
        // DELETE("DELETE")
        DELETE,
        /// <summary>
        /// Patch
        /// </summary>
        // /**
        //  * Patch
        //  */
        // PATCH("PATCH")
        PATCH 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private HttpMethod(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // --------------------
    }
}