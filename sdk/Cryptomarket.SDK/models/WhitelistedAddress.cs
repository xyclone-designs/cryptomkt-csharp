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
    /// Whitelisted address
    /// </summary>
    public class WhitelistedAddress
    {
        /// <summary>
        /// Name of the whitelist item
        /// </summary>
        private string name;
        /// <summary>
        /// Currency code
        /// </summary>
        private string currency;
        /// <summary>
        /// Code of the currency of the hosting network
        /// </summary>
        private string network;
        /// <summary>
        /// Address for deposits
        /// </summary>
        private string address;
        public virtual string GetName()
        {
            return name;
        }

        public virtual void SetName(string name)
        {
            this.name = name;
        }

        public virtual string GetCurrency()
        {
            return currency;
        }

        public virtual void SetCurrency(string currency)
        {
            this.currency = currency;
        }

        public virtual string GetNetwork()
        {
            return network;
        }

        public virtual void SetNetwork(string network)
        {
            this.network = network;
        }

        public virtual string GetAddress()
        {
            return address;
        }

        public virtual void SetAddress(string address)
        {
            this.address = address;
        }

        public virtual string ToString()
        {
            return "WhitelistedAddress [name=" + name + ", currency=" + currency + ", network=" + network + ", address=" + address + "]";
        }
    }
}