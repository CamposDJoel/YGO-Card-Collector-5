//Joel Campos
//6/20/2024
//DeckImportHelp Form

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class DeckImportHelp : Form
    {
        public DeckImportHelp(DeckSelectorForm deckselectorform)
        {
            DecksSelectorForm = deckselectorform;
            InitializeComponent();
            panellist.Add(PanelPage1);
            panellist.Add(PanelPage2);
            panellist.Add(PanelPage3);
            panellist.Add(PanelPage4);
            panellist.Add(PanelPage5);

            lblPageCounter.Text = string.Format("{0}/{1}", _CurrentPage, panellist.Count);
        }

        private List<Panel> panellist = new List<Panel>();
        private int _CurrentPage = 1;
        private Object DecksSelectorForm;

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            panellist[_CurrentPage - 1].Visible = false;
            if (_CurrentPage == panellist.Count)
            {
                _CurrentPage = 1;
            }
            else
            {
                _CurrentPage++;
            }
            panellist[_CurrentPage - 1].Visible = true;
            lblPageCounter.Text = string.Format("{0}/{1}", _CurrentPage, panellist.Count);
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            panellist[_CurrentPage - 1].Visible = false;
            if (_CurrentPage == 1)
            {
                _CurrentPage = panellist.Count;
            }
            else
            {
                _CurrentPage--;
            }
            panellist[_CurrentPage - 1].Visible = true;
            lblPageCounter.Text = string.Format("{0}/{1}", _CurrentPage, panellist.Count);
        }

        private void btnBackToCollector_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click2);
            Dispose();
            Form CollectorsForm = (Form)DecksSelectorForm;
            CollectorsForm.Show();
        }
    }
}
