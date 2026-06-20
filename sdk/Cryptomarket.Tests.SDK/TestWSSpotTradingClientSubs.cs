using Org.Junit.Assert;
using Java.Io;
using Com.CryptoMarket.Params;
using CryptoMarket.Tests.SDK.Helpers;
using CryptoMarket.Tests.SDK.Websocket;
using Org.Junit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CryptoMarket.Tests.SDK
{
    public class TestWSSpotTradingClientSubs
    {
        CryptoMarketWSSpotTradingClient wsClient;
        public virtual void Before()
        {
            wsClient = new CryptoMarketWSSpotTradingClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
            wsClient.Connect();
            Helpers.Sleep(3);
        }

        public virtual void After()
        {
            wsClient.Dispose();
        }

        public virtual void TestTimeFlow()
        {
            TimeFlow.Reset();
            bool goodFLow;
            goodFLow = TimeFlow.CheckNextTimestamp("2021-01-27T15:47:54.418Z");
            if (!goodFLow)
            {
                Fail();
            }

            goodFLow = TimeFlow.CheckNextTimestamp("2021-01-27T15:47:55.118Z");
            if (!goodFLow)
            {
                Fail();
            }

            goodFLow = TimeFlow.CheckNextTimestamp("2021-01-27T15:47:54.418Z");
            if (goodFLow)
            {
                Fail();
            }
        }

        public virtual void TestReportSubscription()
        {
            var failChecker = new FailChecker();
            wsClient.SubscribeToReports(Helpers.NotificationListChecker(failChecker, Checker.checkReport), Helpers.ObjectAndExceptionChecker(failChecker, Checker.checkBooleanTrue));
            Helpers.Sleep(3);
            string clientOrderId = String.Format("%d", System.CurrentTimeMillis());
            MakeSampleOrder(clientOrderId);
            CancelOrder(clientOrderId);
            wsClient.UnsubscribeToReports((result, exception) =>
            {
                if (!result)
                {
                    Fail();
                }
            });
            Helpers.Sleep(3);
            AssertFalse(failChecker.Failed());
        }

        private void CancelOrder(string clientOrderId)
        {
            wsClient.CancelSpotOrder(clientOrderId, null);
            Helpers.Sleep(3);
        }

        private void MakeSampleOrder(string clientOrderId)
        {
            wsClient.CreateSpotOrder(new ParamsBuilder().ClientOrderId(clientOrderId).Symbol("EOSETH").Side(Side.SELL).Price("1000").Quantity("0.01"), null);
            Helpers.Sleep(3);
        }

        public virtual void TestSpotBalanceSubscriptions()
        {
            var failChecker = new FailChecker();
            wsClient.SubscribeToSpotBalances(SubscriptionMode.UPDATES, Helpers.NotificationListChecker(failChecker, Checker.checkBalance), Helpers.ObjectAndExceptionChecker(failChecker, Checker.checkBooleanTrue));
            Helpers.Sleep(4);
            string clientOrderId = String.Format("%d", System.CurrentTimeMillis());
            MakeSampleOrder(clientOrderId);
            Helpers.Sleep(4);
            CancelOrder(clientOrderId);

            // three updates, the first, one creation and one cancel.
            wsClient.UnsubscribeToSpotBalances(Helpers.ObjectAndExceptionChecker(failChecker, Checker.checkBooleanTrue));
            Helpers.Sleep(4);
            AssertFalse(failChecker.Failed());
        }
    }
}