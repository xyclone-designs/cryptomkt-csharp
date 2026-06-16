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
    /// Subaccount settings
    /// </summary>
    public class SubAccountSettings
    {
        string subAccountId;
        bool depositAddressGenerationEnabled;
        bool withdrawEnabled;
        string description;
        string createdAt;
        string updatedAt;
        public virtual string GetSubAccountId()
        {
            return subAccountId;
        }

        public virtual void SetSubAccountId(string subAccountId)
        {
            this.subAccountId = subAccountId;
        }

        /// <summary>
        ///    * @return True if the deposit address generation is enabled
        /// </summary>
        public virtual bool IsDepositAddressGenerationEnabled()
        {
            return depositAddressGenerationEnabled;
        }

        public virtual void SetDepositAddressGenerationEnabled(bool depositAddressGenerationEnabled)
        {
            this.depositAddressGenerationEnabled = depositAddressGenerationEnabled;
        }

        /// <summary>
        ///    * @return True if withdraw is enabled
        /// </summary>
        public virtual bool IsWithdrawEnabled()
        {
            return withdrawEnabled;
        }

        public virtual void SetWithdrawEnabled(bool withdrawEnabled)
        {
            this.withdrawEnabled = withdrawEnabled;
        }

        public virtual string GetDescription()
        {
            return description;
        }

        public virtual void SetDescription(string description)
        {
            this.description = description;
        }

        public virtual string GetCreatedAt()
        {
            return createdAt;
        }

        public virtual void SetCreatedAt(string createdAt)
        {
            this.createdAt = createdAt;
        }

        public virtual string GetUpdatedAt()
        {
            return updatedAt;
        }

        public virtual void SetUpdatedAt(string updatedAt)
        {
            this.updatedAt = updatedAt;
        }

        public virtual string ToString()
        {
            return "ACLSetting [createdAt=" + createdAt + ", depositAddressGenerationEnabled=" + depositAddressGenerationEnabled + ", description=" + description + ", subAccountId=" + subAccountId + ", updatedAt=" + updatedAt + ", withdrawEnabled=" + withdrawEnabled + "]";
        }
    }
}