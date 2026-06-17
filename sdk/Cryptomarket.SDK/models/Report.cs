using Cryptomarket.SDK.Params;

namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// An order report or a trade report
    /// </summary>
    public class Report
    {
        public string? Id { get; set; }
        public string? ClientOrderId { get; set; }
        public string? Symbol { get; set; }
        public Side? Side { get; set; }
        public OrderStatus? Status { get; set; }
        public OrderType? Type { get; set; }
        public string? TimeInForce { get; set; }
        public string? Quantity { get; set; }
        public string? Price { get; set; }
        public string? QuantityCumulative { get; set; }
        public bool PostOnly { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
        public string? StopPrice { get; set; }
        public string? ExpireTime { get; set; }
        public ReportType? ReportType { get; set; }
        public string? TradeId { get; set; }
        public string? TradeQuantity { get; set; }
        public string? TradePrice { get; set; }
        public string? TradeFee { get; set; }
        public string? OriginalClientOrderId { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Report [id={0}, clientOrderId={1}, createdAt={2}, expireTime={3}, originalClientOrderId={4}, postOnly={5}, price={6}, quantity={7}, quantityCumulative={8}, reportType={9}, side={10}, status={11}, stopPrice={12}, symbol={13}, timeInForce={14}, tradeFee={15}, tradeId={16}, tradePrice={17}, tradeQuantity={18}, type={19}, updatedAt={20}]",
                Id, 
                ClientOrderId, 
                CreatedAt, 
                ExpireTime, 
                OriginalClientOrderId, 
                PostOnly, 
                Price, 
                Quantity, 
                QuantityCumulative, 
                ReportType, 
                Side, 
                Status, 
                StopPrice, 
                Symbol, 
                TimeInForce, 
                TradeFee, 
                TradeId, 
                TradePrice, 
                TradeQuantity, 
                Type, 
                UpdatedAt);
        }
    }
}