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
    public class Fee
    {
        private string fee;
        private string networkFee;
        private string amount;
        private string currency;
        public Fee(string fee, string networkFee, string amount, string currency)
        {
            this.fee = fee;
            this.networkFee = networkFee;
            this.amount = amount;
            this.currency = currency;
        }

        public virtual string GetFee()
        {
            return fee;
        }

        public virtual void SetFee(string fee)
        {
            this.fee = fee;
        }

        public virtual string GetNetworkFee()
        {
            return networkFee;
        }

        public virtual void SetNetworkFee(string networkFee)
        {
            this.networkFee = networkFee;
        }

        public virtual string GetAmount()
        {
            return amount;
        }

        public virtual void SetAmount(string amount)
        {
            this.amount = amount;
        }

        public virtual string GetCurrency()
        {
            return currency;
        }

        public virtual void SetCurrency(string currency)
        {
            this.currency = currency;
        }

        public virtual string ToString()
        {
            return "Fee [fee=" + fee + ", networkFee=" + networkFee + ", amount=" + amount + ", currency=" + currency + "]";
        }
    }
}