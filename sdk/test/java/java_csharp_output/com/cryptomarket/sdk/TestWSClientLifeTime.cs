using Org.Junit.Assert;
using Java.Io;
using Java.Util;
using Java.Util.Function;
using Com.Cryptomarket.Sdk.Exceptions;
using Com.Cryptomarket.Sdk.Websocket;
using Org.Junit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Com.Cryptomarket.Sdk
{
    class Failed
    {
        public static bool failed = false;
    }

    public class TestWSClientLifeTime
    {
        BiConsumer<IList<string>, CryptomarketSDKException> checkException = (result, exception) =>
        {
            if (exception != null)
            {
                Fail();
            }
        };
        public virtual void TestPublicClientLifetime()
        {
            CryptomarketWSMarketDataClient wsClient;
            wsClient = new CryptomarketWSMarketDataClientImpl();
            wsClient.OnConnect(() =>
            {
                System.@out.Println("connected");
                new Thread(() =>
                {
                    wsClient.SubscribeToFullOrderBook((data, notificationType) => System.@out.Println(notificationType), Arrays.AsList("EOSETH"), checkException);
                    Helpers.Sleep(3);
                    wsClient.Dispose();
                }).Run();
            });
            wsClient.OnClose((reason) => System.@out.Println("closing"));
            wsClient.OnFailure((t) => t.PrintStackTrace());
            wsClient.Connect();
            Helpers.Sleep(6);
        }

        public virtual void TestTradingClientLifetime()
        {
            CryptomarketWSSpotTradingClient wsClient;
            wsClient = new CryptomarketWSSpotTradingClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
            wsClient.OnConnect(() =>
            {
                System.@out.Println("connected");
                Helpers.Sleep(3);
                wsClient.Dispose();
            });
            wsClient.OnClose((reason) => System.@out.Println("closing"));
            wsClient.OnFailure((t) => t.PrintStackTrace());
            wsClient.Connect();
            Helpers.Sleep(3);
        }

        public virtual void TestAccountClientLifetime()
        {
            CryptomarketWSWalletClient wsClient;
            wsClient = new CryptomarketWSWalletClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
            wsClient.OnClose((reason) =>
            {
                System.@out.Println("closing");
            });
            wsClient.OnConnect(() =>
            {
                System.@out.Println("connected");
                wsClient.GetWalletBalances((balanceList, exception) =>
                {
                    System.@out.Println(balanceList);
                    if (exception != null)
                    {
                        exception.PrintStackTrace();
                        Fail();
                    }
                });
                Helpers.Sleep(3);
                wsClient.Dispose();
            });
            wsClient.OnFailure((t) =>
            {
                t.PrintStackTrace();
            });
            wsClient.Connect();
            Helpers.Sleep(6);
        }

        public virtual void TestFailedAuth()
        {
            Failed.failed = false;
            CryptomarketWSWalletClient wsClient = new CryptomarketWSWalletClientImpl("uno", "dois");
            wsClient.OnFailure((t) =>
            {
                Failed.failed = true;
            });
            wsClient.Connect();
            Helpers.Sleep(3);
            AssertTrue(Failed.failed);
        }
    }
}