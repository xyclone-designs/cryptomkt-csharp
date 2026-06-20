using Org.Junit.Assert;
using Java.Util;
using Org.Junit;
using CryptoMarket.Tests.SDK.Exceptions;
using CryptoMarket.Tests.SDK.Models;
using CryptoMarket.Tests.SDK.Rest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CryptoMarket.Tests.SDK
{
    public class TestRestClientChangeCredentials
    {
        CryptoMarketRestClient client = new CryptoMarketRestClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
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
            catch (CryptoMarketSDKException e)
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