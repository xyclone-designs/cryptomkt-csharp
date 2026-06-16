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
    /// Symbol
    /// </summary>
    public class Symbol
    {
        private string type;
        private string baseCurrency;
        private string quoteCurrency;
        private string status;
        private string quantityIncrement;
        private string tickSize;
        private string takeRate;
        private string makeRate;
        private string feeCurrency;
        public virtual string GetType()
        {
            return type;
        }

        public virtual void SetType(string type)
        {
            this.type = type;
        }

        public virtual string GetBaseCurrency()
        {
            return baseCurrency;
        }

        public virtual void SetBaseCurrency(string baseCurrency)
        {
            this.baseCurrency = baseCurrency;
        }

        public virtual string GetQuoteCurrency()
        {
            return quoteCurrency;
        }

        public virtual void SetQuoteCurrency(string quoteCurrency)
        {
            this.quoteCurrency = quoteCurrency;
        }

        public virtual string GetStatus()
        {
            return status;
        }

        public virtual void SetStatus(string status)
        {
            this.status = status;
        }

        public virtual string GetQuantityIncrement()
        {
            return quantityIncrement;
        }

        public virtual void SetQuantityIncrement(string quantityIncrement)
        {
            this.quantityIncrement = quantityIncrement;
        }

        public virtual string GetTickSize()
        {
            return tickSize;
        }

        public virtual void SetTickSize(string tickSize)
        {
            this.tickSize = tickSize;
        }

        public virtual string GetTakeRate()
        {
            return takeRate;
        }

        public virtual void SetTakeRate(string takeRate)
        {
            this.takeRate = takeRate;
        }

        public virtual string GetMakeRate()
        {
            return makeRate;
        }

        public virtual void SetMakeRate(string makeRate)
        {
            this.makeRate = makeRate;
        }

        public virtual string GetFeeCurrency()
        {
            return feeCurrency;
        }

        public virtual void SetFeeCurrency(string feeCurrency)
        {
            this.feeCurrency = feeCurrency;
        }

        public virtual string ToString()
        {
            return "Symbol [type=" + type + ", baseCurrency=" + baseCurrency + ", quoteCurrency=" + quoteCurrency + ", status=" + status + ", quantityIncrement=" + quantityIncrement + ", tickSize=" + tickSize + ", takeRate=" + takeRate + ", makeRate=" + makeRate + ", feeCurrency=" + feeCurrency + "]";
        }
    }
}