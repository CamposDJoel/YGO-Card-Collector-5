namespace YGO_Card_Collector_5
{
    partial class StatsReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatsReport));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Group_MS_Monsters = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Group_MS_Spells = new System.Windows.Forms.GroupBox();
            this.Group_MS_Traps = new System.Windows.Forms.GroupBox();
            this.Group_MS_Totals = new System.Windows.Forms.GroupBox();
            this.Group_MS_Colors = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(799, 433);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Black;
            this.tabPage1.Controls.Add(this.Group_MS_Colors);
            this.tabPage1.Controls.Add(this.Group_MS_Totals);
            this.tabPage1.Controls.Add(this.Group_MS_Traps);
            this.tabPage1.Controls.Add(this.Group_MS_Spells);
            this.tabPage1.Controls.Add(this.Group_MS_Monsters);
            this.tabPage1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(791, 407);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Master Collection Stats";
            // 
            // Group_MS_Monsters
            // 
            this.Group_MS_Monsters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Group_MS_Monsters.Location = new System.Drawing.Point(4, 0);
            this.Group_MS_Monsters.Name = "Group_MS_Monsters";
            this.Group_MS_Monsters.Size = new System.Drawing.Size(390, 404);
            this.Group_MS_Monsters.TabIndex = 0;
            this.Group_MS_Monsters.TabStop = false;
            this.Group_MS_Monsters.Text = "Monsters";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Black;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(791, 407);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Booster Pks";
            // 
            // Group_MS_Spells
            // 
            this.Group_MS_Spells.ForeColor = System.Drawing.Color.Green;
            this.Group_MS_Spells.Location = new System.Drawing.Point(400, 0);
            this.Group_MS_Spells.Name = "Group_MS_Spells";
            this.Group_MS_Spells.Size = new System.Drawing.Size(388, 110);
            this.Group_MS_Spells.TabIndex = 1;
            this.Group_MS_Spells.TabStop = false;
            this.Group_MS_Spells.Text = "Spells";
            // 
            // Group_MS_Traps
            // 
            this.Group_MS_Traps.ForeColor = System.Drawing.Color.Magenta;
            this.Group_MS_Traps.Location = new System.Drawing.Point(400, 110);
            this.Group_MS_Traps.Name = "Group_MS_Traps";
            this.Group_MS_Traps.Size = new System.Drawing.Size(388, 69);
            this.Group_MS_Traps.TabIndex = 2;
            this.Group_MS_Traps.TabStop = false;
            this.Group_MS_Traps.Text = "Traps";
            // 
            // Group_MS_Totals
            // 
            this.Group_MS_Totals.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Group_MS_Totals.Location = new System.Drawing.Point(400, 179);
            this.Group_MS_Totals.Name = "Group_MS_Totals";
            this.Group_MS_Totals.Size = new System.Drawing.Size(388, 83);
            this.Group_MS_Totals.TabIndex = 3;
            this.Group_MS_Totals.TabStop = false;
            this.Group_MS_Totals.Text = "Totals";
            // 
            // Group_MS_Colors
            // 
            this.Group_MS_Colors.ForeColor = System.Drawing.Color.Gray;
            this.Group_MS_Colors.Location = new System.Drawing.Point(400, 261);
            this.Group_MS_Colors.Name = "Group_MS_Colors";
            this.Group_MS_Colors.Size = new System.Drawing.Size(388, 143);
            this.Group_MS_Colors.TabIndex = 4;
            this.Group_MS_Colors.TabStop = false;
            this.Group_MS_Colors.Text = "Card Colors";
            // 
            // StatsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StatsReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collection Stats - YGO Card Collector 5";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox Group_MS_Monsters;
        private System.Windows.Forms.GroupBox Group_MS_Traps;
        private System.Windows.Forms.GroupBox Group_MS_Spells;
        private System.Windows.Forms.GroupBox Group_MS_Totals;
        private System.Windows.Forms.GroupBox Group_MS_Colors;
    }
}