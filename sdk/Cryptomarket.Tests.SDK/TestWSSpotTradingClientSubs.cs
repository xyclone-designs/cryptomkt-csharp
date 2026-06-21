using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Models;
using CryptoMarket.SDK.Params;
using CryptoMarket.SDK.Rest;
using CryptoMarket.SDK.Websocket;

namespace CryptoMarket.Tests.SDK
{
    public class TestWSSpotTradingClientSubs
    {
        ICryptoMarketWSSpotTradingClient wsClient;

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

        public virtual void TestReportSubscription()
        {
            var failChecker = new Helpers.FailChecker();
            wsClient.SubscribeToReports(Helpers.NotificationListChecker(failChecker, Checker.CheckReport), Helpers.ObjectAndExceptionChecker(failChecker, Checker.CheckBooleanTrue));
            Helpers.Sleep(3);
            string clientOrderId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            MakeSampleOrder(clientOrderId);
            CancelOrder(clientOrderId);
            wsClient.UnsubscribeToReports((result, exception) =>
            {
                if (!result)
                {
                    Assert.Fail();
                }
            });
            Helpers.Sleep(3);
            Assert.False(failChecker.Failed());
        }

        private void CancelOrder(string clientOrderId)
        {
            wsClient.CancelSpotOrder(clientOrderId, null);
            Helpers.Sleep(3);
        }

        private void MakeSampleOrder(string clientOrderId)
        {
            wsClient.CreateSpotOrder(new ParamsBuilder().ClientOrderId(clientOrderId).Symbol("EOSETH").Side(Side.Sell).Price("1000").Quantity("0.01"), null);
            Helpers.Sleep(3);
        }

        public virtual void TestSpotBalanceSubscriptions()
        {
            var failChecker = new Helpers.FailChecker();
            wsClient.SubscribeToSpotBalances(SubscriptionMode.UPDATES, Helpers.NotificationListChecker(failChecker, Checker.CheckBalance), Helpers.ObjectAndExceptionChecker(failChecker, Checker.CheckBooleanTrue));
            Helpers.Sleep(4);
            string clientOrderId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            MakeSampleOrder(clientOrderId);
            Helpers.Sleep(4);
            CancelOrder(clientOrderId);

            // three updates, the first, one creation and one cancel.
            wsClient.UnsubscribeToSpotBalances(Helpers.ObjectAndExceptionChecker(failChecker, Checker.CheckBooleanTrue));
            Helpers.Sleep(4);
            Assert.False(failChecker.Failed());
        }
    }
}