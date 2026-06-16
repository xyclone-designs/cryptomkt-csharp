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
    /// Personal commission rate by symbol
    /// </summary>
    public class Commission
    {
        private string symbol;
        private string takeRate;
        private string makeRate;
        public virtual string GetSymbol()
        {
            return symbol;
        }

        public virtual void SetSymbol(string symbol)
        {
            this.symbol = symbol;
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

        public virtual string ToString()
        {
            return "Commission [makeRate=" + makeRate + ", symbol=" + symbol + ", takeRate=" + takeRate + "]";
        }
    }
}