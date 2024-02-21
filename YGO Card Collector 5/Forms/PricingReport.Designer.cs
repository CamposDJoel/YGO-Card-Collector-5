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
            this.GroupPriceGroup = new System.Windows.Forms.GroupBox();
            this.radioMedianOption = new System.Windows.Forms.RadioButton();
            this.radioMarketOption = new System.Windows.Forms.RadioButton();
            this.radioFloorOption = new System.Windows.Forms.RadioButton();
            this.lblMarketPriceTotalValue = new System.Windows.Forms.Label();
            this.ListTop1000Report = new System.Windows.Forms.ListBox();
            this.label69 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GroupPriceGroupDB = new System.Windows.Forms.GroupBox();
            this.radioMedianOptionDB = new System.Windows.Forms.RadioButton();
            this.radioMarketOptionDB = new System.Windows.Forms.RadioButton();
            this.radioFloorOptionDB = new System.Windows.Forms.RadioButton();
            this.lblMarketPriceTotalValueDB = new System.Windows.Forms.Label();
            this.ListTop1000ReportDB = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TabSetExplorer = new System.Windows.Forms.TabPage();
            this.PanelSetInfo = new System.Windows.Forms.Panel();
            this.label70 = new System.Windows.Forms.Label();
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
            this.GroupPriceGroup.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.GroupPriceGroupDB.SuspendLayout();
            this.TabSetExplorer.SuspendLayout();
            this.PanelSetInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBackToCollector
            // 
            this.btnBackToCollector.BackColor = System.Drawing.Color.Maroon;
            this.btnBackToCollector.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToCollector.ForeColor = System.Drawing.Color.White;
            this.btnBackToCollector.Location = new System.Drawing.Point(3, 3);
            this.btnBackToCollector.Name = "btnBackToCollector";
            this.btnBackToCollector.Size = new System.Drawing.Size(134, 20);
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
            this.tabPage1.Controls.Add(this.GroupPriceGroup);
            this.tabPage1.Controls.Add(this.lblMarketPriceTotalValue);
            this.tabPage1.Controls.Add(this.ListTop1000Report);
            this.tabPage1.Controls.Add(this.label69);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(782, 396);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Your Collection Totals";
            // 
            // GroupPriceGroup
            // 
            this.GroupPriceGroup.Controls.Add(this.radioMedianOption);
            this.GroupPriceGroup.Controls.Add(this.radioMarketOption);
            this.GroupPriceGroup.Controls.Add(this.radioFloorOption);
            this.GroupPriceGroup.ForeColor = System.Drawing.Color.White;
            this.GroupPriceGroup.Location = new System.Drawing.Point(261, 4);
            this.GroupPriceGroup.Name = "GroupPriceGroup";
            this.GroupPriceGroup.Size = new System.Drawing.Size(282, 38);
            this.GroupPriceGroup.TabIndex = 17;
            this.GroupPriceGroup.TabStop = false;
            this.GroupPriceGroup.Text = "Select Price Group";
            // 
            // radioMedianOption
            // 
            this.radioMedianOption.AutoSize = true;
            this.radioMedianOption.Location = new System.Drawing.Point(187, 15);
            this.radioMedianOption.Name = "radioMedianOption";
            this.radioMedianOption.Size = new System.Drawing.Size(67, 17);
            this.radioMedianOption.TabIndex = 2;
            this.radioMedianOption.Text = "MEDIAN";
            this.radioMedianOption.UseVisualStyleBackColor = true;
            this.radioMedianOption.CheckedChanged += new System.EventHandler(this.radioMedianOption_CheckedChanged);
            // 
            // radioMarketOption
            // 
            this.radioMarketOption.AutoSize = true;
            this.radioMarketOption.Location = new System.Drawing.Point(92, 15);
            this.radioMarketOption.Name = "radioMarketOption";
            this.radioMarketOption.Size = new System.Drawing.Size(70, 17);
            this.radioMarketOption.TabIndex = 1;
            this.radioMarketOption.Text = "MARKET";
            this.radioMarketOption.UseVisualStyleBackColor = true;
            this.radioMarketOption.CheckedChanged += new System.EventHandler(this.radioMarketOption_CheckedChanged);
            // 
            // radioFloorOption
            // 
            this.radioFloorOption.AutoSize = true;
            this.radioFloorOption.Checked = true;
            this.radioFloorOption.Location = new System.Drawing.Point(7, 15);
            this.radioFloorOption.Name = "radioFloorOption";
            this.radioFloorOption.Size = new System.Drawing.Size(61, 17);
            this.radioFloorOption.TabIndex = 0;
            this.radioFloorOption.TabStop = true;
            this.radioFloorOption.Text = "FLOOR";
            this.radioFloorOption.UseVisualStyleBackColor = true;
            this.radioFloorOption.CheckedChanged += new System.EventHandler(this.radioFloorOption_CheckedChanged);
            // 
            // lblMarketPriceTotalValue
            // 
            this.lblMarketPriceTotalValue.AutoSize = true;
            this.lblMarketPriceTotalValue.BackColor = System.Drawing.Color.Transparent;
            this.lblMarketPriceTotalValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketPriceTotalValue.ForeColor = System.Drawing.Color.White;
            this.lblMarketPriceTotalValue.Location = new System.Drawing.Point(290, 367);
            this.lblMarketPriceTotalValue.Name = "lblMarketPriceTotalValue";
            this.lblMarketPriceTotalValue.Size = new System.Drawing.Size(130, 24);
            this.lblMarketPriceTotalValue.TabIndex = 16;
            this.lblMarketPriceTotalValue.Text = "Total Value:";
            // 
            // ListTop1000Report
            // 
            this.ListTop1000Report.BackColor = System.Drawing.SystemColors.Desktop;
            this.ListTop1000Report.ForeColor = System.Drawing.Color.White;
            this.ListTop1000Report.FormattingEnabled = true;
            this.ListTop1000Report.Location = new System.Drawing.Point(119, 56);
            this.ListTop1000Report.Name = "ListTop1000Report";
            this.ListTop1000Report.Size = new System.Drawing.Size(582, 303);
            this.ListTop1000Report.TabIndex = 15;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.BackColor = System.Drawing.Color.Transparent;
            this.label69.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.Color.White;
            this.label69.Location = new System.Drawing.Point(13, 5);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(184, 24);
            this.label69.TabIndex = 14;
            this.label69.Text = "DB Prices Report";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Black;
            this.tabPage2.Controls.Add(this.GroupPriceGroupDB);
            this.tabPage2.Controls.Add(this.lblMarketPriceTotalValueDB);
            this.tabPage2.Controls.Add(this.ListTop1000ReportDB);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(782, 396);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DB Totals";
            // 
            // GroupPriceGroupDB
            // 
            this.GroupPriceGroupDB.Controls.Add(this.radioMedianOptionDB);
            this.GroupPriceGroupDB.Controls.Add(this.radioMarketOptionDB);
            this.GroupPriceGroupDB.Controls.Add(this.radioFloorOptionDB);
            this.GroupPriceGroupDB.ForeColor = System.Drawing.Color.White;
            this.GroupPriceGroupDB.Location = new System.Drawing.Point(261, 4);
            this.GroupPriceGroupDB.Name = "GroupPriceGroupDB";
            this.GroupPriceGroupDB.Size = new System.Drawing.Size(282, 38);
            this.GroupPriceGroupDB.TabIndex = 21;
            this.GroupPriceGroupDB.TabStop = false;
            this.GroupPriceGroupDB.Text = "Select Price Group";
            // 
            // radioMedianOptionDB
            // 
            this.radioMedianOptionDB.AutoSize = true;
            this.radioMedianOptionDB.Location = new System.Drawing.Point(187, 15);
            this.radioMedianOptionDB.Name = "radioMedianOptionDB";
            this.radioMedianOptionDB.Size = new System.Drawing.Size(67, 17);
            this.radioMedianOptionDB.TabIndex = 2;
            this.radioMedianOptionDB.Text = "MEDIAN";
            this.radioMedianOptionDB.UseVisualStyleBackColor = true;
            this.radioMedianOptionDB.CheckedChanged += new System.EventHandler(this.radioMedianOptionDB_CheckedChanged);
            // 
            // radioMarketOptionDB
            // 
            this.radioMarketOptionDB.AutoSize = true;
            this.radioMarketOptionDB.Location = new System.Drawing.Point(92, 15);
            this.radioMarketOptionDB.Name = "radioMarketOptionDB";
            this.radioMarketOptionDB.Size = new System.Drawing.Size(70, 17);
            this.radioMarketOptionDB.TabIndex = 1;
            this.radioMarketOptionDB.Text = "MARKET";
            this.radioMarketOptionDB.UseVisualStyleBackColor = true;
            this.radioMarketOptionDB.CheckedChanged += new System.EventHandler(this.radioMarketOptionDB_CheckedChanged);
            // 
            // radioFloorOptionDB
            // 
            this.radioFloorOptionDB.AutoSize = true;
            this.radioFloorOptionDB.Checked = true;
            this.radioFloorOptionDB.Location = new System.Drawing.Point(7, 15);
            this.radioFloorOptionDB.Name = "radioFloorOptionDB";
            this.radioFloorOptionDB.Size = new System.Drawing.Size(61, 17);
            this.radioFloorOptionDB.TabIndex = 0;
            this.radioFloorOptionDB.TabStop = true;
            this.radioFloorOptionDB.Text = "FLOOR";
            this.radioFloorOptionDB.UseVisualStyleBackColor = true;
            this.radioFloorOptionDB.CheckedChanged += new System.EventHandler(this.radioFloorOptionDB_CheckedChanged);
            // 
            // lblMarketPriceTotalValueDB
            // 
            this.lblMarketPriceTotalValueDB.AutoSize = true;
            this.lblMarketPriceTotalValueDB.BackColor = System.Drawing.Color.Transparent;
            this.lblMarketPriceTotalValueDB.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketPriceTotalValueDB.ForeColor = System.Drawing.Color.White;
            this.lblMarketPriceTotalValueDB.Location = new System.Drawing.Point(290, 367);
            this.lblMarketPriceTotalValueDB.Name = "lblMarketPriceTotalValueDB";
            this.lblMarketPriceTotalValueDB.Size = new System.Drawing.Size(130, 24);
            this.lblMarketPriceTotalValueDB.TabIndex = 20;
            this.lblMarketPriceTotalValueDB.Text = "Total Value:";
            // 
            // ListTop1000ReportDB
            // 
            this.ListTop1000ReportDB.BackColor = System.Drawing.SystemColors.Desktop;
            this.ListTop1000ReportDB.ForeColor = System.Drawing.Color.White;
            this.ListTop1000ReportDB.FormattingEnabled = true;
            this.ListTop1000ReportDB.Location = new System.Drawing.Point(119, 56);
            this.ListTop1000ReportDB.Name = "ListTop1000ReportDB";
            this.ListTop1000ReportDB.Size = new System.Drawing.Size(582, 303);
            this.ListTop1000ReportDB.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "DB Prices Report";
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
            this.PanelSetInfo.Controls.Add(this.label70);
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
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.BackColor = System.Drawing.Color.Transparent;
            this.label70.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.Color.White;
            this.label70.Location = new System.Drawing.Point(331, 23);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(48, 16);
            this.label70.TabIndex = 9;
            this.label70.Text = "Floor $:";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.BackColor = System.Drawing.Color.Transparent;
            this.label80.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.ForeColor = System.Drawing.Color.White;
            this.label80.Location = new System.Drawing.Point(505, 23);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(50, 16);
            this.label80.TabIndex = 7;
            this.label80.Text = "Owned?";
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
            this.label77.Location = new System.Drawing.Point(247, 23);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pricing Report - YGO Card Collector 5";
            this.TABCONTROLMASTER.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.GroupPriceGroup.ResumeLayout(false);
            this.GroupPriceGroup.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.GroupPriceGroupDB.ResumeLayout(false);
            this.GroupPriceGroupDB.PerformLayout();
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
        private System.Windows.Forms.GroupBox GroupPriceGroup;
        private System.Windows.Forms.RadioButton radioMedianOption;
        private System.Windows.Forms.RadioButton radioMarketOption;
        private System.Windows.Forms.RadioButton radioFloorOption;
        private System.Windows.Forms.Label lblMarketPriceTotalValue;
        private System.Windows.Forms.ListBox ListTop1000Report;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.GroupBox GroupPriceGroupDB;
        private System.Windows.Forms.RadioButton radioMedianOptionDB;
        private System.Windows.Forms.RadioButton radioMarketOptionDB;
        private System.Windows.Forms.RadioButton radioFloorOptionDB;
        private System.Windows.Forms.Label lblMarketPriceTotalValueDB;
        private System.Windows.Forms.ListBox ListTop1000ReportDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label70;
    }
}