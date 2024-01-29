namespace YGO_Card_Collector_5
{
    partial class FormLauncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLauncher));
            this.lblCredits = new System.Windows.Forms.Label();
            this.lblJsonStatus = new System.Windows.Forms.Label();
            this.BarProgress = new System.Windows.Forms.ProgressBar();
            this.PanelOutput = new System.Windows.Forms.Panel();
            this.lblCardSorting = new System.Windows.Forms.Label();
            this.lblLaunchAppOption = new System.Windows.Forms.Label();
            this.lblDatabaseOption = new System.Windows.Forms.Label();
            this.lblSettingsOption = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.PanelOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.BackColor = System.Drawing.Color.Transparent;
            this.lblCredits.ForeColor = System.Drawing.Color.Lime;
            this.lblCredits.Location = new System.Drawing.Point(13, 479);
            this.lblCredits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(254, 12);
            this.lblCredits.TabIndex = 0;
            this.lblCredits.Text = "Designed and implemented by CamposD.Joel";
            // 
            // lblJsonStatus
            // 
            this.lblJsonStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblJsonStatus.ForeColor = System.Drawing.Color.White;
            this.lblJsonStatus.Location = new System.Drawing.Point(0, 0);
            this.lblJsonStatus.Name = "lblJsonStatus";
            this.lblJsonStatus.Size = new System.Drawing.Size(343, 18);
            this.lblJsonStatus.TabIndex = 2;
            // 
            // BarProgress
            // 
            this.BarProgress.Location = new System.Drawing.Point(288, 234);
            this.BarProgress.Name = "BarProgress";
            this.BarProgress.Size = new System.Drawing.Size(350, 23);
            this.BarProgress.TabIndex = 3;
            this.BarProgress.Visible = false;
            // 
            // PanelOutput
            // 
            this.PanelOutput.BackColor = System.Drawing.Color.Black;
            this.PanelOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelOutput.Controls.Add(this.lblCardSorting);
            this.PanelOutput.Controls.Add(this.lblJsonStatus);
            this.PanelOutput.Location = new System.Drawing.Point(288, 263);
            this.PanelOutput.Name = "PanelOutput";
            this.PanelOutput.Size = new System.Drawing.Size(350, 76);
            this.PanelOutput.TabIndex = 4;
            this.PanelOutput.Visible = false;
            // 
            // lblCardSorting
            // 
            this.lblCardSorting.BackColor = System.Drawing.Color.Transparent;
            this.lblCardSorting.ForeColor = System.Drawing.Color.White;
            this.lblCardSorting.Location = new System.Drawing.Point(2, 20);
            this.lblCardSorting.Name = "lblCardSorting";
            this.lblCardSorting.Size = new System.Drawing.Size(343, 18);
            this.lblCardSorting.TabIndex = 3;
            // 
            // lblLaunchAppOption
            // 
            this.lblLaunchAppOption.BackColor = System.Drawing.Color.Transparent;
            this.lblLaunchAppOption.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaunchAppOption.ForeColor = System.Drawing.Color.White;
            this.lblLaunchAppOption.Location = new System.Drawing.Point(12, 169);
            this.lblLaunchAppOption.Name = "lblLaunchAppOption";
            this.lblLaunchAppOption.Size = new System.Drawing.Size(230, 28);
            this.lblLaunchAppOption.TabIndex = 5;
            this.lblLaunchAppOption.Text = "Collection Tracker";
            this.lblLaunchAppOption.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblLaunchAppOption.Click += new System.EventHandler(this.lblLaunchAppOption_Click);
            // 
            // lblDatabaseOption
            // 
            this.lblDatabaseOption.BackColor = System.Drawing.Color.Transparent;
            this.lblDatabaseOption.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaseOption.ForeColor = System.Drawing.Color.White;
            this.lblDatabaseOption.Location = new System.Drawing.Point(12, 215);
            this.lblDatabaseOption.Name = "lblDatabaseOption";
            this.lblDatabaseOption.Size = new System.Drawing.Size(230, 28);
            this.lblDatabaseOption.TabIndex = 6;
            this.lblDatabaseOption.Text = "Database Manager";
            this.lblDatabaseOption.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblDatabaseOption.Click += new System.EventHandler(this.lblDatabaseOption_Click);
            // 
            // lblSettingsOption
            // 
            this.lblSettingsOption.BackColor = System.Drawing.Color.Transparent;
            this.lblSettingsOption.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsOption.ForeColor = System.Drawing.Color.White;
            this.lblSettingsOption.Location = new System.Drawing.Point(13, 263);
            this.lblSettingsOption.Name = "lblSettingsOption";
            this.lblSettingsOption.Size = new System.Drawing.Size(230, 28);
            this.lblSettingsOption.TabIndex = 7;
            this.lblSettingsOption.Text = "Settings";
            this.lblSettingsOption.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.Yellow;
            this.lblProgress.Location = new System.Drawing.Point(286, 215);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(80, 17);
            this.lblProgress.TabIndex = 8;
            this.lblProgress.Text = "Progress:";
            this.lblProgress.Visible = false;
            // 
            // FormLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(725, 439);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblSettingsOption);
            this.Controls.Add(this.lblDatabaseOption);
            this.Controls.Add(this.lblLaunchAppOption);
            this.Controls.Add(this.PanelOutput);
            this.Controls.Add(this.BarProgress);
            this.Controls.Add(this.lblCredits);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FormLauncher";
            this.Text = "Welcome! - YGO Card Collector 5";
            this.PanelOutput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.Label lblJsonStatus;
        private System.Windows.Forms.ProgressBar BarProgress;
        private System.Windows.Forms.Panel PanelOutput;
        private System.Windows.Forms.Label lblCardSorting;
        private System.Windows.Forms.Label lblLaunchAppOption;
        private System.Windows.Forms.Label lblDatabaseOption;
        private System.Windows.Forms.Label lblSettingsOption;
        private System.Windows.Forms.Label lblProgress;
    }
}

