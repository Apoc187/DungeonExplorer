using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DungeonExplorer.MainGameHandling;
using static System.Windows.Forms.AxHost;

namespace DungeonExplorer
{
    public partial class FormEvents : Form
    {
        ////<summary>
        ////Required designer variable.
        ////</summary>
        //private System.ComponentModel.IContainer components = null;

        ////<summary>
        ////Clean up any resources being used.
        ////</summary>
        ////<param name = "disposing" > true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        // <summary>
        // /Required method for Designer support - do not modify
        // /the contents of this method with the code editor.
        // </summary>




        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Button action1 { get; set; }
        public System.Windows.Forms.Button action2 { get; set; }
        public System.Windows.Forms.Button action3 { get; set; }
        public System.Windows.Forms.Button action6 { get; set; }
        public System.Windows.Forms.Button action5 { get; set; }
        public System.Windows.Forms.Button action4 { get; set; }
        public System.Windows.Forms.Button action9 { get; set; }
        public System.Windows.Forms.Button action8 { get; set; }
        public System.Windows.Forms.Button action7 { get; set; }


        public System.Windows.Forms.Button TextLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label currentLocation;
        private System.Windows.Forms.Label extraInfo;
        private System.Windows.Forms.ProgressBar healthBar;
        private System.Windows.Forms.Label HealthLabel;
        private System.Windows.Forms.Label EnergyLabel;
        private System.Windows.Forms.ProgressBar energyBar;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TabPage Inspect;
        private System.Windows.Forms.TabPage Situation;
        private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.TabControl gameMenus;
        private System.Windows.Forms.Label StartMenuText;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Panel StartMenuPanel;
        private System.Windows.Forms.FlowLayoutPanel ClassPanel;
        //private System.Windows.Forms.RadioButton classRadio1;
        //private System.Windows.Forms.RadioButton classRadio2;
        //private System.Windows.Forms.RadioButton classRadio3;
        //private System.Windows.Forms.RadioButton classRadio4;
        //private System.Windows.Forms.RadioButton classRadio5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label StartMenuText2;
        private System.Windows.Forms.Label Title3;
        private System.Windows.Forms.Label Title2;
        private System.Windows.Forms.Label Title1;
        private System.Windows.Forms.Button startButton;
        #endregion


        public void InitializeComponent()
        {

            {


                this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
                this.action1 = new System.Windows.Forms.Button();
                this.action2 = new System.Windows.Forms.Button();
                this.action3 = new System.Windows.Forms.Button();
                this.action6 = new System.Windows.Forms.Button();
                this.action5 = new System.Windows.Forms.Button();
                this.action4 = new System.Windows.Forms.Button();
                this.action9 = new System.Windows.Forms.Button();
                this.action8 = new System.Windows.Forms.Button();
                this.action7 = new System.Windows.Forms.Button();
                this.pictureBox1 = new System.Windows.Forms.PictureBox();
                this.currentLocation = new System.Windows.Forms.Label();
                this.extraInfo = new System.Windows.Forms.Label();
                this.TextLabel = new System.Windows.Forms.Button();
                this.healthBar = new System.Windows.Forms.ProgressBar();
                this.HealthLabel = new System.Windows.Forms.Label();
                this.EnergyLabel = new System.Windows.Forms.Label();
                this.energyBar = new System.Windows.Forms.ProgressBar();
                this.nameLabel = new System.Windows.Forms.Label();
                this.Inspect = new System.Windows.Forms.TabPage();
                this.Situation = new System.Windows.Forms.TabPage();
                this.label1 = new System.Windows.Forms.Label();
                //this.gameMenus = new System.Windows.Forms.TabControl();
                this.StartMenuText = new System.Windows.Forms.Label();
                this.nameInput = new System.Windows.Forms.TextBox();
                this.StartMenuPanel = new System.Windows.Forms.Panel();
                this.startButton = new System.Windows.Forms.Button();
                this.Title3 = new System.Windows.Forms.Label();
                this.Title2 = new System.Windows.Forms.Label();
                this.Title1 = new System.Windows.Forms.Label();
                this.StartMenuText2 = new System.Windows.Forms.Label();
                this.ClassPanel = new System.Windows.Forms.FlowLayoutPanel();
                //this.classRadio1 = new System.Windows.Forms.RadioButton();
                //this.classRadio2 = new System.Windows.Forms.RadioButton();
                //this.classRadio3 = new System.Windows.Forms.RadioButton();
                //this.classRadio4 = new System.Windows.Forms.RadioButton();
                //this.classRadio5 = new System.Windows.Forms.RadioButton();
                this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                this.Situation.SuspendLayout();
                //this.gameMenus.SuspendLayout();
                this.StartMenuPanel.SuspendLayout();
                this.ClassPanel.SuspendLayout();
                this.SuspendLayout();
                // 
                // flowLayoutPanel1
                // 
                this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
                this.flowLayoutPanel1.Name = "flowLayoutPanel1";
                this.flowLayoutPanel1.Size = new System.Drawing.Size(240, 205);
                this.flowLayoutPanel1.TabIndex = 0;



                //
                // TextLabel
                //
                this.TextLabel.Location = new System.Drawing.Point(12, 12);
                this.TextLabel.Name = "TextLabel";
                this.TextLabel.Size = new System.Drawing.Size(348, 322);
                this.TextLabel.TabIndex = 0;
                this.TextLabel.Text = "this piece of doodoo doesnt wanna update its text so just click to view the current text";
                this.TextLabel.Click += new System.EventHandler(this.temp_Click);
                this.TextLabel.Update();
                Console.WriteLine(Player.Instance.Get_DescString());

                // 
                // action1
                // 
                this.action1.Location = new System.Drawing.Point(377, 165);
                this.action1.Name = "action1";
                this.action1.Size = new System.Drawing.Size(117, 95);
                this.action1.TabIndex = 1;
                this.action1.Text = "nullAction";
                this.action1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                this.action1.UseVisualStyleBackColor = true;
                this.action1.Click += new System.EventHandler(this.Action1_Click);
                // 
                // action2
                // 
                this.action2.Location = new System.Drawing.Point(500, 165);
                this.action2.Name = "action2";
                this.action2.Size = new System.Drawing.Size(117, 95);
                this.action2.TabIndex = 2;
                this.action2.Text = "nullAction";
                this.action2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                this.action2.UseVisualStyleBackColor = true;
                this.action2.Click += new System.EventHandler(this.Action2_Click);
                // 
                // action3
                // 
                this.action3.Location = new System.Drawing.Point(623, 165);
                this.action3.Name = "action3";
                this.action3.Size = new System.Drawing.Size(117, 95);
                this.action3.TabIndex = 3;
                this.action3.Text = "nullAction";
                this.action3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                this.action3.UseVisualStyleBackColor = true;
                this.action3.Click += new System.EventHandler(this.Action3_Click);
                // 
                // action6
                // 
                this.action6.Location = new System.Drawing.Point(623, 265);
                this.action6.Name = "action6";
                this.action6.Size = new System.Drawing.Size(117, 95);
                this.action6.TabIndex = 6;
                this.action6.Text = "nullAction";
                this.action6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                this.action6.UseVisualStyleBackColor = true;
                this.action6.Click += new System.EventHandler(this.Action6_Click);
                // 
                // action5
                // 
                this.action5.Location = new System.Drawing.Point(500, 266);
                this.action5.Name = "action5";
                this.action5.Size = new System.Drawing.Size(117, 95);
                this.action5.TabIndex = 5;
                this.action5.Text = "nullAction";
                this.action5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                this.action5.UseVisualStyleBackColor = true;
                this.action5.Click += new System.EventHandler(this.Action5_Click);
                // 
                // action4
                // 
                this.action4.Location = new System.Drawing.Point(377, 266);
                this.action4.Name = "action4";
                this.action4.Size = new System.Drawing.Size(117, 95);
                this.action4.TabIndex = 4;
                this.action4.Text = "nullAction";
                this.action4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                this.action4.UseVisualStyleBackColor = true;
                this.action4.Click += new System.EventHandler(this.Action4_Click);
                // 
                // action9
                // 
                this.action9.Location = new System.Drawing.Point(623, 366);
                this.action9.Name = "action9";
                this.action9.Size = new System.Drawing.Size(117, 95);
                this.action9.TabIndex = 9;
                this.action9.Text = "nullAction";
                this.action9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                this.action9.UseVisualStyleBackColor = true;
                this.action9.Click += new System.EventHandler(this.Action9_Click);
                // 
                // action8
                // 
                this.action8.Location = new System.Drawing.Point(500, 366);
                this.action8.Name = "action8";
                this.action8.Size = new System.Drawing.Size(117, 95);
                this.action8.TabIndex = 8;
                this.action8.Text = "nullAction";
                this.action8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                this.action8.UseVisualStyleBackColor = true;
                this.action8.Click += new System.EventHandler(this.Action8_Click);
                // 
                // action7
                // 
                this.action7.Location = new System.Drawing.Point(377, 366);
                this.action7.Name = "action7";
                this.action7.Size = new System.Drawing.Size(117, 95);
                this.action7.TabIndex = 7;
                this.action7.Text = "nullAction";
                this.action7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                this.action7.UseVisualStyleBackColor = true;
                this.action7.Click += new System.EventHandler(this.Action7_Click);
                // 
                // pictureBox1
                // 
                this.pictureBox1.Location = new System.Drawing.Point(377, 9);
                this.pictureBox1.Name = "pictureBox1";
                this.pictureBox1.Size = new System.Drawing.Size(362, 128);
                this.pictureBox1.TabIndex = 10;
                this.pictureBox1.TabStop = false;
                // 
                // currentLocation
                // 
                this.currentLocation.AutoSize = true;
                this.currentLocation.Location = new System.Drawing.Point(374, 149);
                this.currentLocation.Name = "currentLocation";
                this.currentLocation.RightToLeft = System.Windows.Forms.RightToLeft.No;
                this.currentLocation.Size = new System.Drawing.Size(64, 13);
                this.currentLocation.TabIndex = 11;
                this.currentLocation.Text = " ";
                // 
                // extraInfo
                // 
                this.extraInfo.AutoSize = true;
                this.extraInfo.Location = new System.Drawing.Point(620, 149);
                this.extraInfo.Name = "extraInfo";
                this.extraInfo.Size = new System.Drawing.Size(41, 13);
                this.extraInfo.TabIndex = 12;
                this.extraInfo.Text = " ";
                // 
                // healthBar
                // 
                this.healthBar.Location = new System.Drawing.Point(178, 409);
                this.healthBar.Name = "healthBar";
                this.healthBar.Size = new System.Drawing.Size(193, 13);
                this.healthBar.Step = 1;
                this.healthBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
                this.healthBar.TabIndex = 14;
                this.healthBar.Value = 100;
                this.healthBar.Visible = false;
                // 
                // HealthLabel
                // 
                this.HealthLabel.AutoSize = true;
                this.HealthLabel.Location = new System.Drawing.Point(134, 409);
                this.HealthLabel.Name = "HealthLabel";
                this.HealthLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
                this.HealthLabel.Size = new System.Drawing.Size(38, 13);
                this.HealthLabel.TabIndex = 15;
                this.HealthLabel.Text = " ";
                // 
                // EnergyLabel
                // 
                this.EnergyLabel.AutoSize = true;
                this.EnergyLabel.Location = new System.Drawing.Point(134, 428);
                this.EnergyLabel.Name = "EnergyLabel";
                this.EnergyLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
                this.EnergyLabel.Size = new System.Drawing.Size(40, 13);
                this.EnergyLabel.TabIndex = 17;
                this.EnergyLabel.Text = " ";
                // 
                // energyBar
                // 
                this.energyBar.BackColor = System.Drawing.SystemColors.Control;
                this.energyBar.Location = new System.Drawing.Point(178, 428);
                this.energyBar.Name = "energyBar";
                this.energyBar.Size = new System.Drawing.Size(193, 13);
                this.energyBar.Step = 1;
                this.energyBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
                this.energyBar.TabIndex = 16;
                this.energyBar.Value = 100;
                this.energyBar.Visible = false;
                // 
                // nameLabel
                // 
                this.nameLabel.AutoSize = true;
                this.nameLabel.Location = new System.Drawing.Point(16, 415);
                this.nameLabel.Name = "nameLabel";
                this.nameLabel.Size = new System.Drawing.Size(51, 13);
                this.nameLabel.TabIndex = 18;
                this.nameLabel.Text = " ";
                // 
                // Inspect
                // 
                //this.Inspect.Location = new System.Drawing.Point(4, 22);
                //this.Inspect.Name = "Inspect";
                //this.Inspect.Padding = new System.Windows.Forms.Padding(3);
                //this.Inspect.Size = new System.Drawing.Size(348, 322);
                //this.Inspect.TabIndex = 1;
                //this.Inspect.Text = "Inspect";
                //this.Inspect.UseVisualStyleBackColor = true;

                // 
                // Situation

                //this.Situation.Location = new System.Drawing.Point(4, 22);
                //this.Situation.Name = "Situation";
                //this.Situation.Padding = new System.Windows.Forms.Padding(3);
                //this.Situation.Size = new System.Drawing.Size(348, 322);
                //this.Situation.TabIndex = 0;
                //this.Situation.Text = "Situation";
                //this.Situation.UseVisualStyleBackColor = true;
                //this.Situation.Click += new System.EventHandler(this.Situation_Click);
                // 
                // label1
                // 
                this.label1.Location = new System.Drawing.Point(0, 0);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(100, 23);
                this.label1.TabIndex = 0;


                // 
                // gameMenus
                // 

                //this.gameMenus.Controls.Add(this.Situation);
                //this.gameMenus.Controls.Add(this.Inspect);
                //this.gameMenus.Location = new System.Drawing.Point(12, 12);
                //this.gameMenus.Name = "gameMenus";
                //this.gameMenus.SelectedIndex = 0;
                //this.gameMenus.Size = new System.Drawing.Size(356, 348);
                //this.gameMenus.TabIndex = 22;
                // 
                // StartMenuText
                // 
                this.StartMenuText.AutoSize = true;
                this.StartMenuText.Location = new System.Drawing.Point(16, 12);
                this.StartMenuText.Name = "StartMenuText";
                this.StartMenuText.Size = new System.Drawing.Size(607, 13);
                this.StartMenuText.TabIndex = 0;
                this.StartMenuText.Text = "Woah there! Before you play the game, you need to pick one of the options. Either" +
        " create a new character, or load a past save.";
                // 
                // nameInput
                // 
                this.nameInput.Location = new System.Drawing.Point(42, 97);
                this.nameInput.Name = "nameInput";
                this.nameInput.Size = new System.Drawing.Size(418, 20);
                this.nameInput.TabIndex = 1;
                this.nameInput.Text = "Ian";
                // 
                // StartMenuPanel
                // 
                this.StartMenuPanel.Controls.Add(this.startButton);
                this.StartMenuPanel.Controls.Add(this.Title3);
                this.StartMenuPanel.Controls.Add(this.Title2);
                this.StartMenuPanel.Controls.Add(this.Title1);
                this.StartMenuPanel.Controls.Add(this.StartMenuText2);
                this.StartMenuPanel.Controls.Add(this.ClassPanel);
                this.StartMenuPanel.Controls.Add(this.nameInput);
                this.StartMenuPanel.Controls.Add(this.StartMenuText);
                this.StartMenuPanel.Controls.Add(this.flowLayoutPanel3);
                this.StartMenuPanel.Location = new System.Drawing.Point(0, 0);
                this.StartMenuPanel.Name = "StartMenuPanel";
                this.StartMenuPanel.Size = new System.Drawing.Size(748, 469);
                this.StartMenuPanel.TabIndex = 23;
                // 
                // startButton
                // 
                this.startButton.Location = new System.Drawing.Point(42, 407);
                this.startButton.Name = "startButton";
                this.startButton.Size = new System.Drawing.Size(419, 23);
                this.startButton.TabIndex = 14;
                this.startButton.Text = "Start";
                this.startButton.UseVisualStyleBackColor = true;
                this.startButton.Click += new System.EventHandler(this.startButton_Click);
                // 
                // Title3
                // 
                this.Title3.AutoSize = true;
                this.Title3.Location = new System.Drawing.Point(42, 268);
                this.Title3.Name = "Title3";
                this.Title3.Size = new System.Drawing.Size(101, 13);
                this.Title3.TabIndex = 13;
                this.Title3.Text = "Optional Challenges";
                // 
                // Title2
                // 
                this.Title2.AutoSize = true;
                this.Title2.Location = new System.Drawing.Point(42, 126);
                this.Title2.Name = "Title2";
                this.Title2.Size = new System.Drawing.Size(32, 13);
                this.Title2.TabIndex = 12;
                this.Title2.Text = "Class";
                // 
                // Title1
                // 
                this.Title1.AutoSize = true;
                this.Title1.Location = new System.Drawing.Point(42, 81);
                this.Title1.Name = "Title1";
                this.Title1.Size = new System.Drawing.Size(35, 13);
                this.Title1.TabIndex = 11;
                this.Title1.Text = "Name";
                // 
                // StartMenuText2
                // 
                this.StartMenuText2.AutoSize = true;
                this.StartMenuText2.Location = new System.Drawing.Point(16, 37);
                this.StartMenuText2.Name = "StartMenuText2";
                this.StartMenuText2.Size = new System.Drawing.Size(597, 13);
                this.StartMenuText2.TabIndex = 10;
                this.StartMenuText2.Text = "Choose a name and class for yourself, and if you\'re up for an extra challenge, ad" +
        "d some Challenges to make the game harder!";
                // 
                // ClassPanel
                // 
                //this.ClassPanel.Controls.Add(this.classRadio1);
                //this.ClassPanel.Controls.Add(this.classRadio2);
                //this.ClassPanel.Controls.Add(this.classRadio3);
                //this.ClassPanel.Controls.Add(this.classRadio4);
                //this.ClassPanel.Controls.Add(this.classRadio5);
                this.ClassPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
                this.ClassPanel.Location = new System.Drawing.Point(42, 142);
                this.ClassPanel.Name = "ClassPanel";
                this.ClassPanel.Size = new System.Drawing.Size(419, 118);
                this.ClassPanel.TabIndex = 2;
                // 
                // classRadio1
                // 
                //this.classRadio1.AutoSize = true;
                //this.classRadio1.Checked = true;
                //this.classRadio1.Location = new System.Drawing.Point(3, 3);
                //this.classRadio1.Name = "classRadio1";
                //this.classRadio1.Size = new System.Drawing.Size(415, 17);
                //this.classRadio1.TabIndex = 5;
                //this.classRadio1.TabStop = true;
                //this.classRadio1.Text = "Planetary Defense (No Stat Bonus, Spawn with Handgun and 7 Handgun Rounds)";
                //this.classRadio1.UseVisualStyleBackColor = true;
                //// 
                //// classRadio2
                //// 
                //this.classRadio2.AutoSize = true;
                //this.classRadio2.Location = new System.Drawing.Point(3, 26);
                //this.classRadio2.Name = "classRadio2";
                //this.classRadio2.Size = new System.Drawing.Size(185, 17);
                //this.classRadio2.TabIndex = 4;
                //this.classRadio2.Text = "Shock Trooper (+3 STR, +2 DEX)";
                //this.classRadio2.UseVisualStyleBackColor = true;
                //// 
                //// classRadio3
                //// 
                //this.classRadio3.AutoSize = true;
                //this.classRadio3.Location = new System.Drawing.Point(3, 49);
                //this.classRadio3.Name = "classRadio3";
                //this.classRadio3.Size = new System.Drawing.Size(296, 17);
                //this.classRadio3.TabIndex = 6;
                //this.classRadio3.Text = "Pilot (+1 DEX, +2 INT, Spawn with Flare and Wing Blade)";
                //this.classRadio3.UseVisualStyleBackColor = true;
                //// 
                //// classRadio4
                //// 
                //this.classRadio4.AutoSize = true;
                //this.classRadio4.Location = new System.Drawing.Point(3, 72);
                //this.classRadio4.Name = "classRadio4";
                //this.classRadio4.Size = new System.Drawing.Size(284, 17);
                //this.classRadio4.TabIndex = 7;
                //this.classRadio4.Text = "Marine Commando (+4 STR, Able to melee all enemies)";
                //this.classRadio4.UseVisualStyleBackColor = true;
                //// 
                //// classRadio5
                //// 
                //this.classRadio5.AutoSize = true;
                //this.classRadio5.Location = new System.Drawing.Point(3, 95);
                //this.classRadio5.Name = "classRadio5";
                //this.classRadio5.Size = new System.Drawing.Size(244, 17);
                //this.classRadio5.TabIndex = 8;
                //this.classRadio5.Text = "Scientist (+1 DEX, +4 INT, Special Interfacing)";
                //this.classRadio5.UseVisualStyleBackColor = true;
                // 
                // flowLayoutPanel3
                // 
                this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
                this.flowLayoutPanel3.Location = new System.Drawing.Point(42, 284);
                this.flowLayoutPanel3.Name = "flowLayoutPanel3";
                this.flowLayoutPanel3.Size = new System.Drawing.Size(418, 117);
                this.flowLayoutPanel3.TabIndex = 9;
                // 
                // FormEvents
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(752, 473);
                this.Controls.Add(this.StartMenuPanel);
                //this.Controls.Add(this.gameMenus);
                this.Controls.Add(this.nameLabel);
                this.Controls.Add(this.EnergyLabel);
                this.Controls.Add(this.energyBar);
                this.Controls.Add(this.HealthLabel);
                this.Controls.Add(this.healthBar);
                this.Controls.Add(this.extraInfo);
                this.Controls.Add(this.currentLocation);
                this.Controls.Add(this.pictureBox1);
                this.Controls.Add(this.TextLabel);
                this.Controls.Add(this.action9);
                this.Controls.Add(this.action8);
                this.Controls.Add(this.action7);
                this.Controls.Add(this.action6);
                this.Controls.Add(this.action5);
                this.Controls.Add(this.action4);
                this.Controls.Add(this.action3);
                this.Controls.Add(this.action2);
                this.Controls.Add(this.action1);
                this.Controls.Add(this.flowLayoutPanel1);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                this.Name = "FormEvents";
                this.Text = "Game";
                this.Load += new System.EventHandler(this.Form1_Load);
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                this.Situation.ResumeLayout(false);
                //this.gameMenus.ResumeLayout(false);

                Dictionary<GridButton_States, Dictionary<int, string>> Actions = new Dictionary<GridButton_States, Dictionary<int, string>>
                {
                    {GridButton_States.Navigation, new Dictionary<int, string>{ { 1, " " }, { 2, "North" }, { 3, " " }, { 4, "West" }, { 5, "Rest" }, { 6, "East" }, { 7, " " }, { 8, "South" }, { 9, " " } } },
                    {GridButton_States.Misc, new Dictionary<int, string>{ { 1, "Interact" }, { 2, " " }, { 3, "Don't Interact" }, { 4, " " }, { 5, " " }, { 6, " " }, { 7, " " }, { 8, " " }, { 9, " " } } },
                    {GridButton_States.Combat, new Dictionary<int, string>{ { 1, "Primary Weapon" }, { 2, "Punch" }, { 3, "Secondary Weapon" }, { 4, " " }, { 5, " " }, { 6, " " }, { 7, " " }, { 8, " " }, { 9, " " } } },
                    {GridButton_States.Inventory, new Dictionary<int, string>{ { 1, "Left Jacket Pocket" }, { 2, "Backpack" }, { 3, "Right Jacket Pocket" }, { 4, "Left Pant Pocket" }, { 5, "Backpack" }, { 6, "Right Pant Pocket" }, { 7, "Left Cargo Pocket" }, { 8, "Waist Pouch" }, { 9, "Right Cargo Pocket" } } },
                    {GridButton_States.InvItem, new Dictionary<int, string>{ { 1, "Consume" }, { 2, "Back" }, { 3, "Drop" }, { 4, " " }, { 5, " " }, { 6, " " }, { 7, " " }, { 8, " " }, { 9, " " } } },
                };




                //action1.Text = Actions[Player.Instance.CurrentState][1];
                //action2.Text = Actions[Player.Instance.CurrentState][2];
                //action3.Text = Actions[Player.Instance.CurrentState][3];
                //action4.Text = Actions[Player.Instance.CurrentState][4];
                //action5.Text = Actions[Player.Instance.CurrentState][5];
                //action6.Text = Actions[Player.Instance.CurrentState][6];
                //action7.Text = Actions[Player.Instance.CurrentState][7];
                //action8.Text = Actions[Player.Instance.CurrentState][8];
                //action9.Text = Actions[Player.Instance.CurrentState][9];
                action1.Text = "Action1";
                action2.Text = "Action2";
                action3.Text = "Action3";
                action4.Text = "Action4";
                action5.Text = "Action5";
                action6.Text = "Action6";
                action7.Text = "Action7";
                action8.Text = "Action8";
                action9.Text = "Action9";




                //.Situation.ResumeLayout(false);
                //this.gameMenus.ResumeLayout(false);
                this.StartMenuPanel.ResumeLayout(false);
                this.StartMenuPanel.PerformLayout();
                this.ClassPanel.ResumeLayout(false);
                this.ClassPanel.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();
            }
        }
    }
}
        

   

        
    
