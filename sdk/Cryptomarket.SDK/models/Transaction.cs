using Com.Cryptomarket.Params;
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
    /// Transaction
    /// </summary>
    public class Transaction
    {
        private long id;
        private TransactionStatus status;
        private TransactionType type;
        private TransactionSubtype subtype;
        private string createdAt;
        private string updatedAt;
        private string lastActivityAt;
        private NativeTransaction nativeTransaction;
        private string networkCode;
        private CommitRisk commitRisk;
        public virtual long GetId()
        {
            return id;
        }

        public virtual void SetId(long id)
        {
            this.id = id;
        }

        public virtual TransactionStatus GetStatus()
        {
            return status;
        }

        public virtual void SetStatus(TransactionStatus status)
        {
            this.status = status;
        }

        public virtual TransactionType GetType()
        {
            return type;
        }

        public virtual void SetType(TransactionType type)
        {
            this.type = type;
        }

        public virtual TransactionSubtype GetSubtype()
        {
            return subtype;
        }

        public virtual void SetSubtype(TransactionSubtype subtype)
        {
            this.subtype = subtype;
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

        public virtual string GetLastActivityAt()
        {
            return lastActivityAt;
        }

        public virtual void SetLastActivityAt(string lastActivityAt)
        {
            this.lastActivityAt = lastActivityAt;
        }

        public virtual NativeTransaction GetNativeTransaction()
        {
            return nativeTransaction;
        }

        public virtual void SetNativeTransaction(NativeTransaction nativeTransaction)
        {
            this.nativeTransaction = nativeTransaction;
        }

        public virtual string GetNetworkCode()
        {
            return networkCode;
        }

        public virtual void SetNetworkCode(string networkCode)
        {
            this.networkCode = networkCode;
        }

        public virtual CommitRisk GetCommitRisk()
        {
            return commitRisk;
        }

        public virtual void SetCommitRisk(CommitRisk commitRisk)
        {
            this.commitRisk = commitRisk;
        }

        public virtual string ToString()
        {
            return "Transaction [id=" + id + ", status=" + status + ", type=" + type + ", subtype=" + subtype + ", createdAt=" + createdAt + ", updatedAt=" + updatedAt + ", lastActivityAt=" + lastActivityAt + ", nativeTransaction=" + nativeTransaction + ", networkCode=" + networkCode + ", commitRisk=" + commitRisk + "]";
        }
    }
}