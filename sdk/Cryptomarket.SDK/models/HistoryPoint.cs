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
    /// Price history point
    /// </summary>
    public class HistoryPoint
    {
        private string timestamp;
        private string open;
        private string close;
        private string min;
        private string max;
        public virtual string GetTimestamp()
        {
            return timestamp;
        }

        public virtual void SetTimestamp(string timestamp)
        {
            this.timestamp = timestamp;
        }

        public virtual string GetOpen()
        {
            return open;
        }

        public virtual void SetOpen(string open)
        {
            this.open = open;
        }

        public virtual string GetClose()
        {
            return close;
        }

        public virtual void SetClose(string close)
        {
            this.close = close;
        }

        public virtual string GetMin()
        {
            return min;
        }

        public virtual void SetMin(string min)
        {
            this.min = min;
        }

        public virtual string GetMax()
        {
            return max;
        }

        public virtual void SetMax(string max)
        {
            this.max = max;
        }

        public virtual string ToString()
        {
            return "HistoryPoint [close=" + close + ", max=" + max + ", min=" + min + ", open=" + open + ", timestamp=" + timestamp + "]";
        }
    }
}