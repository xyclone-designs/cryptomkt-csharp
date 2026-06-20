using CryptoMarket.SDK.Params;

namespace CryptoMarket.SDK.Requests
{
    public class WithdrawRequest
    {
        public string Currency { get; }
        public string NetworkCode { get; }
        public double Amount { get; }
        public string Address { get; }
        public string PaymentId { get; }
        public bool IncludeFee { get; }
        public bool AutoCommit { get; }
        public string UseOffchain { get; }
        public string PublicComment { get; }

        public WithdrawRequest(ParamsBuilder paramsBuilder)
        {
            Dictionary<string, string> paramsMap = paramsBuilder.Build();

            Currency = paramsMap[ArgNames.CURRENCY];
            NetworkCode = paramsMap[ArgNames.NETWORK_CODE];
            Amount = double.Parse(paramsMap[ArgNames.AMOUNT]);
            PaymentId = paramsMap[ArgNames.PAYMENT_ID];
            IncludeFee = bool.Parse(paramsMap[ArgNames.INCLUDE_FEE]);
            AutoCommit = bool.Parse(paramsMap[ArgNames.AUTO_COMMIT]);
            UseOffchain = paramsMap[ArgNames.USE_OFFCHAIN];
            PublicComment = paramsMap[ArgNames.PUBLIC_COMMENT];
            Address = paramsMap[ArgNames.ADDRESS];
        }
    }
}