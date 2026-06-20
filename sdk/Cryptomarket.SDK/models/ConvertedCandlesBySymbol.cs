
namespace CryptoMarket.SDK.Models
{
    /// <summary>
    /// Candle
    /// </summary>
    public class ConvertedCandlesBySymbol
    {
        public string? TargetCurrency { get; set; }
        public IList<Candle>? Data { get; set; }

        public override string ToString()
        {
            return string.Format(
                "ConvertedCandles [targetCurrency={0}, data={1}]", 
                TargetCurrency,
                Data is null ? null : '[' + string.Join(", ", Data) + ']');
        }
    }
}