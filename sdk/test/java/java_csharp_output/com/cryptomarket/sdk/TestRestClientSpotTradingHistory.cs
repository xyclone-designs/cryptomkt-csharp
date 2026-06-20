using Java.Util;
using Com.Cryptomarket.Params;
using Com.Cryptomarket.Sdk.Exceptions;
using Com.Cryptomarket.Sdk.Models;
using Com.Cryptomarket.Sdk.Rest;
using Org.Junit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Com.Cryptomarket.Sdk
{
    public class TestRestClientSpotTradingHistory
    {
        CryptomarketRestClient client = new CryptomarketRestClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
        public virtual void TestGetOrderHistoryAndGetOrders()
        {
            IList<Order> orders = client.GetSpotOrderHistory(new ParamsBuilder().Symbol("EOSETH"));
            orders.ForEach(Checker.checkOrder);
        }

        public virtual void TestGetOrderHistoryAndGetOrdersWithParams()
        {
            IList<Order> orders = client.GetSpotOrderHistory(new ParamsBuilder().By(SortBy.TIMESTAMP).Sort(Sort.DESC).Limit(1000).Offset(0).From("1610701510"));
            orders.ForEach(Checker.checkOrder);
        }

        public virtual void TestGetTradingHistory()
        {
            IList<Trade> trades = client.GetSpotTradesHistory(new ParamsBuilder().Limit(12));
            trades.ForEach(Checker.checkTrade);
        }

        public virtual void TestGetTradingHistoryWithParamsWithParams()
        {
            IList<Trade> trades = client.GetSpotTradesHistory(new ParamsBuilder().By(SortBy.TIMESTAMP).Sort(Sort.DESC).Limit(1000).Offset(0).From("1610701510"));
            trades.ForEach(Checker.checkTrade);
        }
    }
}