
namespace Cryptomarket.SDK.Exceptions
{
    /// <summary>
    /// An Exception for argument errors while constructing params for requests
    /// </summary>
    public class CryptomarketArgumentException : CryptomarketSDKException
    {
        public CryptomarketArgumentException(string errorMessage) : base(errorMessage) { }
    }
}