using Java.Util;
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
    /// Order
    /// </summary>
    public class Order
    {
        private string id;
        private string clientOrderId;
        private string orderListId;
        private ContingencyType contingencyType;
        private string symbol;
        private Side side;
        private OrderStatus status;
        private OrderType type;
        private TimeInForce timeInForce;
        private string price;
        private string averagePrice;
        private string quantity;
        private string quantityCumulative;
        private string createdAt;
        private string updatedAt;
        private bool postOnly;
        private string stopPrice;
        private string expireTime;
        private IList<Trade> trades;
        private string originalClientOrderId;
        public virtual string GetId()
        {
            return id;
        }

        public virtual void SetId(string id)
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

        public virtual string GetOrderListId()
        {
            return orderListId;
        }

        public virtual void SetOrderListId(string orderListId)
        {
            this.orderListId = orderListId;
        }

        public virtual ContingencyType GetContingencyType()
        {
            return contingencyType;
        }

        public virtual void SetContingencyType(ContingencyType contingencyType)
        {
            this.contingencyType = contingencyType;
        }

        public virtual string GetSymbol()
        {
            return symbol;
        }

        public virtual void SetSymbol(string symbol)
        {
            this.symbol = symbol;
        }

        public virtual Side GetSide()
        {
            return side;
        }

        public virtual void SetSide(Side side)
        {
            this.side = side;
        }

        public virtual OrderStatus GetStatus()
        {
            return status;
        }

        public virtual void SetStatus(OrderStatus status)
        {
            this.status = status;
        }

        public virtual OrderType GetType()
        {
            return type;
        }

        public virtual void SetType(OrderType type)
        {
            this.type = type;
        }

        public virtual TimeInForce GetTimeInForce()
        {
            return timeInForce;
        }

        public virtual void SetTimeInForce(TimeInForce timeInForce)
        {
            this.timeInForce = timeInForce;
        }

        public virtual string GetPrice()
        {
            return price;
        }

        public virtual void SetPrice(string price)
        {
            this.price = price;
        }

        public virtual string GetAveragePrice()
        {
            return averagePrice;
        }

        public virtual void SetAveragePrice(string averagePrice)
        {
            this.averagePrice = averagePrice;
        }

        public virtual string GetQuantity()
        {
            return quantity;
        }

        public virtual void SetQuantity(string quantity)
        {
            this.quantity = quantity;
        }

        public virtual string GetQuantityCumulative()
        {
            return quantityCumulative;
        }

        public virtual void SetQuantityCumulative(string quantityCumulative)
        {
            this.quantityCumulative = quantityCumulative;
        }

        public virtual string GetCreatedAt()
        {
            return createdAt;
        }

        public virtual void SetCreatedAt(string createdAt)
        {
            this.createdAt = createdAt;
        }

        public virtual string GetUpdatedAt()
        {
            return updatedAt;
        }

        public virtual void SetUpdatedAt(string updatedAt)
        {
            this.updatedAt = updatedAt;
        }

        /// <summary>
        ///    * @return True if is a post only order
        /// </summary>
        public virtual bool IsPostOnly()
        {
            return postOnly;
        }

        public virtual void SetPostOnly(bool postOnly)
        {
            this.postOnly = postOnly;
        }

        public virtual string GetStopPrice()
        {
            return stopPrice;
        }

        public virtual void SetStopPrice(string stopPrice)
        {
            this.stopPrice = stopPrice;
        }

        public virtual string GetExpireTime()
        {
            return expireTime;
        }

        public virtual void SetExpireTime(string expireTime)
        {
            this.expireTime = expireTime;
        }

        public virtual IList<Trade> GetTrades()
        {
            return trades;
        }

        public virtual void SetTrades(IList<Trade> trades)
        {
            this.trades = trades;
        }

        public virtual string GetOriginalClientOrderId()
        {
            return originalClientOrderId;
        }

        public virtual void SetOriginalClientOrderId(string originalClientOrderId)
        {
            this.originalClientOrderId = originalClientOrderId;
        }

        public virtual string ToString()
        {
            return "Order [id=" + id + ", clientOrderId=" + clientOrderId + ", orderListId=" + orderListId + ", contingencyType=" + contingencyType + ", symbol=" + symbol + ", side=" + side + ", status=" + status + ", type=" + type + ", timeInForce=" + timeInForce + ", price=" + price + ", averagePrice=" + averagePrice + ", quantity=" + quantity + ", quantityCumulative=" + quantityCumulative + ", createdAt=" + createdAt + ", updatedAt=" + updatedAt + ", postOnly=" + postOnly + ", stopPrice=" + stopPrice + ", expireTime=" + expireTime + ", trades=" + trades + ", originalClientOrderId=" + originalClientOrderId + "]";
        }
    }
}