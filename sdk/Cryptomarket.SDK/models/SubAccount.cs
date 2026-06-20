using CryptoMarket.SDK.Params;

namespace CryptoMarket.SDK.Models
{
    public class SubAccount
    {
        public string? SubAccountId { get; set; }
        public string? Email { get; set; }
        public SubAccountStatus? Status { get; set; }

        public override string ToString()
        {
            return string.Format("SubAccount [email={0}, status={1}, subAccountId={2}]", Email, Status, SubAccountId);
        }
    }
}