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
    /// Websocket orderbook top
    /// </summary>
    public class WSOrderBookTop
    {
        long timestamp;
        string bestAsk;
        string bestAskQuantity;
        string bestBid;
        string bestBidQuantity;
        public virtual long GetTimestamp()
        {
            return timestamp;
        }

        public virtual void SetTimestamp(long timestamp)
        {
            this.timestamp = timestamp;
        }

        public virtual string GetBestAsk()
        {
            return bestAsk;
        }

        public virtual void SetBestAsk(string bestAsk)
        {
            this.bestAsk = bestAsk;
        }

        public virtual string GetBestAskQuantity()
        {
            return bestAskQuantity;
        }

        public virtual void SetBestAskQuantity(string bestAskQuantity)
        {
            this.bestAskQuantity = bestAskQuantity;
        }

        public virtual string GetBestBid()
        {
            return bestBid;
        }

        public virtual void SetBestBid(string bestBid)
        {
            this.bestBid = bestBid;
        }

        public virtual string GetBestBidQuantity()
        {
            return bestBidQuantity;
        }

        public virtual void SetBestBidQuantity(string bestBidQuantity)
        {
            this.bestBidQuantity = bestBidQuantity;
        }

        public virtual string ToString()
        {
            return "WSOrderBookTop [bestAsk=" + bestAsk + ", bestAskQuantity=" + bestAskQuantity + ", bestBid=" + bestBid + ", bestBidQuantity=" + bestBidQuantity + ", timestamp=" + timestamp + "]";
        }
    }
}