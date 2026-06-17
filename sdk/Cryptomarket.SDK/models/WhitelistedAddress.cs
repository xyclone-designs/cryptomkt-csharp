
namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// Whitelisted address
    /// </summary>
    public class WhitelistedAddress
    {
        /// <summary>
        /// Name of the whitelist item
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Currency code
        /// </summary>
        public string? Currency { get; set; }
        /// <summary>
        /// Code of the currency of the hosting network
        /// </summary>
        public string? Network { get; set; }
        /// <summary>
        /// Address for deposits
        /// </summary>
        public string? Address { get; set; }

        public override string ToString()
        {
            return string.Format(
                "WhitelistedAddress [name={0}, currency={1}, network={2}, address={3}]",
                Name,
                Currency,
                Network,
                Address);
        }
    }
}