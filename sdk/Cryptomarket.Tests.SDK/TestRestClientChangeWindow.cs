using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Models;
using CryptoMarket.SDK.Rest;

namespace CryptoMarket.Tests.SDK
{
    public class TestRestClientChangeWindow
    {
        ICryptoMarketRestClient client = new CryptoMarketRestClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
        public virtual void TestChangeCredentials()
        {
            IList<Balance> balances = client.GetWalletBalances();

            if (balances.Count == 0)
                Assert.Fail();
            
            foreach (var balance in balances) 
                if (string.IsNullOrEmpty(balance.Currency))
                    Assert.Fail();

            client.ChangeWindow(100);

            try
            {
                balances = client.GetWalletBalances();
                Assert.Fail("should fail");
            }
            catch (CryptoMarketSDKException) { }

            client.ChangeWindow(10000);
            
            balances = client.GetWalletBalances();

            if (balances.Count == 0)
                Assert.Fail();

            foreach (var balance in balances)
                if (string.IsNullOrEmpty(balance.Currency))
                    Assert.Fail();
        }
    }
}