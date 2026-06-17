
namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// Amount lock. amount of user balance locked
    /// </summary>
    public class AmountLock
    {
        public long? Id { get; set; }
        public string? Currency { get; set; }
        public string? Amount { get; set; }
        public string? DateEnd { get; set; }
        public string? Description { get; set; }
        public bool? Canceled { get; set; }
        public string? CanceledAt { get; set; }
        public string? CancelDescription { get; set; }
        public string? CreatedAt { get; set; }

        public override string ToString()
        {
            return string.Format(
                "AmountLock [id={0}, amount={1}, cancelDescription={2}, canceled={3}, canceledAt={4}, createdAt={5}, currency={6}, dateEnd={7}, description={8}]",
                Id, 
                Amount, 
                CancelDescription,
                Canceled, 
                CanceledAt, 
                CreatedAt, 
                Currency, 
                DateEnd, 
                Description);
        }
    }
}