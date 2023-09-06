
namespace ScreenTranslator
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelYOffset = new System.Windows.Forms.Label();
            this.labelXOffset = new System.Windows.Forms.Label();
            this.numericUpDownYOffset = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownXOffset = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBoxTranslationBehavior = new System.Windows.Forms.ComboBox();
            this.textBoxTrigger = new System.Windows.Forms.TextBox();
            this.checkBoxMinimizeToTray = new System.Windows.Forms.CheckBox();
            this.comboBoxSourceLanguage = new System.Windows.Forms.ComboBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonTextbox = new System.Windows.Forms.RadioButton();
            this.radioButtonLabel = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTrigger = new System.Windows.Forms.Label();
            this.labelTranslationBehavior = new System.Windows.Forms.Label();
            this.groupBoxApplication = new System.Windows.Forms.GroupBox();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.checkBoxTopMost = new System.Windows.Forms.CheckBox();
            this.checkBoxStartup = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBoxAbout = new System.Windows.Forms.GroupBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemBalloonTips = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXOffset)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxApplication.SuspendLayout();
            this.groupBoxAbout.SuspendLayout();
            this.contextMenuStripTrayIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelYOffset
            // 
            this.labelYOffset.AutoSize = true;
            this.labelYOffset.Location = new System.Drawing.Point(17, 26);
            this.labelYOffset.Name = "labelYOffset";
            this.labelYOffset.Size = new System.Drawing.Size(45, 13);
            this.labelYOffset.TabIndex = 0;
            this.labelYOffset.Text = "Y Offset";
            this.toolTip1.SetToolTip(this.labelYOffset, "Number of pixels to move down each translation overlay");
            // 
            // labelXOffset
            // 
            this.labelXOffset.AutoSize = true;
            this.labelXOffset.Location = new System.Drawing.Point(17, 62);
            this.labelXOffset.Name = "labelXOffset";
            this.labelXOffset.Size = new System.Drawing.Size(45, 13);
            this.labelXOffset.TabIndex = 2;
            this.labelXOffset.Text = "X Offset";
            this.toolTip1.SetToolTip(this.labelXOffset, "Number of pixels to move right each translation overlay");
            // 
            // numericUpDownYOffset
            // 
            this.numericUpDownYOffset.Location = new System.Drawing.Point(68, 24);
            this.numericUpDownYOffset.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownYOffset.Name = "numericUpDownYOffset";
            this.numericUpDownYOffset.Size = new System.Drawing.Size(77, 20);
            this.numericUpDownYOffset.TabIndex = 3;
            this.toolTip1.SetToolTip(this.numericUpDownYOffset, "Positive for downward bias");
            this.numericUpDownYOffset.ValueChanged += new System.EventHandler(this.numericUpDownYOffset_ValueChanged);
            // 
            // numericUpDownXOffset
            // 
            this.numericUpDownXOffset.Location = new System.Drawing.Point(68, 60);
            this.numericUpDownXOffset.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownXOffset.Name = "numericUpDownXOffset";
            this.numericUpDownXOffset.Size = new System.Drawing.Size(77, 20);
            this.numericUpDownXOffset.TabIndex = 4;
            this.toolTip1.SetToolTip(this.numericUpDownXOffset, "Positive for rightward bias");
            this.numericUpDownXOffset.ValueChanged += new System.EventHandler(this.numericUpDownXOffset_ValueChanged);
            // 
            // comboBoxTranslationBehavior
            // 
            this.comboBoxTranslationBehavior.FormattingEnabled = true;
            this.comboBoxTranslationBehavior.Items.AddRange(new object[] {
            "Entire parent window",
            "Single element"});
            this.comboBoxTranslationBehavior.Location = new System.Drawing.Point(170, 24);
            this.comboBoxTranslationBehavior.Name = "comboBoxTranslationBehavior";
            this.comboBoxTranslationBehavior.Size = new System.Drawing.Size(155, 21);
            this.comboBoxTranslationBehavior.TabIndex = 0;
            this.comboBoxTranslationBehavior.Text = "Entire parent window";
            this.toolTip1.SetToolTip(this.comboBoxTranslationBehavior, "Select the extent of translation: single element or entire window");
            this.comboBoxTranslationBehavior.SelectedValueChanged += new System.EventHandler(this.comboBoxTranslationBehavior_SelectedValueChanged);
            // 
            // textBoxTrigger
            // 
            this.textBoxTrigger.Location = new System.Drawing.Point(170, 57);
            this.textBoxTrigger.Name = "textBoxTrigger";
            this.textBoxTrigger.Size = new System.Drawing.Size(155, 20);
            this.textBoxTrigger.TabIndex = 3;
            this.textBoxTrigger.Text = "0";
            this.toolTip1.SetToolTip(this.textBoxTrigger, "Number of milliseconds to wait after the trigger to initiate translation. Note: C" +
        "lick the middle mouse button to trigger");
            this.textBoxTrigger.TextChanged += new System.EventHandler(this.textBoxTrigger_TextChanged);
            // 
            // checkBoxMinimizeToTray
            // 
            this.checkBoxMinimizeToTray.AutoSize = true;
            this.checkBoxMinimizeToTray.Location = new System.Drawing.Point(20, 31);
            this.checkBoxMinimizeToTray.Name = "checkBoxMinimizeToTray";
            this.checkBoxMinimizeToTray.Size = new System.Drawing.Size(98, 17);
            this.checkBoxMinimizeToTray.TabIndex = 0;
            this.checkBoxMinimizeToTray.Text = "Minimize to tray";
            this.toolTip1.SetToolTip(this.checkBoxMinimizeToTray, "When you minimize the program, instead of going to the taskbar, it goes to the sy" +
        "stem tray");
            this.checkBoxMinimizeToTray.UseVisualStyleBackColor = true;
            this.checkBoxMinimizeToTray.CheckedChanged += new System.EventHandler(this.checkBoxMinimizeToTray_CheckedChanged);
            // 
            // comboBoxSourceLanguage
            // 
            this.comboBoxSourceLanguage.FormattingEnabled = true;
            this.comboBoxSourceLanguage.Items.AddRange(new object[] {
            "Auto",
            "Arabic",
            "Chinese",
            "French",
            "German",
            "Hindi",
            "Indonesian",
            "Gaelic",
            "Italian",
            "Japanese",
            "Korean",
            "Polish",
            "Portuguese",
            "Russian",
            "Spanish",
            "Turkish",
            "Vietnamese"});
            this.comboBoxSourceLanguage.Location = new System.Drawing.Point(171, 91);
            this.comboBoxSourceLanguage.Name = "comboBoxSourceLanguage";
            this.comboBoxSourceLanguage.Size = new System.Drawing.Size(156, 21);
            this.comboBoxSourceLanguage.TabIndex = 5;
            this.comboBoxSourceLanguage.Text = "Chinese";
            this.toolTip1.SetToolTip(this.comboBoxSourceLanguage, "Select the language you\'re translating from for best results. If not, select auto" +
        " (experimental)");
            this.comboBoxSourceLanguage.SelectedValueChanged += new System.EventHandler(this.comboBoxSourceLanguage_SelectedValueChanged);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(18, 58);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStatus.Size = new System.Drawing.Size(308, 129);
            this.textBoxStatus.TabIndex = 2;
            this.textBoxStatus.Text = "All is quiet right now..";
            this.toolTip1.SetToolTip(this.textBoxStatus, "Status texts and logs will show here during the translation process");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonTextbox);
            this.groupBox1.Controls.Add(this.radioButtonLabel);
            this.groupBox1.Controls.Add(this.numericUpDownXOffset);
            this.groupBox1.Controls.Add(this.labelYOffset);
            this.groupBox1.Controls.Add(this.labelXOffset);
            this.groupBox1.Controls.Add(this.numericUpDownYOffset);
            this.groupBox1.Location = new System.Drawing.Point(13, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 89);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Translation overlay";
            // 
            // radioButtonTextbox
            // 
            this.radioButtonTextbox.AutoSize = true;
            this.radioButtonTextbox.Checked = true;
            this.radioButtonTextbox.Location = new System.Drawing.Point(214, 60);
            this.radioButtonTextbox.Name = "radioButtonTextbox";
            this.radioButtonTextbox.Size = new System.Drawing.Size(112, 17);
            this.radioButtonTextbox.TabIndex = 6;
            this.radioButtonTextbox.TabStop = true;
            this.radioButtonTextbox.Text = "Overlay as textbox";
            this.radioButtonTextbox.UseVisualStyleBackColor = true;
            this.radioButtonTextbox.CheckedChanged += new System.EventHandler(this.radioButtonTextbox_CheckedChanged);
            // 
            // radioButtonLabel
            // 
            this.radioButtonLabel.AutoSize = true;
            this.radioButtonLabel.Location = new System.Drawing.Point(214, 26);
            this.radioButtonLabel.Name = "radioButtonLabel";
            this.radioButtonLabel.Size = new System.Drawing.Size(100, 17);
            this.radioButtonLabel.TabIndex = 5;
            this.radioButtonLabel.Text = "Overlay as label";
            this.radioButtonLabel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxSourceLanguage);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxTrigger);
            this.groupBox2.Controls.Add(this.labelTrigger);
            this.groupBox2.Controls.Add(this.labelTranslationBehavior);
            this.groupBox2.Controls.Add(this.comboBoxTranslationBehavior);
            this.groupBox2.Location = new System.Drawing.Point(12, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 121);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Behavior";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source language";
            // 
            // labelTrigger
            // 
            this.labelTrigger.AutoSize = true;
            this.labelTrigger.Location = new System.Drawing.Point(16, 60);
            this.labelTrigger.Name = "labelTrigger";
            this.labelTrigger.Size = new System.Drawing.Size(70, 13);
            this.labelTrigger.TabIndex = 2;
            this.labelTrigger.Text = "Trigger Delay";
            // 
            // labelTranslationBehavior
            // 
            this.labelTranslationBehavior.AutoSize = true;
            this.labelTranslationBehavior.Location = new System.Drawing.Point(16, 27);
            this.labelTranslationBehavior.Name = "labelTranslationBehavior";
            this.labelTranslationBehavior.Size = new System.Drawing.Size(91, 13);
            this.labelTranslationBehavior.TabIndex = 1;
            this.labelTranslationBehavior.Text = "Translation extent";
            // 
            // groupBoxApplication
            // 
            this.groupBoxApplication.Controls.Add(this.buttonAbout);
            this.groupBoxApplication.Controls.Add(this.checkBoxTopMost);
            this.groupBoxApplication.Controls.Add(this.textBoxStatus);
            this.groupBoxApplication.Controls.Add(this.checkBoxStartup);
            this.groupBoxApplication.Controls.Add(this.checkBoxMinimizeToTray);
            this.groupBoxApplication.Location = new System.Drawing.Point(12, 235);
            this.groupBoxApplication.Name = "groupBoxApplication";
            this.groupBoxApplication.Size = new System.Drawing.Size(339, 201);
            this.groupBoxApplication.TabIndex = 7;
            this.groupBoxApplication.TabStop = false;
            this.groupBoxApplication.Text = "Application";
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(308, 0);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(20, 20);
            this.buttonAbout.TabIndex = 10;
            this.buttonAbout.Text = "?";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // checkBoxTopMost
            // 
            this.checkBoxTopMost.AutoSize = true;
            this.checkBoxTopMost.Location = new System.Drawing.Point(246, 31);
            this.checkBoxTopMost.Name = "checkBoxTopMost";
            this.checkBoxTopMost.Size = new System.Drawing.Size(82, 17);
            this.checkBoxTopMost.TabIndex = 3;
            this.checkBoxTopMost.Text = "Set topmost";
            this.checkBoxTopMost.UseVisualStyleBackColor = true;
            this.checkBoxTopMost.CheckedChanged += new System.EventHandler(this.checkBoxTopMost_CheckedChanged);
            // 
            // checkBoxStartup
            // 
            this.checkBoxStartup.AutoSize = true;
            this.checkBoxStartup.Location = new System.Drawing.Point(124, 31);
            this.checkBoxStartup.Name = "checkBoxStartup";
            this.checkBoxStartup.Size = new System.Drawing.Size(114, 17);
            this.checkBoxStartup.TabIndex = 1;
            this.checkBoxStartup.Text = "Start with windows";
            this.checkBoxStartup.UseVisualStyleBackColor = true;
            this.checkBoxStartup.CheckedChanged += new System.EventHandler(this.checkBoxStartup_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(307, 150);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // groupBoxAbout
            // 
            this.groupBoxAbout.Controls.Add(this.textBox1);
            this.groupBoxAbout.Location = new System.Drawing.Point(13, 449);
            this.groupBoxAbout.Name = "groupBoxAbout";
            this.groupBoxAbout.Size = new System.Drawing.Size(338, 185);
            this.groupBoxAbout.TabIndex = 8;
            this.groupBoxAbout.TabStop = false;
            this.groupBoxAbout.Text = "About";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "ScreenTranslator is actively monitoring for translation requests.\r\nMiddle mouse c" +
    "lick to translate, move to top left of screen to remove overlays.";
            this.notifyIcon1.BalloonTipTitle = "ScreenTranslator";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStripTrayIcon;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ScreenTranslator";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStripTrayIcon
            // 
            this.contextMenuStripTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemBalloonTips,
            this.toolStripMenuItemEnable,
            this.toolStripMenuItemDisable,
            this.toolStripMenuItemClose});
            this.contextMenuStripTrayIcon.Name = "contextMenuStripTrayIcon";
            this.contextMenuStripTrayIcon.Size = new System.Drawing.Size(137, 92);
            // 
            // toolStripMenuItemBalloonTips
            // 
            this.toolStripMenuItemBalloonTips.Checked = true;
            this.toolStripMenuItemBalloonTips.CheckOnClick = true;
            this.toolStripMenuItemBalloonTips.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemBalloonTips.Name = "toolStripMenuItemBalloonTips";
            this.toolStripMenuItemBalloonTips.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItemBalloonTips.Text = "Balloon tips";
            this.toolStripMenuItemBalloonTips.CheckedChanged += new System.EventHandler(this.toolStripMenuItemBalloonTips_CheckedChanged);
            // 
            // toolStripMenuItemEnable
            // 
            this.toolStripMenuItemEnable.Enabled = false;
            this.toolStripMenuItemEnable.Name = "toolStripMenuItemEnable";
            this.toolStripMenuItemEnable.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItemEnable.Text = "Enable";
            this.toolStripMenuItemEnable.Click += new System.EventHandler(this.toolStripMenuItemEnable_Click);
            // 
            // toolStripMenuItemDisable
            // 
            this.toolStripMenuItemDisable.Name = "toolStripMenuItemDisable";
            this.toolStripMenuItemDisable.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItemDisable.Text = "Disable";
            this.toolStripMenuItemDisable.Click += new System.EventHandler(this.toolStripMenuItemDisable_Click);
            // 
            // toolStripMenuItemClose
            // 
            this.toolStripMenuItemClose.Name = "toolStripMenuItemClose";
            this.toolStripMenuItemClose.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItemClose.Text = "Close";
            this.toolStripMenuItemClose.Click += new System.EventHandler(this.toolStripMenuItemClose_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 445);
            this.Controls.Add(this.groupBoxAbout);
            this.Controls.Add(this.groupBoxApplication);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScreenTranslator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXOffset)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxApplication.ResumeLayout(false);
            this.groupBoxApplication.PerformLayout();
            this.groupBoxAbout.ResumeLayout(false);
            this.groupBoxAbout.PerformLayout();
            this.contextMenuStripTrayIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelYOffset;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelXOffset;
        private System.Windows.Forms.NumericUpDown numericUpDownYOffset;
        private System.Windows.Forms.NumericUpDown numericUpDownXOffset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonTextbox;
        private System.Windows.Forms.RadioButton radioButtonLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelTranslationBehavior;
        private System.Windows.Forms.ComboBox comboBoxTranslationBehavior;
        private System.Windows.Forms.TextBox textBoxTrigger;
        private System.Windows.Forms.Label labelTrigger;
        private System.Windows.Forms.GroupBox groupBoxApplication;
        private System.Windows.Forms.CheckBox checkBoxStartup;
        private System.Windows.Forms.CheckBox checkBoxMinimizeToTray;
        private System.Windows.Forms.ComboBox comboBoxSourceLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.GroupBox groupBoxAbout;
        private System.Windows.Forms.CheckBox checkBoxTopMost;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTrayIcon;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClose;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEnable;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDisable;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBalloonTips;
        private System.Windows.Forms.Button buttonAbout;
    }
}

