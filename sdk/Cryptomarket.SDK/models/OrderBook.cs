using Java.Util;
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
    /// Order book
    /// </summary>
    public class OrderBook
    {
        private IList<OrderbookLevel> ask;
        private IList<OrderbookLevel> bid;
        private string batchingTime;
        private string symbol;
        private string timestamp;
        private string askAveragePrice;
        private string bidAveragePrice;
        private int sequence;
        public virtual IList<OrderbookLevel> GetAsk()
        {
            return ask;
        }

        public virtual void SetAsk(IList<OrderbookLevel> ask)
        {
            this.ask = ask;
        }

        public virtual IList<OrderbookLevel> GetBid()
        {
            return bid;
        }

        public virtual void SetBid(IList<OrderbookLevel> bid)
        {
            this.bid = bid;
        }

        public virtual string GetBatchingTime()
        {
            return batchingTime;
        }

        public virtual void SetBatchingTime(string batchingTime)
        {
            this.batchingTime = batchingTime;
        }

        public virtual string GetSymbol()
        {
            return symbol;
        }

        public virtual void SetSymbol(string symbol)
        {
            this.symbol = symbol;
        }

        public virtual string GetTimestamp()
        {
            return timestamp;
        }

        public virtual void SetTimestamp(string timestamp)
        {
            this.timestamp = timestamp;
        }

        public virtual string GetAskAveragePrice()
        {
            return askAveragePrice;
        }

        public virtual void SetAskAveragePrice(string askAveragePrice)
        {
            this.askAveragePrice = askAveragePrice;
        }

        public virtual string GetBidAveragePrice()
        {
            return bidAveragePrice;
        }

        public virtual void SetBidAveragePrice(string bidAveragePrice)
        {
            this.bidAveragePrice = bidAveragePrice;
        }

        public virtual int GetSequence()
        {
            return sequence;
        }

        public virtual void SetSequence(int sequence)
        {
            this.sequence = sequence;
        }

        public virtual string ToString()
        {
            return "OrderBook [ask=" + ask + ", askAveragePrice=" + askAveragePrice + ", batchingTime=" + batchingTime + ", bid=" + bid + ", bidAveragePrice=" + bidAveragePrice + ", sequence=" + sequence + ", symbol=" + symbol + ", timestamp=" + timestamp + "]";
        }
    }
}