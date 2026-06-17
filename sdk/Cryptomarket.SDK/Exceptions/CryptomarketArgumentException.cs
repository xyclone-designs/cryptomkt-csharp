
namespace Cryptomarket.Exceptions
{
    /// <summary>
    /// An Exception for argument errors while constructing params for requests
    /// </summary>
    public class CryptomarketArgumentException(string errorMessage) : CryptomarketSDKException(errorMessage) { }
}