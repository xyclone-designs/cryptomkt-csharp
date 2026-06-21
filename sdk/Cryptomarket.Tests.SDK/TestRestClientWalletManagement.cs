using CryptoMarket.SDK.Models;
using CryptoMarket.SDK.Params;
using CryptoMarket.SDK.Rest;

namespace CryptoMarket.Tests.SDK
{
    public class TestRestClientWalletManagement
    {
        ICryptoMarketRestClient client = new CryptoMarketRestClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());

        public virtual void TestGetWalletBalances()
        {
            IList<Balance> balances = client.GetWalletBalances();
            
            if (balances.Count == 0)
                Assert.Fail();

            foreach (var balance in balances)
                if (string.IsNullOrEmpty(balance.Currency))
                    Assert.Fail();
        }

        public virtual void TestGetWalletBalanceOfCurrency()
        {
            Balance balance = client.GetWalletBalanceByCurrency("ADA");
            Checker.CheckBalance.Invoke(balance);
        }

        public virtual void TestGetDepositCriptoAddresses()
        {
            IList<Address> addresses = client.GetDepositCryptoAddresses(null, null);

            foreach (var address in addresses) Checker.CheckAddress.Invoke(address);
        }

        public virtual void TestGetDepositCriptoAddressOfCurrency()
        {
            IList<Address> addresses = client.GetDepositCryptoAddresses("NEXO", null);

            foreach (var address in addresses) Checker.CheckAddress.Invoke(address);
        }

        public virtual void TestCreateDepositCryptoAddress()
        {
            Address addresses = client.CreateDepositCryptoAddress("BTC", null);
            Checker.CheckAddress.Invoke(addresses);
        }

        public virtual void TestLast10DepositCryptoAddresses()
        {
            IList<Address> addresses = client.GetLast10DepositCryptoAddresses("EOS", null);

            foreach (var address in addresses) Checker.CheckAddress.Invoke(address);
        }

        public virtual void TestLast10WithdrawalCryptoAddresses()
        {
            IList<Address> addresses = client.GetLast10WithdrawalCryptoAddresses("EOS", null);

            foreach (var address in addresses) Checker.CheckAddress.Invoke(address);
        }

        public virtual void TestWithdrawCrypto()
        {
            IList<Address> adaAddresses = client.GetDepositCryptoAddresses("ADA", null);
            string transaction_id = client.WithdrawCrypto(new ParamsBuilder().Currency("ADA").Amount("0.1").Address(adaAddresses[0].Address_));
            if (transaction_id.Equals(""))
            {
                Assert.Fail();
            }
        }

        public virtual void TestWithdrawCryptoCommit()
        {
            IList<Address> adaAddresses = client.GetDepositCryptoAddresses("ADA", null);
            string transactionId = client.WithdrawCrypto(new ParamsBuilder().Currency("ADA").Amount("0.1").Address(adaAddresses[0].Address_).AutoCommit(false));
            if (transactionId.Equals(""))
            {
                Assert.Fail();
            }

            bool result = client.WithdrawCryptoCommit(transactionId);
            if (!result)
            {
                Assert.Fail();
            }
        }

        public virtual void TestWithdrawCryptoRollback()
        {
            IList<Address> adaAddresses = client.GetDepositCryptoAddresses("ADA", null);
            string transactionId = client.WithdrawCrypto(new ParamsBuilder().Currency("ADA").Amount("0.1").Address(adaAddresses[0].Address_).AutoCommit(false));
            if (transactionId.Equals(""))
            {
                Assert.Fail();
            }

            bool result = client.WithdrawCryptoRollback(transactionId);
            if (!result)
            {
                Assert.Fail();
            }
        }

        public virtual void TestGetEstimateWithdrawFees()
        {
            var fees = client.GetEstimateWithdrawalFees([new FeeRequest("EOS", "100", null), new FeeRequest("ETH", "100", null)]);
            if (fees.Count != 2)
            {
                Assert.Fail("invalid amount of fees");
            }

            foreach (var fee in fees) Checker.CheckFee.Invoke(fee);
        }

        public virtual void TestGetBulkEstimateWithdrawFees()
        {
            var fees = client.GetBulkEstimateWithdrawalFees([new FeeRequest("EOS", "100", null), new FeeRequest("ETH", "100", null)]);
            if (fees.Count != 2)
            {
                Assert.Fail("invalid amount of fees");
            }

            foreach (var fee in fees) Checker.CheckFee.Invoke(fee);
        }

        public virtual void TestGetEstimateWithdrawFee()
        {
            string estimate = client.GetEstimateWithdrawalFee("EOS", "100", null);
            if (estimate.Equals(""))
            {
                Assert.Fail();
            }
        }

        public virtual void TestGetEstimateWithdrawFeesHash()
        {
            string estimate = client.GetWithdrawalFeesHash();
            if (estimate.Equals(""))
            {
                Assert.Fail();
            }
        }

        public virtual void TestCryptoAddressBelongsToCurrentAccount()
        {
            IList<Address> addresses = client.GetDepositCryptoAddresses("ADA", null);
            bool isMine = client.CheckCryptoAddressBelongsToCurrentAccount(addresses[0].Address_);
            if (!isMine)
            {
                Assert.Fail();
            }
        }

        public virtual void TestTransferBetweenWalletAndExchage()
        {
            string transactionId = client.TransferBetweenWalletAndExchange(new ParamsBuilder().Currency("ADA").Amount("0.1").Source(AccountType.Wallet).Destination(AccountType.Spot));
            if (transactionId.Equals(""))
            {
                Assert.Fail();
            }

            transactionId = client.TransferBetweenWalletAndExchange(new ParamsBuilder().Currency("ADA").Amount("0.1").Source(AccountType.Spot).Destination(AccountType.Wallet));
            if (transactionId.Equals(""))
            {
                Assert.Fail();
            }
        }

        public virtual void TestGetTransactionHistory()
        {
            IList<Transaction> transactions = client.GetTransactionHistory(new ParamsBuilder());
            
            foreach (var transaction in transactions) Checker.CheckTransaction.Invoke(transaction);
        }

        public virtual void TestGetTransactionHistoryWithParams()
        {
            IList<Transaction> transactions = client.GetTransactionHistory(new ParamsBuilder().OrderBy(OrderBy.CREATED_AT).Sort(Sort.DESC).Limit(1000).Offset(0).Currencies([]).From("1614815872000"));
            Assert.True(transactions.Count > 0);
            
            foreach (var transaction in transactions) Checker.CheckTransaction.Invoke(transaction);
        }

        public virtual void TestGetTransaction()
        {
            IList<Transaction> transactions = client.GetTransactionHistory(new ParamsBuilder().Limit(1));
            Transaction transaction = client.GetTransaction(transactions[0].NativeTransaction.Id);
            Checker.CheckTransaction.Invoke(transaction);
        }

        public virtual void TestOffchainAvailable()
        {
            IList<Address> eosAddresses = client.GetDepositCryptoAddresses("EOS", null);
            client.CheckIfOffchainIsAvailable("EOS", eosAddresses[0].Address_, null);
        }

        public virtual void TestGetAmountLock() { }
    }
}