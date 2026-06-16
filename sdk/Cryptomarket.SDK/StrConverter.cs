using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.SDK.AccountType;
using static Cryptomarket.SDK.ContingencyType;
using static Cryptomarket.SDK.Depth;
using static Cryptomarket.SDK.IdentifyBy;
using static Cryptomarket.SDK.NotificationType;
using static Cryptomarket.SDK.OBSpeed;
using static Cryptomarket.SDK.OrderBy;
using static Cryptomarket.SDK.OrderStatus;
using static Cryptomarket.SDK.OrderType;
using static Cryptomarket.SDK.Period;
using static Cryptomarket.SDK.PriceSpeed;
using static Cryptomarket.SDK.ReportType;
using static Cryptomarket.SDK.Side;
using static Cryptomarket.SDK.Sort;
using static Cryptomarket.SDK.SortBy;
using static Cryptomarket.SDK.SubAccountStatus;
using static Cryptomarket.SDK.SubAccountTransferType;
using static Cryptomarket.SDK.SubscriptionMode;
using static Cryptomarket.SDK.TickerSpeed;
using static Cryptomarket.SDK.TimeInForce;
using static Cryptomarket.SDK.TransactionStatus;
using static Cryptomarket.SDK.TransactionSubtype;
using static Cryptomarket.SDK.TransactionType;
using static Cryptomarket.SDK.UseOffchain;

namespace Cryptomarket.SDK
{
    public class StrConverter
    {
        public static string FromCamelCaseToCapSnakeCase(string str)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char ch in str.ToCharArray())
            {
                if (Character.IsUpperCase(ch))
                {
                    builder.Append("_");
                }

                builder.Append(Character.ToUpperCase(ch));
            }

            return builder.ToString();
        }
    }
}