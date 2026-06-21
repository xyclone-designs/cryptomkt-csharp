
namespace CryptoMarket.SDK.Models
{
    public class FeeRequest(string? currency, string? amount, string? networkCode)
    {
        public string? Currency { get; set; } = currency;
        public string? Amount { get; set; } = amount;
        public string? NetworkCode { get; set; } = networkCode;

        public override string ToString()
        {
            return string.Format("FeeRequest [currency={0}, amount={1}, networkCode={2}]", Currency, Amount, NetworkCode);
        }
    }
}