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
    /// Amount lock. amount of user balance locked
    /// </summary>
    public class AmountLock
    {
        private long id;
        private string currency;
        private string amount;
        private string dateEnd;
        private string description;
        private bool canceled;
        private string canceledAt;
        private string cancelDescription;
        private string createdAt;
        public virtual long GetId()
        {
            return id;
        }

        public virtual void SetId(long id)
        {
            this.id = id;
        }

        public virtual string GetCurrency()
        {
            return currency;
        }

        public virtual void SetCurrency(string currency)
        {
            this.currency = currency;
        }

        public virtual string GetAmount()
        {
            return amount;
        }

        public virtual void SetAmount(string amount)
        {
            this.amount = amount;
        }

        public virtual string GetDateEnd()
        {
            return dateEnd;
        }

        public virtual void SetDateEnd(string dateEnd)
        {
            this.dateEnd = dateEnd;
        }

        public virtual string GetDescription()
        {
            return description;
        }

        public virtual void SetDescription(string description)
        {
            this.description = description;
        }

        /// <summary>
        ///    * @return True if the lock is canceled
        /// </summary>
        public virtual bool IsCanceled()
        {
            return canceled;
        }

        public virtual void SetCanceled(bool canceled)
        {
            this.canceled = canceled;
        }

        public virtual string GetCanceledAt()
        {
            return canceledAt;
        }

        public virtual void SetCanceledAt(string canceledAt)
        {
            this.canceledAt = canceledAt;
        }

        public virtual string GetCancelDescription()
        {
            return cancelDescription;
        }

        public virtual void SetCancelDescription(string cancelDescription)
        {
            this.cancelDescription = cancelDescription;
        }

        public virtual string GetCreatedAt()
        {
            return createdAt;
        }

        public virtual void SetCreatedAt(string createdAt)
        {
            this.createdAt = createdAt;
        }

        public virtual string ToString()
        {
            return "AmountLock [id=" + id + ", amount=" + amount + ", cancelDescription=" + cancelDescription + ", cancelled=" + canceled + ", cancelledAt=" + canceledAt + ", createdAt=" + createdAt + ", currency=" + currency + ", dateEnd=" + dateEnd + ", description=" + description + "]";
        }
    }
}