
namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// Websocket public trade
    /// </summary>
    public class WSPublicTrade
    {
        public long? Timestamp { get; set; }
        public long? Id { get; set; }
        public string? Price { get; set; }
        public string? Quantity { get; set; }
        public string? Side { get; set; }

        public override string ToString()
        {
            return string.Format("WSPublicTrade [timestamp={0}, id={1}, price={2}, quantity={3}, side={4}]", Timestamp, Id, Price, Quantity, Side);
        }
    }
}