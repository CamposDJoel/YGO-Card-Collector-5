//Joel Campos
//3/12/2024
//CollectorsHelp Class

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class CollectorsHelp : Form
    {
        public CollectorsHelp(Object collertorform)
        {
            CollectorForm = collertorform;
            InitializeComponent();
            panellist.Add(PanelPage1);
            panellist.Add(PanelPage2);
            panellist.Add(PanelPage3);
            panellist.Add(PanelPage4);
            panellist.Add(PanelPage5);
            panellist.Add(PanelPage6);
            panellist.Add(PanelPage7);
            panellist.Add(PanelPage8);
            panellist.Add(PanelPage9);

            lblPageCounter.Text = string.Format("{0}/{1}", _CurrentPage, panellist.Count);
        }

        private List<Panel> panellist = new List<Panel>();
        private int _CurrentPage = 1;
        private Object CollectorForm;

        #region Other Event Listeners
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            panellist[_CurrentPage -1 ].Visible = false;
            if(_CurrentPage == panellist.Count) 
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
            Form CollectorsForm = (Form)CollectorForm;
            CollectorsForm.Show();
        }
    }
}
