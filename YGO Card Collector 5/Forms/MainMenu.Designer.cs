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
            this.lblLaunchAppOption = new System.Windows.Forms.Label();
            this.lblDatabaseOption = new System.Windows.Forms.Label();
            this.lblSettingsOption = new System.Windows.Forms.Label();
            this.GroupWinMode = new System.Windows.Forms.GroupBox();
            this.RadioBinderOption = new System.Windows.Forms.RadioButton();
            this.RadioBigWinOption = new System.Windows.Forms.RadioButton();
            this.RadioDefaultOption = new System.Windows.Forms.RadioButton();
            this.lblDatabaseUpdateOption = new System.Windows.Forms.Label();
            this.lblDBRestrict = new System.Windows.Forms.Label();
            this.GroupWinMode.SuspendLayout();
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
            // lblLaunchAppOption
            // 
            this.lblLaunchAppOption.BackColor = System.Drawing.Color.Transparent;
            this.lblLaunchAppOption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLaunchAppOption.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaunchAppOption.ForeColor = System.Drawing.Color.Yellow;
            this.lblLaunchAppOption.Location = new System.Drawing.Point(12, 111);
            this.lblLaunchAppOption.Name = "lblLaunchAppOption";
            this.lblLaunchAppOption.Size = new System.Drawing.Size(315, 35);
            this.lblLaunchAppOption.TabIndex = 5;
            this.lblLaunchAppOption.Text = "Collection Tracker";
            this.lblLaunchAppOption.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblLaunchAppOption.Click += new System.EventHandler(this.lblLaunchAppOption_Click);
            // 
            // lblDatabaseOption
            // 
            this.lblDatabaseOption.BackColor = System.Drawing.Color.Transparent;
            this.lblDatabaseOption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDatabaseOption.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaseOption.ForeColor = System.Drawing.Color.Yellow;
            this.lblDatabaseOption.Location = new System.Drawing.Point(12, 271);
            this.lblDatabaseOption.Name = "lblDatabaseOption";
            this.lblDatabaseOption.Size = new System.Drawing.Size(315, 35);
            this.lblDatabaseOption.TabIndex = 6;
            this.lblDatabaseOption.Text = "Database Manager";
            this.lblDatabaseOption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDatabaseOption.Click += new System.EventHandler(this.lblDatabaseOption_Click);
            // 
            // lblSettingsOption
            // 
            this.lblSettingsOption.BackColor = System.Drawing.Color.Transparent;
            this.lblSettingsOption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSettingsOption.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsOption.ForeColor = System.Drawing.Color.Yellow;
            this.lblSettingsOption.Location = new System.Drawing.Point(13, 319);
            this.lblSettingsOption.Name = "lblSettingsOption";
            this.lblSettingsOption.Size = new System.Drawing.Size(315, 35);
            this.lblSettingsOption.TabIndex = 7;
            this.lblSettingsOption.Text = "Settings";
            this.lblSettingsOption.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblSettingsOption.Click += new System.EventHandler(this.lblSettingsOption_Click);
            // 
            // GroupWinMode
            // 
            this.GroupWinMode.BackColor = System.Drawing.Color.Transparent;
            this.GroupWinMode.Controls.Add(this.RadioBinderOption);
            this.GroupWinMode.Controls.Add(this.RadioBigWinOption);
            this.GroupWinMode.Controls.Add(this.RadioDefaultOption);
            this.GroupWinMode.ForeColor = System.Drawing.Color.Yellow;
            this.GroupWinMode.Location = new System.Drawing.Point(69, 149);
            this.GroupWinMode.Name = "GroupWinMode";
            this.GroupWinMode.Size = new System.Drawing.Size(173, 72);
            this.GroupWinMode.TabIndex = 9;
            this.GroupWinMode.TabStop = false;
            this.GroupWinMode.Text = "Window Mode";
            // 
            // RadioBinderOption
            // 
            this.RadioBinderOption.AutoSize = true;
            this.RadioBinderOption.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioBinderOption.Location = new System.Drawing.Point(10, 48);
            this.RadioBinderOption.Name = "RadioBinderOption";
            this.RadioBinderOption.Size = new System.Drawing.Size(118, 21);
            this.RadioBinderOption.TabIndex = 3;
            this.RadioBinderOption.Text = "Binder Mode";
            this.RadioBinderOption.UseVisualStyleBackColor = true;
            this.RadioBinderOption.CheckedChanged += new System.EventHandler(this.RadioBinderOption_CheckedChanged);
            // 
            // RadioBigWinOption
            // 
            this.RadioBigWinOption.AutoSize = true;
            this.RadioBigWinOption.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioBigWinOption.Location = new System.Drawing.Point(10, 29);
            this.RadioBigWinOption.Name = "RadioBigWinOption";
            this.RadioBigWinOption.Size = new System.Drawing.Size(154, 21);
            this.RadioBigWinOption.TabIndex = 2;
            this.RadioBigWinOption.Text = "Big Window Mode";
            this.RadioBigWinOption.UseVisualStyleBackColor = true;
            this.RadioBigWinOption.CheckedChanged += new System.EventHandler(this.RadioBigWinOption_CheckedChanged);
            // 
            // RadioDefaultOption
            // 
            this.RadioDefaultOption.AutoSize = true;
            this.RadioDefaultOption.Checked = true;
            this.RadioDefaultOption.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioDefaultOption.Location = new System.Drawing.Point(11, 11);
            this.RadioDefaultOption.Name = "RadioDefaultOption";
            this.RadioDefaultOption.Size = new System.Drawing.Size(91, 21);
            this.RadioDefaultOption.TabIndex = 0;
            this.RadioDefaultOption.TabStop = true;
            this.RadioDefaultOption.Text = "Compact";
            this.RadioDefaultOption.UseVisualStyleBackColor = true;
            this.RadioDefaultOption.CheckedChanged += new System.EventHandler(this.RadioDefaultOption_CheckedChanged);
            // 
            // lblDatabaseUpdateOption
            // 
            this.lblDatabaseUpdateOption.BackColor = System.Drawing.Color.Transparent;
            this.lblDatabaseUpdateOption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDatabaseUpdateOption.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaseUpdateOption.ForeColor = System.Drawing.Color.Yellow;
            this.lblDatabaseUpdateOption.Location = new System.Drawing.Point(13, 224);
            this.lblDatabaseUpdateOption.Name = "lblDatabaseUpdateOption";
            this.lblDatabaseUpdateOption.Size = new System.Drawing.Size(315, 35);
            this.lblDatabaseUpdateOption.TabIndex = 10;
            this.lblDatabaseUpdateOption.Text = "Database Update Tool";
            this.lblDatabaseUpdateOption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDatabaseUpdateOption.Click += new System.EventHandler(this.lblDatabaseUpdateOption_Click);
            // 
            // lblDBRestrict
            // 
            this.lblDBRestrict.AutoSize = true;
            this.lblDBRestrict.BackColor = System.Drawing.Color.Black;
            this.lblDBRestrict.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBRestrict.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDBRestrict.Location = new System.Drawing.Point(21, 387);
            this.lblDBRestrict.Name = "lblDBRestrict";
            this.lblDBRestrict.Size = new System.Drawing.Size(445, 22);
            this.lblDBRestrict.TabIndex = 11;
            this.lblDBRestrict.Text = "DB Tools ONLY available during FULL DB Mode.";
            this.lblDBRestrict.Visible = false;
            // 
            // FormLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 457);
            this.Controls.Add(this.lblDBRestrict);
            this.Controls.Add(this.lblDatabaseUpdateOption);
            this.Controls.Add(this.GroupWinMode);
            this.Controls.Add(this.lblSettingsOption);
            this.Controls.Add(this.lblDatabaseOption);
            this.Controls.Add(this.lblLaunchAppOption);
            this.Controls.Add(this.lblCredits);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FormLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu - YGO Card Collector 5";
            this.GroupWinMode.ResumeLayout(false);
            this.GroupWinMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.Label lblLaunchAppOption;
        private System.Windows.Forms.Label lblDatabaseOption;
        private System.Windows.Forms.Label lblSettingsOption;
        private System.Windows.Forms.GroupBox GroupWinMode;
        private System.Windows.Forms.RadioButton RadioBigWinOption;
        private System.Windows.Forms.RadioButton RadioDefaultOption;
        private System.Windows.Forms.Label lblDatabaseUpdateOption;
        private System.Windows.Forms.RadioButton RadioBinderOption;
        private System.Windows.Forms.Label lblDBRestrict;
    }
}

