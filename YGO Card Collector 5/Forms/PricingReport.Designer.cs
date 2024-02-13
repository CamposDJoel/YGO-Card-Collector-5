namespace YGO_Card_Collector_5
{
    partial class PricingReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PricingReport));
            this.btnBackToCollector = new System.Windows.Forms.Button();
            this.TABCONTROLMASTER = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblMedianPriceTotalValueDb = new System.Windows.Forms.Label();
            this.lblMarketPriceTotalValueDB = new System.Windows.Forms.Label();
            this.ListTop1000ReportMedianDB = new System.Windows.Forms.ListBox();
            this.label71 = new System.Windows.Forms.Label();
            this.ListTop1000ReportDB = new System.Windows.Forms.ListBox();
            this.label70 = new System.Windows.Forms.Label();
            this.lblMedianPriceTotalValueCollection = new System.Windows.Forms.Label();
            this.lblMarketPriceTotalValueCollection = new System.Windows.Forms.Label();
            this.ListTop1000ReportMedianCollection = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ListTop1000ReportCollection = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TabSetExplorer = new System.Windows.Forms.TabPage();
            this.PanelSetInfo = new System.Windows.Forms.Panel();
            this.label80 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.ListSets = new System.Windows.Forms.ListBox();
            this.ListSetGroups = new System.Windows.Forms.ListBox();
            this.TABCONTROLMASTER.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.TabSetExplorer.SuspendLayout();
            this.PanelSetInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBackToCollector
            // 
            this.btnBackToCollector.BackColor = System.Drawing.Color.Maroon;
            this.btnBackToCollector.ForeColor = System.Drawing.Color.White;
            this.btnBackToCollector.Location = new System.Drawing.Point(3, 3);
            this.btnBackToCollector.Name = "btnBackToCollector";
            this.btnBackToCollector.Size = new System.Drawing.Size(125, 20);
            this.btnBackToCollector.TabIndex = 264;
            this.btnBackToCollector.Text = "<-- Back to Collector";
            this.btnBackToCollector.UseVisualStyleBackColor = false;
            this.btnBackToCollector.Click += new System.EventHandler(this.btnBackToCollector_Click);
            // 
            // TABCONTROLMASTER
            // 
            this.TABCONTROLMASTER.Controls.Add(this.tabPage1);
            this.TABCONTROLMASTER.Controls.Add(this.tabPage2);
            this.TABCONTROLMASTER.Controls.Add(this.TabSetExplorer);
            this.TABCONTROLMASTER.Location = new System.Drawing.Point(7, 32);
            this.TABCONTROLMASTER.Name = "TABCONTROLMASTER";
            this.TABCONTROLMASTER.SelectedIndex = 0;
            this.TABCONTROLMASTER.Size = new System.Drawing.Size(790, 422);
            this.TABCONTROLMASTER.TabIndex = 265;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Black;
            this.tabPage1.Controls.Add(this.lblMedianPriceTotalValueCollection);
            this.tabPage1.Controls.Add(this.lblMarketPriceTotalValueCollection);
            this.tabPage1.Controls.Add(this.ListTop1000ReportMedianCollection);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.ListTop1000ReportCollection);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(782, 396);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Your Collection Totals";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Black;
            this.tabPage2.Controls.Add(this.lblMedianPriceTotalValueDb);
            this.tabPage2.Controls.Add(this.lblMarketPriceTotalValueDB);
            this.tabPage2.Controls.Add(this.ListTop1000ReportMedianDB);
            this.tabPage2.Controls.Add(this.label71);
            this.tabPage2.Controls.Add(this.ListTop1000ReportDB);
            this.tabPage2.Controls.Add(this.label70);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(782, 396);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DB Totals";
            // 
            // lblMedianPriceTotalValueDb
            // 
            this.lblMedianPriceTotalValueDb.AutoSize = true;
            this.lblMedianPriceTotalValueDb.BackColor = System.Drawing.Color.Black;
            this.lblMedianPriceTotalValueDb.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedianPriceTotalValueDb.ForeColor = System.Drawing.Color.White;
            this.lblMedianPriceTotalValueDb.Location = new System.Drawing.Point(412, 353);
            this.lblMedianPriceTotalValueDb.Name = "lblMedianPriceTotalValueDb";
            this.lblMedianPriceTotalValueDb.Size = new System.Drawing.Size(130, 24);
            this.lblMedianPriceTotalValueDb.TabIndex = 18;
            this.lblMedianPriceTotalValueDb.Text = "Total Value:";
            // 
            // lblMarketPriceTotalValueDB
            // 
            this.lblMarketPriceTotalValueDB.AutoSize = true;
            this.lblMarketPriceTotalValueDB.BackColor = System.Drawing.Color.Black;
            this.lblMarketPriceTotalValueDB.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketPriceTotalValueDB.ForeColor = System.Drawing.Color.White;
            this.lblMarketPriceTotalValueDB.Location = new System.Drawing.Point(11, 353);
            this.lblMarketPriceTotalValueDB.Name = "lblMarketPriceTotalValueDB";
            this.lblMarketPriceTotalValueDB.Size = new System.Drawing.Size(130, 24);
            this.lblMarketPriceTotalValueDB.TabIndex = 17;
            this.lblMarketPriceTotalValueDB.Text = "Total Value:";
            // 
            // ListTop1000ReportMedianDB
            // 
            this.ListTop1000ReportMedianDB.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ListTop1000ReportMedianDB.FormattingEnabled = true;
            this.ListTop1000ReportMedianDB.Location = new System.Drawing.Point(416, 47);
            this.ListTop1000ReportMedianDB.Name = "ListTop1000ReportMedianDB";
            this.ListTop1000ReportMedianDB.Size = new System.Drawing.Size(355, 303);
            this.ListTop1000ReportMedianDB.TabIndex = 16;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.BackColor = System.Drawing.Color.Black;
            this.label71.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.ForeColor = System.Drawing.Color.White;
            this.label71.Location = new System.Drawing.Point(412, 20);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(148, 24);
            this.label71.TabIndex = 15;
            this.label71.Text = "Median Price:";
            // 
            // ListTop1000ReportDB
            // 
            this.ListTop1000ReportDB.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ListTop1000ReportDB.FormattingEnabled = true;
            this.ListTop1000ReportDB.Location = new System.Drawing.Point(15, 47);
            this.ListTop1000ReportDB.Name = "ListTop1000ReportDB";
            this.ListTop1000ReportDB.Size = new System.Drawing.Size(355, 303);
            this.ListTop1000ReportDB.TabIndex = 14;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.BackColor = System.Drawing.Color.Black;
            this.label70.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.Color.White;
            this.label70.Location = new System.Drawing.Point(11, 20);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(144, 24);
            this.label70.TabIndex = 13;
            this.label70.Text = "Market Price:";
            // 
            // lblMedianPriceTotalValueCollection
            // 
            this.lblMedianPriceTotalValueCollection.AutoSize = true;
            this.lblMedianPriceTotalValueCollection.BackColor = System.Drawing.Color.Black;
            this.lblMedianPriceTotalValueCollection.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedianPriceTotalValueCollection.ForeColor = System.Drawing.Color.White;
            this.lblMedianPriceTotalValueCollection.Location = new System.Drawing.Point(412, 353);
            this.lblMedianPriceTotalValueCollection.Name = "lblMedianPriceTotalValueCollection";
            this.lblMedianPriceTotalValueCollection.Size = new System.Drawing.Size(130, 24);
            this.lblMedianPriceTotalValueCollection.TabIndex = 24;
            this.lblMedianPriceTotalValueCollection.Text = "Total Value:";
            // 
            // lblMarketPriceTotalValueCollection
            // 
            this.lblMarketPriceTotalValueCollection.AutoSize = true;
            this.lblMarketPriceTotalValueCollection.BackColor = System.Drawing.Color.Black;
            this.lblMarketPriceTotalValueCollection.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketPriceTotalValueCollection.ForeColor = System.Drawing.Color.White;
            this.lblMarketPriceTotalValueCollection.Location = new System.Drawing.Point(11, 353);
            this.lblMarketPriceTotalValueCollection.Name = "lblMarketPriceTotalValueCollection";
            this.lblMarketPriceTotalValueCollection.Size = new System.Drawing.Size(130, 24);
            this.lblMarketPriceTotalValueCollection.TabIndex = 23;
            this.lblMarketPriceTotalValueCollection.Text = "Total Value:";
            // 
            // ListTop1000ReportMedianCollection
            // 
            this.ListTop1000ReportMedianCollection.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ListTop1000ReportMedianCollection.FormattingEnabled = true;
            this.ListTop1000ReportMedianCollection.Location = new System.Drawing.Point(416, 47);
            this.ListTop1000ReportMedianCollection.Name = "ListTop1000ReportMedianCollection";
            this.ListTop1000ReportMedianCollection.Size = new System.Drawing.Size(355, 303);
            this.ListTop1000ReportMedianCollection.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(412, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 24);
            this.label3.TabIndex = 21;
            this.label3.Text = "Median Price:";
            // 
            // ListTop1000ReportCollection
            // 
            this.ListTop1000ReportCollection.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ListTop1000ReportCollection.FormattingEnabled = true;
            this.ListTop1000ReportCollection.Location = new System.Drawing.Point(15, 47);
            this.ListTop1000ReportCollection.Name = "ListTop1000ReportCollection";
            this.ListTop1000ReportCollection.Size = new System.Drawing.Size(355, 303);
            this.ListTop1000ReportCollection.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(11, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "Market Price:";
            // 
            // TabSetExplorer
            // 
            this.TabSetExplorer.BackColor = System.Drawing.Color.Black;
            this.TabSetExplorer.Controls.Add(this.PanelSetInfo);
            this.TabSetExplorer.Controls.Add(this.label72);
            this.TabSetExplorer.Controls.Add(this.ListSets);
            this.TabSetExplorer.Controls.Add(this.ListSetGroups);
            this.TabSetExplorer.Location = new System.Drawing.Point(4, 22);
            this.TabSetExplorer.Name = "TabSetExplorer";
            this.TabSetExplorer.Padding = new System.Windows.Forms.Padding(3);
            this.TabSetExplorer.Size = new System.Drawing.Size(782, 396);
            this.TabSetExplorer.TabIndex = 2;
            this.TabSetExplorer.Text = "Set Pack Value Explorer";
            // 
            // PanelSetInfo
            // 
            this.PanelSetInfo.AutoScroll = true;
            this.PanelSetInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelSetInfo.Controls.Add(this.label80);
            this.PanelSetInfo.Controls.Add(this.label79);
            this.PanelSetInfo.Controls.Add(this.label78);
            this.PanelSetInfo.Controls.Add(this.label77);
            this.PanelSetInfo.Controls.Add(this.label76);
            this.PanelSetInfo.Controls.Add(this.label75);
            this.PanelSetInfo.Controls.Add(this.label74);
            this.PanelSetInfo.Location = new System.Drawing.Point(184, 6);
            this.PanelSetInfo.Name = "PanelSetInfo";
            this.PanelSetInfo.Size = new System.Drawing.Size(592, 382);
            this.PanelSetInfo.TabIndex = 67;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.BackColor = System.Drawing.Color.Transparent;
            this.label80.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.ForeColor = System.Drawing.Color.White;
            this.label80.Location = new System.Drawing.Point(500, 23);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(66, 16);
            this.label80.TabIndex = 7;
            this.label80.Text = "Obtained?:";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.BackColor = System.Drawing.Color.Transparent;
            this.label79.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.ForeColor = System.Drawing.Color.White;
            this.label79.Location = new System.Drawing.Point(447, 23);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(58, 16);
            this.label79.TabIndex = 6;
            this.label79.Text = "Median $:";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.BackColor = System.Drawing.Color.Transparent;
            this.label78.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.ForeColor = System.Drawing.Color.White;
            this.label78.Location = new System.Drawing.Point(388, 23);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(55, 16);
            this.label78.TabIndex = 5;
            this.label78.Text = "Market $:";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.BackColor = System.Drawing.Color.Transparent;
            this.label77.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.ForeColor = System.Drawing.Color.White;
            this.label77.Location = new System.Drawing.Point(307, 23);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(42, 16);
            this.label77.TabIndex = 4;
            this.label77.Text = "Rarity:";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.BackColor = System.Drawing.Color.Transparent;
            this.label76.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.ForeColor = System.Drawing.Color.White;
            this.label76.Location = new System.Drawing.Point(86, 23);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(68, 16);
            this.label76.TabIndex = 3;
            this.label76.Text = "Card Name:";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.BackColor = System.Drawing.Color.Transparent;
            this.label75.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.ForeColor = System.Drawing.Color.White;
            this.label75.Location = new System.Drawing.Point(8, 23);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(39, 16);
            this.label75.TabIndex = 2;
            this.label75.Text = "Code:";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.BackColor = System.Drawing.Color.Transparent;
            this.label74.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.ForeColor = System.Drawing.Color.White;
            this.label74.Location = new System.Drawing.Point(4, 3);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(79, 17);
            this.label74.TabIndex = 1;
            this.label74.Text = "Card List:";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.Location = new System.Drawing.Point(88, 97);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(15, 15);
            this.label72.TabIndex = 66;
            this.label72.Text = "\\/";
            // 
            // ListSets
            // 
            this.ListSets.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ListSets.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListSets.FormattingEnabled = true;
            this.ListSets.ItemHeight = 15;
            this.ListSets.Location = new System.Drawing.Point(3, 114);
            this.ListSets.Name = "ListSets";
            this.ListSets.Size = new System.Drawing.Size(175, 229);
            this.ListSets.TabIndex = 65;
            this.ListSets.SelectedIndexChanged += new System.EventHandler(this.ListSets_SelectedIndexChanged);
            // 
            // ListSetGroups
            // 
            this.ListSetGroups.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ListSetGroups.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListSetGroups.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListSetGroups.FormattingEnabled = true;
            this.ListSetGroups.ItemHeight = 15;
            this.ListSetGroups.Items.AddRange(new object[] {
            "Booster Packs",
            "Sp Edition Boxes",
            "Starter Decks",
            "Structure Decks",
            "Tins",
            "Speed Duel",
            "Duelists Packs",
            "Duel Terminal",
            "Other",
            "Magazines, Books, and Comics",
            "Tournaments",
            "Promos",
            "Video Game Bundles"});
            this.ListSetGroups.Location = new System.Drawing.Point(4, 3);
            this.ListSetGroups.Name = "ListSetGroups";
            this.ListSetGroups.Size = new System.Drawing.Size(174, 94);
            this.ListSetGroups.TabIndex = 64;
            this.ListSetGroups.SelectedIndexChanged += new System.EventHandler(this.ListSetGroups_SelectedIndexChanged);
            // 
            // PricingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.TABCONTROLMASTER);
            this.Controls.Add(this.btnBackToCollector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PricingReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pricing Report - YGO Card Collector 5";
            this.TABCONTROLMASTER.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.TabSetExplorer.ResumeLayout(false);
            this.TabSetExplorer.PerformLayout();
            this.PanelSetInfo.ResumeLayout(false);
            this.PanelSetInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBackToCollector;
        private System.Windows.Forms.TabControl TABCONTROLMASTER;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblMedianPriceTotalValueDb;
        private System.Windows.Forms.Label lblMarketPriceTotalValueDB;
        private System.Windows.Forms.ListBox ListTop1000ReportMedianDB;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.ListBox ListTop1000ReportDB;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label lblMedianPriceTotalValueCollection;
        private System.Windows.Forms.Label lblMarketPriceTotalValueCollection;
        private System.Windows.Forms.ListBox ListTop1000ReportMedianCollection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ListTop1000ReportCollection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage TabSetExplorer;
        private System.Windows.Forms.Panel PanelSetInfo;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.ListBox ListSets;
        private System.Windows.Forms.ListBox ListSetGroups;
    }
}