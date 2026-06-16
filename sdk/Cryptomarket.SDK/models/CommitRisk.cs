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
    public class CommitRisk
    {
        private int score;
        private bool rbf;
        private bool lowFee;
        public virtual int GetScore()
        {
            return score;
        }

        public virtual void SetScore(int score)
        {
            this.score = score;
        }

        public virtual bool GetRbf()
        {
            return rbf;
        }

        public virtual void SetRbf(bool rbf)
        {
            this.rbf = rbf;
        }

        public virtual bool GetLowFee()
        {
            return lowFee;
        }

        public virtual void SetLowFee(bool lowFee)
        {
            this.lowFee = lowFee;
        }

        public virtual string ToString()
        {
            return "CommitRisk [source=" + score + ", rbg=" + rbf + ", lowFee=" + lowFee + "]";
        }
    }
}