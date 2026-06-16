using Com.Squareup.Moshi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.SDK.Models.AccountType;
using static Cryptomarket.SDK.Models.ContingencyType;
using static Cryptomarket.SDK.Models.Depth;
using static Cryptomarket.SDK.Models.IdentifyBy;
using static Cryptomarket.SDK.Models.NotificationType;
using static Cryptomarket.SDK.Models.OBSpeed;
using static Cryptomarket.SDK.Models.OrderBy;
using static Cryptomarket.SDK.Models.OrderStatus;
using static Cryptomarket.SDK.Models.OrderType;
using static Cryptomarket.SDK.Models.Period;
using static Cryptomarket.SDK.Models.PriceSpeed;
using static Cryptomarket.SDK.Models.ReportType;
using static Cryptomarket.SDK.Models.Side;
using static Cryptomarket.SDK.Models.Sort;
using static Cryptomarket.SDK.Models.SortBy;
using static Cryptomarket.SDK.Models.SubAccountStatus;
using static Cryptomarket.SDK.Models.SubAccountTransferType;
using static Cryptomarket.SDK.Models.SubscriptionMode;
using static Cryptomarket.SDK.Models.TickerSpeed;
using static Cryptomarket.SDK.Models.TimeInForce;
using static Cryptomarket.SDK.Models.TransactionStatus;
using static Cryptomarket.SDK.Models.TransactionSubtype;
using static Cryptomarket.SDK.Models.TransactionType;
using static Cryptomarket.SDK.Models.UseOffchain;

namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// Wallet address
    /// </summary>
    public class Address
    {
        /// <summary>
        /// currency of the address
        /// </summary>
        private string currency;
        /// <summary>
        /// the address
        /// </summary>
        private string address;
        /// <summary>
        /// aditional identifier required for some currencies
        /// </summary>
        private string paymentId;
        /// <summary>
        /// aditional identifier required for some currencies
        /// </summary>
        private string publicKey;
        /// <summary>
        /// network code
        /// </summary>
        private string networkCode;
        public virtual string GetCurrency()
        {
            return currency;
        }

        public virtual void SetCurrency(string currency)
        {
            this.currency = currency;
        }

        public virtual string GetAddress()
        {
            return address;
        }

        public virtual void SetAddress(string address)
        {
            this.address = address;
        }

        public virtual string GetPaymentId()
        {
            return paymentId;
        }

        public virtual void SetPaymentId(string paymentId)
        {
            this.paymentId = paymentId;
        }

        public virtual string GetPublicKey()
        {
            return publicKey;
        }

        public virtual void SetPublicKey(string publicKey)
        {
            this.publicKey = publicKey;
        }

        public virtual string GetNetworkCode()
        {
            return networkCode;
        }

        public virtual void SetNetworkCode(string networkCode)
        {
            this.networkCode = networkCode;
        }

        public virtual string ToString()
        {
            return "Address [currency=" + currency + ", address=" + address + ", paymentId=" + paymentId + ", publicKey=" + publicKey + ", networkCode=" + networkCode + "]";
        }
    }
}