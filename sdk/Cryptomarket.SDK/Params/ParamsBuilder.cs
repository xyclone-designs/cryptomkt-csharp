using CryptoMarket.SDK.Exceptions;

using System.Text;

namespace CryptoMarket.SDK.Params
{
    /// <summary>
    /// Builds and aggregates the params of a requests
    /// </summary>
    public class ParamsBuilder
    {
        private Dictionary<string, object> @params = [];

        public virtual object Remove(string argName)
        {
            return @params.Remove(argName);
        }
        private static string FromSnakeCaseToCamelCase(string arg)
        {
            string[] parts = arg.Split("_", 0);
            StringBuilder builder = new ();
            for (int i = 0; i < parts.Length; i++)
            {
                if (i == 0)
                {
                    builder.Append(parts[i]);
                    continue;
                }

                builder
                    .Append(parts[i][..1].ToUpperInvariant())
                    .Append(parts[i].Substring(1));
            }

            return builder.ToString();
        }

        public virtual Dictionary<string, string> Build()
        {
            return @params.ToDictionary(_ => _.Key, _ => _.ToString());
        }
        public virtual Dictionary<string, object> BuildObjectMap()
        {
            return @params;
        }

        private ParamsBuilder AddArg(string key, bool? arg)
        {
            if (arg != null)
                @params.Add(key, arg.Value.ToString());

            return this;
        }
        private ParamsBuilder AddArg(string key, string? arg)
        {
            if (arg != null)
                @params.Add(key, arg);

            return this;
        }
        private ParamsBuilder AddArg(string key, int? arg)
        {
            if (arg != null)
                @params.Add(key, arg.Value.ToString());

            return this;
        }
        private ParamsBuilder AddArg<T>(string key, T arg) where T : Enum
        {
            if (arg != null)
                @params.Add(key, arg.ToString());

            return this;
        }

        private ParamsBuilder AddCommaSeparatedList(string key, IList<string> list)
        {
            if (list != null && list.Count > 0)
                @params.Add(key, string.Join(",", list));
            return this;
        }
        private ParamsBuilder AddListOrAsterisc(string key, IList<string> list)
        {
            @params.Add(key, list == null || list.Count == 0 ? ["*"] : list);

            return this;
        }
        private ParamsBuilder AddList(string key, IList<string> list)
        {
            if (list != null && list.Count != 0)
                @params.Add(key, list);

            return this;
        }
        private ParamsBuilder AddEnumList<T>(string key, IList<T> list) where T : Enum
        {
            IList<string> strList = [];

            if (list != null && list.Count > 0)
                strList = [.. list.Select(_ => _.ToString())];

            return AddCommaSeparatedList(key, strList);
        }

        public virtual ParamsBuilder CheckRequired(IList<string> requiredParams)
        {
            IList<string> missing = [.. requiredParams.Where(_ => !@params.ContainsKey(_))];

            if (missing.Count > 0)
            {
                throw new CryptoMarketArgumentException(string.Format("Missing required parameters: [{0}]", string.Join(", ", missing)));
            }

            return this;
        }

        public virtual ParamsBuilder Parameter(string key, string value)
        {
            return AddArg(key, value);
        }
        public virtual ParamsBuilder Currencies(IList<string> currencies)
        {
            return AddCommaSeparatedList(ArgNames.CURRENCIES, currencies);
        }
        public virtual ParamsBuilder Symbols(IList<string> symbols)
        {
            return AddCommaSeparatedList(ArgNames.SYMBOLS, symbols);
        }
        public virtual ParamsBuilder From(string from)
        {
            return AddArg(ArgNames.FROM, from);
        }
        public virtual ParamsBuilder Till(string till)
        {
            return AddArg(ArgNames.TILL, till);
        }
        public virtual ParamsBuilder Limit(int limit)
        {
            return AddArg(ArgNames.LIMIT, limit);
        }
        public virtual ParamsBuilder Limit(string limit)
        {
            return AddArg(ArgNames.LIMIT, limit);
        }
        public virtual ParamsBuilder Offset(int offset)
        {
            return AddArg(ArgNames.OFFSET, offset);
        }
        public virtual ParamsBuilder Sort(Sort sort)
        {
            return AddArg(ArgNames.SORT, sort);
        }
        public virtual ParamsBuilder By(SortBy by)
        {
            return AddArg(ArgNames.BY, by);
        }
        public virtual ParamsBuilder OrderBy(OrderBy by)
        {
            return AddArg(ArgNames.ORDER_BY, by);
        }
        public virtual ParamsBuilder To(string to)
        {
            return AddArg(ArgNames.TO, to);
        }
        public virtual ParamsBuilder Since(string since)
        {
            return AddArg(ArgNames.SINCE, since);
        }
        public virtual ParamsBuilder Until(string until)
        {
            return AddArg(ArgNames.UNTIL, until);
        }
        public virtual ParamsBuilder Period(Period period)
        {
            return AddArg(ArgNames.PERIOD, period);
        }
        public virtual ParamsBuilder Symbol(string symbol)
        {
            return AddArg(ArgNames.SYMBOL, symbol);
        }
        public virtual ParamsBuilder Side(Side side)
        {
            return AddArg(ArgNames.SIDE, side);
        }
        public virtual ParamsBuilder Quantity(string quantity)
        {
            return AddArg(ArgNames.QUANTITY, quantity);
        }
        public virtual ParamsBuilder ClientOrderId(string clientOrderId)
        {
            return AddArg(ArgNames.CLIENT_ORDER_ID, clientOrderId);
        }
        public virtual ParamsBuilder OrderType(OrderType orderType)
        {
            return AddArg(ArgNames.ORDER_TYPE, orderType);
        }
        public virtual ParamsBuilder Price(string price)
        {
            return AddArg(ArgNames.PRICE, price);
        }
        public virtual ParamsBuilder StopPrice(string stopPrice)
        {
            return AddArg(ArgNames.STOP_PRICE, stopPrice);
        }
        public virtual ParamsBuilder TimeInForce(TimeInForce timeInForce)
        {
            return AddArg(ArgNames.TIME_IN_FORCE, timeInForce);
        }
        public virtual ParamsBuilder ExpireTime(string expireTime)
        {
            return AddArg(ArgNames.EXPIRE_TIME, expireTime);
        }
        public virtual ParamsBuilder StrictValidate(bool strictValidate)
        {
            return AddArg(ArgNames.STRICT_VALIDATE, strictValidate);
        }
        public virtual ParamsBuilder PostOnly(bool postOnly)
        {
            return AddArg(ArgNames.POST_ONLY, postOnly);
        }
        public virtual ParamsBuilder TakeRate(string takeRate)
        {
            return AddArg(ArgNames.TAKE_RATE, takeRate);
        }
        public virtual ParamsBuilder MakeRate(string makeRate)
        {
            return AddArg(ArgNames.MAKE_RATE, makeRate);
        }
        public virtual ParamsBuilder NewClientOrderId(string newClientOrderId)
        {
            return AddArg(ArgNames.NEW_CLIENT_ORDER_ID, newClientOrderId);
        }
        public virtual ParamsBuilder Currency(string currency)
        {
            return AddArg(ArgNames.CURRENCY, currency);
        }
        public virtual ParamsBuilder Address(string address)
        {
            return AddArg(ArgNames.ADDRESS, address);
        }
        public virtual ParamsBuilder Amount(string amount)
        {
            return AddArg(ArgNames.AMOUNT, amount);
        }
        public virtual ParamsBuilder PaymentId(string paymentId)
        {
            return AddArg(ArgNames.PAYMENT_ID, paymentId);
        }
        public virtual ParamsBuilder IncludeFee(bool includeFee)
        {
            return AddArg(ArgNames.INCLUDE_FEE, includeFee);
        }
        public virtual ParamsBuilder AutoCommit(bool autoCommit)
        {
            return AddArg(ArgNames.AUTO_COMMIT, autoCommit);
        }
        public virtual ParamsBuilder UseOffchain(UseOffchain useOffchain)
        {
            return AddArg(ArgNames.USE_OFFCHAIN, useOffchain);
        }
        public virtual ParamsBuilder PublicComment(string publicComment)
        {
            return AddArg(ArgNames.PUBLIC_COMMENT, publicComment);
        }
        public virtual ParamsBuilder Source(AccountType accountType)
        {
            return AddArg(ArgNames.SOURCE, accountType);
        }
        public virtual ParamsBuilder Destination(AccountType accountType)
        {
            return AddArg(ArgNames.DESTINATION, accountType);
        }
        public virtual ParamsBuilder Types(IList<TransactionType> transactionTypes)
        {
            return AddEnumList(ArgNames.TYPES, transactionTypes);
        }
        public virtual ParamsBuilder Subtypes(IList<TransactionSubtype> subtypes)
        {
            return AddEnumList(ArgNames.SUBTYPES, subtypes);
        }
        public virtual ParamsBuilder Statuses<T>(IList<T> statuses) where T : Enum
        {
            return AddEnumList(ArgNames.STATUSES, statuses);
        }
        public virtual ParamsBuilder TransactionIds(IList<string> transactionIds)
        {
            return AddCommaSeparatedList(ArgNames.TRANSACTION_IDS, transactionIds);
        }
        public virtual ParamsBuilder IdFrom(int idFrom)
        {
            return AddArg(ArgNames.ID_FROM, idFrom);
        }
        public virtual ParamsBuilder IdTill(int idTill)
        {
            return AddArg(ArgNames.ID_TILL, idTill);
        }
        public virtual ParamsBuilder BaseCurrency(string baseCurrency)
        {
            return AddArg(ArgNames.BASE_CURRENCY, baseCurrency);
        }
        public virtual ParamsBuilder ActiveAt(string activeAt)
        {
            return AddArg(ArgNames.ACTIVE_AT, activeAt);
        }
        public virtual ParamsBuilder TransactionId(string transactionId)
        {
            return AddArg(ArgNames.TRANSACTION_ID, transactionId);
        }
        public virtual ParamsBuilder Active(bool active)
        {
            return AddArg(ArgNames.ACTIVE, active);
        }
        public virtual ParamsBuilder Volume(int volume)
        {
            return AddArg(ArgNames.VOLUME, volume);
        }
        public virtual ParamsBuilder FromCurrency(string fromCurrency)
        {
            return AddArg(ArgNames.FROM_CURRENCY, fromCurrency);
        }
        public virtual ParamsBuilder ToCurrency(string toCurrency)
        {
            return AddArg(ArgNames.TO_CURRENCY, toCurrency);
        }
        public virtual ParamsBuilder IdentifyBy(IdentifyBy identifyBy)
        {
            return AddArg(ArgNames.IDENTIFY_BY, identifyBy);
        }
        public virtual ParamsBuilder Identifier(string identifier)
        {
            return AddArg(ArgNames.IDENTIFIER, identifier);
        }
        public virtual ParamsBuilder OrderListId(string orderListId)
        {
            return AddArg(ArgNames.ORDER_LIST_ID, orderListId);
        }
        public virtual ParamsBuilder ContingencyType(ContingencyType contingencyType)
        {
            return AddArg(ArgNames.CONTINGENCY_TYPE, contingencyType);
        }
        public virtual ParamsBuilder SymbolListOrAsteric(IList<string> symbols)
        {
            return AddListOrAsterisc(ArgNames.SYMBOLS, symbols);
        }
        public virtual ParamsBuilder OrderList(IList<OrderBuilder> orders)
        {
            this.@params.Add(ArgNames.ORDERS, orders);
            return this;
        }
        public virtual ParamsBuilder SubAccountIds(IList<string> subAccountIds)
        {
            return AddCommaSeparatedList(ArgNames.SUB_ACCOUNT_IDS, subAccountIds);
        }
        public virtual ParamsBuilder DepositAddressGenerationEnabled(bool enabled)
        {
            return AddArg(ArgNames.DEPOSIT_ADDRESS_GENERATION_ENABLED, enabled);
        }
        public virtual ParamsBuilder WithdrawEnabled(bool enabled)
        {
            return AddArg(ArgNames.WITHDRAW_ENABLED, enabled);
        }
        public virtual ParamsBuilder CreatedAt(string createdAt)
        {
            return AddArg(ArgNames.CREATED_AT, createdAt);
        }
        public virtual ParamsBuilder UpdatedAt(string updatedAt)
        {
            return AddArg(ArgNames.UPDATED_AT, updatedAt);
        }
        public virtual ParamsBuilder Description(string description)
        {
            return AddArg(ArgNames.DESCRIPTION, description);
        }
        public virtual ParamsBuilder SubAccountId(string subAccountId)
        {
            return AddArg(ArgNames.SUB_ACCOUNT_ID, subAccountId);
        }
        public virtual ParamsBuilder TransferType(SubAccountTransferType transferType)
        {
            return AddArg(ArgNames.TRANSFER_TYPE, transferType);
        }
        public virtual ParamsBuilder SubcriptionMode(SubscriptionMode mode)
        {
            return AddArg(ArgNames.SUBSCRIPTION_MODE, mode);
        }
        public virtual ParamsBuilder NetworkCode(string networkCode)
        {
            return AddArg(ArgNames.NETWORK_CODE, networkCode);
        }
        public virtual ParamsBuilder TargetCurrency(string targetCurrency)
        {
            return AddArg(ArgNames.TARGET_CURRENCY, targetCurrency);
        }
        public virtual ParamsBuilder PreferredNetwork(string preferredNetwork)
        {
            return AddArg(ArgNames.PREFERRED_NETWORK, preferredNetwork);
        }
        public virtual ParamsBuilder Depth(int depth)
        {
            return AddArg(ArgNames.DEPTH, depth);
        }
        public virtual ParamsBuilder OrderId(string orderId)
        {
            return AddArg(ArgNames.ORDER_ID, orderId);
        }
        public virtual ParamsBuilder Networks(IList<string> networks)
        {
            return AddCommaSeparatedList(ArgNames.NETWORKS, networks);
        }
        public virtual ParamsBuilder Email(string email)
        {
            return AddArg(ArgNames.EMAIL, email);
        }
        public virtual ParamsBuilder Status(SubAccountStatus status)
        {
            return AddArg(ArgNames.STATUS, status);
        }
        public virtual ParamsBuilder SymbolList(IList<string> symbols)
        {
            return AddList(ArgNames.SYMBOLS, symbols);
        }
        public virtual ParamsBuilder CurrencyListOrAsterisc(IList<string> currencies)
        {
            return AddListOrAsterisc(ArgNames.CURRENCIES, currencies);
        }
        public virtual ParamsBuilder GroupTransactions(bool asGroupTransactions)
        {
            return AddArg(ArgNames.GROUP_TRANSACTIONS, asGroupTransactions);
        }
    }
}