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
    /// Websocket orderbook
    /// </summary>
    public class WSOrderBook
    {
        long timestamp;
        long sequence;
        IList<IList<string>> asks;
        IList<IList<string>> bids;
        public virtual long GetTimestamp()
        {
            return timestamp;
        }

        public virtual void SetTimestamp(long timestamp)
        {
            this.timestamp = timestamp;
        }

        public virtual long GetSequence()
        {
            return sequence;
        }

        public virtual void SetSequence(long sequence)
        {
            this.sequence = sequence;
        }

        public virtual IList<IList<string>> GetAsks()
        {
            return asks;
        }

        public virtual void SetAsks(IList<IList<string>> asks)
        {
            this.asks = asks;
        }

        public virtual IList<IList<string>> GetBids()
        {
            return bids;
        }

        public virtual void SetBids(IList<IList<string>> bids)
        {
            this.bids = bids;
        }

        public virtual string ToString()
        {
            return "WSOrderBook [asks=" + asks + ", bids=" + bids + ", sequence=" + sequence + ", timestamp=" + timestamp + "]";
        }
    }
}