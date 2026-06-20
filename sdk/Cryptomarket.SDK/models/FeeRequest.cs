
namespace CryptoMarket.SDK.Models
{
    public class FeeRequest
    {
        public string? Currency { get; set; }
        public string? Amount { get; set; }
        public string? NetworkCode { get; set; }

        public override string ToString()
        {
            return string.Format("FeeRequest [currency={0}, amount={1}, networkCode={2}]", Currency, Amount, NetworkCode);
        }
    }
}