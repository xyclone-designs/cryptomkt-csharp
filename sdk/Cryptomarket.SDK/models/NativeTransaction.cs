
namespace Cryptomarket.SDK.Models
{
    public class NativeTransaction
    {
        public string? Id { get; set; }
        public long? Index { get; set; }
        public string? Currency { get; set; }
        public string? Amount { get; set; }
        public string? Fee { get; set; }
        public string? Address { get; set; }
        public string? PaymentId { get; set; }
        public string? Hash { get; set; }
        public string? OffchainId { get; set; }
        public string? Confirmations { get; set; }
        public string? PublicComment { get; set; }
        public string? NetworkCode { get; set; }
        public string? ErrorCode { get; set; }
        public IList<string>? Sender { get; set; }

        public override string ToString()
        {
            return string.Format(
                "NativeTransaction [id={0}, index={1}, currency={2}, amount={3}, fee={4}, address={5}, paymentId={6}, hash={7}, offchainId={8}, confirmations={9}, publicComment={10}, networkCode={11}, errorCode={12}, sender={13}]",
                Id, 
                Index, 
                Currency, 
                Amount, 
                Fee, 
                Address, 
                PaymentId, 
                Hash, 
                OffchainId, 
                Confirmations, 
                PublicComment, 
                NetworkCode, 
                ErrorCode,
                Sender is null ? null : '[' + string.Join(", ", Sender) + ']');
        }
    }
}