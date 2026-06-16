using Cryptomarket.SDK.Models;

namespace Cryptomarket.SDK.Exceptions
{
    /// <summary>
    /// Exception originationg from the api
    /// </summary>
    public class CryptomarketAPIException : CryptomarketSDKException
    {
        public CryptomarketAPIException(string errorMessage) : base(errorMessage) { }
        public CryptomarketAPIException(string errorMessage, Exception err) : base(errorMessage, err) { }
        public CryptomarketAPIException(ErrorBody errorBody) : base(string.Format("(code={0}) {1}.{2}", errorBody.Code, errorBody.Message, errorBody.Description)) { }
        public CryptomarketAPIException(ErrorBody errorBody, Exception err) : base(string.Format("(code={0}) {1}.{2}", errorBody.Code, errorBody.Message, errorBody.Description), err) { }
    }
}