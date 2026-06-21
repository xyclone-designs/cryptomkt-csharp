using CryptoMarket.SDK.Models;
using CryptoMarket.SDK.Params;
using CryptoMarket.SDK.Rest;

namespace CryptoMarket.Tests.SDK
{
    public class TestRestClientSpotTradingHistory
    {
        ICryptoMarketRestClient client = new CryptoMarketRestClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());

        public virtual void TestGetOrderHistoryAndGetOrders()
        {
            IList<Order> orders = client.GetSpotOrderHistory(new ParamsBuilder().Symbol("EOSETH"));
            
            foreach (var order in orders) Checker.CheckOrder.Invoke(order);
        }
        public virtual void TestGetOrderHistoryAndGetOrdersWithParams()
        {
            IList<Order> orders = client.GetSpotOrderHistory(new ParamsBuilder().By(SortBy.TIMESTAMP).Sort(Sort.DESC).Limit(1000).Offset(0).From("1610701510"));
            
            foreach (var order in orders) Checker.CheckOrder.Invoke(order);
        }
        public virtual void TestGetTradingHistory()
        {
            IList<Trade> trades = client.GetSpotTradesHistory(new ParamsBuilder().Limit(12));
            
            foreach (var trade in trades) Checker.CheckTrade.Invoke(trade);
        }
        public virtual void TestGetTradingHistoryWithParamsWithParams()
        {
            IList<Trade> trades = client.GetSpotTradesHistory(new ParamsBuilder().By(SortBy.TIMESTAMP).Sort(Sort.DESC).Limit(1000).Offset(0).From("1610701510"));

            foreach (var trade in trades) Checker.CheckTrade.Invoke(trade);
        }
    }
}