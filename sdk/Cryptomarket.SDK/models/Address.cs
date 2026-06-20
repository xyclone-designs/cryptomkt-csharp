
namespace CryptoMarket.SDK.Models
{
    /// <summary>
    /// Wallet address
    /// </summary>
    public class Address
    {
        /// <summary>
        /// currency of the address
        /// </summary>
        public string? Currency { get; set; }
        /// <summary>
        /// the address
        /// </summary>
        public string? Address_ { get; set; }
        /// <summary>
        /// aditional identifier required for some currencies
        /// </summary>
        public string? PaymentId { get; set; }
        /// <summary>
        /// aditional identifier required for some currencies
        /// </summary>
        public string? PublicKey { get; set; }
        /// <summary>
        /// network code
        /// </summary>
        public string? NetworkCode { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Address [currency={0}, address={1}, paymentId={2}, publicKey={3}, networkCode={4}]",
                Currency,
                Address_, 
                PaymentId, 
                PublicKey, 
                NetworkCode);
        }
    }
}