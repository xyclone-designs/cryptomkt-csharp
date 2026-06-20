using Org.Junit.Assert;
using Java.Io;
using Java.Util;
using Java.Util.Function;
using CryptoMarket.Tests.SDK.Exceptions;
using CryptoMarket.Tests.SDK.Websocket;
using Org.Junit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

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
                Fail();
            }
        };
        public virtual void TestPublicClientLifetime()
        {
            CryptoMarketWSMarketDataClient wsClient;
            wsClient = new CryptoMarketWSMarketDataClientImpl();
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
            CryptoMarketWSSpotTradingClient wsClient;
            wsClient = new CryptoMarketWSSpotTradingClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
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
            CryptoMarketWSWalletClient wsClient;
            wsClient = new CryptoMarketWSWalletClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
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
            CryptoMarketWSWalletClient wsClient = new CryptoMarketWSWalletClientImpl("uno", "dois");
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