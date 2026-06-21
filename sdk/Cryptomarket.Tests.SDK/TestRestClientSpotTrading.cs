using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Models;
using CryptoMarket.SDK.Params;
using CryptoMarket.SDK.Rest;
using CryptoMarket.SDK.Websocket;

namespace CryptoMarket.Tests.SDK
{
    public class TestRestClientSpotTrading
    {
        ICryptoMarketRestClient client = new CryptoMarketRestClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
        public virtual void TestGetSpotTradingBalance()
        {
            IList<Balance> balances = client.GetSpotTradingBalances();
            
            foreach (var balance in balances) Checker.CheckBalance.Invoke(balance);
        }

        public virtual void TestGetSpotTradingBalanceOfCurrency()
        {
            Balance balance = client.GetSpotTradingBalanceByCurrency("EOS");
            Checker.CheckBalance.Invoke(balance);
        }

        public virtual void TestGetAllActiveSpotOrders()
        {
            IList<Order> orders = client.GetAllActiveSpotOrders(null);

            foreach (var order in orders) Checker.CheckOrder.Invoke(order);
        }

        public virtual void TestCancelAllOrders()
        {
            client.CreateSpotOrder(new ParamsBuilder().Symbol("EOSBTC").Side(Side.Sell).Quantity("0.01").OrderType(OrderType.LIMIT).Price("1000"));
            client.CreateSpotOrder(new ParamsBuilder().Symbol("EOSETH").Side(Side.Sell).Quantity("0.01").OrderType(OrderType.LIMIT).Price("1000"));
            IList<Order> orders = client.CancelAllSpotOrders();
            
            foreach (var order in orders) Checker.CheckOrder.Invoke(order);
        }

        public virtual void TestOrderFlow()
        {
            string clientOrderId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            Order order = client.CreateSpotOrder(new OrderBuilder { ClientOrderId = clientOrderId, Symbol = "EOSUSDT", Side = Side.Sell, TimeInForce = TimeInForce.DAY, Type = OrderType.LIMIT, Quantity = "0.01", Price = "1000" });
            Checker.CheckOrder.Invoke(order);
            order = client.GetActiveSpotOrder(order.ClientOrderId);
            Checker.CheckOrder.Invoke(order);
            order = client.CancelSpotOrder(order.ClientOrderId);
            Checker.CheckOrder.Invoke(order);
        }

        public virtual void TestGetAllTradingCommission()
        {
            IList<Commission> commissions = client.GetAllTradingCommissions();
            
            foreach (var commission in commissions) Checker.CheckCommission.Invoke(commission);
        }

        public virtual void TestGetTradingCommission()
        {
            Commission commission = client.GetTradingCommission("EOSETH");
            Checker.CheckCommission.Invoke(commission);
        }

        public virtual void TestCreateOrderList()
        {
            IList<Order> orders = client.CreateSpotOrderList(ContingencyType.AllOrNone,
            [
                new OrderBuilder { Symbol = "EOSETH", Side = Side.Sell, TimeInForce = TimeInForce.FOK, Quantity = "0.02", Price = "10000" },
                new OrderBuilder { Symbol = "EOSUSDT", Side = Side.Sell, TimeInForce = TimeInForce.FOK, StopPrice = "5000", Quantity = "0.01", Price = "10000" }
            
            ], null);

            foreach (var order in orders) Checker.CheckOrder.Invoke(order);
        }
    }
}