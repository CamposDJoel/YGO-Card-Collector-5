//Joel Campos
//2/6/2024
//Settings Data Class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGO_Card_Collector_5
{
    public static  class SettingsData
    {
        private static bool _SetListSortingOldToNew = true;
        private static bool _DBUpdateTestMode = true;
        private static bool _AutomationHeadless = true;

        public static bool SetPackListSortingOLDToNEW { get { return _SetListSortingOldToNew; } }
        public static bool DBUpdateTestMode { get { return _DBUpdateTestMode; } }
        public static bool AutomationHeadless { get { return _AutomationHeadless; } }

        public static void SwitchSetListSortingSetting(bool value)
        {
            _SetListSortingOldToNew = value;
        }
        public static void SwitchDBUpdateTestModeSetting(bool value)
        {
            _DBUpdateTestMode = value;
        }
        public static void SwitchHeadlessModeSetting(bool value)
        {
            _AutomationHeadless = value;
        }
    }
}
