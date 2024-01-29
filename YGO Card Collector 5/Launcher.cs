//Joel Campos
//1/27/2024
//Launcher Form Class

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class FormLauncher : Form
    {
        public FormLauncher()
        {
            InitializeComponent();

            lblLaunchAppOption.MouseEnter += OnMouseEnterLabel;
            lblLaunchAppOption.MouseLeave += OnMouseLeaveLabel;

            lblSettingsOption.MouseEnter += OnMouseEnterLabel;
            lblSettingsOption.MouseLeave += OnMouseLeaveLabel;

            lblDatabaseOption.MouseEnter += OnMouseEnterLabel;
            lblDatabaseOption.MouseLeave += OnMouseLeaveLabel;
        }

        private void LoadDB()
        {
            string jsonFilePath = Directory.GetCurrentDirectory() + "\\Database\\CardDB.json";
            string rawdata = File.ReadAllText(jsonFilePath);
            lblProgress.Visible = true;
            BarProgress.Visible = true;
            PanelOutput.Visible = true;

            //Hide the menu options
            lblLaunchAppOption.Visible = false;
            lblSettingsOption.Visible = false;
            lblDatabaseOption.Visible = false;

            Tools.WaitNSeconds(1000);

            //Attempt to deserialize the JSON. If it fail simply show error.
            try
            {
                Database.MasterCards = JsonConvert.DeserializeObject<List<MasterCard>>(rawdata);
                lblJsonStatus.Text = "JSON DB Deserialization Successful!";
            }
            catch (Exception)
            {
                //Show the menu options again
                lblLaunchAppOption.Visible = true;
                lblSettingsOption.Visible = true;
                lblDatabaseOption.Visible = true;

                BarProgress.Visible = false;
                lblJsonStatus.Text = "JSON DB Deserialization Failed! - Fix JSON!";
                return;
            }

            //Continue to sorting the master card list
            int counter = 1;
            BarProgress.Maximum = Database.MasterCards.Count;
            foreach (MasterCard ThisMasterCard in Database.MasterCards)
            {
                //Message
                lblCardSorting.Text = string.Format("Sorting Card: {0}/{1}", counter, Database.MasterCards.Count);

                //Step 1: Add this card to the dictionary for quick search by name
                Database.MasterCardByName.Add(ThisMasterCard.Name, ThisMasterCard);

                //Step 2: Add this Master Card into its corresponding Card Group
                Database.AddCardIntoCardGroup(ThisMasterCard);

                //Step 3: Sort each MasterCard's SetCards into its respective sets
                foreach (SetCard thisSetCard in ThisMasterCard.SetCards)
                {                   
                    //if this setCard in has no CODE, dont do shit with it
                    if (thisSetCard.Code == "")
                    {
                        //JUST IGNORE IT!
                    }
                    else
                    {
                        //Set a "Key" for this set card
                        string setCardKey = thisSetCard.Code + "|" + thisSetCard.Rarity + "|" + thisSetCard.Name;

                        //Konami has duplicate card sets in the DB (suckers!), to handle this, ignore any card with
                        //an already existing key in the DB
                        if (Database.SetCardByKey.ContainsKey(setCardKey))
                        {
                            //Ignore this set card
                        }
                        else
                        {
                            //Actually sort this set card

                            //Add this card to the DB Set list and dictionary
                            Database.SetCards.Add(thisSetCard);
                            Database.SetCardByKey.Add(setCardKey, thisSetCard);

                            //Save the SetCode to the MasterCardByCode to quick searces of Master Cards by a Set Code
                            if (!Database.MasterCardByCode.ContainsKey(thisSetCard.Code))
                            {
                                Database.MasterCardByCode.Add(thisSetCard.Code, ThisMasterCard);
                            }

                            //Extract the Pack Name and check if it exists in the DB
                            string SetPackName = thisSetCard.Name;

                            if (!Database.SetPackByName.ContainsKey(SetPackName))
                            {
                                //Create the set pack
                                SetPack NewPack = new SetPack(thisSetCard.Name, thisSetCard.Code, thisSetCard.ReleaseDate);
                                Database.SetPacks.Add(NewPack);
                                Database.SetPackByName.Add(SetPackName, NewPack);
                            }

                            //Now you can add the SetCard to the SetPack
                            SetPack SetToAddTo = Database.SetPackByName[SetPackName];
                            SetToAddTo.AddCard(thisSetCard);
                        }                                            
                    }                   
                }

                //Last Step: Update progress bar
                BarProgress.Value = counter;
                counter++;
            }
        }

        private void OnMouseEnterLabel(object sender, EventArgs e)
        {
            //SoundServer.PlaySoundEffect(SoundEffect.Hover);
            Label thisLabel = (Label)sender;
            thisLabel.BorderStyle = BorderStyle.FixedSingle;
        }
        private void OnMouseLeaveLabel(object sender, EventArgs e)
        {
            Label thisLabel = (Label)sender;
            thisLabel.BorderStyle = BorderStyle.None;
        }

        private void lblLaunchAppOption_Click(object sender, EventArgs e)
        {
            LoadDB();

            //Open Collection tracker
        }

        private void lblDatabaseOption_Click(object sender, EventArgs e)
        {
            LoadDB();

            //Open Database Manager
            Hide();
            DatabaseManager DM = new DatabaseManager();
            DM.Show();
        }
    }
}
