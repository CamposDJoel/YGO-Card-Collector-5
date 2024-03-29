﻿namespace YGO_Card_Collector_5
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
            this.RadioTestModeOFF = new System.Windows.Forms.RadioButton();
            this.RadioTestModeON = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadioHeadlessOFF = new System.Windows.Forms.RadioButton();
            this.RadioHeadlessON = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RadioPackSortingNEW = new System.Windows.Forms.RadioButton();
            this.RadioPackSortingOLD = new System.Windows.Forms.RadioButton();
            this.btnBackToMainMenu = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RadioThemeSlifer = new System.Windows.Forms.RadioButton();
            this.RadioThemeYugiSlifer = new System.Windows.Forms.RadioButton();
            this.RadioThemeBLS = new System.Windows.Forms.RadioButton();
            this.RadioThemeBlueEyesUltimate = new System.Windows.Forms.RadioButton();
            this.RadioThemeTraptrix = new System.Windows.Forms.RadioButton();
            this.RadioThemeDMG = new System.Windows.Forms.RadioButton();
            this.RadioThemeDM = new System.Windows.Forms.RadioButton();
            this.GroupMusic = new System.Windows.Forms.GroupBox();
            this.RadioMusicOFF = new System.Windows.Forms.RadioButton();
            this.RadioMusicON = new System.Windows.Forms.RadioButton();
            this.GroupSFX = new System.Windows.Forms.GroupBox();
            this.RadioSFXOFF = new System.Windows.Forms.RadioButton();
            this.RadioSFXON = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdateTags = new System.Windows.Forms.Button();
            this.txtTagNameCircle = new System.Windows.Forms.TextBox();
            this.txtTagNameTriangle = new System.Windows.Forms.TextBox();
            this.txtTagNameSquare = new System.Windows.Forms.TextBox();
            this.txtTagNameStar = new System.Windows.Forms.TextBox();
            this.btnTagCircle = new System.Windows.Forms.Button();
            this.PicTagCircle = new System.Windows.Forms.PictureBox();
            this.PicTagTriangle = new System.Windows.Forms.PictureBox();
            this.PicTagSquare = new System.Windows.Forms.PictureBox();
            this.PicTagStar = new System.Windows.Forms.PictureBox();
            this.GroupTestMode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.GroupMusic.SuspendLayout();
            this.GroupSFX.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicTagCircle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTagTriangle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTagSquare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTagStar)).BeginInit();
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
            this.GroupTestMode.Location = new System.Drawing.Point(585, 43);
            this.GroupTestMode.Name = "GroupTestMode";
            this.GroupTestMode.Size = new System.Drawing.Size(162, 52);
            this.GroupTestMode.TabIndex = 2;
            this.GroupTestMode.TabStop = false;
            this.GroupTestMode.Text = "DB Update Test Mode";
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.RadioHeadlessOFF);
            this.groupBox1.Controls.Add(this.RadioHeadlessON);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox1.Location = new System.Drawing.Point(585, 109);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(11, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Relaunch App to apply.";
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
            this.btnBackToMainMenu.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToMainMenu.ForeColor = System.Drawing.Color.White;
            this.btnBackToMainMenu.Location = new System.Drawing.Point(8, 6);
            this.btnBackToMainMenu.Name = "btnBackToMainMenu";
            this.btnBackToMainMenu.Size = new System.Drawing.Size(136, 22);
            this.btnBackToMainMenu.TabIndex = 4;
            this.btnBackToMainMenu.Text = "<-- Back to Main Menu";
            this.btnBackToMainMenu.UseVisualStyleBackColor = false;
            this.btnBackToMainMenu.Click += new System.EventHandler(this.btnBackToMainMenu_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.RadioThemeSlifer);
            this.groupBox3.Controls.Add(this.RadioThemeYugiSlifer);
            this.groupBox3.Controls.Add(this.RadioThemeBLS);
            this.groupBox3.Controls.Add(this.RadioThemeBlueEyesUltimate);
            this.groupBox3.Controls.Add(this.RadioThemeTraptrix);
            this.groupBox3.Controls.Add(this.RadioThemeDMG);
            this.groupBox3.Controls.Add(this.RadioThemeDM);
            this.groupBox3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox3.Location = new System.Drawing.Point(327, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 262);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Theme";
            // 
            // RadioThemeSlifer
            // 
            this.RadioThemeSlifer.AutoSize = true;
            this.RadioThemeSlifer.Location = new System.Drawing.Point(15, 174);
            this.RadioThemeSlifer.Name = "RadioThemeSlifer";
            this.RadioThemeSlifer.Size = new System.Drawing.Size(161, 19);
            this.RadioThemeSlifer.TabIndex = 6;
            this.RadioThemeSlifer.Text = "Slifer the Sky Dragon";
            this.RadioThemeSlifer.UseVisualStyleBackColor = true;
            this.RadioThemeSlifer.CheckedChanged += new System.EventHandler(this.RadioThemeSlifer_CheckedChanged);
            // 
            // RadioThemeYugiSlifer
            // 
            this.RadioThemeYugiSlifer.AutoSize = true;
            this.RadioThemeYugiSlifer.Location = new System.Drawing.Point(15, 149);
            this.RadioThemeYugiSlifer.Name = "RadioThemeYugiSlifer";
            this.RadioThemeYugiSlifer.Size = new System.Drawing.Size(92, 19);
            this.RadioThemeYugiSlifer.TabIndex = 5;
            this.RadioThemeYugiSlifer.Text = "Yugi-Slifer";
            this.RadioThemeYugiSlifer.UseVisualStyleBackColor = true;
            this.RadioThemeYugiSlifer.CheckedChanged += new System.EventHandler(this.RadioThemeYugiSlifer_CheckedChanged);
            // 
            // RadioThemeBLS
            // 
            this.RadioThemeBLS.AutoSize = true;
            this.RadioThemeBLS.Location = new System.Drawing.Point(15, 124);
            this.RadioThemeBLS.Name = "RadioThemeBLS";
            this.RadioThemeBLS.Size = new System.Drawing.Size(156, 19);
            this.RadioThemeBLS.TabIndex = 4;
            this.RadioThemeBLS.Text = "Black Luster Soldier";
            this.RadioThemeBLS.UseVisualStyleBackColor = true;
            this.RadioThemeBLS.CheckedChanged += new System.EventHandler(this.RadioThemeBLS_CheckedChanged);
            // 
            // RadioThemeBlueEyesUltimate
            // 
            this.RadioThemeBlueEyesUltimate.AutoSize = true;
            this.RadioThemeBlueEyesUltimate.Location = new System.Drawing.Point(15, 99);
            this.RadioThemeBlueEyesUltimate.Name = "RadioThemeBlueEyesUltimate";
            this.RadioThemeBlueEyesUltimate.Size = new System.Drawing.Size(199, 19);
            this.RadioThemeBlueEyesUltimate.TabIndex = 3;
            this.RadioThemeBlueEyesUltimate.Text = "Blue-Eyes Ultimate Dragon";
            this.RadioThemeBlueEyesUltimate.UseVisualStyleBackColor = true;
            this.RadioThemeBlueEyesUltimate.CheckedChanged += new System.EventHandler(this.RadioThemeBlueEyesUltimate_CheckedChanged);
            // 
            // RadioThemeTraptrix
            // 
            this.RadioThemeTraptrix.AutoSize = true;
            this.RadioThemeTraptrix.Location = new System.Drawing.Point(15, 74);
            this.RadioThemeTraptrix.Name = "RadioThemeTraptrix";
            this.RadioThemeTraptrix.Size = new System.Drawing.Size(77, 19);
            this.RadioThemeTraptrix.TabIndex = 2;
            this.RadioThemeTraptrix.Text = "Traptrix";
            this.RadioThemeTraptrix.UseVisualStyleBackColor = true;
            this.RadioThemeTraptrix.CheckedChanged += new System.EventHandler(this.RadioThemeTraptrix_CheckedChanged);
            // 
            // RadioThemeDMG
            // 
            this.RadioThemeDMG.AutoSize = true;
            this.RadioThemeDMG.Location = new System.Drawing.Point(15, 49);
            this.RadioThemeDMG.Name = "RadioThemeDMG";
            this.RadioThemeDMG.Size = new System.Drawing.Size(145, 19);
            this.RadioThemeDMG.TabIndex = 1;
            this.RadioThemeDMG.Text = "Dark Magician Girl";
            this.RadioThemeDMG.UseVisualStyleBackColor = true;
            this.RadioThemeDMG.CheckedChanged += new System.EventHandler(this.RadioThemeDMG_CheckedChanged);
            // 
            // RadioThemeDM
            // 
            this.RadioThemeDM.AutoSize = true;
            this.RadioThemeDM.Location = new System.Drawing.Point(15, 24);
            this.RadioThemeDM.Name = "RadioThemeDM";
            this.RadioThemeDM.Size = new System.Drawing.Size(118, 19);
            this.RadioThemeDM.TabIndex = 0;
            this.RadioThemeDM.Text = "Dark Magician";
            this.RadioThemeDM.UseVisualStyleBackColor = true;
            this.RadioThemeDM.CheckedChanged += new System.EventHandler(this.RadioThemeDM_CheckedChanged);
            // 
            // GroupMusic
            // 
            this.GroupMusic.BackColor = System.Drawing.Color.Transparent;
            this.GroupMusic.Controls.Add(this.RadioMusicOFF);
            this.GroupMusic.Controls.Add(this.RadioMusicON);
            this.GroupMusic.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupMusic.ForeColor = System.Drawing.Color.Yellow;
            this.GroupMusic.Location = new System.Drawing.Point(32, 126);
            this.GroupMusic.Name = "GroupMusic";
            this.GroupMusic.Size = new System.Drawing.Size(162, 52);
            this.GroupMusic.TabIndex = 6;
            this.GroupMusic.TabStop = false;
            this.GroupMusic.Text = "Music";
            // 
            // RadioMusicOFF
            // 
            this.RadioMusicOFF.AutoSize = true;
            this.RadioMusicOFF.Location = new System.Drawing.Point(73, 24);
            this.RadioMusicOFF.Name = "RadioMusicOFF";
            this.RadioMusicOFF.Size = new System.Drawing.Size(51, 19);
            this.RadioMusicOFF.TabIndex = 1;
            this.RadioMusicOFF.Text = "OFF";
            this.RadioMusicOFF.UseVisualStyleBackColor = true;
            this.RadioMusicOFF.CheckedChanged += new System.EventHandler(this.RadioMusicOFF_CheckedChanged);
            // 
            // RadioMusicON
            // 
            this.RadioMusicON.AutoSize = true;
            this.RadioMusicON.Location = new System.Drawing.Point(15, 24);
            this.RadioMusicON.Name = "RadioMusicON";
            this.RadioMusicON.Size = new System.Drawing.Size(45, 19);
            this.RadioMusicON.TabIndex = 0;
            this.RadioMusicON.Text = "ON";
            this.RadioMusicON.UseVisualStyleBackColor = true;
            this.RadioMusicON.CheckedChanged += new System.EventHandler(this.RadioMusicON_CheckedChanged);
            // 
            // GroupSFX
            // 
            this.GroupSFX.BackColor = System.Drawing.Color.Transparent;
            this.GroupSFX.Controls.Add(this.RadioSFXOFF);
            this.GroupSFX.Controls.Add(this.RadioSFXON);
            this.GroupSFX.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupSFX.ForeColor = System.Drawing.Color.Yellow;
            this.GroupSFX.Location = new System.Drawing.Point(32, 190);
            this.GroupSFX.Name = "GroupSFX";
            this.GroupSFX.Size = new System.Drawing.Size(162, 52);
            this.GroupSFX.TabIndex = 7;
            this.GroupSFX.TabStop = false;
            this.GroupSFX.Text = "SFX";
            // 
            // RadioSFXOFF
            // 
            this.RadioSFXOFF.AutoSize = true;
            this.RadioSFXOFF.Location = new System.Drawing.Point(73, 24);
            this.RadioSFXOFF.Name = "RadioSFXOFF";
            this.RadioSFXOFF.Size = new System.Drawing.Size(51, 19);
            this.RadioSFXOFF.TabIndex = 1;
            this.RadioSFXOFF.Text = "OFF";
            this.RadioSFXOFF.UseVisualStyleBackColor = true;
            this.RadioSFXOFF.CheckedChanged += new System.EventHandler(this.RadioSFXOFF_CheckedChanged);
            // 
            // RadioSFXON
            // 
            this.RadioSFXON.AutoSize = true;
            this.RadioSFXON.Location = new System.Drawing.Point(15, 24);
            this.RadioSFXON.Name = "RadioSFXON";
            this.RadioSFXON.Size = new System.Drawing.Size(45, 19);
            this.RadioSFXON.TabIndex = 0;
            this.RadioSFXON.Text = "ON";
            this.RadioSFXON.UseVisualStyleBackColor = true;
            this.RadioSFXON.CheckedChanged += new System.EventHandler(this.RadioSFXON_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.btnUpdateTags);
            this.groupBox4.Controls.Add(this.txtTagNameCircle);
            this.groupBox4.Controls.Add(this.txtTagNameTriangle);
            this.groupBox4.Controls.Add(this.txtTagNameSquare);
            this.groupBox4.Controls.Add(this.txtTagNameStar);
            this.groupBox4.Controls.Add(this.btnTagCircle);
            this.groupBox4.Controls.Add(this.PicTagCircle);
            this.groupBox4.Controls.Add(this.PicTagTriangle);
            this.groupBox4.Controls.Add(this.PicTagSquare);
            this.groupBox4.Controls.Add(this.PicTagStar);
            this.groupBox4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox4.Location = new System.Drawing.Point(32, 253);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(165, 196);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Custom Tag\'s Names";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(5, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 26);
            this.label2.TabIndex = 297;
            this.label2.Text = "Custom names cannot be empty of contain \"|\"";
            // 
            // btnUpdateTags
            // 
            this.btnUpdateTags.BackColor = System.Drawing.Color.Black;
            this.btnUpdateTags.Location = new System.Drawing.Point(46, 144);
            this.btnUpdateTags.Name = "btnUpdateTags";
            this.btnUpdateTags.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateTags.TabIndex = 296;
            this.btnUpdateTags.Text = "UPDATE";
            this.btnUpdateTags.UseVisualStyleBackColor = false;
            this.btnUpdateTags.Click += new System.EventHandler(this.btnUpdateTags_Click);
            // 
            // txtTagNameCircle
            // 
            this.txtTagNameCircle.Location = new System.Drawing.Point(50, 116);
            this.txtTagNameCircle.Name = "txtTagNameCircle";
            this.txtTagNameCircle.Size = new System.Drawing.Size(100, 23);
            this.txtTagNameCircle.TabIndex = 295;
            // 
            // txtTagNameTriangle
            // 
            this.txtTagNameTriangle.Location = new System.Drawing.Point(50, 87);
            this.txtTagNameTriangle.Name = "txtTagNameTriangle";
            this.txtTagNameTriangle.Size = new System.Drawing.Size(100, 23);
            this.txtTagNameTriangle.TabIndex = 294;
            // 
            // txtTagNameSquare
            // 
            this.txtTagNameSquare.Location = new System.Drawing.Point(50, 58);
            this.txtTagNameSquare.Name = "txtTagNameSquare";
            this.txtTagNameSquare.Size = new System.Drawing.Size(100, 23);
            this.txtTagNameSquare.TabIndex = 293;
            // 
            // txtTagNameStar
            // 
            this.txtTagNameStar.Location = new System.Drawing.Point(50, 28);
            this.txtTagNameStar.Name = "txtTagNameStar";
            this.txtTagNameStar.Size = new System.Drawing.Size(100, 23);
            this.txtTagNameStar.TabIndex = 292;
            // 
            // btnTagCircle
            // 
            this.btnTagCircle.BackColor = System.Drawing.Color.Black;
            this.btnTagCircle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTagCircle.BackgroundImage")));
            this.btnTagCircle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTagCircle.Location = new System.Drawing.Point(-140, 104);
            this.btnTagCircle.Name = "btnTagCircle";
            this.btnTagCircle.Size = new System.Drawing.Size(30, 30);
            this.btnTagCircle.TabIndex = 287;
            this.btnTagCircle.UseVisualStyleBackColor = false;
            // 
            // PicTagCircle
            // 
            this.PicTagCircle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicTagCircle.Image = ((System.Drawing.Image)(resources.GetObject("PicTagCircle.Image")));
            this.PicTagCircle.Location = new System.Drawing.Point(14, 109);
            this.PicTagCircle.Name = "PicTagCircle";
            this.PicTagCircle.Size = new System.Drawing.Size(30, 30);
            this.PicTagCircle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicTagCircle.TabIndex = 291;
            this.PicTagCircle.TabStop = false;
            // 
            // PicTagTriangle
            // 
            this.PicTagTriangle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicTagTriangle.Image = ((System.Drawing.Image)(resources.GetObject("PicTagTriangle.Image")));
            this.PicTagTriangle.Location = new System.Drawing.Point(14, 80);
            this.PicTagTriangle.Name = "PicTagTriangle";
            this.PicTagTriangle.Size = new System.Drawing.Size(30, 30);
            this.PicTagTriangle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicTagTriangle.TabIndex = 290;
            this.PicTagTriangle.TabStop = false;
            // 
            // PicTagSquare
            // 
            this.PicTagSquare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicTagSquare.Image = ((System.Drawing.Image)(resources.GetObject("PicTagSquare.Image")));
            this.PicTagSquare.Location = new System.Drawing.Point(14, 51);
            this.PicTagSquare.Name = "PicTagSquare";
            this.PicTagSquare.Size = new System.Drawing.Size(30, 30);
            this.PicTagSquare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicTagSquare.TabIndex = 289;
            this.PicTagSquare.TabStop = false;
            // 
            // PicTagStar
            // 
            this.PicTagStar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicTagStar.Image = ((System.Drawing.Image)(resources.GetObject("PicTagStar.Image")));
            this.PicTagStar.Location = new System.Drawing.Point(14, 22);
            this.PicTagStar.Name = "PicTagStar";
            this.PicTagStar.Size = new System.Drawing.Size(30, 30);
            this.PicTagStar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicTagStar.TabIndex = 288;
            this.PicTagStar.TabStop = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.GroupSFX);
            this.Controls.Add(this.GroupMusic);
            this.Controls.Add(this.groupBox3);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.GroupMusic.ResumeLayout(false);
            this.GroupMusic.PerformLayout();
            this.GroupSFX.ResumeLayout(false);
            this.GroupSFX.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicTagCircle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTagTriangle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTagSquare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTagStar)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton RadioThemeDM;
        private System.Windows.Forms.RadioButton RadioThemeTraptrix;
        private System.Windows.Forms.RadioButton RadioThemeDMG;
        private System.Windows.Forms.RadioButton RadioThemeBlueEyesUltimate;
        private System.Windows.Forms.GroupBox GroupMusic;
        private System.Windows.Forms.RadioButton RadioMusicOFF;
        private System.Windows.Forms.RadioButton RadioMusicON;
        private System.Windows.Forms.GroupBox GroupSFX;
        private System.Windows.Forms.RadioButton RadioSFXOFF;
        private System.Windows.Forms.RadioButton RadioSFXON;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnTagCircle;
        private System.Windows.Forms.PictureBox PicTagCircle;
        private System.Windows.Forms.PictureBox PicTagTriangle;
        private System.Windows.Forms.PictureBox PicTagSquare;
        private System.Windows.Forms.PictureBox PicTagStar;
        private System.Windows.Forms.Button btnUpdateTags;
        private System.Windows.Forms.TextBox txtTagNameCircle;
        private System.Windows.Forms.TextBox txtTagNameTriangle;
        private System.Windows.Forms.TextBox txtTagNameSquare;
        private System.Windows.Forms.TextBox txtTagNameStar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RadioThemeSlifer;
        private System.Windows.Forms.RadioButton RadioThemeYugiSlifer;
        private System.Windows.Forms.RadioButton RadioThemeBLS;
    }
}