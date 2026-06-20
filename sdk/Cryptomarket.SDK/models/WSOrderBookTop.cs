
namespace CryptoMarket.SDK.Models
{
    /// <summary>
    /// Websocket orderbook top
    /// </summary>
    public class WSOrderBookTop
    {
        public long? Timestamp { get; set; }
        public string? BestAsk { get; set; }
        public string? BestAskQuantity { get; set; }
        public string? BestBid { get; set; }
        public string? BestBidQuantity { get; set; }

        public override string ToString()
        {
            return string.Format("WSOrderBookTop [bestAsk={0}, bestAskQuantity={1}, bestBid={2}, bestBidQuantity={3}, timestamp={4}]", BestAsk, BestAskQuantity, BestBid, BestBidQuantity, Timestamp);
        }
    }
}