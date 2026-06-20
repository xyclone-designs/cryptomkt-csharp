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
    public class TestRestClientChangeWindow
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
            client.ChangeWindow(100);
            try
            {
                balances = client.GetWalletBalances();
                Fail("should fail");
            }
            catch (CryptomarketSDKException e)
            {
            }

            client.ChangeWindow(10000);
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