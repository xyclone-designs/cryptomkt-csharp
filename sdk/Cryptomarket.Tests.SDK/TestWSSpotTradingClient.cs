using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Models;
using CryptoMarket.SDK.Params;
using CryptoMarket.SDK.Rest;
using CryptoMarket.SDK.Websocket;

namespace CryptoMarket.Tests.SDK
{
    public class TestWSSpotTradingClient
    {
        ICryptoMarketWSSpotTradingClient wsClient;
        bool authenticated = false;
        public virtual void Before()
        {
            wsClient = new CryptoMarketWSSpotTradingClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret(), 60000);
            wsClient.Connect();
        }

        public virtual void After()
        {
            wsClient.Dispose();
        }

        public virtual void TestGetSpotTradingBalances()
        {
            Helpers.FailChecker failChecker = new ();
            wsClient.GetSpotTradingBalances(Helpers.ListAndExceptionChecker(failChecker, Checker.CheckBalance));
            Helpers.Sleep(3);
            Assert.False(failChecker.Failed());
        }

        public virtual void TestSpotTradingBalance()
        {
            Helpers.FailChecker failChecker = new ();
            wsClient.GetSpotTradingBalanceOfCurrency("EOS", Helpers.ObjectAndExceptionChecker(failChecker, Checker.CheckBalance));
            Helpers.Sleep(3);
            if (failChecker.Failed())
            {
                Assert.Fail(failChecker.ErrMsg);
            }

            Assert.False(failChecker.Failed());
        }

        public virtual void TestOrderFlow()
        {
            string oldClientOrderId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString() + "11";
            string newClientOrderId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString() + "22";

            // create
            wsClient.CreateSpotOrder(new ParamsBuilder().Side(Side.Sell).Symbol("EOSETH").Price("10000").Quantity("0.01").ClientOrderId(oldClientOrderId), (report, exception) =>
            {
                Checker.CheckReport.Invoke(report);
            });
            Helpers.Sleep(3);

            // check
            wsClient.GetAllActiveOrders((reportList, exception) =>
            {
                if (exception != null)
                {
                    Assert.Fail();
                }

                bool present = false;
                foreach (Report order in reportList)
                {
                    if (order.ClientOrderId.Equals(oldClientOrderId))
                        present = true;
                }

                if (!present)
                    Assert.Fail("could not find");
            });
            Helpers.Sleep(3);

            // replace
            wsClient.ReplaceSpotOrder(oldClientOrderId, newClientOrderId, "0.02", "2000", null, null, (report, exception) =>
            {
                if (exception != null)
                {
                    Assert.Fail();
                }

                if (!report.OriginalClientOrderId.Equals(oldClientOrderId))
                {
                    Assert.Fail();
                }
            });
            Helpers.Sleep(3);

            // cancel
            wsClient.CancelSpotOrder(newClientOrderId, (report, exception) =>
            {
                if (exception != null)
                {
                    Assert.Fail();
                }

                if (!report.Status.Equals(OrderStatus.CANCELED))
                    Assert.Fail();
                if (report.ClientOrderId.Equals(oldClientOrderId))
                    Assert.Fail();
            });
            Helpers.Sleep(3);
        }

        public virtual void TestGetActiveSpotOrdersAndCancelAllSpotOrders()
        {
            wsClient.CancelAllSpotOrders(null);
            for (int i = 0; i < 5; i++)
            {
                wsClient.CreateSpotOrder(new ParamsBuilder().Symbol("EOSETH").Side(Side.Sell).Price("1000").Quantity("0.01"), null);
            }

            Action<IList<Report>, CryptoMarketSDKException> checkReportListSizeAndValidity = (reportList, exception) =>
            {
                if (exception != null)
                {
                    Assert.Fail();
                }

                if (reportList.Count != 5)
                {
                    Assert.Fail();
                }

                foreach (var report in reportList) Checker.CheckReport.Invoke(report);
            };
            Helpers.Sleep(3);
            wsClient.GetAllActiveOrders(checkReportListSizeAndValidity);
            Helpers.Sleep(3);
            wsClient.CancelAllSpotOrders(checkReportListSizeAndValidity);
            Helpers.Sleep(3);
        }

        public virtual void TestGetSpotTradingCommissions()
        {
            wsClient.GetSpotCommissions((results, exception) =>
            {
                foreach (var result in results) Checker.CheckCommission.Invoke(result);
            });
            Helpers.Sleep(3);
        }

        public virtual void TestGetSpotTradingCommission()
        {
            wsClient.GetSpotCommissionOfSymbol("EOSETH", (result, exception) =>
            {
                Checker.CheckCommission.Invoke(result);
            });
            Helpers.Sleep(3);
        }

        public virtual void TestCreateOrderList()
        {
            string orderListId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            string secondClientOrderId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString() + "2";
            Side side = Side.Sell;
            string quantity = "0.01";
            string price = "10000";
            var failChecker = new Helpers.FailChecker ();
            wsClient.CreateSpotOrderList(ContingencyType.AllOrNone,
            [
                new OrderBuilder { ClientOrderId = orderListId, Symbol = "EOSETH", Side = side, TimeInForce = TimeInForce.FOK, Quantity = quantity, Price = price }, 
                new OrderBuilder { ClientOrderId = secondClientOrderId, Symbol = "EOSBTC", Side = side, TimeInForce = TimeInForce.FOK, Quantity = quantity, Price = price }
            
            ], orderListId, Helpers.ObjectAndExceptionChecker(failChecker, Checker.CheckReport));
            
            Helpers.Sleep(12);

            if (failChecker.Failed())
            {
                Assert.Fail(failChecker.ErrMsg);
            }

            Assert.False(failChecker.Failed());
        }
    }
}