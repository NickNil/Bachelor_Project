namespace Prototype_Solution
{
    partial class Start
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
            this.btnStart = new System.Windows.Forms.Button();
            this.nrOfModules = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNrOfModules = new System.Windows.Forms.Label();
            this.labelLayout = new System.Windows.Forms.Label();
            this.labelPanel = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.picBtn1 = new System.Windows.Forms.Button();
            this.picBtn2 = new System.Windows.Forms.Button();
            this.picBtn3 = new System.Windows.Forms.Button();
            this.picBtn4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(584, 236);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // nrOfModules
            // 
            this.nrOfModules.FormattingEnabled = true;
            this.nrOfModules.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.nrOfModules.Location = new System.Drawing.Point(12, 41);
            this.nrOfModules.Name = "nrOfModules";
            this.nrOfModules.Size = new System.Drawing.Size(121, 21);
            this.nrOfModules.TabIndex = 4;
            this.nrOfModules.SelectedIndexChanged += new System.EventHandler(this.nrOfModules_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Location = new System.Drawing.Point(509, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 150);
            this.panel1.TabIndex = 9;
            // 
            // labelNrOfModules
            // 
            this.labelNrOfModules.AutoSize = true;
            this.labelNrOfModules.Location = new System.Drawing.Point(12, 25);
            this.labelNrOfModules.Name = "labelNrOfModules";
            this.labelNrOfModules.Size = new System.Drawing.Size(73, 13);
            this.labelNrOfModules.TabIndex = 10;
            this.labelNrOfModules.Text = "Antall moduler";
            // 
            // labelLayout
            // 
            this.labelLayout.AutoSize = true;
            this.labelLayout.Location = new System.Drawing.Point(270, 25);
            this.labelLayout.Name = "labelLayout";
            this.labelLayout.Size = new System.Drawing.Size(39, 13);
            this.labelLayout.TabIndex = 11;
            this.labelLayout.Text = "Layout";
            // 
            // labelPanel
            // 
            this.labelPanel.AutoSize = true;
            this.labelPanel.Location = new System.Drawing.Point(506, 25);
            this.labelPanel.Name = "labelPanel";
            this.labelPanel.Size = new System.Drawing.Size(45, 13);
            this.labelPanel.TabIndex = 12;
            this.labelPanel.Text = "Moduler";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(506, 194);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(160, 13);
            this.labelInfo.TabIndex = 13;
            this.labelInfo.Text = "Høyreklikk for å legge til moduler";
            // 
            // picBtn1
            // 
            this.picBtn1.Location = new System.Drawing.Point(179, 41);
            this.picBtn1.Name = "picBtn1";
            this.picBtn1.Size = new System.Drawing.Size(100, 100);
            this.picBtn1.TabIndex = 14;
            this.picBtn1.UseVisualStyleBackColor = true;
            this.picBtn1.Visible = false;
            this.picBtn1.Click += new System.EventHandler(this.picBtn_Click);
            // 
            // picBtn2
            // 
            this.picBtn2.Location = new System.Drawing.Point(300, 41);
            this.picBtn2.Name = "picBtn2";
            this.picBtn2.Size = new System.Drawing.Size(100, 100);
            this.picBtn2.TabIndex = 15;
            this.picBtn2.UseVisualStyleBackColor = true;
            this.picBtn2.Visible = false;
            this.picBtn2.Click += new System.EventHandler(this.picBtn_Click);
            // 
            // picBtn3
            // 
            this.picBtn3.Location = new System.Drawing.Point(179, 147);
            this.picBtn3.Name = "picBtn3";
            this.picBtn3.Size = new System.Drawing.Size(100, 100);
            this.picBtn3.TabIndex = 16;
            this.picBtn3.UseVisualStyleBackColor = true;
            this.picBtn3.Visible = false;
            this.picBtn3.Click += new System.EventHandler(this.picBtn_Click);
            // 
            // picBtn4
            // 
            this.picBtn4.Location = new System.Drawing.Point(300, 147);
            this.picBtn4.Name = "picBtn4";
            this.picBtn4.Size = new System.Drawing.Size(100, 100);
            this.picBtn4.TabIndex = 17;
            this.picBtn4.UseVisualStyleBackColor = true;
            this.picBtn4.Visible = false;
            this.picBtn4.Click += new System.EventHandler(this.picBtn_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 289);
            this.Controls.Add(this.picBtn4);
            this.Controls.Add(this.picBtn3);
            this.Controls.Add(this.picBtn2);
            this.Controls.Add(this.picBtn1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelPanel);
            this.Controls.Add(this.labelLayout);
            this.Controls.Add(this.labelNrOfModules);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nrOfModules);
            this.Controls.Add(this.btnStart);
            this.Name = "Start";
            this.Text = "Setup";
            this.Load += new System.EventHandler(this.Start_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox nrOfModules;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelNrOfModules;
        private System.Windows.Forms.Label labelLayout;
        private System.Windows.Forms.Label labelPanel;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button picBtn1;
        private System.Windows.Forms.Button picBtn2;
        private System.Windows.Forms.Button picBtn3;
        private System.Windows.Forms.Button picBtn4;
    }
}