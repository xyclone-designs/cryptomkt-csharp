
namespace CryptoMarket.SDK.Exceptions
{
    /// <summary>
    /// The base exception of com.cryptomarket.sdk
    /// </summary>
    public class CryptoMarketSDKException : Exception
    {
        public CryptoMarketSDKException(string errorMessage) : base(errorMessage) { }
        public CryptoMarketSDKException(string errorMessage, Exception err) : base(errorMessage, err) { }
    }
}