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
    /// Public Trade
    /// </summary>
    public class PublicTrade
    {
        private long id;
        private string quantity;
        private string price;
        private string side;
        private string timestamp;
        public virtual long GetId()
        {
            return id;
        }

        public virtual void SetId(long id)
        {
            this.id = id;
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

        public virtual string GetSide()
        {
            return side;
        }

        public virtual void SetSide(string side)
        {
            this.side = side;
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
            return "Trade [id=" + id + ", price=" + price + ", quantity=" + quantity + ", side=" + side + ", timestamp=" + timestamp + "]";
        }
    }
}