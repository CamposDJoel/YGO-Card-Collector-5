namespace YGO_Card_Collector_5
{
    partial class Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.btnLoadDB2019 = new System.Windows.Forms.Button();
            this.btnLoadDB = new System.Windows.Forms.Button();
            this.GroupDBSelection = new System.Windows.Forms.GroupBox();
            this.listYearSelection = new System.Windows.Forms.ListBox();
            this.radioYear = new System.Windows.Forms.RadioButton();
            this.radioFULL = new System.Windows.Forms.RadioButton();
            this.lblJsonStatus = new System.Windows.Forms.Label();
            this.picTittleBanner = new System.Windows.Forms.PictureBox();
            this.lblYearWarning = new System.Windows.Forms.Label();
            this.GroupDBSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTittleBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadDB2019
            // 
            this.btnLoadDB2019.BackColor = System.Drawing.Color.Indigo;
            this.btnLoadDB2019.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDB2019.ForeColor = System.Drawing.Color.White;
            this.btnLoadDB2019.Location = new System.Drawing.Point(604, 365);
            this.btnLoadDB2019.Name = "btnLoadDB2019";
            this.btnLoadDB2019.Size = new System.Drawing.Size(196, 93);
            this.btnLoadDB2019.TabIndex = 14;
            this.btnLoadDB2019.Text = "Load 2019 Data";
            this.btnLoadDB2019.UseVisualStyleBackColor = false;
            this.btnLoadDB2019.Click += new System.EventHandler(this.btnLoadDB2019_Click);
            // 
            // btnLoadDB
            // 
            this.btnLoadDB.BackColor = System.Drawing.Color.Indigo;
            this.btnLoadDB.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDB.ForeColor = System.Drawing.Color.White;
            this.btnLoadDB.Location = new System.Drawing.Point(36, 133);
            this.btnLoadDB.Name = "btnLoadDB";
            this.btnLoadDB.Size = new System.Drawing.Size(196, 93);
            this.btnLoadDB.TabIndex = 13;
            this.btnLoadDB.Text = "Load Data";
            this.btnLoadDB.UseVisualStyleBackColor = false;
            this.btnLoadDB.Click += new System.EventHandler(this.btnLoadDB_Click);
            // 
            // GroupDBSelection
            // 
            this.GroupDBSelection.BackColor = System.Drawing.Color.Transparent;
            this.GroupDBSelection.Controls.Add(this.lblYearWarning);
            this.GroupDBSelection.Controls.Add(this.listYearSelection);
            this.GroupDBSelection.Controls.Add(this.radioYear);
            this.GroupDBSelection.Controls.Add(this.radioFULL);
            this.GroupDBSelection.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupDBSelection.ForeColor = System.Drawing.Color.Yellow;
            this.GroupDBSelection.Location = new System.Drawing.Point(36, 227);
            this.GroupDBSelection.Name = "GroupDBSelection";
            this.GroupDBSelection.Size = new System.Drawing.Size(200, 188);
            this.GroupDBSelection.TabIndex = 15;
            this.GroupDBSelection.TabStop = false;
            this.GroupDBSelection.Text = "Select DB Mode";
            // 
            // listYearSelection
            // 
            this.listYearSelection.FormattingEnabled = true;
            this.listYearSelection.ItemHeight = 15;
            this.listYearSelection.Items.AddRange(new object[] {
            "2023",
            "2022",
            "2021",
            "2020",
            "2019",
            "2018",
            "2017",
            "2016",
            "2015",
            "2014",
            "2013",
            "2012",
            "2011",
            "2010",
            "2009",
            "2008",
            "2007",
            "2006",
            "2005",
            "2004",
            "2003",
            "2002"});
            this.listYearSelection.Location = new System.Drawing.Point(109, 46);
            this.listYearSelection.Name = "listYearSelection";
            this.listYearSelection.Size = new System.Drawing.Size(77, 94);
            this.listYearSelection.TabIndex = 2;
            this.listYearSelection.Visible = false;
            // 
            // radioYear
            // 
            this.radioYear.AutoSize = true;
            this.radioYear.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioYear.Location = new System.Drawing.Point(33, 43);
            this.radioYear.Name = "radioYear";
            this.radioYear.Size = new System.Drawing.Size(76, 26);
            this.radioYear.TabIndex = 1;
            this.radioYear.Text = "Year:";
            this.radioYear.UseVisualStyleBackColor = true;
            this.radioYear.CheckedChanged += new System.EventHandler(this.radioYear_CheckedChanged);
            // 
            // radioFULL
            // 
            this.radioFULL.AutoSize = true;
            this.radioFULL.Checked = true;
            this.radioFULL.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioFULL.Location = new System.Drawing.Point(33, 18);
            this.radioFULL.Name = "radioFULL";
            this.radioFULL.Size = new System.Drawing.Size(93, 26);
            this.radioFULL.TabIndex = 0;
            this.radioFULL.TabStop = true;
            this.radioFULL.Text = "Full DB";
            this.radioFULL.UseVisualStyleBackColor = true;
            this.radioFULL.CheckedChanged += new System.EventHandler(this.radioFULL_CheckedChanged);
            // 
            // lblJsonStatus
            // 
            this.lblJsonStatus.AutoSize = true;
            this.lblJsonStatus.BackColor = System.Drawing.Color.Black;
            this.lblJsonStatus.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJsonStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblJsonStatus.Location = new System.Drawing.Point(45, 418);
            this.lblJsonStatus.Name = "lblJsonStatus";
            this.lblJsonStatus.Size = new System.Drawing.Size(168, 38);
            this.lblJsonStatus.TabIndex = 16;
            this.lblJsonStatus.Text = "JSON Failed to load\r\nPlease review DB file.";
            this.lblJsonStatus.Visible = false;
            // 
            // picTittleBanner
            // 
            this.picTittleBanner.BackColor = System.Drawing.Color.Transparent;
            this.picTittleBanner.Image = ((System.Drawing.Image)(resources.GetObject("picTittleBanner.Image")));
            this.picTittleBanner.Location = new System.Drawing.Point(36, 3);
            this.picTittleBanner.Name = "picTittleBanner";
            this.picTittleBanner.Size = new System.Drawing.Size(406, 124);
            this.picTittleBanner.TabIndex = 17;
            this.picTittleBanner.TabStop = false;
            // 
            // lblYearWarning
            // 
            this.lblYearWarning.BackColor = System.Drawing.Color.Black;
            this.lblYearWarning.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblYearWarning.Location = new System.Drawing.Point(9, 143);
            this.lblYearWarning.Name = "lblYearWarning";
            this.lblYearWarning.Size = new System.Drawing.Size(177, 40);
            this.lblYearWarning.TabIndex = 18;
            this.lblYearWarning.Text = "Deck Builder and DB Updater/Manager unavailable while in Year DB Mode.";
            this.lblYearWarning.Visible = false;
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.picTittleBanner);
            this.Controls.Add(this.lblJsonStatus);
            this.Controls.Add(this.GroupDBSelection);
            this.Controls.Add(this.btnLoadDB2019);
            this.Controls.Add(this.btnLoadDB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher - YGO Card Collector 5";
            this.GroupDBSelection.ResumeLayout(false);
            this.GroupDBSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTittleBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadDB2019;
        private System.Windows.Forms.Button btnLoadDB;
        private System.Windows.Forms.GroupBox GroupDBSelection;
        private System.Windows.Forms.RadioButton radioYear;
        private System.Windows.Forms.RadioButton radioFULL;
        private System.Windows.Forms.ListBox listYearSelection;
        private System.Windows.Forms.Label lblJsonStatus;
        private System.Windows.Forms.PictureBox picTittleBanner;
        private System.Windows.Forms.Label lblYearWarning;
    }
}