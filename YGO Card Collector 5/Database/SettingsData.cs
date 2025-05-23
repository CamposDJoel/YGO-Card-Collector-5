﻿//Joel Campos
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
        private static bool _MusicOn = true;
        private static bool _SXFOn = true;
        private static AppTheme _CurrentTheme = AppTheme.DarkMagician;
        private static string _TagStarName = "Star";
        private static string _TagSquareName = "Square";
        private static string _TagTriangleName = "Triangle";
        private static string _TagCircleName = "Circle";
        private static bool _FullDBMode = false;

        public static bool SetPackListSortingOLDToNEW { get { return _SetListSortingOldToNew; } }
        public static bool DBUpdateTestMode { get { return _DBUpdateTestMode; } }
        public static bool AutomationHeadless { get { return _AutomationHeadless; } }
        public static bool MusicOn { get { return _MusicOn; } }
        public static bool SFXOn { get { return _SXFOn; } }
        public static AppTheme CurrentTheme { get { return _CurrentTheme; } }
        public static string StarTagName { get { return _TagStarName; } }
        public static string SquareTagName { get { return _TagSquareName; } }
        public static string TriangleTagName { get { return _TagTriangleName; } }
        public static string CircleTagName { get { return _TagCircleName; } }
        public static bool FULLDBMode { get { return _FullDBMode; } set { _FullDBMode = value; } }

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
        public static void SwitchCurrentThemeSetting(int value)
        {
            _CurrentTheme = (AppTheme)value;
            WriteSettingsDataFile();
        }
        public static void SwitchMusicSetting(bool value)
        {
            _MusicOn = value;
            WriteSettingsDataFile();
        }
        public static void SwitchSFXSetting(bool value)
        {
            _SXFOn = value;
            WriteSettingsDataFile();
        }
        public static void ChangeTagName(TagIcon thisTag, string newName)
        {
            switch(thisTag)
            {
                case TagIcon.Star: _TagStarName = newName; break;
                case TagIcon.Square: _TagSquareName = newName; break;
                case TagIcon.Triangle: _TagTriangleName = newName; break;
                case TagIcon.Circle: _TagCircleName = newName; break;
            }
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
                    case "Music": _MusicOn = Convert.ToBoolean(settingData[1]); break;
                    case "SFX": _SXFOn = Convert.ToBoolean(settingData[1]); break;
                    case "TagStarName": _TagStarName = settingData[1]; break;
                    case "TagSquareName": _TagSquareName = settingData[1]; break;
                    case "TagTriangleName": _TagTriangleName = settingData[1]; break;
                    case "TagCircleName": _TagCircleName = settingData[1]; break;
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
                "Theme",
                "Music",
                "SFX",
                "TagStarName",
                "TagSquareName",
                "TagTriangleName",
                "TagCircleName"
            };

            outputdata.Add(settings.Count.ToString());
            foreach (string setting in settings)
            {
                switch(setting) 
                {
                    case "SetSorting":
                        bool value = _SetListSortingOldToNew;
                        outputdata.Add(string.Format("{0}|{1}", setting, value)); break;

                    case "TestMode":
                        value = _DBUpdateTestMode;
                        outputdata.Add(string.Format("{0}|{1}", setting, value)); break;

                    case "HeadlessMode":
                        value = _AutomationHeadless;
                        outputdata.Add(string.Format("{0}|{1}", setting, value)); break;

                    case "Theme":
                        int intValue = (int)_CurrentTheme;
                        outputdata.Add(string.Format("{0}|{1}", setting, intValue)); break;

                    case "Music":
                        value = _MusicOn;
                        outputdata.Add(string.Format("{0}|{1}", setting, value)); break;

                    case "SFX":
                        value = _SXFOn;
                        outputdata.Add(string.Format("{0}|{1}", setting, value)); break;

                    case "TagStarName":
                        string strvalue = _TagStarName;
                        outputdata.Add(string.Format("{0}|{1}", setting, strvalue)); break;

                    case "TagSquareName":
                        strvalue = _TagSquareName;
                        outputdata.Add(string.Format("{0}|{1}", setting, strvalue)); break;

                    case "TagTriangleName":
                        strvalue = _TagTriangleName;
                        outputdata.Add(string.Format("{0}|{1}", setting, strvalue)); break;

                    case "TagCircleName":
                        strvalue = _TagCircleName;
                        outputdata.Add(string.Format("{0}|{1}", setting, strvalue)); break;
                }                           
            }

            File.WriteAllLines(Directory.GetCurrentDirectory() + "\\Settings\\Settings.txt", outputdata);
        }
    }

    public enum AppTheme
    {
        DarkMagician = 0,
        DarkMagicianGirl,
        Traptrix,
        BlueEyesUltimate,
        BlackLusterSoldier,
        YugiSlifer,
        Slifer
    }
}
