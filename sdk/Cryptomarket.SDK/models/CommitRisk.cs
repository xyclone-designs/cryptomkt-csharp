
namespace CryptoMarket.SDK.Models
{
    public class CommitRisk
    {
        public int? Score { get; set; }
        public bool Rbf { get; set; }
        public bool LowFee { get; set; }

        public override string ToString()
        {
            return string.Format("CommitRisk [score={0}, rbf={0}, lowFee={0}]", Score, Rbf, LowFee);
        }
    }
}