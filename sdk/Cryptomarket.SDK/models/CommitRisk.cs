
namespace Cryptomarket.SDK.Models
{
    public class CommitRisk
    {
        // TODO: This whole class. WTF

        public int? Score { get; set; }
        public bool Rbf { get; set; }
        public bool LowFee { get; set; }

        public override string ToString()
        {
            return string.Format("CommitRisk [source={0}, rbg={0}, lowFee={0}]", Score/*Source ???*/, Rbf/* RBG ???*/, LowFee);
        }
    }
}