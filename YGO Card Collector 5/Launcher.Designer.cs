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
            this.btnLoadDB = new System.Windows.Forms.Button();
            this.lblJsonStatus = new System.Windows.Forms.Label();
            this.BarProgress = new System.Windows.Forms.ProgressBar();
            this.PanelOutput = new System.Windows.Forms.Panel();
            this.lblCardSorting = new System.Windows.Forms.Label();
            this.PanelOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.BackColor = System.Drawing.Color.Transparent;
            this.lblCredits.ForeColor = System.Drawing.Color.Lime;
            this.lblCredits.Location = new System.Drawing.Point(8, 193);
            this.lblCredits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(254, 12);
            this.lblCredits.TabIndex = 0;
            this.lblCredits.Text = "Designed and implemented by CamposD.Joel";
            // 
            // btnLoadDB
            // 
            this.btnLoadDB.BackColor = System.Drawing.Color.Navy;
            this.btnLoadDB.ForeColor = System.Drawing.Color.White;
            this.btnLoadDB.Location = new System.Drawing.Point(129, 8);
            this.btnLoadDB.Name = "btnLoadDB";
            this.btnLoadDB.Size = new System.Drawing.Size(221, 47);
            this.btnLoadDB.TabIndex = 1;
            this.btnLoadDB.Text = "Launch App";
            this.btnLoadDB.UseVisualStyleBackColor = false;
            this.btnLoadDB.Click += new System.EventHandler(this.btnLoadDB_Click);
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
            this.BarProgress.Location = new System.Drawing.Point(129, 61);
            this.BarProgress.Name = "BarProgress";
            this.BarProgress.Size = new System.Drawing.Size(221, 23);
            this.BarProgress.TabIndex = 3;
            this.BarProgress.Visible = false;
            // 
            // PanelOutput
            // 
            this.PanelOutput.BackColor = System.Drawing.Color.Black;
            this.PanelOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelOutput.Controls.Add(this.lblCardSorting);
            this.PanelOutput.Controls.Add(this.lblJsonStatus);
            this.PanelOutput.Location = new System.Drawing.Point(66, 90);
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
            // FormLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(480, 207);
            this.Controls.Add(this.PanelOutput);
            this.Controls.Add(this.BarProgress);
            this.Controls.Add(this.btnLoadDB);
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
        private System.Windows.Forms.Button btnLoadDB;
        private System.Windows.Forms.Label lblJsonStatus;
        private System.Windows.Forms.ProgressBar BarProgress;
        private System.Windows.Forms.Panel PanelOutput;
        private System.Windows.Forms.Label lblCardSorting;
    }
}

