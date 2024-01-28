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
    }
}
