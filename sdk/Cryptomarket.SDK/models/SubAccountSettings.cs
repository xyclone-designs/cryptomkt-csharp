
namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// Subaccount settings
    /// </summary>
    public class SubAccountSettings
    {
        public string? SubAccountId { get; set; }
        public bool? DepositAddressGenerationEnabled { get; set; }
        public bool? WithdrawEnabled { get; set; }
        public string? Description { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }

        public override string ToString()
        {
            return string.Format(
                "ACLSetting [createdAt={0}, depositAddressGenerationEnabled={1}, description={2}, subAccountId={3}, updatedAt={4}, withdrawEnabled={5}]",
                CreatedAt, 
                DepositAddressGenerationEnabled, 
                Description, 
                SubAccountId, 
                UpdatedAt, 
                WithdrawEnabled);
        }
    }
}