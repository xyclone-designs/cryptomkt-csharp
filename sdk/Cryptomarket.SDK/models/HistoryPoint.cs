
namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// Price history point
    /// </summary>
    public class HistoryPoint
    {
        public string? Timestamp { get; set; }
        public string? Open { get; set; }
        public string? Close { get; set; }
        public string? Min { get; set; }
        public string? Max { get; set; }

        public override string ToString()
        {
            return string.Format("HistoryPoint [close={0}, max={1}, min={2}, open={3}, timestamp={4}]", Close, Max, Min, Open, Timestamp);
        }
    }
}