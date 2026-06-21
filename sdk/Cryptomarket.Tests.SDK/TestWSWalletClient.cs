using CryptoMarket.SDK.Models;
using CryptoMarket.SDK.Params;
using CryptoMarket.SDK.Websocket;
using System.Transactions;

namespace CryptoMarket.Tests.SDK
{
    public class TestWSWalletClient
    {
        ICryptoMarketWSWalletClient wsClient;
        bool authenticated = false;

        public virtual void Before()
        {
            wsClient = new CryptoMarketWSWalletClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
            wsClient.Connect();
            Helpers.Sleep(3);
        }

        public virtual void After()
        {
            wsClient.Dispose();
        }

        public virtual void TestGetWalletBalances()
        {
            wsClient.GetWalletBalances((results, exception) =>
            {
                foreach (var result in results) Checker.CheckBalance.Invoke(result);
            });

            Helpers.Sleep(3);
        }

        public virtual void TestGetWalletBalance()
        {
            wsClient.GetWalletBalanceByCurrency("EOS", (result, exception) =>
            {
                Checker.CheckBalance.Invoke(result);
            });
            Helpers.Sleep(3);
        }

        public virtual void TestGetTransactions()
        {
            wsClient.GetTransactions((results, exception) => { foreach (var result in results) Checker.CheckTransaction.Invoke(result); }, null);
            Helpers.Sleep(3);
        }

        public virtual void TestGetTransactionHistoryWithParams()
        {
            wsClient.GetTransactions((transactions, exception) =>
            {
                Assert.True(transactions.Count > 0);

                foreach (var transaction in transactions) Checker.CheckTransaction.Invoke(transaction);

            }, new ParamsBuilder().OrderBy(OrderBy.CREATED_AT).Sort(Sort.DESC).Limit(1000).Offset(0).Currencies([]).From("1614815872000"));
        }
    }
}