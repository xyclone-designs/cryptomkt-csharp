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
    /// Native transaction
    /// </summary>
    public class NativeTransaction
    {
        private string id;
        private long index;
        private string currency;
        private string amount;
        private string fee;
        private string address;
        private string paymentId;
        private string hash;
        private string offchainId;
        private string confirmations;
        private string publicComment;
        private string networkCode;
        private string errorCode;
        private IList<string> sender;
        public virtual string GetId()
        {
            return id;
        }

        public virtual void SetId(string id)
        {
            this.id = id;
        }

        public virtual long GetIndex()
        {
            return index;
        }

        public virtual void SetIndex(long index)
        {
            this.index = index;
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

        public virtual string GetFee()
        {
            return fee;
        }

        public virtual void SetFee(string fee)
        {
            this.fee = fee;
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

        public virtual string GetHash()
        {
            return hash;
        }

        public virtual void SetHash(string hash)
        {
            this.hash = hash;
        }

        public virtual string GetOffchainId()
        {
            return offchainId;
        }

        public virtual void SetOffchainId(string offchainId)
        {
            this.offchainId = offchainId;
        }

        public virtual string GetConfirmations()
        {
            return confirmations;
        }

        public virtual void SetConfirmations(string confirmations)
        {
            this.confirmations = confirmations;
        }

        public virtual string GetPublicComment()
        {
            return publicComment;
        }

        public virtual void SetPublicComment(string publicComment)
        {
            this.publicComment = publicComment;
        }

        public virtual string GetErrorCode()
        {
            return errorCode;
        }

        public virtual void SetErrorCode(string errorCode)
        {
            this.errorCode = errorCode;
        }

        public virtual IList<string> GetSender()
        {
            return sender;
        }

        public virtual void SetSender(IList<string> sender)
        {
            this.sender = sender;
        }

        public virtual string ToString()
        {
            return "NativeTransaction [id=" + id + ", index=" + index + ", currency=" + currency + ", amount=" + amount + ", fee=" + fee + ", address=" + address + ", paymentId=" + paymentId + ", hash=" + hash + ", offchainId=" + offchainId + ", confirmations=" + confirmations + ", publicComment=" + publicComment + ", networkCode=" + networkCode + ", errorCode=" + errorCode + ", sender=" + sender + "]";
        }
    }
}