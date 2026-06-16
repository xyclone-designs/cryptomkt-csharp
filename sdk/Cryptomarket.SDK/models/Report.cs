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
    /// An order report or a trade report
    /// </summary>
    public class Report
    {
        private string id;
        private string clientOrderId;
        private string symbol;
        private Side side;
        private OrderStatus status;
        private OrderType type;
        private string timeInForce;
        private string quantity;
        private string price;
        private string quantityCumulative;
        private bool postOnly;
        private string createdAt;
        private string updatedAt;
        private string stopPrice;
        private string expireTime;
        private ReportType reportType;
        private string tradeId;
        private string tradeQuantity;
        private string tradePrice;
        private string tradeFee;
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

        public virtual string GetTimeInForce()
        {
            return timeInForce;
        }

        public virtual void SetTimeInForce(string timeInForce)
        {
            this.timeInForce = timeInForce;
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

        public virtual string GetQuantityCumulative()
        {
            return quantityCumulative;
        }

        public virtual void SetQuantityCumulative(string quantityCumulative)
        {
            this.quantityCumulative = quantityCumulative;
        }

        /// <summary>
        ///    * @return True if the order is post only
        /// </summary>
        public virtual bool IsPostOnly()
        {
            return postOnly;
        }

        public virtual void SetPostOnly(bool postOnly)
        {
            this.postOnly = postOnly;
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

        public virtual ReportType GetReportType()
        {
            return reportType;
        }

        public virtual void SetReportType(ReportType reportType)
        {
            this.reportType = reportType;
        }

        public virtual string GetTradeId()
        {
            return tradeId;
        }

        public virtual void SetTradeId(string tradeId)
        {
            this.tradeId = tradeId;
        }

        public virtual string GetTradeQuantity()
        {
            return tradeQuantity;
        }

        public virtual void SetTradeQuantity(string tradeQuantity)
        {
            this.tradeQuantity = tradeQuantity;
        }

        public virtual string GetTradePrice()
        {
            return tradePrice;
        }

        public virtual void SetTradePrice(string tradePrice)
        {
            this.tradePrice = tradePrice;
        }

        public virtual string GetTradeFee()
        {
            return tradeFee;
        }

        public virtual void SetTradeFee(string tradeFee)
        {
            this.tradeFee = tradeFee;
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
            return "Report [id=" + id + ", clientOrderId=" + clientOrderId + ", createdAt=" + createdAt + ", expireTime=" + expireTime + ", originalClientOrderId=" + originalClientOrderId + ", postOnly=" + postOnly + ", price=" + price + ", quantity=" + quantity + ", quantityCumulative=" + quantityCumulative + ", reportType=" + reportType + ", side=" + side + ", status=" + status + ", stopPrice=" + stopPrice + ", symbol=" + symbol + ", timeInForce=" + timeInForce + ", tradeFee=" + tradeFee + ", tradeId=" + tradeId + ", tradePrice=" + tradePrice + ", tradeQuantity=" + tradeQuantity + ", type=" + type + ", updatedAt=" + updatedAt + "]";
        }
    }
}