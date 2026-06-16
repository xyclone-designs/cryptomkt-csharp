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
    /// Websocket ticker
    /// </summary>
    public class WSTicker
    {
        long timestamp;
        string bestAsk;
        string bestAskQuantity;
        string bestBid;
        string bestBidQuantity;
        string open;
        string close;
        string high;
        string low;
        string volumeBase;
        string volumeQuote;
        string priceChange;
        string priceChangePercent;
        long lastTradeId;
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

        public virtual string GetClose()
        {
            return close;
        }

        public virtual void SetClose(string close)
        {
            this.close = close;
        }

        public virtual string GetHigh()
        {
            return high;
        }

        public virtual void SetHigh(string high)
        {
            this.high = high;
        }

        public virtual string GetLow()
        {
            return low;
        }

        public virtual void SetLow(string low)
        {
            this.low = low;
        }

        public virtual string GetPriceChange()
        {
            return priceChange;
        }

        public virtual void SetPriceChange(string priceChange)
        {
            this.priceChange = priceChange;
        }

        public virtual string GetPriceChangePercent()
        {
            return priceChangePercent;
        }

        public virtual void SetPriceChangePercent(string priceChangePercent)
        {
            this.priceChangePercent = priceChangePercent;
        }

        public virtual long GetLastTradeId()
        {
            return lastTradeId;
        }

        public virtual void SetLastTradeId(long lastTradeId)
        {
            this.lastTradeId = lastTradeId;
        }

        public virtual string GetVolumeBase()
        {
            return volumeBase;
        }

        public virtual void SetVolumeBase(string volumeBase)
        {
            this.volumeBase = volumeBase;
        }

        public virtual string GetVolumeQuote()
        {
            return volumeQuote;
        }

        public virtual void SetVolumeQuote(string volumeQuote)
        {
            this.volumeQuote = volumeQuote;
        }

        public virtual string GetOpen()
        {
            return open;
        }

        public virtual void SetOpen(string open)
        {
            this.open = open;
        }

        public virtual string ToString()
        {
            return "WSTicker [timestamp=" + timestamp + ", bestAsk=" + bestAsk + ", bestAskQuantity=" + bestAskQuantity + ", bestBid=" + bestBid + ", bestBidQuantity=" + bestBidQuantity + ", open=" + open + ", close=" + close + ", high=" + high + ", low=" + low + ", volumeBase=" + volumeBase + ", volumeQuote=" + volumeQuote + ", priceChange=" + priceChange + ", priceChangePercent=" + priceChangePercent + ", lastTradeId=" + lastTradeId + "]";
        }
    }
}