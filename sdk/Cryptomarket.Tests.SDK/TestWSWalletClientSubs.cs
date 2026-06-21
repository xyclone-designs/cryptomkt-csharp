using CryptoMarket.SDK.Params;
using CryptoMarket.SDK.Rest;
using CryptoMarket.SDK.Websocket;

namespace CryptoMarket.Tests.SDK
{
    public class TestWSWalletClientSubs
    {
        ICryptoMarketWSWalletClient wsClient;
        ICryptoMarketRestClient restClient;

        public virtual void Before()
        {
            wsClient = new CryptoMarketWSWalletClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
            wsClient.Connect();
            restClient = new CryptoMarketRestClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
            Helpers.Sleep(3);
        }

        public virtual void After()
        {
            wsClient.Dispose();
        }

        public virtual void TestSubscribeToTransactions()
        {
            Helpers.FailChecker failChecker = new ();
            wsClient.SubscribeToTransactions(Helpers.Checker(failChecker, Checker.CheckTransaction), Helpers.ObjectAndExceptionChecker(failChecker, Checker.CheckBooleanTrue));
            Helpers.Sleep(3);
            restClient.TransferBetweenWalletAndExchange(new ParamsBuilder().Currency("EOS").Amount("0.01").Source(AccountType.Wallet).Destination(AccountType.Spot));
            Helpers.Sleep(3);
            restClient.TransferBetweenWalletAndExchange(new ParamsBuilder().Currency("EOS").Amount("0.01").Destination(AccountType.Wallet).Source(AccountType.Spot));
            Helpers.Sleep(3);
            wsClient.UnsubscribeToTransactions(Helpers.ObjectAndExceptionChecker(failChecker, Checker.CheckBooleanTrue));
            Helpers.Sleep(3);
            Assert.False(failChecker.Failed());
        }

        public virtual void TestSubscribeToWalletBalances()
        {
            Helpers.FailChecker failChecker = new ();
            wsClient.SubscribeToWalletBalances(Helpers.NotificationListChecker(failChecker, Checker.CheckBalance), Helpers.ObjectAndExceptionChecker(failChecker, Checker.CheckBooleanTrue));
            Helpers.Sleep(3);
            restClient.TransferBetweenWalletAndExchange(new ParamsBuilder().Currency("EOS").Amount("0.01").Source(AccountType.Wallet).Destination(AccountType.Spot));
            Helpers.Sleep(3);
            restClient.TransferBetweenWalletAndExchange(new ParamsBuilder().Currency("EOS").Amount("0.01").Destination(AccountType.Wallet).Source(AccountType.Spot));
            Helpers.Sleep(3);
            wsClient.UnsubscribeToWalletBalances(Helpers.ObjectAndExceptionChecker(failChecker, Checker.CheckBooleanTrue));
            Helpers.Sleep(3);
            Assert.False(failChecker.Failed());
        }
    }
}