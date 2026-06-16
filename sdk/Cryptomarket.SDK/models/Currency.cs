using Java.Util;
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
    /// Currency
    /// </summary>
    public class Currency
    {
        private string fullName;
        private bool crypto;
        private bool payinEnabled;
        private bool payoutEnabled;
        private bool transferEnabled;
        private string sign;
        private string cryptoPaymentIdName;
        private string cryptoExplorer;
        private string precisionTransfer;
        private Double accountTopOrder;
        private string qrPrefix;
        private bool delisted;
        private IList<Network> networks;
        public virtual string GetFullName()
        {
            return fullName;
        }

        public virtual void SetFullName(string fullName)
        {
            this.fullName = fullName;
        }

        /// <summary>
        ///    * @return True if is a crypto currency (and not a fiat currency)
        /// </summary>
        public virtual bool IsCrypto()
        {
            return crypto;
        }

        public virtual void SetCrypto(bool crypto)
        {
            this.crypto = crypto;
        }

        /// <summary>
        ///    * @return True is pay in is enabled
        /// </summary>
        public virtual bool IsPayinEnabled()
        {
            return payinEnabled;
        }

        public virtual void SetPayinEnabled(bool payinEnabled)
        {
            this.payinEnabled = payinEnabled;
        }

        /// <summary>
        ///    * @return True if is payout enabled
        /// </summary>
        public virtual bool IsPayoutEnabled()
        {
            return payoutEnabled;
        }

        public virtual void SetPayoutEnabled(bool payoutEnabled)
        {
            this.payoutEnabled = payoutEnabled;
        }

        /// <summary>
        ///    * @return True if transfers are enabled
        /// </summary>
        public virtual bool IsTransferEnabled()
        {
            return transferEnabled;
        }

        public virtual void SetTransferEnabled(bool transferEnabled)
        {
            this.transferEnabled = transferEnabled;
        }

        public virtual string GetSign()
        {
            return sign;
        }

        public virtual void SetSign(string sign)
        {
            this.sign = sign;
        }

        public virtual string GetCryptoPaymentIdName()
        {
            return cryptoPaymentIdName;
        }

        public virtual void SetCryptoPaymentIdName(string cryptoPaymentIdName)
        {
            this.cryptoPaymentIdName = cryptoPaymentIdName;
        }

        public virtual string GetCryptoExplorer()
        {
            return cryptoExplorer;
        }

        public virtual void SetCryptoExplorer(string cryptoExplorer)
        {
            this.cryptoExplorer = cryptoExplorer;
        }

        public virtual string GetPrecisionTransfer()
        {
            return precisionTransfer;
        }

        public virtual void SetPrecisionTransfer(string precisionTransfer)
        {
            this.precisionTransfer = precisionTransfer;
        }

        public virtual Double GetAccountTopOrder()
        {
            return accountTopOrder;
        }

        public virtual void SetAccountTopOrder(Double accountTopOrder)
        {
            this.accountTopOrder = accountTopOrder;
        }

        public virtual string GetQrPrefix()
        {
            return qrPrefix;
        }

        public virtual void SetQrPrefix(string qrPrefix)
        {
            this.qrPrefix = qrPrefix;
        }

        /// <summary>
        ///    * @return True if the currency has been delisted
        /// </summary>
        public virtual bool IsDelisted()
        {
            return delisted;
        }

        public virtual void SetDelisted(bool delisted)
        {
            this.delisted = delisted;
        }

        public virtual IList<Network> GetNetworks()
        {
            return networks;
        }

        public virtual void SetNetworks(IList<Network> networks)
        {
            this.networks = networks;
        }

        public virtual string ToString()
        {
            return "Currency [fullName=" + fullName + ", crypto=" + crypto + ", payinEnabled=" + payinEnabled + ", payoutEnabled=" + payoutEnabled + ", transferEnabled=" + transferEnabled + ", sign=" + sign + ", cryptoPaymentIdName=" + cryptoPaymentIdName + ", cryptoExplorer=" + cryptoExplorer + ", precisionTransfer=" + precisionTransfer + ", accountTopOrder=" + accountTopOrder + ", qrPrefix=" + qrPrefix + ", delisted=" + delisted + ", networks=" + networks + "]";
        }
    }
}