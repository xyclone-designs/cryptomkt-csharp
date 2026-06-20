
namespace CryptoMarket.SDK.Models
{
    /// <summary>
    /// Websocket ticker
    /// </summary>
    public class WSTicker
    {
        public virtual long? Timestamp { get; set; }
        public virtual string? BestAsk { get; set; }
        public virtual string? BestAskQuantity { get; set; }
        public virtual string? BestBid { get; set; }
        public virtual string? BestBidQuantity { get; set; }
        public virtual string? Open { get; set; }
        public virtual string? Close { get; set; }
        public virtual string? High { get; set; }
        public virtual string? Low { get; set; }
        public virtual string? VolumeBase { get; set; }
        public virtual string? VolumeQuote { get; set; }
        public virtual string? PriceChange { get; set; }
        public virtual string? PriceChangePercent { get; set; }
        public virtual long? LastTradeId { get; set; }

        public override string ToString()
        {
            return string.Format(
                "WSTicker [timestamp={0} , bestAsk={1} , bestAskQuantity={2} , bestBid={3} , bestBidQuantity={4} , open={5} , close={6} , high={7} , low={8} , volumeBase={9} , volumeQuote={10} , priceChange={11} , priceChangePercent={12} , lastTradeId={13} ]",
                Timestamp,
                BestAsk,
                BestAskQuantity,
                BestBid,
                BestBidQuantity,
                Open,
                Close,
                High,
                Low,
                VolumeBase,
                VolumeQuote,
                PriceChange,
                PriceChangePercent,
                LastTradeId);
        }
    }
}