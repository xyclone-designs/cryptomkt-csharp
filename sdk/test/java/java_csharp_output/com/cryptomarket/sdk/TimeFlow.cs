using Java.Text;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Com.Cryptomarket.Sdk
{
    public class TimeFlow
    {
        private static Calendar datetime = Calendar.GetInstance();
        private static SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSS");
        public static void Reset()
        {
            TimeFlow.datetime.Set(2020, 12, 12, 12, 12, 12);
        }

        public static bool CheckNextTimestamp(string isoDatetime)
        {
            bool goodFlow = true;
            Calendar datetime = Calendar.GetInstance();
            try
            {
                datetime.SetTime(TimeFlow.sdf.Parse(isoDatetime));
            }
            catch (ParseException e)
            {
                e.PrintStackTrace();
            }

            if (TimeFlow.datetime.After(datetime))
                goodFlow = false;
            TimeFlow.datetime = datetime;
            return goodFlow;
        }
    }
}