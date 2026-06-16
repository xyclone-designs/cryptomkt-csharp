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
    /// Ticker
    /// </summary>
    public class Ticker
    {
        private string ask;
        private string bid;
        private string last;
        private string low;
        private string high;
        private string open;
        private string volume;
        private string volumeQuote;
        private string timestamp;
        public virtual string GetAsk()
        {
            return ask;
        }

        public virtual void SetAsk(string ask)
        {
            this.ask = ask;
        }

        public virtual string GetBid()
        {
            return bid;
        }

        public virtual void SetBid(string bid)
        {
            this.bid = bid;
        }

        public virtual string GetLast()
        {
            return last;
        }

        public virtual void SetLast(string last)
        {
            this.last = last;
        }

        public virtual string GetLow()
        {
            return low;
        }

        public virtual void SetLow(string low)
        {
            this.low = low;
        }

        public virtual string GetHigh()
        {
            return high;
        }

        public virtual void SetHigh(string high)
        {
            this.high = high;
        }

        public virtual string GetOpen()
        {
            return open;
        }

        public virtual void SetOpen(string open)
        {
            this.open = open;
        }

        public virtual string GetVolume()
        {
            return volume;
        }

        public virtual void SetVolume(string volume)
        {
            this.volume = volume;
        }

        public virtual string GetVolumeQuote()
        {
            return volumeQuote;
        }

        public virtual void SetVolumeQuote(string volumeQuote)
        {
            this.volumeQuote = volumeQuote;
        }

        public virtual string GetTimestamp()
        {
            return timestamp;
        }

        public virtual void SetTimestamp(string timestamp)
        {
            this.timestamp = timestamp;
        }

        public virtual string ToString()
        {
            return "Ticker [ask=" + ask + ", bid=" + bid + ", high=" + high + ", last=" + last + ", low=" + low + ", open=" + open + ", timestamp=" + timestamp + ", volume=" + volume + ", volumeQuote=" + volumeQuote + "]";
        }
    }
}