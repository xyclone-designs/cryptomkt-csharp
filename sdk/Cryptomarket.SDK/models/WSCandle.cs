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
    /// Websocket Candle
    /// </summary>
    public class WSCandle
    {
        long timestamp;
        string open;
        string close;
        string high;
        string low;
        string volumeBase;
        string volumeQuote;
        public virtual long GetTimestamp()
        {
            return timestamp;
        }

        public virtual void SetTimestamp(long timestamp)
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

        public virtual string GetBaseVolume()
        {
            return volumeBase;
        }

        public virtual void SetBaseVolume(string volumeBase)
        {
            this.volumeBase = volumeBase;
        }

        public virtual string GetQuoteVolume()
        {
            return volumeQuote;
        }

        public virtual void SetQuoteVolume(string volumeQuote)
        {
            this.volumeQuote = volumeQuote;
        }

        public virtual string ToString()
        {
            return "WSCandle [close=" + close + ", high=" + high + ", low=" + low + ", open=" + open + ", timestamp=" + timestamp + ", volumeBase=" + volumeBase + ", volumeQuote=" + volumeQuote + "]";
        }
    }
}