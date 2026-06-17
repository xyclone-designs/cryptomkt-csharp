
namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// Orderbook level. A amount of able to beeing buyed or selled for a given price
    /// </summary>
    public class OrderbookLevel
    {
        public string? Price { get; set; }
        public string? Amount { get; set; }

        public override string ToString()
        {
            return string.Format("OrderbookLevel [amount={0}, price={1}]", Amount, Price);
        }
    }
}