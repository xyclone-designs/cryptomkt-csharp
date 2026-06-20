
namespace CryptoMarket.SDK.Exceptions
{
    /// <summary>
    /// An Exception for argument errors while constructing params for requests
    /// </summary>
    public class CryptoMarketArgumentException(string errorMessage) : CryptoMarketSDKException(errorMessage) { }
}