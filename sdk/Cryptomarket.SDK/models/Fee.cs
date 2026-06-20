
namespace CryptoMarket.SDK.Models
{
    public class Fee
    {
        public string? Fee_ { get; set; }
        public string? NetworkFee { get; set; }
        public string? Amount { get; set; }
        public string? Currency { get; set; }

        public override string ToString()
        {
            return string.Format("Fee [fee={0}, networkFee={1}, amount={2}, currency={3}]", Fee_, NetworkFee, Amount, Currency);
        }
    }
}