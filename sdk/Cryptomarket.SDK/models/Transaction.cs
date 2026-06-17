using Cryptomarket.SDK.Params;

namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// Transaction
    /// </summary>
    public class Transaction
    {
        public long? Id { get; set; }
        public TransactionStatus? Status { get; set; }
        public TransactionType? Type { get; set; }
        public TransactionSubtype? Subtype { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
        public string? LastActivityAt { get; set; }
        public NativeTransaction? NativeTransaction { get; set; }
        public string? NetworkCode { get; set; }
        public CommitRisk? CommitRisk { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Transaction [id={0}, status={1}, type={2}, subtype={3}, createdAt={4}, updatedAt={5}, lastActivityAt={6}, nativeTransaction={7}, networkCode={8}, commitRisk={9}]",
                Id, 
                Status, 
                Type, 
                Subtype, 
                CreatedAt, 
                UpdatedAt, 
                LastActivityAt, 
                NativeTransaction, 
                NetworkCode, 
                CommitRisk);
        }
    }
}