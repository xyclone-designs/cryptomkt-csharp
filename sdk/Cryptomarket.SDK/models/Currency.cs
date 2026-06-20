
namespace CryptoMarket.SDK.Models
{
    public class Currency
    {
        public string? FullName { get; set; }
        public bool? Crypto { get; set; }
        public bool? PayinEnabled { get; set; }
        public bool? PayoutEnabled { get; set; }
        public bool? TransferEnabled { get; set; }
        public string? Sign { get; set; }
        public string? CryptoPaymentIdName { get; set; }
        public string? CryptoExplorer { get; set; }
        public string? PrecisionTransfer { get; set; }
        public double? AccountTopOrder { get; set; }
        public string? QrPrefix { get; set; }
        public bool? Delisted { get; set; }
        public IList<Network>? Networks { get; set; } 

        public override string ToString()
        {
            return string.Format(
                "Currency [fullName={0}, crypto={1}, payinEnabled={2}, payoutEnabled={3}, transferEnabled={4}, sign={5}, cryptoPaymentIdName={6}, cryptoExplorer={7}, precisionTransfer={8}, accountTopOrder={9}, qrPrefix={10}, delisted={11}, networks={12}]",
                FullName, 
                Crypto, 
                PayinEnabled, 
                PayoutEnabled, 
                TransferEnabled, 
                Sign, 
                CryptoPaymentIdName, 
                CryptoExplorer, 
                PrecisionTransfer, 
                AccountTopOrder, 
                QrPrefix, 
                Delisted,
                Networks is null ? null : '[' + string.Join(", ", Networks) + ']');
        }
    }
}