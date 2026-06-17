
namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// User Balance
    /// </summary>
    public class Balance
    {
        public string? Currency { get; set; }
        public string? Available { get; set; }
        public string? Reserved { get; set; }

        public override string ToString()
        {
            return string.Format("Balance [currency={0}, available={1}, reserved={2}]", Currency, Available, Reserved);
        }
    }
}