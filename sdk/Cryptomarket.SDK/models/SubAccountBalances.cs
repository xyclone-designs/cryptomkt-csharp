
namespace Cryptomarket.SDK.Models
{
    public class SubAccountBalances
    {
        public IList<Balance>? WalletBalances { get; set; }
        public IList<Balance>? SpotBalances { get; set; }

        public override string ToString()
        {
            return string.Format(
                "SubAccountBalances [SpotBalances={0}, WalletBalances={1}]", 
                SpotBalances is null ? null : '[' + string.Join(", ", SpotBalances) + ']',
                WalletBalances is null ? null : '[' + string.Join(", ", WalletBalances) + ']');
        }
    }
}