using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Com.Cryptomarket.Sdk
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