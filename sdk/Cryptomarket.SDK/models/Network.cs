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
    /// Currency Network
    /// </summary>
    public class Network
    {
        private string code;
        private string network;
        private string protocol;
        private bool defaultNetwork;
        private bool payinEnabled;
        private bool payoutEnabled;
        private string precisionPayout;
        private string payoutFee;
        private bool payoutIsPaymentId;
        private bool payinPaymentId;
        private int payinConfirmations;
        private string addressRegex;
        private string paymentIdRegex;
        private string lowProcessingTime;
        private string highProcessingTime;
        private string avgProcessingTime;
        private string cryptoPaymentIdName;
        private string cryptoExplorer;
        private string networkName;
        private bool ensAvailable;
        private string contractAddress;
        private bool multichain;
        private Dictionary<string, string> assetId;
        public virtual string GetCode()
        {
            return code;
        }

        public virtual void SetCode(string code)
        {
            this.code = code;
        }

        public virtual string GetNetwork()
        {
            return network;
        }

        public virtual void SetNetwork(string network)
        {
            this.network = network;
        }

        /// <summary>
        ///    * @return True if the network supports ENS (Etherium Name Service)
        /// </summary>
        public virtual bool IsEnsAvailable()
        {
            return ensAvailable;
        }

        public virtual void SetEnsAvailable(bool isEnsAvailable)
        {
            this.ensAvailable = isEnsAvailable;
        }

        public virtual string GetProtocol()
        {
            return protocol;
        }

        public virtual void SetProtocol(string protocol)
        {
            this.protocol = protocol;
        }

        /// <summary>
        ///    * @return True if is default network for the currency
        /// </summary>
        public virtual bool IsDefaultNetwork()
        {
            return defaultNetwork;
        }

        public virtual void SetDefaultNetwork(bool isDefaultNetwork)
        {
            this.defaultNetwork = isDefaultNetwork;
        }

        /// <summary>
        ///    * @return True if pay in is enable
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
        ///    * @return True if pay out is enabled
        /// </summary>
        public virtual bool IsPayoutEnabled()
        {
            return payoutEnabled;
        }

        public virtual void SetPayoutEnabled(bool payoutEnabled)
        {
            this.payoutEnabled = payoutEnabled;
        }

        public virtual string GetPrecisionPayout()
        {
            return precisionPayout;
        }

        public virtual void SetPrecisionPayout(string precisionPayout)
        {
            this.precisionPayout = precisionPayout;
        }

        public virtual string GetPayoutFee()
        {
            return payoutFee;
        }

        public virtual void SetPayoutFee(string payoutFee)
        {
            this.payoutFee = payoutFee;
        }

        /// <summary>
        ///    * @return True if needs a payment id to withdraw
        /// </summary>
        public virtual bool IsPayoutPaymentId()
        {
            return payoutIsPaymentId;
        }

        public virtual void SetPayoutPaymentId(bool payoutPaymentId)
        {
            this.payoutIsPaymentId = payoutPaymentId;
        }

        /// <summary>
        ///    * @return True if payment id is required for deposits
        /// </summary>
        public virtual bool IsPayinPaymentId()
        {
            return payinPaymentId;
        }

        public virtual void SetPayinPaymentId(bool payinPaymentId)
        {
            this.payinPaymentId = payinPaymentId;
        }

        public virtual int GetPayinConfirmations()
        {
            return payinConfirmations;
        }

        public virtual void SetPayinConfirmations(int payinConfirmations)
        {
            this.payinConfirmations = payinConfirmations;
        }

        public virtual string GetAddressRegex()
        {
            return addressRegex;
        }

        public virtual void SetAddressRegex(string addressRegex)
        {
            this.addressRegex = addressRegex;
        }

        public virtual string GetPaymentIdRegex()
        {
            return paymentIdRegex;
        }

        public virtual void SetPaymentIdRegex(string paymentIdRegex)
        {
            this.paymentIdRegex = paymentIdRegex;
        }

        public virtual string GetLowProcessingTime()
        {
            return lowProcessingTime;
        }

        public virtual void SetLowProcessingTime(string lowProcessingTime)
        {
            this.lowProcessingTime = lowProcessingTime;
        }

        public virtual string GetHighProcessingTime()
        {
            return highProcessingTime;
        }

        public virtual void SetHighProcessingTime(string highProcessingTime)
        {
            this.highProcessingTime = highProcessingTime;
        }

        public virtual string GetAvgProcessingTime()
        {
            return avgProcessingTime;
        }

        public virtual void SetAvgProcessingTime(string avgProcessingTime)
        {
            this.avgProcessingTime = avgProcessingTime;
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

        public virtual string GetNetworkName()
        {
            return networkName;
        }

        public virtual void SetNetworkName(string networkName)
        {
            this.networkName = networkName;
        }

        public virtual string GetContractAddress()
        {
            return contractAddress;
        }

        public virtual void SetContractAddress(string contractAddress)
        {
            this.contractAddress = contractAddress;
        }

        public virtual bool GetMultichain()
        {
            return multichain;
        }

        public virtual void SetMultichain(bool multichain)
        {
            this.multichain = multichain;
        }

        public virtual Dictionary<string, string> GetAssetId()
        {
            return assetId;
        }

        public virtual void SetAssetId(Dictionary<string, string> assetId)
        {
            this.assetId = assetId;
        }

        public virtual string ToString()
        {
            return "Network [code=" + code + ", network=" + network + ", ensAvailable=" + ensAvailable + ", protocol=" + protocol + ", defaultNetwork=" + defaultNetwork + ", payinEnabled=" + payinEnabled + ", payoutEnabled=" + payoutEnabled + ", precisionPayout=" + precisionPayout + ", payoutFee=" + payoutFee + ", payoutIsPaymentId=" + payoutIsPaymentId + ", payinPaymentId=" + payinPaymentId + ", payinConfirmations=" + payinConfirmations + ", addressRegex=" + addressRegex + ", paymentIdRegex=" + paymentIdRegex + ", lowProcessingTime=" + lowProcessingTime + ", highProcessingTime=" + highProcessingTime + ", avgProcessingTime=" + avgProcessingTime + ", cryptoPaymentIdName=" + cryptoPaymentIdName + ", cryptoExplorer=" + cryptoExplorer + "]";
        }
    }
}