namespace YGO_Card_Collector_5
{
    partial class DeckSelectorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeckSelectorForm));
            this.PanelDeckList = new System.Windows.Forms.Panel();
            this.GroupDeckInfo = new System.Windows.Forms.GroupBox();
            this.listDeckList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBackToMainMenu = new System.Windows.Forms.Button();
            this.btnEditDeck = new System.Windows.Forms.Button();
            this.PanelDeckList.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelDeckList
            // 
            this.PanelDeckList.BackColor = System.Drawing.Color.Black;
            this.PanelDeckList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelDeckList.Controls.Add(this.btnEditDeck);
            this.PanelDeckList.Controls.Add(this.GroupDeckInfo);
            this.PanelDeckList.Controls.Add(this.listDeckList);
            this.PanelDeckList.Controls.Add(this.label1);
            this.PanelDeckList.Location = new System.Drawing.Point(13, 53);
            this.PanelDeckList.Name = "PanelDeckList";
            this.PanelDeckList.Size = new System.Drawing.Size(282, 396);
            this.PanelDeckList.TabIndex = 0;
            // 
            // GroupDeckInfo
            // 
            this.GroupDeckInfo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupDeckInfo.ForeColor = System.Drawing.Color.Yellow;
            this.GroupDeckInfo.Location = new System.Drawing.Point(12, 200);
            this.GroupDeckInfo.Name = "GroupDeckInfo";
            this.GroupDeckInfo.Size = new System.Drawing.Size(255, 129);
            this.GroupDeckInfo.TabIndex = 2;
            this.GroupDeckInfo.TabStop = false;
            this.GroupDeckInfo.Text = "Deck Info";
            // 
            // listDeckList
            // 
            this.listDeckList.FormattingEnabled = true;
            this.listDeckList.Location = new System.Drawing.Point(13, 46);
            this.listDeckList.Name = "listDeckList";
            this.listDeckList.Size = new System.Drawing.Size(255, 147);
            this.listDeckList.TabIndex = 1;
            this.listDeckList.SelectedIndexChanged += new System.EventHandler(this.listDeckList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Deck:";
            // 
            // btnBackToMainMenu
            // 
            this.btnBackToMainMenu.BackColor = System.Drawing.Color.Maroon;
            this.btnBackToMainMenu.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToMainMenu.ForeColor = System.Drawing.Color.White;
            this.btnBackToMainMenu.Location = new System.Drawing.Point(12, 12);
            this.btnBackToMainMenu.Name = "btnBackToMainMenu";
            this.btnBackToMainMenu.Size = new System.Drawing.Size(135, 20);
            this.btnBackToMainMenu.TabIndex = 263;
            this.btnBackToMainMenu.Text = "<-- Back to Main Menu";
            this.btnBackToMainMenu.UseVisualStyleBackColor = false;
            this.btnBackToMainMenu.Click += new System.EventHandler(this.btnBackToMainMenu_Click);
            // 
            // btnEditDeck
            // 
            this.btnEditDeck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEditDeck.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDeck.Location = new System.Drawing.Point(54, 340);
            this.btnEditDeck.Name = "btnEditDeck";
            this.btnEditDeck.Size = new System.Drawing.Size(169, 42);
            this.btnEditDeck.TabIndex = 3;
            this.btnEditDeck.Text = "Edit Deck";
            this.btnEditDeck.UseVisualStyleBackColor = false;
            this.btnEditDeck.Visible = false;
            this.btnEditDeck.Click += new System.EventHandler(this.btnEditDeck_Click);
            // 
            // DeckSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.btnBackToMainMenu);
            this.Controls.Add(this.PanelDeckList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DeckSelectorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deck Builder - YGO Card Collector 5";
            this.PanelDeckList.ResumeLayout(false);
            this.PanelDeckList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelDeckList;
        private System.Windows.Forms.GroupBox GroupDeckInfo;
        private System.Windows.Forms.ListBox listDeckList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBackToMainMenu;
        private System.Windows.Forms.Button btnEditDeck;
    }
}