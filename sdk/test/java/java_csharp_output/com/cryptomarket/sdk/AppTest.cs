using Com.Cryptomarket.Sdk.Rest;
using Junit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Com.Cryptomarket.Sdk
{
    /// <summary>
    /// Unit test for simple App.
    /// </summary>
    public class AppTest : TestCase
    {
        CryptomarketRestClient client = new CryptomarketRestClientImpl(KeyLoader.GetApiKey(), KeyLoader.GetApiSecret());
        public AppTest(string testName) : base(testName)
        {
        }

        /// <returns>the suite of tests being tested</returns>
        public static Test Suite()
        {
            return new TestSuite(typeof(AppTest));
        }

        /// <summary>
        /// Rigourous Test :-)
        /// </summary>
        public virtual void TestApp()
        {
            AssertTrue(true);
        }
    }
}