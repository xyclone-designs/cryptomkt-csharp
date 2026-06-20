
using CryptoMarket.SDK.Params;

namespace CryptoMarket.SDK.Requests
{
    public class OrderListRequest(ContingencyType contingencyType, string orderListId, IList<OrderBuilder> orders)
    {
        public ContingencyType ContingencyType { get; } = contingencyType;
        public string OrderListId { get; } = orderListId;
        public IList<OrderBuilder> Orders { get; } = orders;
    }
}