
namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// Symbol
    /// </summary>
    public class Symbol
    {
        public string? Type { get; set; }
        public string? BaseCurrency { get; set; }
        public string? QuoteCurrency { get; set; }
        public string? Status { get; set; }
        public string? QuantityIncrement { get; set; }
        public string? TickSize { get; set; }
        public string? TakeRate { get; set; }
        public string? MakeRate { get; set; }
        public string? FeeCurrency { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Symbol [type={0}, baseCurrency={1}, quoteCurrency={2}, status={3}, quantityIncrement={4}, tickSize={5}, takeRate={6}, makeRate={7}, feeCurrency={8}]",
                Type, 
                BaseCurrency, 
                QuoteCurrency, 
                Status, 
                QuantityIncrement, 
                TickSize, 
                TakeRate, 
                MakeRate, 
                FeeCurrency);
        }
    }
}