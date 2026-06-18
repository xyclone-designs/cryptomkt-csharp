
namespace Cryptomarket.SDK.Exceptions
{
    /// <summary>
    /// An exception thrown when conversion to java classes fails
    /// </summary>
    public class ParseException : CryptomarketSDKException
    {
        public ParseException(string errorMessage) : base(errorMessage) { }
        public ParseException(string errorMessage, Exception err) : base(errorMessage, err) { }
    }
}