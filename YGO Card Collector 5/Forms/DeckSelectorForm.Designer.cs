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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEditDeck = new System.Windows.Forms.Button();
            this.GroupDeckInfo = new System.Windows.Forms.GroupBox();
            this.btnSelectedUpdate = new System.Windows.Forms.Button();
            this.checkEnableEdit = new System.Windows.Forms.CheckBox();
            this.lblSelectedSideDeckCount = new System.Windows.Forms.Label();
            this.lblSelectedExtraDeckCount = new System.Windows.Forms.Label();
            this.lblSelectedMainDeckCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSelectedDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSelectedName = new System.Windows.Forms.TextBox();
            this.lblNewDeckName = new System.Windows.Forms.Label();
            this.listDeckList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBackToMainMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.txtNewDeckDescription = new System.Windows.Forms.TextBox();
            this.lblNewDeckDescription = new System.Windows.Forms.Label();
            this.txtNewDeckName = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblError2 = new System.Windows.Forms.Label();
            this.PanelDeckList.SuspendLayout();
            this.GroupDeckInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelDeckList
            // 
            this.PanelDeckList.BackColor = System.Drawing.Color.Black;
            this.PanelDeckList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelDeckList.Controls.Add(this.btnDelete);
            this.PanelDeckList.Controls.Add(this.btnEditDeck);
            this.PanelDeckList.Controls.Add(this.GroupDeckInfo);
            this.PanelDeckList.Controls.Add(this.listDeckList);
            this.PanelDeckList.Controls.Add(this.label1);
            this.PanelDeckList.Location = new System.Drawing.Point(318, 44);
            this.PanelDeckList.Name = "PanelDeckList";
            this.PanelDeckList.Size = new System.Drawing.Size(282, 411);
            this.PanelDeckList.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(208, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEditDeck
            // 
            this.btnEditDeck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEditDeck.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDeck.Location = new System.Drawing.Point(54, 362);
            this.btnEditDeck.Name = "btnEditDeck";
            this.btnEditDeck.Size = new System.Drawing.Size(169, 42);
            this.btnEditDeck.TabIndex = 3;
            this.btnEditDeck.Text = "Build Deck";
            this.btnEditDeck.UseVisualStyleBackColor = false;
            this.btnEditDeck.Visible = false;
            this.btnEditDeck.Click += new System.EventHandler(this.btnEditDeck_Click);
            // 
            // GroupDeckInfo
            // 
            this.GroupDeckInfo.Controls.Add(this.lblError2);
            this.GroupDeckInfo.Controls.Add(this.btnSelectedUpdate);
            this.GroupDeckInfo.Controls.Add(this.checkEnableEdit);
            this.GroupDeckInfo.Controls.Add(this.lblSelectedSideDeckCount);
            this.GroupDeckInfo.Controls.Add(this.lblSelectedExtraDeckCount);
            this.GroupDeckInfo.Controls.Add(this.lblSelectedMainDeckCount);
            this.GroupDeckInfo.Controls.Add(this.label7);
            this.GroupDeckInfo.Controls.Add(this.label6);
            this.GroupDeckInfo.Controls.Add(this.label5);
            this.GroupDeckInfo.Controls.Add(this.txtSelectedDescription);
            this.GroupDeckInfo.Controls.Add(this.label4);
            this.GroupDeckInfo.Controls.Add(this.txtSelectedName);
            this.GroupDeckInfo.Controls.Add(this.lblNewDeckName);
            this.GroupDeckInfo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupDeckInfo.ForeColor = System.Drawing.Color.Yellow;
            this.GroupDeckInfo.Location = new System.Drawing.Point(12, 181);
            this.GroupDeckInfo.Name = "GroupDeckInfo";
            this.GroupDeckInfo.Size = new System.Drawing.Size(255, 175);
            this.GroupDeckInfo.TabIndex = 2;
            this.GroupDeckInfo.TabStop = false;
            this.GroupDeckInfo.Text = "Deck Info";
            // 
            // btnSelectedUpdate
            // 
            this.btnSelectedUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSelectedUpdate.Enabled = false;
            this.btnSelectedUpdate.Location = new System.Drawing.Point(161, 79);
            this.btnSelectedUpdate.Name = "btnSelectedUpdate";
            this.btnSelectedUpdate.Size = new System.Drawing.Size(69, 23);
            this.btnSelectedUpdate.TabIndex = 16;
            this.btnSelectedUpdate.Text = "Update";
            this.btnSelectedUpdate.UseVisualStyleBackColor = false;
            this.btnSelectedUpdate.Click += new System.EventHandler(this.btnSelectedUpdate_Click);
            // 
            // checkEnableEdit
            // 
            this.checkEnableEdit.AutoSize = true;
            this.checkEnableEdit.Location = new System.Drawing.Point(9, 84);
            this.checkEnableEdit.Name = "checkEnableEdit";
            this.checkEnableEdit.Size = new System.Drawing.Size(152, 16);
            this.checkEnableEdit.TabIndex = 15;
            this.checkEnableEdit.Text = "Enable Name/Desc Edit";
            this.checkEnableEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkEnableEdit.UseVisualStyleBackColor = true;
            this.checkEnableEdit.CheckedChanged += new System.EventHandler(this.checkEnableEdit_CheckedChanged);
            // 
            // lblSelectedSideDeckCount
            // 
            this.lblSelectedSideDeckCount.AutoSize = true;
            this.lblSelectedSideDeckCount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedSideDeckCount.ForeColor = System.Drawing.Color.Yellow;
            this.lblSelectedSideDeckCount.Location = new System.Drawing.Point(134, 154);
            this.lblSelectedSideDeckCount.Name = "lblSelectedSideDeckCount";
            this.lblSelectedSideDeckCount.Size = new System.Drawing.Size(65, 15);
            this.lblSelectedSideDeckCount.TabIndex = 14;
            this.lblSelectedSideDeckCount.Text = "15 Cards";
            // 
            // lblSelectedExtraDeckCount
            // 
            this.lblSelectedExtraDeckCount.AutoSize = true;
            this.lblSelectedExtraDeckCount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedExtraDeckCount.ForeColor = System.Drawing.Color.Yellow;
            this.lblSelectedExtraDeckCount.Location = new System.Drawing.Point(134, 139);
            this.lblSelectedExtraDeckCount.Name = "lblSelectedExtraDeckCount";
            this.lblSelectedExtraDeckCount.Size = new System.Drawing.Size(65, 15);
            this.lblSelectedExtraDeckCount.TabIndex = 13;
            this.lblSelectedExtraDeckCount.Text = "15 Cards";
            // 
            // lblSelectedMainDeckCount
            // 
            this.lblSelectedMainDeckCount.AutoSize = true;
            this.lblSelectedMainDeckCount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedMainDeckCount.ForeColor = System.Drawing.Color.Yellow;
            this.lblSelectedMainDeckCount.Location = new System.Drawing.Point(134, 124);
            this.lblSelectedMainDeckCount.Name = "lblSelectedMainDeckCount";
            this.lblSelectedMainDeckCount.Size = new System.Drawing.Size(65, 15);
            this.lblSelectedMainDeckCount.TabIndex = 12;
            this.lblSelectedMainDeckCount.Text = "60 Cards";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Yellow;
            this.label7.Location = new System.Drawing.Point(50, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Side Deck:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(50, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Extra Deck:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(50, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Main Deck:";
            // 
            // txtSelectedDescription
            // 
            this.txtSelectedDescription.Enabled = false;
            this.txtSelectedDescription.Location = new System.Drawing.Point(61, 55);
            this.txtSelectedDescription.Name = "txtSelectedDescription";
            this.txtSelectedDescription.Size = new System.Drawing.Size(169, 20);
            this.txtSelectedDescription.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(6, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Description:";
            // 
            // txtSelectedName
            // 
            this.txtSelectedName.Enabled = false;
            this.txtSelectedName.Location = new System.Drawing.Point(61, 15);
            this.txtSelectedName.Name = "txtSelectedName";
            this.txtSelectedName.Size = new System.Drawing.Size(169, 20);
            this.txtSelectedName.TabIndex = 6;
            // 
            // lblNewDeckName
            // 
            this.lblNewDeckName.AutoSize = true;
            this.lblNewDeckName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewDeckName.ForeColor = System.Drawing.Color.Yellow;
            this.lblNewDeckName.Location = new System.Drawing.Point(6, 16);
            this.lblNewDeckName.Name = "lblNewDeckName";
            this.lblNewDeckName.Size = new System.Drawing.Size(49, 15);
            this.lblNewDeckName.TabIndex = 4;
            this.lblNewDeckName.Text = "Name:";
            // 
            // listDeckList
            // 
            this.listDeckList.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDeckList.FormattingEnabled = true;
            this.listDeckList.ItemHeight = 15;
            this.listDeckList.Location = new System.Drawing.Point(13, 36);
            this.listDeckList.Name = "listDeckList";
            this.listDeckList.Size = new System.Drawing.Size(255, 139);
            this.listDeckList.TabIndex = 1;
            this.listDeckList.SelectedIndexChanged += new System.EventHandler(this.listDeckList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(9, 4);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblError);
            this.panel1.Controls.Add(this.txtNewDeckDescription);
            this.panel1.Controls.Add(this.lblNewDeckDescription);
            this.panel1.Controls.Add(this.txtNewDeckName);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 300);
            this.panel1.TabIndex = 264;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(9, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Name:";
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblError.Location = new System.Drawing.Point(51, 198);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(191, 33);
            this.lblError.TabIndex = 8;
            this.lblError.Text = "Name must contain ONLY Letters/Numbers";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;
            // 
            // txtNewDeckDescription
            // 
            this.txtNewDeckDescription.Location = new System.Drawing.Point(91, 151);
            this.txtNewDeckDescription.Multiline = true;
            this.txtNewDeckDescription.Name = "txtNewDeckDescription";
            this.txtNewDeckDescription.Size = new System.Drawing.Size(169, 42);
            this.txtNewDeckDescription.TabIndex = 7;
            // 
            // lblNewDeckDescription
            // 
            this.lblNewDeckDescription.AutoSize = true;
            this.lblNewDeckDescription.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewDeckDescription.ForeColor = System.Drawing.Color.Yellow;
            this.lblNewDeckDescription.Location = new System.Drawing.Point(9, 124);
            this.lblNewDeckDescription.Name = "lblNewDeckDescription";
            this.lblNewDeckDescription.Size = new System.Drawing.Size(135, 24);
            this.lblNewDeckDescription.TabIndex = 6;
            this.lblNewDeckDescription.Text = "Description:";
            // 
            // txtNewDeckName
            // 
            this.txtNewDeckName.Location = new System.Drawing.Point(91, 92);
            this.txtNewDeckName.Name = "txtNewDeckName";
            this.txtNewDeckName.Size = new System.Drawing.Size(169, 20);
            this.txtNewDeckName.TabIndex = 5;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCreate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(54, 233);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(169, 42);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(9, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Create New Deck:";
            // 
            // lblError2
            // 
            this.lblError2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblError2.Location = new System.Drawing.Point(6, 102);
            this.lblError2.Name = "lblError2";
            this.lblError2.Size = new System.Drawing.Size(243, 23);
            this.lblError2.TabIndex = 17;
            this.lblError2.Text = "Name must contain ONLY Letters/Numbers";
            this.lblError2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError2.Visible = false;
            // 
            // DeckSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.panel1);
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
            this.GroupDeckInfo.ResumeLayout(false);
            this.GroupDeckInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelDeckList;
        private System.Windows.Forms.GroupBox GroupDeckInfo;
        private System.Windows.Forms.ListBox listDeckList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBackToMainMenu;
        private System.Windows.Forms.Button btnEditDeck;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNewDeckDescription;
        private System.Windows.Forms.Label lblNewDeckDescription;
        private System.Windows.Forms.TextBox txtNewDeckName;
        private System.Windows.Forms.Label lblNewDeckName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtSelectedName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSelectedDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSelectedSideDeckCount;
        private System.Windows.Forms.Label lblSelectedExtraDeckCount;
        private System.Windows.Forms.Label lblSelectedMainDeckCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSelectedUpdate;
        private System.Windows.Forms.CheckBox checkEnableEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblError2;
    }
}