using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Websocket;

namespace CryptoMarket.Tests.SDK
{
    class Failed
    {
        public static bool failed = false;
    }

    public class TestWSClientLifeTime
    {
        Action<IList<string>, CryptoMarketSDKException> checkException = (result, exception) =>
        {
            if (exception != null)
            {
                Assert.Fail();
            }
        };
        public virtual void TestPublicClientLifetime()
        {
            ICryptoMarketWSMarketDataClient wsClient;
            wsClient = new CryptoMarketWSMarketDataClientImpl()
            {
                OnClose = _ => { Console.WriteLine("Closing"); },
                OnFailure = _ => { Console.Error.WriteLine(_.StackTrace); },
            };
            wsClient.OnConnect = () =>
            {
                Console.WriteLine("connected");
                new Thread(() =>
                {
                    wsClient.SubscribeToFullOrderBook((data, notificationType) => Console.WriteLine(notificationType), ["EOSETH"], checkException);
                    Helpers.Sleep(3);
                    wsClient.Dispose();

                }).Start();
            };
            wsClient.Connect();
            Helpers.Sleep(6);
        }

        public virtual void TestTradingClientLifetime()
        {
            ICryptoMarketWSSpotTradingClient wsClient = new CryptoMarketWSSpotTradingClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret())
            {
                OnClose = _ => { Console.WriteLine("Closing"); },
                OnFailure = _ => { Console.Error.WriteLine(_.StackTrace); },
            };
            wsClient.OnConnect = () =>
            {
                Console.WriteLine("connected");
                Helpers.Sleep(3);
                wsClient.Dispose();
            };
            wsClient.Connect();
            Helpers.Sleep(3);
        }

        public virtual void TestAccountClientLifetime()
        {
            ICryptoMarketWSWalletClient wsClient = new CryptoMarketWSWalletClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret())
            {
                OnClose = _ => { Console.WriteLine("Closing"); },
                OnFailure = _ => { Console.Error.WriteLine(_.StackTrace); },
            };

            wsClient.OnConnect = () =>
            {
                Console.WriteLine("connected");
                wsClient.GetWalletBalances((balanceList, exception) =>
                {
                    Console.WriteLine(balanceList);

                    if (exception != null)
                    {
                        Console.Error.WriteLine(exception.StackTrace);
                        Assert.Fail();
                    }
                });
                Helpers.Sleep(3);
                wsClient.Dispose();
            };

            wsClient.Connect();
            Helpers.Sleep(6);
        }

        public virtual void TestFailedAuth()
        {
            Failed.failed = false;
            ICryptoMarketWSWalletClient wsClient = new CryptoMarketWSWalletClientImpl("uno", "dois")
            {
                OnFailure = _ => { Failed.failed = true; }
            };
            wsClient.Connect();
            Helpers.Sleep(3);
            Assert.True(Failed.failed);
        }
    }
}