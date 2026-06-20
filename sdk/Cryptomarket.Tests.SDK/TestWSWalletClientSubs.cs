using Org.Junit.Assert;
using Java.Io;
using Com.CryptoMarket.Params;
using CryptoMarket.Tests.SDK.Helpers;
using CryptoMarket.Tests.SDK.Exceptions;
using CryptoMarket.Tests.SDK.Rest;
using CryptoMarket.Tests.SDK.Websocket;
using Org.Junit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CryptoMarket.Tests.SDK
{
    public class TestWSWalletClientSubs
    {
        CryptoMarketWSWalletClient wsClient;
        CryptoMarketRestClient restClient;
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
            FailChecker failChecker = new FailChecker();
            wsClient.SubscribeToTransactions(Helpers.Checker(failChecker, Checker.checkTransaction), Helpers.ObjectAndExceptionChecker(failChecker, Checker.checkBooleanTrue));
            Helpers.Sleep(3);
            restClient.TransferBetweenWalletAndExchange(new ParamsBuilder().Currency("EOS").Amount("0.01").Source(AccountType.WALLET).Destination(AccountType.SPOT));
            Helpers.Sleep(3);
            restClient.TransferBetweenWalletAndExchange(new ParamsBuilder().Currency("EOS").Amount("0.01").Destination(AccountType.WALLET).Source(AccountType.SPOT));
            Helpers.Sleep(3);
            wsClient.UnsubscribeToTransactions(Helpers.ObjectAndExceptionChecker(failChecker, Checker.checkBooleanTrue));
            Helpers.Sleep(3);
            AssertFalse(failChecker.Failed());
        }

        public virtual void TestSubscribeToWalletBalances()
        {
            FailChecker failChecker = new FailChecker();
            wsClient.SubscribeToWalletBalances(Helpers.NotificationListChecker(failChecker, Checker.checkBalance), Helpers.ObjectAndExceptionChecker(failChecker, Checker.checkBooleanTrue));
            Helpers.Sleep(3);
            restClient.TransferBetweenWalletAndExchange(new ParamsBuilder().Currency("EOS").Amount("0.01").Source(AccountType.WALLET).Destination(AccountType.SPOT));
            Helpers.Sleep(3);
            restClient.TransferBetweenWalletAndExchange(new ParamsBuilder().Currency("EOS").Amount("0.01").Destination(AccountType.WALLET).Source(AccountType.SPOT));
            Helpers.Sleep(3);
            wsClient.UnsubscribeToWalletBalances(Helpers.ObjectAndExceptionChecker(failChecker, Checker.checkBooleanTrue));
            Helpers.Sleep(3);
            AssertFalse(failChecker.Failed());
        }
    }
}