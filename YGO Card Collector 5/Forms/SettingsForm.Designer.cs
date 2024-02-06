namespace YGO_Card_Collector_5
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.lblTotalAqua = new System.Windows.Forms.Label();
            this.GroupTestMode = new System.Windows.Forms.GroupBox();
            this.RadioTestModeON = new System.Windows.Forms.RadioButton();
            this.RadioTestModeOFF = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadioHeadlessOFF = new System.Windows.Forms.RadioButton();
            this.RadioHeadlessON = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RadioPackSortingNEW = new System.Windows.Forms.RadioButton();
            this.RadioPackSortingOLD = new System.Windows.Forms.RadioButton();
            this.btnBackToMainMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupTestMode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotalAqua
            // 
            this.lblTotalAqua.AutoSize = true;
            this.lblTotalAqua.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAqua.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAqua.ForeColor = System.Drawing.Color.White;
            this.lblTotalAqua.Location = new System.Drawing.Point(343, 9);
            this.lblTotalAqua.Name = "lblTotalAqua";
            this.lblTotalAqua.Size = new System.Drawing.Size(93, 24);
            this.lblTotalAqua.TabIndex = 1;
            this.lblTotalAqua.Text = "Settings";
            // 
            // GroupTestMode
            // 
            this.GroupTestMode.BackColor = System.Drawing.Color.Transparent;
            this.GroupTestMode.Controls.Add(this.RadioTestModeOFF);
            this.GroupTestMode.Controls.Add(this.RadioTestModeON);
            this.GroupTestMode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupTestMode.ForeColor = System.Drawing.Color.Yellow;
            this.GroupTestMode.Location = new System.Drawing.Point(32, 118);
            this.GroupTestMode.Name = "GroupTestMode";
            this.GroupTestMode.Size = new System.Drawing.Size(162, 52);
            this.GroupTestMode.TabIndex = 2;
            this.GroupTestMode.TabStop = false;
            this.GroupTestMode.Text = "DB Update Test Mode";
            // 
            // RadioTestModeON
            // 
            this.RadioTestModeON.AutoSize = true;
            this.RadioTestModeON.Location = new System.Drawing.Point(15, 24);
            this.RadioTestModeON.Name = "RadioTestModeON";
            this.RadioTestModeON.Size = new System.Drawing.Size(45, 19);
            this.RadioTestModeON.TabIndex = 0;
            this.RadioTestModeON.Text = "ON";
            this.RadioTestModeON.UseVisualStyleBackColor = true;
            this.RadioTestModeON.CheckedChanged += new System.EventHandler(this.RadioTestModeON_CheckedChanged);
            // 
            // RadioTestModeOFF
            // 
            this.RadioTestModeOFF.AutoSize = true;
            this.RadioTestModeOFF.Location = new System.Drawing.Point(73, 24);
            this.RadioTestModeOFF.Name = "RadioTestModeOFF";
            this.RadioTestModeOFF.Size = new System.Drawing.Size(51, 19);
            this.RadioTestModeOFF.TabIndex = 1;
            this.RadioTestModeOFF.Text = "OFF";
            this.RadioTestModeOFF.UseVisualStyleBackColor = true;
            this.RadioTestModeOFF.CheckedChanged += new System.EventHandler(this.RadioTestModeOFF_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.RadioHeadlessOFF);
            this.groupBox1.Controls.Add(this.RadioHeadlessON);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox1.Location = new System.Drawing.Point(32, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 52);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Automation Headless";
            // 
            // RadioHeadlessOFF
            // 
            this.RadioHeadlessOFF.AutoSize = true;
            this.RadioHeadlessOFF.Location = new System.Drawing.Point(73, 24);
            this.RadioHeadlessOFF.Name = "RadioHeadlessOFF";
            this.RadioHeadlessOFF.Size = new System.Drawing.Size(51, 19);
            this.RadioHeadlessOFF.TabIndex = 1;
            this.RadioHeadlessOFF.Text = "OFF";
            this.RadioHeadlessOFF.UseVisualStyleBackColor = true;
            this.RadioHeadlessOFF.CheckedChanged += new System.EventHandler(this.RadioHeadlessOFF_CheckedChanged);
            // 
            // RadioHeadlessON
            // 
            this.RadioHeadlessON.AutoSize = true;
            this.RadioHeadlessON.Location = new System.Drawing.Point(15, 24);
            this.RadioHeadlessON.Name = "RadioHeadlessON";
            this.RadioHeadlessON.Size = new System.Drawing.Size(45, 19);
            this.RadioHeadlessON.TabIndex = 0;
            this.RadioHeadlessON.Text = "ON";
            this.RadioHeadlessON.UseVisualStyleBackColor = true;
            this.RadioHeadlessON.CheckedChanged += new System.EventHandler(this.RadioHeadlessON_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.RadioPackSortingNEW);
            this.groupBox2.Controls.Add(this.RadioPackSortingOLD);
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox2.Location = new System.Drawing.Point(32, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 69);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sorting SetPack Lists";
            // 
            // RadioPackSortingNEW
            // 
            this.RadioPackSortingNEW.AutoSize = true;
            this.RadioPackSortingNEW.Location = new System.Drawing.Point(149, 22);
            this.RadioPackSortingNEW.Name = "RadioPackSortingNEW";
            this.RadioPackSortingNEW.Size = new System.Drawing.Size(88, 19);
            this.RadioPackSortingNEW.TabIndex = 1;
            this.RadioPackSortingNEW.Text = "New->Old";
            this.RadioPackSortingNEW.UseVisualStyleBackColor = true;
            this.RadioPackSortingNEW.CheckedChanged += new System.EventHandler(this.RadioPackSortingNEW_CheckedChanged);
            // 
            // RadioPackSortingOLD
            // 
            this.RadioPackSortingOLD.AutoSize = true;
            this.RadioPackSortingOLD.Location = new System.Drawing.Point(15, 24);
            this.RadioPackSortingOLD.Name = "RadioPackSortingOLD";
            this.RadioPackSortingOLD.Size = new System.Drawing.Size(88, 19);
            this.RadioPackSortingOLD.TabIndex = 0;
            this.RadioPackSortingOLD.Text = "Old->New";
            this.RadioPackSortingOLD.UseVisualStyleBackColor = true;
            this.RadioPackSortingOLD.CheckedChanged += new System.EventHandler(this.RadioPackSortingOLD_CheckedChanged);
            // 
            // btnBackToMainMenu
            // 
            this.btnBackToMainMenu.BackColor = System.Drawing.Color.Maroon;
            this.btnBackToMainMenu.ForeColor = System.Drawing.Color.White;
            this.btnBackToMainMenu.Location = new System.Drawing.Point(8, 6);
            this.btnBackToMainMenu.Name = "btnBackToMainMenu";
            this.btnBackToMainMenu.Size = new System.Drawing.Size(125, 22);
            this.btnBackToMainMenu.TabIndex = 4;
            this.btnBackToMainMenu.Text = "<-- Back to Main Menu";
            this.btnBackToMainMenu.UseVisualStyleBackColor = false;
            this.btnBackToMainMenu.Click += new System.EventHandler(this.btnBackToMainMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(11, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Applies to the first DB Initialization";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.btnBackToMainMenu);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupTestMode);
            this.Controls.Add(this.lblTotalAqua);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings - YGO Card Collector 5";
            this.GroupTestMode.ResumeLayout(false);
            this.GroupTestMode.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalAqua;
        private System.Windows.Forms.GroupBox GroupTestMode;
        private System.Windows.Forms.RadioButton RadioTestModeOFF;
        private System.Windows.Forms.RadioButton RadioTestModeON;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RadioHeadlessOFF;
        private System.Windows.Forms.RadioButton RadioHeadlessON;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RadioPackSortingNEW;
        private System.Windows.Forms.RadioButton RadioPackSortingOLD;
        private System.Windows.Forms.Button btnBackToMainMenu;
        private System.Windows.Forms.Label label1;
    }
}