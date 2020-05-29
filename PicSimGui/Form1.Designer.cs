namespace PicSim
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Ausgabe = new System.Windows.Forms.ListView();
            this.Programcounter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Program = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Go = new System.Windows.Forms.Button();
            this.Step = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.GroupBox();
            this.C = new System.Windows.Forms.Label();
            this.DC = new System.Windows.Forms.Label();
            this.Z = new System.Windows.Forms.Label();
            this.PD = new System.Windows.Forms.Label();
            this.TO = new System.Windows.Forms.Label();
            this.RP0 = new System.Windows.Forms.Label();
            this.RP1 = new System.Windows.Forms.Label();
            this.IRP = new System.Windows.Forms.Label();
            this.OPTION_REG = new System.Windows.Forms.GroupBox();
            this.PS0 = new System.Windows.Forms.Label();
            this.PS1 = new System.Windows.Forms.Label();
            this.PS2 = new System.Windows.Forms.Label();
            this.PSA = new System.Windows.Forms.Label();
            this.T0SE = new System.Windows.Forms.Label();
            this.T0CS = new System.Windows.Forms.Label();
            this.INTEDG = new System.Windows.Forms.Label();
            this.RBPU = new System.Windows.Forms.Label();
            this.Reset = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Quartz = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Ausgabegeschwindigkeit = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.Status.SuspendLayout();
            this.OPTION_REG.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1026, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ladenToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(59, 26);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // ladenToolStripMenuItem
            // 
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.ladenToolStripMenuItem.Text = "laden";
            this.ladenToolStripMenuItem.Click += new System.EventHandler(this.ladenToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.hilfeToolStripMenuItem.Text = "hilfe";
            // 
            // Ausgabe
            // 
            this.Ausgabe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Programcounter,
            this.Program});
            this.Ausgabe.HideSelection = false;
            this.Ausgabe.Location = new System.Drawing.Point(11, 55);
            this.Ausgabe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Ausgabe.Name = "Ausgabe";
            this.Ausgabe.Size = new System.Drawing.Size(299, 390);
            this.Ausgabe.TabIndex = 1;
            this.Ausgabe.UseCompatibleStateImageBehavior = false;
            this.Ausgabe.View = System.Windows.Forms.View.Details;
            // 
            // Programcounter
            // 
            this.Programcounter.DisplayIndex = 1;
            this.Programcounter.Text = "Programcounter";
            this.Programcounter.Width = 110;
            // 
            // Program
            // 
            this.Program.DisplayIndex = 0;
            this.Program.Text = "Program";
            this.Program.Width = 128;
            // 
            // Go
            // 
            this.Go.Location = new System.Drawing.Point(884, 325);
            this.Go.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(112, 30);
            this.Go.TabIndex = 2;
            this.Go.Text = "Go";
            this.Go.UseVisualStyleBackColor = true;
            this.Go.Click += new System.EventHandler(this.Go_Click);
            // 
            // Step
            // 
            this.Step.Location = new System.Drawing.Point(884, 359);
            this.Step.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Step.Name = "Step";
            this.Step.Size = new System.Drawing.Size(112, 34);
            this.Step.TabIndex = 3;
            this.Step.Text = "Step";
            this.Step.UseVisualStyleBackColor = true;
            this.Step.Click += new System.EventHandler(this.Step_Click);
            // 
            // Status
            // 
            this.Status.Controls.Add(this.C);
            this.Status.Controls.Add(this.DC);
            this.Status.Controls.Add(this.Z);
            this.Status.Controls.Add(this.PD);
            this.Status.Controls.Add(this.TO);
            this.Status.Controls.Add(this.RP0);
            this.Status.Controls.Add(this.RP1);
            this.Status.Controls.Add(this.IRP);
            this.Status.Location = new System.Drawing.Point(361, 41);
            this.Status.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Status.Name = "Status";
            this.Status.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Status.Size = new System.Drawing.Size(418, 80);
            this.Status.TabIndex = 5;
            this.Status.TabStop = false;
            this.Status.Text = "Status";
            // 
            // C
            // 
            this.C.AutoSize = true;
            this.C.Location = new System.Drawing.Point(369, 25);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(17, 17);
            this.C.TabIndex = 7;
            this.C.Text = "C";
            // 
            // DC
            // 
            this.DC.AutoSize = true;
            this.DC.Location = new System.Drawing.Point(317, 25);
            this.DC.Name = "DC";
            this.DC.Size = new System.Drawing.Size(27, 17);
            this.DC.TabIndex = 6;
            this.DC.Text = "DC";
            // 
            // Z
            // 
            this.Z.AutoSize = true;
            this.Z.Location = new System.Drawing.Point(265, 25);
            this.Z.Name = "Z";
            this.Z.Size = new System.Drawing.Size(17, 17);
            this.Z.TabIndex = 5;
            this.Z.Text = "Z";
            // 
            // PD
            // 
            this.PD.AutoSize = true;
            this.PD.Location = new System.Drawing.Point(213, 25);
            this.PD.Name = "PD";
            this.PD.Size = new System.Drawing.Size(27, 17);
            this.PD.TabIndex = 4;
            this.PD.Text = "PD";
            // 
            // TO
            // 
            this.TO.AutoSize = true;
            this.TO.Location = new System.Drawing.Point(161, 25);
            this.TO.Name = "TO";
            this.TO.Size = new System.Drawing.Size(28, 17);
            this.TO.TabIndex = 3;
            this.TO.Text = "TO";
            // 
            // RP0
            // 
            this.RP0.AutoSize = true;
            this.RP0.Location = new System.Drawing.Point(109, 25);
            this.RP0.Name = "RP0";
            this.RP0.Size = new System.Drawing.Size(35, 17);
            this.RP0.TabIndex = 2;
            this.RP0.Text = "RP0";
            // 
            // RP1
            // 
            this.RP1.AutoSize = true;
            this.RP1.Location = new System.Drawing.Point(57, 25);
            this.RP1.Name = "RP1";
            this.RP1.Size = new System.Drawing.Size(35, 17);
            this.RP1.TabIndex = 1;
            this.RP1.Text = "RP1";
            // 
            // IRP
            // 
            this.IRP.AutoSize = true;
            this.IRP.Location = new System.Drawing.Point(5, 25);
            this.IRP.Name = "IRP";
            this.IRP.Size = new System.Drawing.Size(30, 17);
            this.IRP.TabIndex = 0;
            this.IRP.Text = "IRP";
            // 
            // OPTION_REG
            // 
            this.OPTION_REG.Controls.Add(this.PS0);
            this.OPTION_REG.Controls.Add(this.PS1);
            this.OPTION_REG.Controls.Add(this.PS2);
            this.OPTION_REG.Controls.Add(this.PSA);
            this.OPTION_REG.Controls.Add(this.T0SE);
            this.OPTION_REG.Controls.Add(this.T0CS);
            this.OPTION_REG.Controls.Add(this.INTEDG);
            this.OPTION_REG.Controls.Add(this.RBPU);
            this.OPTION_REG.Location = new System.Drawing.Point(361, 152);
            this.OPTION_REG.Name = "OPTION_REG";
            this.OPTION_REG.Size = new System.Drawing.Size(418, 76);
            this.OPTION_REG.TabIndex = 6;
            this.OPTION_REG.TabStop = false;
            this.OPTION_REG.Text = "OPTION_REG";
            // 
            // PS0
            // 
            this.PS0.AutoSize = true;
            this.PS0.Location = new System.Drawing.Point(371, 22);
            this.PS0.Name = "PS0";
            this.PS0.Size = new System.Drawing.Size(34, 17);
            this.PS0.TabIndex = 7;
            this.PS0.Text = "PS0";
            // 
            // PS1
            // 
            this.PS1.AutoSize = true;
            this.PS1.Location = new System.Drawing.Point(319, 22);
            this.PS1.Name = "PS1";
            this.PS1.Size = new System.Drawing.Size(34, 17);
            this.PS1.TabIndex = 6;
            this.PS1.Text = "PS1";
            // 
            // PS2
            // 
            this.PS2.AutoSize = true;
            this.PS2.Location = new System.Drawing.Point(267, 22);
            this.PS2.Name = "PS2";
            this.PS2.Size = new System.Drawing.Size(34, 17);
            this.PS2.TabIndex = 5;
            this.PS2.Text = "PS2";
            // 
            // PSA
            // 
            this.PSA.AutoSize = true;
            this.PSA.Location = new System.Drawing.Point(215, 22);
            this.PSA.Name = "PSA";
            this.PSA.Size = new System.Drawing.Size(35, 17);
            this.PSA.TabIndex = 4;
            this.PSA.Text = "PSA";
            // 
            // T0SE
            // 
            this.T0SE.AutoSize = true;
            this.T0SE.Location = new System.Drawing.Point(163, 22);
            this.T0SE.Name = "T0SE";
            this.T0SE.Size = new System.Drawing.Size(43, 17);
            this.T0SE.TabIndex = 3;
            this.T0SE.Text = "T0SE";
            // 
            // T0CS
            // 
            this.T0CS.AutoSize = true;
            this.T0CS.Location = new System.Drawing.Point(111, 22);
            this.T0CS.Name = "T0CS";
            this.T0CS.Size = new System.Drawing.Size(43, 17);
            this.T0CS.TabIndex = 2;
            this.T0CS.Text = "T0CS";
            // 
            // INTEDG
            // 
            this.INTEDG.AutoSize = true;
            this.INTEDG.Location = new System.Drawing.Point(59, 22);
            this.INTEDG.Name = "INTEDG";
            this.INTEDG.Size = new System.Drawing.Size(60, 17);
            this.INTEDG.TabIndex = 1;
            this.INTEDG.Text = "INTEDG";
            // 
            // RBPU
            // 
            this.RBPU.AutoSize = true;
            this.RBPU.Location = new System.Drawing.Point(7, 22);
            this.RBPU.Name = "RBPU";
            this.RBPU.Size = new System.Drawing.Size(46, 17);
            this.RBPU.TabIndex = 0;
            this.RBPU.Text = "RBPU";
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(884, 290);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(112, 30);
            this.Reset.TabIndex = 7;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(884, 398);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(112, 34);
            this.Stop.TabIndex = 8;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "32",
            "64",
            "128"});
            this.comboBox1.Location = new System.Drawing.Point(681, 325);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Quartz
            // 
            this.Quartz.AutoSize = true;
            this.Quartz.Location = new System.Drawing.Point(715, 297);
            this.Quartz.Name = "Quartz";
            this.Quartz.Size = new System.Drawing.Size(51, 17);
            this.Quartz.TabIndex = 11;
            this.Quartz.Text = "Quartz";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "langsam",
            "normal",
            "schnell"});
            this.comboBox2.Location = new System.Drawing.Point(504, 325);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 12;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Ausgabegeschwindigkeit
            // 
            this.Ausgabegeschwindigkeit.AutoSize = true;
            this.Ausgabegeschwindigkeit.Location = new System.Drawing.Point(501, 297);
            this.Ausgabegeschwindigkeit.Name = "Ausgabegeschwindigkeit";
            this.Ausgabegeschwindigkeit.Size = new System.Drawing.Size(163, 17);
            this.Ausgabegeschwindigkeit.TabIndex = 13;
            this.Ausgabegeschwindigkeit.Text = "Ausgabegeschwindigkeit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 456);
            this.Controls.Add(this.Ausgabegeschwindigkeit);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.Quartz);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.OPTION_REG);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Step);
            this.Controls.Add(this.Go);
            this.Controls.Add(this.Ausgabe);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.OPTION_REG.ResumeLayout(false);
            this.OPTION_REG.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ladenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ListView Ausgabe;
        public System.Windows.Forms.ColumnHeader Program;
        public System.Windows.Forms.ColumnHeader Programcounter;
        private System.Windows.Forms.Button Go;
        private System.Windows.Forms.Button Step;
        private System.Windows.Forms.GroupBox Status;
        private System.Windows.Forms.Label IRP;
        private System.Windows.Forms.Label C;
        private System.Windows.Forms.Label DC;
        private System.Windows.Forms.Label Z;
        private System.Windows.Forms.Label PD;
        private System.Windows.Forms.Label TO;
        private System.Windows.Forms.Label RP0;
        private System.Windows.Forms.Label RP1;
        private System.Windows.Forms.GroupBox OPTION_REG;
        private System.Windows.Forms.Label PS0;
        private System.Windows.Forms.Label PS1;
        private System.Windows.Forms.Label PS2;
        private System.Windows.Forms.Label PSA;
        private System.Windows.Forms.Label T0SE;
        private System.Windows.Forms.Label T0CS;
        private System.Windows.Forms.Label INTEDG;
        private System.Windows.Forms.Label RBPU;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Stop;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label Quartz;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label Ausgabegeschwindigkeit;
    }
}

