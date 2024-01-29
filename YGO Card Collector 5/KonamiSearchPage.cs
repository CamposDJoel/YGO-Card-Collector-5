using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YGO_Card_Collector_5
{
    public static class KonamiSearchPage
    {
        //Common element IDs
        public static string Xpath_GroupBanner = "//div[@id=\"ctype_set\"]";
        public static string Xpath_CookiesAcceptButton = "//button[@id=\"onetrust-accept-btn-handler\"]";

        public static string Xpath_SearchButton = "//div[@id=\"submit_area\"]//span[.='Search']";
        public static string Xpath_MonsterGroup = "//li/span[.='Monster Cards']";
        public static string Xpath_SpellGroup = "//li/span[.='Spell Cards']";
        public static string Xpath_TrapGroup = "//li/span[.='Trap Cards']";


        public static string Xpath_WarriorTypeButton = "//li[@class=\"species_4_en\"]//span";
        public static string Xpath_BeastTypeButton = "//li[@class=\"species_6_en\"]//span";

        public static void WaitUntilPageIsLoaded()
        {
            Element.WaitUntilElementIsVisble(Xpath_SearchButton);
            Element.WaitUntilElementIsVisble(Xpath_GroupBanner);
        }
        public static void AcceptCookiesBanner()
        {
            //Try to accept cockies
            try
            {
                Element.ClickByXpath(Xpath_CookiesAcceptButton);
            }
            catch (Exception)
            {
                Console.WriteLine("No Cookies Banner was displayed. It wasnt clear out.");
            }
        }
        public static void SearchCardGroup(CardGroup group)
        {
            //Convert the group enum to its string counterpart
            string groupString = CardGroupToString(group);

            string basexpath = "";
            //Click the Designated Monster/Spell/Trap submenu
            if (group == CardGroup.Normal_Traps || group == CardGroup.Continuous_Traps || group == CardGroup.Counter_Traps)
            {
                Element.ClickByXpath(Xpath_TrapGroup);
                basexpath = "//ul[@class=\"fliter_btns filter_effect_trap\"]";
            }
            else if (group == CardGroup.Normal_Spells || group == CardGroup.Continuous_Spells || group == CardGroup.QuickPlay_Spells ||
                group == CardGroup.Equip_Spells || group == CardGroup.Field_Spells || group == CardGroup.Ritual_Spells)
            {
                Element.ClickByXpath(Xpath_SpellGroup);
                basexpath = "//ul[@class=\"fliter_btns filter_effect_magic\"]";
            }
            else
            {
                Element.ClickByXpath(Xpath_MonsterGroup);
            }

            //Click the respective group
            if (group == CardGroup.Beast_Monsters) { Element.ClickByXpath(Xpath_BeastTypeButton); }
            else if (group == CardGroup.Warrior_Monsters) { Element.ClickByXpath(Xpath_WarriorTypeButton); }
            else
            {
                Element.ClickByXpath(basexpath + "//span[contains(text(), \"" + groupString + "\")]");
            }

            //Click Search
            Element.ClickByXpath(Xpath_SearchButton);

            //Call the CardListPage to wait until that page is loaded
            KonamiCardListPage.WaitUntilPageIsLoaded();

            //Change the view to 100 cards per page as a list
            KonamiCardListPage.Set100ItemsPerPageView();

            //Local Funtion to get the group name used in the search
            string CardGroupToString(CardGroup cardGroup)
            {
                switch (cardGroup)
                {
                    case CardGroup.Aqua_Monsters: return "Aqua";
                    case CardGroup.Beast_Monsters: return "Beast";
                    case CardGroup.BeastWarrior_Monsters: return "Beast-Warrior";
                    case CardGroup.Cyberse_Monsters: return "Cyberse";
                    case CardGroup.Dinosaur_Monsters: return "Dinosaur";
                    case CardGroup.DivineBeast_Monsters: return "Divine-Beast";
                    case CardGroup.Dragon_Monsters: return "Dragon";
                    case CardGroup.Fairy_Monsters: return "Fairy";
                    case CardGroup.Fiend_Monsters: return "Fiend";
                    case CardGroup.Fish_Monsters: return "Fish";
                    case CardGroup.IllusionType_Monsters: return "Illusion Type";
                    case CardGroup.Insect_Monsters: return "Insect";
                    case CardGroup.Machine_Monsters: return "Machine";
                    case CardGroup.Plant_Monsters: return "Plant";
                    case CardGroup.Psychic_Monsters: return "Psychic";
                    case CardGroup.Pyro_Monsters: return "Pyro";
                    case CardGroup.Reptile_Monsters: return "Reptile";
                    case CardGroup.Rock_Monsters: return "Rock";
                    case CardGroup.SeaSerpent_Monsters: return "Sea Serpent";
                    case CardGroup.Spellcaster_Monsters: return "Spellcaster";
                    case CardGroup.Thunder_Monsters: return "Thunder";
                    case CardGroup.Warrior_Monsters: return "Warrior";
                    case CardGroup.WingedBeast_Monsters: return "Winged Beast";
                    case CardGroup.Wyrm_Monsters: return "Wyrm";
                    case CardGroup.Zombie_Monsters: return "Zombie";

                    case CardGroup.Normal_Spells: return "Normal";
                    case CardGroup.Continuous_Spells: return "Continuous";
                    case CardGroup.QuickPlay_Spells: return "Quick-Play";
                    case CardGroup.Equip_Spells: return "Equip";
                    case CardGroup.Field_Spells: return "Field";
                    case CardGroup.Ritual_Spells: return "Ritual";

                    case CardGroup.Normal_Traps: return "Normal";
                    case CardGroup.Continuous_Traps: return "Continuous";
                    case CardGroup.Counter_Traps: return "Counter";
                    default: return "NONE";
                }
            }
        }
    }
}
