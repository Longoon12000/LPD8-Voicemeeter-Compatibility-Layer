namespace MidiHandler
{
    partial class MidiHandler
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MidiHandler));
            this.cbMidiDevices = new System.Windows.Forms.ComboBox();
            this.lblLPD8 = new System.Windows.Forms.Label();
            this.btnEnable = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbMidiDevices
            // 
            this.cbMidiDevices.FormattingEnabled = true;
            this.cbMidiDevices.Location = new System.Drawing.Point(55, 12);
            this.cbMidiDevices.Name = "cbMidiDevices";
            this.cbMidiDevices.Size = new System.Drawing.Size(263, 23);
            this.cbMidiDevices.TabIndex = 1;
            // 
            // lblLPD8
            // 
            this.lblLPD8.AutoSize = true;
            this.lblLPD8.Location = new System.Drawing.Point(12, 15);
            this.lblLPD8.Name = "lblLPD8";
            this.lblLPD8.Size = new System.Drawing.Size(37, 15);
            this.lblLPD8.TabIndex = 0;
            this.lblLPD8.Text = "&LPD8:";
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(324, 12);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(75, 23);
            this.btnEnable.TabIndex = 2;
            this.btnEnable.Text = "&Enable";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "LPD8 Voicemeeter Compatibility Layer";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // notifyIconContextMenuStrip
            // 
            this.notifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.notifyIconContextMenuStrip.Name = "notifyIconContextMenuStrip";
            this.notifyIconContextMenuStrip.Size = new System.Drawing.Size(103, 48);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.resetToolStripMenuItem.Text = "&Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MidiHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 43);
            this.Controls.Add(this.btnEnable);
            this.Controls.Add(this.lblLPD8);
            this.Controls.Add(this.cbMidiDevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MidiHandler";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "LPD8 Voicemeeter Compatiblity Layer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MidiHandler_FormClosing);
            this.Shown += new System.EventHandler(this.MidiHandler_Shown);
            this.notifyIconContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbMidiDevices;
        private Label lblLPD8;
        private Button btnEnable;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip notifyIconContextMenuStrip;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}