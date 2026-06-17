
namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// Websocket orderbook
    /// </summary>
    public class WSOrderBook
    {
        public long? Timestamp { get; set; }
        public long? Sequence { get; set; }
        public IList<IList<string>>? Asks { get; set; }
        public IList<IList<string>>? Bids { get; set; }

        public override string ToString()
        {
            return string.Format(
                "WSOrderBook [asks={0}, bids={1}, sequence={2}, timestamp={3}]", 
                Asks is null ? null : '[' + string.Join(", ", '[' + string.Join(",", Asks.Select(_ => _)) + ']') + ']',
                Bids is null ? null : '[' + string.Join(", ", '[' + string.Join(",", Bids.Select(_ => _)) + ']') + ']', 
                Sequence, 
                Timestamp);
        }
    }
}