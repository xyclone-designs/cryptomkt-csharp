
namespace CryptoMarket.SDK.Models
{
    /// <summary>
    /// Websocket price rate
    /// </summary>
    public class WSPriceRate
    {
        public long? Timestamp { get; set; }
        public string? Rate { get; set; }

        public override string ToString()
        {
            return string.Format("WSPriceRate [timestamp={0}, rate={1}]", Timestamp, Rate);
        }
    }
}