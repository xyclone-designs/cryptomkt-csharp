using Org.Junit.Assert;
using Java.Util;
using Org.Junit;
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
    public class TestRestClientChangeCredentials
    {
        CryptomarketRestClient client = new CryptomarketRestClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
        public virtual void TestChangeCredentials()
        {
            IList<Balance> balances = client.GetWalletBalances();
            if (balances.Count == 0)
                Fail();
            balances.ForEach((balance) =>
            {
                if (balance.GetCurrency() == null || balance.GetCurrency().Equals(""))
                    Fail();
            });
            client.ChangeCredentials("null", "null");
            try
            {
                balances = client.GetWalletBalances();
                Fail("should fail");
            }
            catch (CryptomarketSDKException e)
            {
            }

            client.ChangeCredentials(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
            balances = client.GetWalletBalances();
            if (balances.Count == 0)
                Fail();
            balances.ForEach((balance) =>
            {
                if (balance.GetCurrency() == null || balance.GetCurrency().Equals(""))
                    Fail();
            });
        }
    }
}