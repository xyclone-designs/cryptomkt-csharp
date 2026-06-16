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
    /// Websocket response
    /// </summary>
    public class WSJsonResponse
    {
        private string jsonrpc;
        private int id;
        private string method;
        private string channel;
        private string targetCurrency;
        private ErrorBody error;
        private object params;
        private object result;
        private object snapshot;
        private object update;
        private object data;
        public virtual string GetJsonrpc()
        {
            return jsonrpc;
        }

        public virtual object GetData()
        {
            return data;
        }

        public virtual void SetData(object data)
        {
            this.data = data;
        }

        public virtual object GetUpdate()
        {
            return update;
        }

        public virtual void SetUpdate(object update)
        {
            this.update = update;
        }

        public virtual object GetSnapshot()
        {
            return snapshot;
        }

        public virtual void SetSnapshot(object snapshot)
        {
            this.snapshot = snapshot;
        }

        public virtual void SetJsonrpc(string jsonrpc)
        {
            this.jsonrpc = jsonrpc;
        }

        public virtual int GetId()
        {
            return id;
        }

        public virtual void SetId(int id)
        {
            this.id = id;
        }

        public virtual string GetMethod()
        {
            return method;
        }

        public virtual void SetMethod(string method)
        {
            this.method = method;
        }

        public virtual string GetChannel()
        {
            return channel;
        }

        public virtual void SetChannel(string channel)
        {
            this.channel = channel;
        }

        public virtual ErrorBody GetError()
        {
            return error;
        }

        public virtual void SetError(ErrorBody error)
        {
            this.error = error;
        }

        public virtual object GetParams()
        {
            return @params;
        }

        public virtual void SetParams(object @params)
        {
            this.@params = @params;
        }

        public virtual object GetResult()
        {
            return result;
        }

        public virtual void SetResult(object result)
        {
            this.result = result;
        }

        public virtual string GetTargetCurrency()
        {
            return targetCurrency;
        }

        public virtual void SetTargetCurrency(string targetCurrency)
        {
            this.targetCurrency = targetCurrency;
        }

        public virtual string ToString()
        {
            return "WSJsonResponse [jsonrpc=" + jsonrpc + ", id=" + id + ", method=" + method + ", channel=" + channel + ", targetCurrency=" + targetCurrency + ", error=" + error + ", params=" + @params + ", result=" + result + ", snapshot=" + snapshot + ", update=" + update + ", data=" + data + "]";
        }
    }
}