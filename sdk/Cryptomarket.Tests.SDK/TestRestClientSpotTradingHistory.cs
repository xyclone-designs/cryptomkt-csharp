using Java.Util;
using Com.CryptoMarket.Params;
using CryptoMarket.Tests.SDK.Exceptions;
using CryptoMarket.Tests.SDK.Models;
using CryptoMarket.Tests.SDK.Rest;
using Org.Junit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CryptoMarket.Tests.SDK
{
    public class TestRestClientSpotTradingHistory
    {
        CryptoMarketRestClient client = new CryptoMarketRestClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
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