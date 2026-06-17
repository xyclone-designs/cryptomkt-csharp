
namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// Ticker
    /// </summary>
    public class Ticker
    {
        public string? Ask { get; set; }
        public string? Bid { get; set; }
        public string? Last { get; set; }
        public string? Low { get; set; }
        public string? High { get; set; }
        public string? Open { get; set; }
        public string? Volume { get; set; }
        public string? VolumeQuote { get; set; }
        public string? Timestamp { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Ticker [ask={0}, bid={1}, high={2}, last={3}, low={4}, open={5}, timestamp={6}, volume={7}, volumeQuote={8}]",
                Ask, 
                Bid, 
                High, 
                Last, 
                Low, 
                Open, 
                Timestamp, 
                Volume, 
                VolumeQuote);
        }
    }
}