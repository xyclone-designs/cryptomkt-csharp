using Org.Junit.Assert;
using Java.Io;
using Java.Util;
using Java.Util.Function;
using Org.Junit;
using Com.Cryptomarket.Params;
using Com.Cryptomarket.Sdk.Helpers;
using Com.Cryptomarket.Sdk.Exceptions;
using Com.Cryptomarket.Sdk.Models;
using Com.Cryptomarket.Sdk.Websocket;
using Java.Util.Concurrent;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Com.Cryptomarket.Sdk
{
    public class TestWSSpotTradingClient
    {
        CryptomarketWSSpotTradingClient wsClient;
        bool authenticated = false;
        public virtual void Before()
        {
            wsClient = new CryptomarketWSSpotTradingClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret(), 60000);
            var ft = new FutureTask<object>(() =>
            {
            }, new object ());
            wsClient.OnConnect(ft);
            wsClient.Connect();
            ft.Get();
        }

        public virtual void After()
        {
            wsClient.Dispose();
        }

        public virtual void TestGetSpotTradingBalances()
        {
            FailChecker failChecker = new FailChecker();
            wsClient.GetSpotTradingBalances(Helpers.ListAndExceptionChecker(failChecker, Checker.checkBalance));
            Helpers.Sleep(3);
            AssertFalse(failChecker.Failed());
        }

        public virtual void TestSpotTradingBalance()
        {
            FailChecker failChecker = new FailChecker();
            wsClient.GetSpotTradingBalanceOfCurrency("EOS", Helpers.ObjectAndExceptionChecker(failChecker, Checker.checkBalance));
            Helpers.Sleep(3);
            if (failChecker.Failed())
            {
                Fail(failChecker.GetErrMsg().Get());
            }

            AssertFalse(failChecker.Failed());
        }

        public virtual void TestOrderFlow()
        {
            string oldClientOrderId = String.Format("%d", System.CurrentTimeMillis()) + "11";
            string newClientOrderId = String.Format("%d", System.CurrentTimeMillis()) + "22";

            // create
            wsClient.CreateSpotOrder(new ParamsBuilder().Side(Side.SELL).Symbol("EOSETH").Price("10000").Quantity("0.01").ClientOrderId(oldClientOrderId), (report, exception) =>
            {
                Checker.checkReport.Accept(report);
            });
            Helpers.Sleep(3);

            // check
            wsClient.GetAllActiveOrders((reportList, exception) =>
            {
                if (exception != null)
                {
                    Fail();
                }

                bool present = false;
                foreach (Report order in reportList)
                {
                    if (order.GetClientOrderId().Equals(oldClientOrderId))
                        present = true;
                }

                if (!present)
                    Fail("could not find");
            });
            Helpers.Sleep(3);

            // replace
            wsClient.ReplaceSpotOrder(oldClientOrderId, newClientOrderId, "0.02", "2000", null, null, (report, exception) =>
            {
                if (exception != null)
                {
                    Fail();
                }

                if (!report.GetOriginalClientOrderId().Equals(oldClientOrderId))
                {
                    Fail();
                }
            });
            Helpers.Sleep(3);

            // cancel
            wsClient.CancelSpotOrder(newClientOrderId, (report, exception) =>
            {
                if (exception != null)
                {
                    Fail();
                }

                if (!report.GetStatus().Equals(OrderStatus.CANCELED))
                    Fail();
                if (report.GetClientOrderId().Equals(oldClientOrderId))
                    Fail();
            });
            Helpers.Sleep(3);
        }

        public virtual void TestGetActiveSpotOrdersAndCancelAllSpotOrders()
        {
            wsClient.CancelAllSpotOrders(null);
            for (int i = 0; i < 5; i++)
            {
                wsClient.CreateSpotOrder(new ParamsBuilder().Symbol("EOSETH").Side(Side.SELL).Price("1000").Quantity("0.01"), null);
            }

            BiConsumer<IList<Report>, CryptomarketSDKException> checkReportListSizeAndValidity = (reportList, exception) =>
            {
                if (exception != null)
                {
                    Fail();
                }

                if (reportList.Count != 5)
                {
                    Fail();
                }

                reportList.ForEach(Checker.checkReport);
            };
            Helpers.Sleep(3);
            wsClient.GetAllActiveOrders(checkReportListSizeAndValidity);
            Helpers.Sleep(3);
            wsClient.CancelAllSpotOrders(checkReportListSizeAndValidity);
            Helpers.Sleep(3);
        }

        public virtual void TestGetSpotTradingCommissions()
        {
            wsClient.GetSpotCommissions((result, exception) =>
            {
                result.ForEach(Checker.checkCommission);
            });
            Helpers.Sleep(3);
        }

        public virtual void TestGetSpotTradingCommission()
        {
            wsClient.GetSpotCommissionOfSymbol("EOSETH", (result, exception) =>
            {
                Checker.checkCommission.Accept(result);
            });
            Helpers.Sleep(3);
        }

        public virtual void TestCreateOrderList()
        {
            string orderListId = String.Format("%d", System.CurrentTimeMillis());
            string secondClientOrderId = String.Format("%d", System.CurrentTimeMillis()) + "2";
            Side side = Side.SELL;
            string quantity = "0.01";
            string price = "10000";
            var failChecker = new FailChecker();
            wsClient.CreateSpotOrderList(ContingencyType.ALL_OR_NONE, Arrays.AsList(new OrderBuilder().ClientOrderId(orderListId).Symbol("EOSETH").Side(side).TimeInForce(TimeInForce.FOK).Quantity(quantity).Price(price), new OrderBuilder().ClientOrderId(secondClientOrderId).Symbol("EOSBTC").Side(side).TimeInForce(TimeInForce.FOK).Quantity(quantity).Price(price)), orderListId, Helpers.ObjectAndExceptionChecker(failChecker, Checker.checkReport));
            Helpers.Sleep(12);
            if (failChecker.Failed())
            {
                Fail(failChecker.GetErrMsg().Get());
            }

            AssertFalse(failChecker.Failed());
        }
    }
}