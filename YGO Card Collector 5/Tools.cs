//Joel Campos
//1/27/2024
//Tools Class

using System;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public static class Tools
    {
        public static void WaitNSeconds(double milliseconds)
        {
            if (milliseconds < 1) return;
            DateTime _desired = DateTime.Now.AddMilliseconds(milliseconds);
            while (DateTime.Now < _desired)
            {
                Application.DoEvents();
            }
        }

        public static bool CompareInLowerCase(string s1, string s2) 
        {
            string a = s1.ToLower();
            string B = s2.ToLower();
            return a.Equals(B);
        }

        public static double CovertPriceToDouble(string price)
        {
            price = price.Replace("$", "");
            return Convert.ToDouble(price);
        }

        public static string FormatTimeElapsed(string time)
        {
            //sample input: "00:05:41.2025073"
            string withoutMillisecond = time.Split('.')[0];
            string[] tokens = withoutMillisecond.Split(':');
            return tokens[0] + " hrs. " + tokens[1] + "mns. " + tokens[2] + "secs.";
        }
    }
}
