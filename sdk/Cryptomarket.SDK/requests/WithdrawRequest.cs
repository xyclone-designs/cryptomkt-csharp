using Java.Util;
using Com.Cryptomarket.Params;
using Cryptomarket.SDK;
using Com.Squareup.Moshi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.SDK.Requests.AccountType;
using static Cryptomarket.SDK.Requests.ContingencyType;
using static Cryptomarket.SDK.Requests.Depth;
using static Cryptomarket.SDK.Requests.IdentifyBy;
using static Cryptomarket.SDK.Requests.NotificationType;
using static Cryptomarket.SDK.Requests.OBSpeed;
using static Cryptomarket.SDK.Requests.OrderBy;
using static Cryptomarket.SDK.Requests.OrderStatus;
using static Cryptomarket.SDK.Requests.OrderType;
using static Cryptomarket.SDK.Requests.Period;
using static Cryptomarket.SDK.Requests.PriceSpeed;
using static Cryptomarket.SDK.Requests.ReportType;
using static Cryptomarket.SDK.Requests.Side;
using static Cryptomarket.SDK.Requests.Sort;
using static Cryptomarket.SDK.Requests.SortBy;
using static Cryptomarket.SDK.Requests.SubAccountStatus;
using static Cryptomarket.SDK.Requests.SubAccountTransferType;
using static Cryptomarket.SDK.Requests.SubscriptionMode;
using static Cryptomarket.SDK.Requests.TickerSpeed;
using static Cryptomarket.SDK.Requests.TimeInForce;
using static Cryptomarket.SDK.Requests.TransactionStatus;
using static Cryptomarket.SDK.Requests.TransactionSubtype;
using static Cryptomarket.SDK.Requests.TransactionType;
using static Cryptomarket.SDK.Requests.UseOffchain;

namespace Cryptomarket.SDK.Requests
{
    public class WithdrawRequest
    {
        private string currency;
        private string networkCode;
        private Double amount;
        private string address;
        private string paymentId;
        private bool includeFee;
        private bool autoCommit;
        private string useOffchain;
        private string publicComment;
        public WithdrawRequest(ParamsBuilder paramsBuilder)
        {
            Dictionary<string, string> paramsMap = paramsBuilder.Build();
            currency = paramsMap[ArgNames.CURRENCY];
            networkCode = paramsMap[ArgNames.NETWORK_CODE];
            amount = Double.ParseDouble((string)paramsMap[ArgNames.AMOUNT]);
            paymentId = paramsMap[ArgNames.PAYMENT_ID];
            includeFee = Boolean.ParseBoolean((string)paramsMap[ArgNames.INCLUDE_FEE]);
            autoCommit = Boolean.ParseBoolean(paramsMap[ArgNames.AUTO_COMMIT]);
            useOffchain = paramsMap[ArgNames.USE_OFFCHAIN];
            publicComment = paramsMap[ArgNames.PUBLIC_COMMENT];
            address = paramsMap[ArgNames.ADDRESS];
        }
    }
}