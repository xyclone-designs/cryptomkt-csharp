
namespace CryptoMarket.SDK.Models
{
    /// <summary>
    /// Price
    /// </summary>
    public class Price
    {
        public string? Currency { get; set; }
        public string? Price_ { get; set; }
        public string? Timestamp { get; set; }

        public override string ToString()
        {
            return string.Format("Price [currency={0}, price={1}, timestamp={2}]", Currency, Price_, Timestamp);
        }
    }
}