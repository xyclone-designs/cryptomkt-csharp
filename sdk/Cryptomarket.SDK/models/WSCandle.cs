
namespace CryptoMarket.SDK.Models
{
    /// <summary>
    /// Websocket Candle
    /// </summary>
    public class WSCandle
    {
        public long? Timestamp { get; set; }
        public string? Open { get; set; }
        public string? Close { get; set; }
        public string? High { get; set; }
        public string? Low { get; set; }
        public string? VolumeBase { get; set; }
        public string? VolumeQuote { get; set; }

        public override string ToString()
        {
            return string.Format(
                "WSCandle [close={0}, high={1}, low={2}, open={3}, timestamp={4}, volumeBase={5}, volumeQuote={6}]",
                Close,
                High,
                Low,
                Open,
                Timestamp,
                VolumeBase,
                VolumeQuote);
        }
    }
}