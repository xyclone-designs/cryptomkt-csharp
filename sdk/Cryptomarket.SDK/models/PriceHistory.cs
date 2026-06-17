
namespace Cryptomarket.SDK.Models
{
    public class PriceHistory
    {
        public string? Currency { get; set; }
        public IList<HistoryPoint>? History { get; set; }

        public override string ToString()
        {
            return string.Format(
                "PriceHistory [currency={0}, history={1}]", 
                Currency,
                History is null ? null : '[' + string.Join(", ", History) + ']');
        }
    }
}