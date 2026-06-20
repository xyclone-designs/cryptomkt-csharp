using CryptoMarket.SDK.Models;

namespace CryptoMarket.SDK.Exceptions
{
    /// <summary>
    /// Exception originationg from the api
    /// </summary>
    public class CryptoMarketAPIException : CryptoMarketSDKException
    {
        public CryptoMarketAPIException(string errorMessage) : base(errorMessage) { }
        public CryptoMarketAPIException(string errorMessage, Exception err) : base(errorMessage, err) { }
        public CryptoMarketAPIException(ErrorBody errorBody) : base(string.Format("(code={0}) {1}.{2}", errorBody.Code, errorBody.Message, errorBody.Description)) { }
        public CryptoMarketAPIException(ErrorBody errorBody, Exception err) : base(string.Format("(code={0}) {1}.{2}", errorBody.Code, errorBody.Message, errorBody.Description), err) { }
    }
}