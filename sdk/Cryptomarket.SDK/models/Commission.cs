
namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// Personal commission rate by symbol
    /// </summary>
    public class Commission
    {
        public string? Symbol { get; set; }
        public string? TakeRate { get; set; }
        public string? MakeRate { get; set; }

        public override string ToString()
        {
            return string.Format("Commission [makeRate={0}, symbol={1}, takeRate={2}]", MakeRate, Symbol, TakeRate);
        }
    }
}