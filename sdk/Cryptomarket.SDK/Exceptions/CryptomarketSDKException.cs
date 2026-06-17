
namespace Cryptomarket.Exceptions
{
    /// <summary>
    /// The base exception of com.cryptomarket.sdk
    /// </summary>
    public class CryptomarketSDKException : Exception
    {
        public CryptomarketSDKException(string errorMessage) : base(errorMessage) { }
        public CryptomarketSDKException(string errorMessage, Exception err) : base(errorMessage, err) { }
    }
}