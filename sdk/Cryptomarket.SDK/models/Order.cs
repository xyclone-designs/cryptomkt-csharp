using Cryptomarket.SDK.Params;

namespace Cryptomarket.SDK.Models
{
    public class Order
    {
        public string? Id { get; set; }
        public string? ClientOrderId { get; set; }
        public string? OrderListId { get; set; }
        public ContingencyType? ContingencyType { get; set; }
        public string? Symbol { get; set; }
        public Side? Side { get; set; }
        public OrderStatus? Status { get; set; }
        public OrderType? Type { get; set; }
        public TimeInForce? TimeInForce { get; set; }
        public string? Price { get; set; }
        public string? AveragePrice { get; set; }
        public string? Quantity { get; set; }
        public string? QuantityCumulative { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
        public bool? PostOnly { get; set; }
        public string? StopPrice { get; set; }
        public string? ExpireTime { get; set; }
        public IList<Trade>? Trades { get; set; }
        public string? OriginalClientOrderId { get; set; }


        public override string ToString()
        {
            return string.Format(
                "Order [id={0}, clientOrderId={1}, orderListId={2}, contingencyType={3}, symbol={4}, side={5}, status={6}, type={7}, timeInForce={8}, price={9}, averagePrice={10}, quantity={11}, quantityCumulative={12}, createdAt={13}, updatedAt={14}, postOnly={15}, stopPrice={16}, expireTime={17}, trades={18}, originalClientOrderId={19}]",
                Id, 
                ClientOrderId, 
                OrderListId, 
                ContingencyType, 
                Symbol, 
                Side, 
                Status, 
                Type, 
                TimeInForce, 
                Price, 
                AveragePrice, 
                Quantity, 
                QuantityCumulative, 
                CreatedAt, 
                UpdatedAt, 
                PostOnly, 
                StopPrice, 
                ExpireTime, 
                Trades is null ? null : '[' + string.Join(", ", Trades) + ']', 
                OriginalClientOrderId);
        }
    }
}