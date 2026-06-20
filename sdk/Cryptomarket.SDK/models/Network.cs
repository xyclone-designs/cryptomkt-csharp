

namespace CryptoMarket.SDK.Models
{
    public class Network
    {
        public string? Code { get; set; }
        public string? Network_ { get; set; }
        public string? Protocol { get; set; }
        public bool? DefaultNetwork { get; set; }
        public bool? PayinEnabled { get; set; }
        public bool? PayoutEnabled { get; set; }
        public string? PrecisionPayout { get; set; }
        public string? PayoutFee { get; set; }
        public bool? PayoutIsPaymentId { get; set; }
        public bool? PayinPaymentId { get; set; }
        public int? PayinConfirmations { get; set; }
        public string? AddressRegex { get; set; }
        public string? PaymentIdRegex { get; set; }
        public string? LowProcessingTime { get; set; }
        public string? HighProcessingTime { get; set; }
        public string? AvgProcessingTime { get; set; }
        public string? CryptoPaymentIdName { get; set; }
        public string? CryptoExplorer { get; set; }
        public string? NetworkName { get; set; }
        public bool? EnsAvailable { get; set; }
        public string? ContractAddress { get; set; }
        public bool? Multichain { get; set; }
        public Dictionary<string, string>? AssetId { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Network [code={0}, network={1}, ensAvailable={2}, protocol={3}, defaultNetwork={4}, payinEnabled={5}, payoutEnabled={6}, precisionPayout={7}, payoutFee={8}, payoutIsPaymentId={9}, payinPaymentId={10}, payinConfirmations={11}, addressRegex={12}, paymentIdRegex={13}, lowProcessingTime={14}, highProcessingTime={15}, avgProcessingTime={16}, cryptoPaymentIdName={17}, cryptoExplorer={18}]",
                Code,
                Network_,
                EnsAvailable,
                Protocol,
                DefaultNetwork,
                PayinEnabled,
                PayoutEnabled,
                PrecisionPayout,
                PayoutFee,
                PayoutIsPaymentId,
                PayinPaymentId,
                PayinConfirmations,
                AddressRegex,
                PaymentIdRegex,
                LowProcessingTime,
                HighProcessingTime,
                AvgProcessingTime,
                CryptoPaymentIdName,
                CryptoExplorer);
        }
    }
}