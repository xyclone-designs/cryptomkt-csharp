
namespace Cryptomarket.SDK.Params
{
    public class OrderBuilder
    {
        public string? ClientOrderId { get; set; }
        public string? Symbol { get; set; }
        public Side? Side { get; set; }
        public OrderType? Type { get; set; }
        public TimeInForce? TimeInForce { get; set; }
        public string? Quantity { get; set; }
        public string? Price { get; set; }
        public string? StopPrice { get; set; }
        public string? ExpireTime { get; set; }
        public bool? StrictValidate { get; set; }
        public bool? PostOnly { get; set; }
        public string? TakeRate { get; set; }
        public string? MakeRate { get; set; }
    }
}