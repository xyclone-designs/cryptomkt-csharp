using Org.Junit.Assert;
using Java.Io;
using Java.Util;
using Org.Junit;
using Com.Cryptomarket.Params;
using Com.Cryptomarket.Sdk.Exceptions;
using Com.Cryptomarket.Sdk.Websocket;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Com.Cryptomarket.Sdk
{
    public class TestWSWalletClient
    {
        CryptomarketWSWalletClient wsClient;
        bool authenticated = false;
        public virtual void Before()
        {
            wsClient = new CryptomarketWSWalletClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
            wsClient.Connect();
            Helpers.Sleep(3);
        }

        public virtual void After()
        {
            wsClient.Dispose();
        }

        public virtual void TestGetWalletBalances()
        {
            wsClient.GetWalletBalances((result, exception) =>
            {
                result.ForEach(Checker.checkBalance);
            });
            Helpers.Sleep(3);
        }

        public virtual void TestGetWalletBalance()
        {
            wsClient.GetWalletBalanceByCurrency("EOS", (result, exception) =>
            {
                Checker.checkBalance.Accept(result);
            });
            Helpers.Sleep(3);
        }

        public virtual void TestGetTransactions()
        {
            wsClient.GetTransactions((result, exception) => result.ForEach(Checker.checkTransaction), null);
            Helpers.Sleep(3);
        }

        public virtual void TestGetTransactionHistoryWithParams()
        {
            wsClient.GetTransactions((transactions, exception) =>
            {
                AssertTrue(transactions.Count > 0);
                transactions.ForEach(Checker.checkTransaction);
            }, new ParamsBuilder().OrderBy(OrderBy.CREATED_AT).Sort(Sort.DESC).Limit(1000).Offset(0).Currencies(List.Of()).From("1614815872000"));
        }
    }
}