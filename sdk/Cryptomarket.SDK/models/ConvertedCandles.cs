
namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// Candle
    /// </summary>
    public class ConvertedCandles
    {
        public string? TargetCurrency { get; set; }
        public Dictionary<string, IList<Candle>>? Data { get; set; }
        
        public override string ToString()
        {
            return string.Format(
                "ConvertedCandles [targetCurrency={0}, data={1}]", 
                TargetCurrency,
                Data is null ? null : '[' + string.Join(',', Data.Select(_ => '{' + _.Key + ", [" + string.Join(',', _.Value) + "]}")) + ']');
        }
    }
}