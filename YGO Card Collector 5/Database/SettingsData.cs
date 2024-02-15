//Joel Campos
//2/6/2024
//Settings Data Class

using System;
using System.Collections.Generic;
using System.IO;

namespace YGO_Card_Collector_5
{
    public static class SettingsData
    {
        private static bool _SetListSortingOldToNew = true;
        private static bool _DBUpdateTestMode = false;
        private static bool _AutomationHeadless = true;
        private static AppTheme _CurrentTheme = AppTheme.DarkMacigian;

        public static bool SetPackListSortingOLDToNEW { get { return _SetListSortingOldToNew; } }
        public static bool DBUpdateTestMode { get { return _DBUpdateTestMode; } }
        public static bool AutomationHeadless { get { return _AutomationHeadless; } }
        public static AppTheme CurrentTheme { get { return _CurrentTheme; } }

        public static void SwitchSetListSortingSetting(bool value)
        {
            _SetListSortingOldToNew = value;
            WriteSettingsDataFile();
        }
        public static void SwitchDBUpdateTestModeSetting(bool value)
        {
            _DBUpdateTestMode = value;
            WriteSettingsDataFile();
        }
        public static void SwitchHeadlessModeSetting(bool value)
        {
            _AutomationHeadless = value;
            WriteSettingsDataFile();
        }

        public static void InitializeSettings()
        {
            StreamReader SR_SaveFile = new StreamReader(
                Directory.GetCurrentDirectory() + "\\Settings\\Settings.txt");

            //Set Sorting
            string line = SR_SaveFile.ReadLine();
            int settingsCount = Convert.ToInt32(line);

            for (int i = 0; i < settingsCount; i++)
            {
                line = SR_SaveFile.ReadLine();
                string[] settingData = line.Split('|');
                string setting = settingData[0];

                switch (setting)
                {
                    case "SetSorting": _SetListSortingOldToNew = Convert.ToBoolean(settingData[1]); break;
                    case "TestMode": _DBUpdateTestMode = Convert.ToBoolean(settingData[1]); break;
                    case "HeadlessMode": _AutomationHeadless = Convert.ToBoolean(settingData[1]); break;
                    case "Theme": _CurrentTheme = (AppTheme)Convert.ToInt32(settingData[1]); break;
                }

            }

            SR_SaveFile?.Close();
        }
        public static void WriteSettingsDataFile()
        {
            List<string> outputdata = new List<string>();
            List<string> settings = new List<string>()
            {
                "SetSorting",
                "TestMode",
                "HeadlessMode",
                "Theme"
            };

            outputdata.Add(settings.Count.ToString());
            foreach (string setting in settings)
            {
                switch(setting) 
                {
                    case "SetSorting":
                        bool value = _SetListSortingOldToNew;
                        int intValue = Convert.ToInt32(value);
                        outputdata.Add(string.Format("{0}|{1}", setting, value)); break;

                    case "TestMode":
                        value = _DBUpdateTestMode;
                        intValue = Convert.ToInt32(value);
                        outputdata.Add(string.Format("{0}|{1}", setting, value)); break;

                    case "HeadlessMode":
                        value = _AutomationHeadless;
                        intValue = Convert.ToInt32(value);
                        outputdata.Add(string.Format("{0}|{1}", setting, value)); break;

                    case "Theme":
                        intValue = (int)_CurrentTheme;
                        outputdata.Add(string.Format("{0}|{1}", setting, intValue)); break;
                }                           
            }

            File.WriteAllLines(Directory.GetCurrentDirectory() + "\\Settings\\Settings.txt", outputdata);
        }
    }

    public enum AppTheme
    {
        DarkMacigian = 0
    }
}
