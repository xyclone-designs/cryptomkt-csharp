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
    /// Error Response from api
    /// </summary>
    public class ErrorResponse
    {
        private int status;
        private ErrorBody error;
        private string timestamp;
        private string path;
        private string requestId;
        private string message;
        public virtual int GetStatus()
        {
            return status;
        }

        public virtual ErrorBody GetError()
        {
            return error;
        }

        public virtual string GetTimestamp()
        {
            return timestamp;
        }

        public virtual string GetPath()
        {
            return path;
        }

        public virtual string GetRequestId()
        {
            return requestId;
        }

        public virtual string GetMessage()
        {
            return message;
        }

        public virtual string ToString()
        {
            return "ErrorResponse [error=" + error + ", message=" + message + ", path=" + path + ", requestId=" + requestId + ", status=" + status + ", timestamp=" + timestamp + "]";
        }
    }
}