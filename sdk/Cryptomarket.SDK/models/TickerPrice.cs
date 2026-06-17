
namespace Cryptomarket.SDK.Models
{
    public class TickerPrice
    {
        public string? Price { get; set; }
        public string? Timestamp { get; set; }

        public override string ToString()
        {
            return string.Format("TickerPrice [price={0}, timestamp={1}]", Price, Timestamp);
        }
    }
}