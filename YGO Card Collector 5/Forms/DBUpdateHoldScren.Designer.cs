namespace YGO_Card_Collector_5
{
    partial class DBUpdateHoldScren
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBUpdateHoldScren));
            this.barProgress = new System.Windows.Forms.ProgressBar();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblPleaseWait = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.PanelLogs = new System.Windows.Forms.Panel();
            this.lblLogs = new System.Windows.Forms.Label();
            this.lblResults = new System.Windows.Forms.Label();
            this.lblJob = new System.Windows.Forms.Label();
            this.lblCardName = new System.Windows.Forms.Label();
            this.PanelLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // barProgress
            // 
            this.barProgress.Location = new System.Drawing.Point(23, 55);
            this.barProgress.Name = "barProgress";
            this.barProgress.Size = new System.Drawing.Size(339, 27);
            this.barProgress.TabIndex = 0;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.BackColor = System.Drawing.Color.Transparent;
            this.lblOutput.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.ForeColor = System.Drawing.Color.Yellow;
            this.lblOutput.Location = new System.Drawing.Point(24, 85);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(180, 17);
            this.lblOutput.TabIndex = 1;
            this.lblOutput.Text = "Updating Card: 1/12000";
            // 
            // lblPleaseWait
            // 
            this.lblPleaseWait.AutoSize = true;
            this.lblPleaseWait.BackColor = System.Drawing.Color.Transparent;
            this.lblPleaseWait.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPleaseWait.ForeColor = System.Drawing.Color.Yellow;
            this.lblPleaseWait.Location = new System.Drawing.Point(24, 121);
            this.lblPleaseWait.Name = "lblPleaseWait";
            this.lblPleaseWait.Size = new System.Drawing.Size(106, 17);
            this.lblPleaseWait.TabIndex = 2;
            this.lblPleaseWait.Text = "Please wait...";
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.BackColor = System.Drawing.Color.Transparent;
            this.lblWarning.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(24, 173);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(280, 17);
            this.lblWarning.TabIndex = 3;
            this.lblWarning.Text = "*Do not disturb the Chrome window...\r\n";
            this.lblWarning.Visible = false;
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFinish.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(86, 125);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(204, 44);
            this.btnFinish.TabIndex = 4;
            this.btnFinish.Text = "Update Complete, return to DB Manager";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Visible = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // PanelLogs
            // 
            this.PanelLogs.AutoScroll = true;
            this.PanelLogs.BackColor = System.Drawing.Color.Black;
            this.PanelLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelLogs.Controls.Add(this.lblLogs);
            this.PanelLogs.Location = new System.Drawing.Point(8, 22);
            this.PanelLogs.Name = "PanelLogs";
            this.PanelLogs.Size = new System.Drawing.Size(366, 100);
            this.PanelLogs.TabIndex = 5;
            this.PanelLogs.Visible = false;
            // 
            // lblLogs
            // 
            this.lblLogs.AutoSize = true;
            this.lblLogs.ForeColor = System.Drawing.Color.Gold;
            this.lblLogs.Location = new System.Drawing.Point(8, 8);
            this.lblLogs.Name = "lblLogs";
            this.lblLogs.Size = new System.Drawing.Size(0, 13);
            this.lblLogs.TabIndex = 2;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.BackColor = System.Drawing.Color.Transparent;
            this.lblResults.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.ForeColor = System.Drawing.Color.Gold;
            this.lblResults.Location = new System.Drawing.Point(21, 5);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(59, 15);
            this.lblResults.TabIndex = 6;
            this.lblResults.Text = "Results:";
            this.lblResults.Visible = false;
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.BackColor = System.Drawing.Color.Transparent;
            this.lblJob.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJob.ForeColor = System.Drawing.Color.Yellow;
            this.lblJob.Location = new System.Drawing.Point(23, 31);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(264, 17);
            this.lblJob.TabIndex = 7;
            this.lblJob.Text = "Job 1/3: Updating Konami Card List";
            this.lblJob.Visible = false;
            // 
            // lblCardName
            // 
            this.lblCardName.AutoSize = true;
            this.lblCardName.BackColor = System.Drawing.Color.Transparent;
            this.lblCardName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardName.ForeColor = System.Drawing.Color.Yellow;
            this.lblCardName.Location = new System.Drawing.Point(24, 103);
            this.lblCardName.Name = "lblCardName";
            this.lblCardName.Size = new System.Drawing.Size(95, 17);
            this.lblCardName.TabIndex = 8;
            this.lblCardName.Text = "No Card Yet";
            // 
            // DBUpdateHoldScren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(383, 210);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.PanelLogs);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.lblPleaseWait);
            this.Controls.Add(this.barProgress);
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.lblCardName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DBUpdateHoldScren";
            this.Text = "DB Update Script Running...";
            this.PanelLogs.ResumeLayout(false);
            this.PanelLogs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar barProgress;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblPleaseWait;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Panel PanelLogs;
        private System.Windows.Forms.Label lblLogs;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.Label lblCardName;
    }
}