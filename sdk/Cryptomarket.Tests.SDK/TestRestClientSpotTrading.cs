using Java.Util;
using CryptoMarket.Tests.SDK.Exceptions;
using CryptoMarket.Tests.SDK.Models;
using CryptoMarket.Tests.SDK.Rest;
using Com.CryptoMarket.Params;
using Org.Junit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CryptoMarket.Tests.SDK
{
    public class TestRestClientSpotTrading
    {
        CryptoMarketRestClient client = new CryptoMarketRestClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
        public virtual void TestGetSpotTradingBalance()
        {
            IList<Balance> balances = client.GetSpotTradingBalances();
            balances.ForEach(Checker.checkBalance);
        }

        public virtual void TestGetSpotTradingBalanceOfCurrency()
        {
            Balance balance = client.GetSpotTradingBalanceByCurrency("EOS");
            Checker.checkBalance.Invoke(balance);
        }

        public virtual void TestGetAllActiveSpotOrders()
        {
            IList<Order> orders = client.GetAllActiveSpotOrders(null);
            orders.ForEach(Checker.checkOrder);
        }

        public virtual void TestCancelAllOrders()
        {
            client.CreateSpotOrder(new ParamsBuilder().Symbol("EOSBTC").Side(Side.SELL).Quantity("0.01").OrderType(OrderType.LIMIT).Price("1000"));
            client.CreateSpotOrder(new ParamsBuilder().Symbol("EOSETH").Side(Side.SELL).Quantity("0.01").OrderType(OrderType.LIMIT).Price("1000"));
            IList<Order> orders = client.CancelAllSpotOrders();
            orders.ForEach(Checker.checkOrder);
        }

        public virtual void TestOrderFlow()
        {
            string clientOrderId = String.Format("%d", System.CurrentTimeMillis());
            Order order = client.CreateSpotOrder(new OrderBuilder().ClientOrderId(clientOrderId).Symbol("EOSETH").Side(Side.SELL).Quantity("0.01").TimeInForce(TimeInForce.DAY).OrderType(OrderType.LIMIT).Price("1000"));
            Checker.checkOrder.Invoke(order);
            order = client.GetActiveSpotOrder(order.GetClientOrderId());
            Checker.checkOrder.Invoke(order);
            order = client.CancelSpotOrder(order.GetClientOrderId());
            Checker.checkOrder.Invoke(order);
        }

        public virtual void TestGetAllTradingCommission()
        {
            IList<Commission> commissions = client.GetAllTradingCommissions();
            commissions.ForEach(Checker.checkCommission);
        }

        public virtual void TestGetTradingCommission()
        {
            Commission commission = client.GetTradingCommission("EOSETH");
            Checker.checkCommission.Invoke(commission);
        }

        public virtual void TestCreateOrderList()
        {
            IList<Order> orders = client.CreateSpotOrderList(ContingencyType.ALL_OR_NONE, Arrays.AsList(new OrderBuilder().Symbol("EOSETH").Side(Side.SELL).TimeInForce(TimeInForce.FOK).Quantity("0.02").Price("10000"), new OrderBuilder().Symbol("EOSUSDT").Side(Side.SELL).TimeInForce(TimeInForce.FOK).StopPrice("5000").Quantity("0.01").Price("10000")), null);
            orders.ForEach(Checker.checkOrder);
        }
    }
}