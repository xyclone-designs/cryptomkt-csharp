using Com.Squareup.Moshi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.Params.AccountType;
using static Cryptomarket.Params.ContingencyType;
using static Cryptomarket.Params.Depth;
using static Cryptomarket.Params.IdentifyBy;
using static Cryptomarket.Params.NotificationType;
using static Cryptomarket.Params.OBSpeed;

namespace Cryptomarket.Params
{
    /// <summary>
    /// Order builder, used in order requests. used as a method chain
    /// </summary>
    public class OrderBuilder
    {
        private string clientOrderId;
        private string symbol;
        private Side side;
        private OrderType type;
        private TimeInForce timeInForce;
        private string quantity;
        private string price;
        private string stopPrice;
        private string expireTime;
        private bool strictValidate;
        private bool postOnly;
        private string takeRate;
        private string makeRate;
        public virtual OrderBuilder ClientOrderId(string clientOrderId)
        {
            this.clientOrderId = clientOrderId;
            return this;
        }

        public virtual OrderBuilder Symbol(string symbol)
        {
            this.symbol = symbol;
            return this;
        }

        public virtual OrderBuilder Side(Side side)
        {
            this.side = side;
            return this;
        }

        public virtual OrderBuilder OrderType(OrderType type)
        {
            this.type = type;
            return this;
        }

        public virtual OrderBuilder TimeInForce(TimeInForce timeInForce)
        {
            this.timeInForce = timeInForce;
            return this;
        }

        public virtual OrderBuilder Quantity(string quantity)
        {
            this.quantity = quantity;
            return this;
        }

        public virtual OrderBuilder Price(string price)
        {
            this.price = price;
            return this;
        }

        public virtual OrderBuilder StopPrice(string stopPrice)
        {
            this.stopPrice = stopPrice;
            return this;
        }

        public virtual OrderBuilder ExpireTime(string expireTime)
        {
            this.expireTime = expireTime;
            return this;
        }

        public virtual OrderBuilder StrictValidate(bool strictValidate)
        {
            this.strictValidate = strictValidate;
            return this;
        }

        public virtual OrderBuilder PostOnly(bool postOnly)
        {
            this.postOnly = postOnly;
            return this;
        }

        public virtual OrderBuilder TakeRate(string takeRate)
        {
            this.takeRate = takeRate;
            return this;
        }

        public virtual OrderBuilder MakeRate(string makeRate)
        {
            this.makeRate = makeRate;
            return this;
        }
    }
}