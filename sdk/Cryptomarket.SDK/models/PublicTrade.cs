
namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// Public Trade
    /// </summary>
    public class PublicTrade
    {
        public long? Id { get; set; }
        public string? Quantity { get; set; }
        public string? Price { get; set; }
        public string? Side { get; set; }
        public string? Timestamp { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Trade [id={0}, price={1}, quantity={2}, side={3}, timestamp={4}]",
                Id,
                Price,
                Quantity,
                Side,
                Timestamp);
        }
    }
}