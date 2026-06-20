
namespace CryptoMarket.SDK.Models
{
    /// <summary>
    /// Order book
    /// </summary>
    public class OrderBook
    {
        public IList<OrderbookLevel>? Ask { get; set; }
        public IList<OrderbookLevel>? Bid { get; set; }
        public string? BatchingTime { get; set; }
        public string? Symbol { get; set; }
        public string? Timestamp { get; set; }
        public string? AskAveragePrice { get; set; }
        public string? BidAveragePrice { get; set; }
        public int? Sequence { get; set; }

        public override string ToString()
        {
            return string.Format(
                "OrderBook [ask={0}, askAveragePrice={1}, batchingTime={2}, bid={3}, bidAveragePrice={4}, sequence={5}, symbol={6}, timestamp={7}]",
				Ask is null ? null : '[' + string.Join(", ", Ask) + ']', 
                AskAveragePrice, 
                BatchingTime,
				Bid is null ? null : '[' + string.Join(", ", Bid) + ']', 
                BidAveragePrice, 
                Sequence, 
                Symbol, 
                Timestamp);
        }
    }
}