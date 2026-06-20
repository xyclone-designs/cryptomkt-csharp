using Org.Junit.Assert;
using Java.Io;
using Com.Cryptomarket.Params;
using Com.Cryptomarket.Sdk.Helpers;
using Com.Cryptomarket.Sdk.Exceptions;
using Com.Cryptomarket.Sdk.Rest;
using Com.Cryptomarket.Sdk.Websocket;
using Org.Junit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Com.Cryptomarket.Sdk
{
    public class TestWSWalletClientSubs
    {
        CryptomarketWSWalletClient wsClient;
        CryptomarketRestClient restClient;
        public virtual void Before()
        {
            wsClient = new CryptomarketWSWalletClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
            wsClient.Connect();
            restClient = new CryptomarketRestClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
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