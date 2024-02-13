//Joel Campos
//1/27/2024
//Tools Class

using OpenQA.Selenium.DevTools.V119.DOM;
using System;
using System.Drawing;
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
        public static void LaunchURLIntoBrowser(string url)
        {
            System.Diagnostics.Process.Start(url);
        }
        public static Color GetPriceColorForLabel(double amount)
        {
            if (amount == 0)
            {
                return Color.Red;
            }
            else if (amount < 1)
            {
                return Color.White;
            }
            else if (amount < 5)
            {
                return Color.LightGreen;
            }
            else if (amount < 50)
            {
                return Color.HotPink;
            }
            else
            {
                return Color.Gold;
            }
        }
        public static Color GetRarityColorForLabel(string rarity)
        {
            switch (rarity)
            {
                case "Common":                           return Color.White;
                case "Rare":                             return Color.PaleGreen;
                case "Ultra Rare":                       return Color.Moccasin;
                case "Ultra Rare(Hobby League Version)": return Color.Moccasin;
                case "Ultimate Rare":                    return Color.HotPink;
                case "Gold Rare":                        return Color.Gold;
                case "Hobby":                            return Color.MediumPurple;
                case "Millennium Secret Rare":           return Color.Goldenrod;
                case "Platinum Secret Rare":             return Color.LightSkyBlue;
                case "Starfoil":                         return Color.BlueViolet;
                case "Shattefoil":                       return Color.MediumTurquoise;
                case "Super Rare":                       return Color.SteelBlue;
                case "Secret Rare":                      return Color.Pink;
                case "Ghost Rare":                       return Color.PowderBlue;
                case "Premium Gold Rare":                return Color.DarkGoldenrod;
                case "Gold Secret":                      return Color.Yellow;
                case "Platinum Rare":                    return Color.Aqua;
                case "COLLECTOR'S RARE":                 return Color.RosyBrown;
                case "Mosaic Rare":                      return Color.DarkViolet;
                case "Quarter Century Secret Rare":      return Color.Plum;
                case "Prismatic Secret Rare":            return Color.Plum;
                case "Ultra Rare (Pharaoh's Rare)":      return Color.DarkRed;
                default: return Color.Red;
            }
        }
    }
}
