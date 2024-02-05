//Joel Campos
//1/29/2024
//DBUpdateHoldScreen Class

using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class DBUpdateHoldScren : Form
    {
        public DBUpdateHoldScren(DatabaseManager managerForm)
        {
            InitializeComponent();
            _managerForm = managerForm;
            barProgress.Maximum = 10000;
            lblOutput.Text = "Starting automation script...";
            lblJob.Visible = true;
        }

        public void SetTotalCardsToScan(int amount)
        {
            barProgress.Maximum = amount;
        }
        public void SetOutputMessage(string message)
        {
            lblOutput.Text = message; 
        }
        public void SendCardStartSignal(string cardname)
        {
            _cardIterator++;
            barProgress.Value = _cardIterator;
            lblOutput.Text = string.Format("Updating Card: {0}/{1}", barProgress.Value, barProgress.Maximum);
            lblCardName.Text = cardname;
        }
        public void SendJobStartSignal(string jobname) 
        {
            lblJob.Visible = true;
            lblJob.Text = jobname;
        }
        public void SendJobFinishSignal()
        {
            _cardIterator = 0;
            barProgress.Value = 0;
            barProgress.Maximum = 10000;
        }
        public void SendFullCompletionSignal()
        {
            StringBuilder sb = new StringBuilder();

            List<string> Logs = Driver.GetUpdateLogs();
            foreach (string line in Logs)  
            {
                sb.AppendLine(line);
            }

            if(Logs.Count > 1500)
            {
                lblLogs.Text = "Log trace is too large.\nReview the output file at \\Output Files\\FullLOG.txt and UpdateLogs.txt";
            }
            else
            {
                lblLogs.Text = sb.ToString();
            }
         
            btnFinish.Visible = true;
            lblWarning.Visible = false;
            //show logs
            lblPleaseWait.Visible = false;
            lblOutput.Visible = false;
            barProgress.Visible = false;
            barProgress.Value = 0;
            _cardIterator = 0;
            PanelLogs.Visible = true;
            lblResults.Visible = true;
        }

        private DatabaseManager _managerForm;
        private int _cardIterator = 0;

        private void btnFinish_Click(object sender, System.EventArgs e)
        {
            //Return to the DB Manager
            _managerForm.Show();
            Dispose();            
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}