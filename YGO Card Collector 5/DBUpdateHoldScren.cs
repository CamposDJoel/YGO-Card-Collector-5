//Joel Campos
//1/29/2024
//DBUpdateHoldScreen Class

using System.Text;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class DBUpdateHoldScren : Form
    {
        public DBUpdateHoldScren(DatabaseManager managerForm, int cardlistAmount)
        {
            InitializeComponent();
            _managerForm = managerForm;
            _cardlistAmount = cardlistAmount;
            barProgress.Maximum = _cardlistAmount;
            lblOutput.Text = "Starting automation script...";
        }

        public void SetOutputMessage(string message)
        {
            lblOutput.Text = message; 
        }
        public void SendCardStartSignal()
        {
            _cardIterator++;
            barProgress.Value = _cardIterator;
            lblOutput.Text = string.Format("Updating Card: {0}/{1}", barProgress.Value, _cardlistAmount);
        }
        public void SendFullCompletionSignal()
        {
            StringBuilder sb = new StringBuilder();
            foreach(string line in Driver.Log)
            {
                sb.AppendLine(line);
            }

            if(Driver.Log.Count > 1500)
            {
                lblLogs.Text = "Log trace is too large.\nReview the output file at \\Output Files\\LOG.txt";
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
            PanelLogs.Visible = true;
            lblResults.Visible = true;
        }

        private DatabaseManager _managerForm;
        private int _cardIterator = 0;
        private int _cardlistAmount = 0;

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