using CryptoMarket.SDK.Params;

namespace CryptoMarket.SDK.Models
{
    /// <summary>
    /// Trade
    /// </summary>
    public class Trade
    {
        public long? Id { get; set; }
        public string? ClientOrderId { get; set; }
        public string? OrderId { get; set; }
        public string? Symbol { get; set; }
        public string? Quantity { get; set; }
        public string? Price { get; set; }
        public Side? Side { get; set; }
        public string? Fee { get; set; }
        public string? Timestamp { get; set; }
        public bool? Taker { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Trade [id={0}, clientOrderId={1}, orderId={2}, symbol={3}, quantity={4}, price={5}, side={6}, fee={7}, timestamp={8}, taker={9}]",
                Id, 
                ClientOrderId, 
                OrderId, 
                Symbol, 
                Quantity, 
                Price, 
                Side, 
                Fee, 
                Timestamp, 
                Taker);
        }
    }
}