
namespace CryptoMarket.Tests.SDK
{
    public class SequenceFlow
    {
        private static int sequence = 0;
        public static bool CheckNextSequence(int sequence)
        {
            bool goodFlow = true;
            if (sequence != 0 && SequenceFlow.sequence > sequence)
                goodFlow = false;
            SequenceFlow.sequence = sequence;
            return goodFlow;
        }
    }
}