using Org.Junit.Assert;
using Java.Util;
using Org.Junit;
using Com.Cryptomarket.Params;
using Com.Cryptomarket.Sdk.Exceptions;
using Com.Cryptomarket.Sdk.Models;
using Com.Cryptomarket.Sdk.Rest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Com.Cryptomarket.Sdk
{
    public class TestRestClientWalletManagement
    {
        CryptomarketRestClient client = new CryptomarketRestClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
        public virtual void TestGetWalletBalances()
        {
            IList<Balance> balances = client.GetWalletBalances();
            if (balances.Count == 0)
                Fail();
            balances.ForEach((balance) =>
            {
                if (balance.GetCurrency() == null || balance.GetCurrency().Equals(""))
                    Fail();
            });
        }

        public virtual void TestGetWalletBalanceOfCurrency()
        {
            Balance balance = client.GetWalletBalanceByCurrency("ADA");
            Checker.checkBalance.Accept(balance);
        }

        public virtual void TestGetDepositCriptoAddresses()
        {
            IList<Address> addresses = client.GetDepositCryptoAddresses(null, null);
            addresses.ForEach(Checker.checkAddress);
        }

        public virtual void TestGetDepositCriptoAddressOfCurrency()
        {
            IList<Address> addresses = client.GetDepositCryptoAddresses("NEXO", null);
            addresses.ForEach(Checker.checkAddress);
        }

        public virtual void TestCreateDepositCryptoAddress()
        {
            Address addresses = client.CreateDepositCryptoAddress("BTC", null);
            Checker.checkAddress.Accept(addresses);
        }

        public virtual void TestLast10DepositCryptoAddresses()
        {
            IList<Address> addresses = client.GetLast10DepositCryptoAddresses("EOS", null);
            addresses.ForEach(Checker.checkAddress);
        }

        public virtual void TestLast10WithdrawalCryptoAddresses()
        {
            IList<Address> addresses = client.GetLast10WithdrawalCryptoAddresses("EOS", null);
            addresses.ForEach(Checker.checkAddress);
        }

        public virtual void TestWithdrawCrypto()
        {
            IList<Address> adaAddresses = client.GetDepositCryptoAddresses("ADA", null);
            string transaction_id = client.WithdrawCrypto(new ParamsBuilder().Currency("ADA").Amount("0.1").Address(adaAddresses[0].GetAddress()));
            if (transaction_id.Equals(""))
            {
                Fail();
            }
        }

        public virtual void TestWithdrawCryptoCommit()
        {
            IList<Address> adaAddresses = client.GetDepositCryptoAddresses("ADA", null);
            string transactionId = client.WithdrawCrypto(new ParamsBuilder().Currency("ADA").Amount("0.1").Address(adaAddresses[0].GetAddress()).AutoCommit(false));
            if (transactionId.Equals(""))
            {
                Fail();
            }

            bool result = client.WithdrawCryptoCommit(transactionId);
            if (!result)
            {
                Fail();
            }
        }

        public virtual void TestWithdrawCryptoRollback()
        {
            IList<Address> adaAddresses = client.GetDepositCryptoAddresses("ADA", null);
            string transactionId = client.WithdrawCrypto(new ParamsBuilder().Currency("ADA").Amount("0.1").Address(adaAddresses[0].GetAddress()).AutoCommit(false));
            if (transactionId.Equals(""))
            {
                Fail();
            }

            bool result = client.WithdrawCryptoRollback(transactionId);
            if (!result)
            {
                Fail();
            }
        }

        public virtual void TestGetEstimateWithdrawFees()
        {
            var fees = client.GetEstimateWithdrawalFees(List.Of(new FeeRequest("EOS", "100", null), new FeeRequest("ETH", "100", null)));
            if (fees.Count != 2)
            {
                Fail("invalid amount of fees");
            }

            fees.ForEach(Checker.checkFee);
        }

        public virtual void TestGetBulkEstimateWithdrawFees()
        {
            var fees = client.GetBulkEstimateWithdrawalFees(List.Of(new FeeRequest("EOS", "100", null), new FeeRequest("ETH", "100", null)));
            if (fees.Count != 2)
            {
                Fail("invalid amount of fees");
            }

            fees.ForEach(Checker.checkFee);
        }

        public virtual void TestGetEstimateWithdrawFee()
        {
            string estimate = client.GetEstimateWithdrawalFee("EOS", "100", null);
            if (estimate.Equals(""))
            {
                Fail();
            }
        }

        public virtual void TestGetEstimateWithdrawFeesHash()
        {
            string estimate = client.GetWithdrawalFeesHash();
            if (estimate.Equals(""))
            {
                Fail();
            }
        }

        // @Test
        // public void testGetEstimateDepositFees() throws CryptomarketSDKException {
        //   var fees = client
        //       .getBulkEstimateDepositFees(List.of(new FeeRequest("EOS", "100"), new FeeRequest("ETH", "100")));
        //   if (fees.size() != 2) {
        //     fail("invalid amount of fees");
        //   }
        //   fees.forEach(Checker.checkFee);
        // }
        // @Test
        // public void testGetEstimateDepositFee() throws CryptomarketSDKException {
        //   String estimate = client.getEstimateDepositFee("EOS", "100", null);
        //   if (estimate.equals("")) {
        //     fail();
        //   }
        // }
        public virtual void TestCryptoAddressBelongsToCurrentAccount()
        {
            IList<Address> addresses = client.GetDepositCryptoAddresses("ADA", null);
            bool isMine = client.CheckCryptoAddressBelongsToCurrentAccount(addresses[0].GetAddress());
            if (!isMine)
            {
                Fail();
            }
        }

        public virtual void TestTransferBetweenWalletAndExchage()
        {
            string transactionId = client.TransferBetweenWalletAndExchange(new ParamsBuilder().Currency("ADA").Amount("0.1").Source(AccountType.WALLET).Destination(AccountType.SPOT));
            if (transactionId.Equals(""))
            {
                Fail();
            }

            transactionId = client.TransferBetweenWalletAndExchange(new ParamsBuilder().Currency("ADA").Amount("0.1").Source(AccountType.SPOT).Destination(AccountType.WALLET));
            if (transactionId.Equals(""))
            {
                Fail();
            }
        }

        public virtual void TestGetTransactionHistory()
        {
            IList<Transaction> transactions = client.GetTransactionHistory(new ParamsBuilder());
            transactions.ForEach(Checker.checkTransaction);
        }

        public virtual void TestGetTransactionHistoryWithParams()
        {
            IList<Transaction> transactions = client.GetTransactionHistory(new ParamsBuilder().OrderBy(OrderBy.CREATED_AT).Sort(Sort.DESC).Limit(1000).Offset(0).Currencies(List.Of()).From("1614815872000"));
            AssertTrue(transactions.Count > 0);
            transactions.ForEach(Checker.checkTransaction);
        }

        public virtual void TestGetTransaction()
        {
            IList<Transaction> transactions = client.GetTransactionHistory(new ParamsBuilder().Limit(1));
            Transaction transaction = client.GetTransaction(transactions[0].GetNativeTransaction().GetId());
            Checker.checkTransaction.Accept(transaction);
        }

        public virtual void TestOffchainAvailable()
        {
            IList<Address> eosAddresses = client.GetDepositCryptoAddresses("EOS", null);
            client.CheckIfOffchainIsAvailable("EOS", eosAddresses[0].GetAddress(), null);
        }

        public virtual void TestGetAmountLock()
        {
        }
    }
}