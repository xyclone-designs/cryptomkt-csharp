
namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// Candle
    /// </summary>
    public class Candle
    {
        public string? Timestamp { get; set; }
        public string? Open { get; set; }
        public string? Close { get; set; }
        public string? Min { get; set; }
        public string? Max { get; set; }
        public string? Volume { get; set; }
        public string? VolumeQuote { get; set; }

        public override string ToString()
        {
            return string.Format("Candle [close={0}, max={1}, min={2}, open={3}, timestamp={4}, volume={5}, volumeQuote={6}]", Close, Max, Min, Open, Timestamp, Volume, VolumeQuote);
        }
    }
}