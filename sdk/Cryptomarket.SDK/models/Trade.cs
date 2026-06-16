using Com.Cryptomarket.Params;
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
    /// Trade
    /// </summary>
    public class Trade
    {
        private long id;
        private string clientOrderId;
        private string orderId;
        private string symbol;
        private string quantity;
        private string price;
        private Side side;
        private string fee;
        private string timestamp;
        private bool taker;
        public virtual long GetId()
        {
            return id;
        }

        public virtual void SetId(long id)
        {
            this.id = id;
        }

        public virtual string GetClientOrderId()
        {
            return clientOrderId;
        }

        public virtual void SetClientOrderId(string clientOrderId)
        {
            this.clientOrderId = clientOrderId;
        }

        public virtual string GetOrderId()
        {
            return orderId;
        }

        public virtual void SetOrderId(string orderId)
        {
            this.orderId = orderId;
        }

        public virtual string GetSymbol()
        {
            return symbol;
        }

        public virtual void SetSymbol(string symbol)
        {
            this.symbol = symbol;
        }

        public virtual string GetQuantity()
        {
            return quantity;
        }

        public virtual void SetQuantity(string quantity)
        {
            this.quantity = quantity;
        }

        public virtual string GetPrice()
        {
            return price;
        }

        public virtual void SetPrice(string price)
        {
            this.price = price;
        }

        public virtual Side GetSide()
        {
            return side;
        }

        public virtual void SetSide(Side side)
        {
            this.side = side;
        }

        public virtual string GetFee()
        {
            return fee;
        }

        public virtual void SetFee(string fee)
        {
            this.fee = fee;
        }

        public virtual string GetTimestamp()
        {
            return timestamp;
        }

        public virtual void SetTimestamp(string timestamp)
        {
            this.timestamp = timestamp;
        }

        /// <summary>
        ///    * @return True if taker
        /// </summary>
        public virtual bool IsTaker()
        {
            return taker;
        }

        public virtual void SetTaker(bool taker)
        {
            this.taker = taker;
        }

        public virtual string ToString()
        {
            return "Trade [id=" + id + ", clientOrderId=" + clientOrderId + ", orderId=" + orderId + ", symbol=" + symbol + ", quantity=" + quantity + ", price=" + price + ", side=" + side + ", fee=" + fee + ", timestamp=" + timestamp + ", taker=" + taker + "]";
        }
    }
}