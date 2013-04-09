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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox_names = new System.Windows.Forms.ListBox();
            this.nrOfModules = new System.Windows.Forms.ComboBox();
            this.picBtn1 = new System.Windows.Forms.PictureBox();
            this.picBtn2 = new System.Windows.Forms.PictureBox();
            this.picBtn3 = new System.Windows.Forms.PictureBox();
            this.picBtn4 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picBtn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtn4)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox_names
            // 
            this.listBox_names.AllowDrop = true;
            this.listBox_names.FormattingEnabled = true;
            this.listBox_names.Items.AddRange(new object[] {
            "Jukebox",
            "Chat",
            "Ad_Image"});
            this.listBox_names.Location = new System.Drawing.Point(21, 27);
            this.listBox_names.Name = "listBox_names";
            this.listBox_names.Size = new System.Drawing.Size(120, 95);
            this.listBox_names.TabIndex = 3;
            this.listBox_names.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.listBox_names.DragOver += new System.Windows.Forms.DragEventHandler(this.listBox_DragOver);
            this.listBox_names.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
            // 
            // nrOfModules
            // 
            this.nrOfModules.FormattingEnabled = true;
            this.nrOfModules.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.nrOfModules.Location = new System.Drawing.Point(21, 162);
            this.nrOfModules.Name = "nrOfModules";
            this.nrOfModules.Size = new System.Drawing.Size(121, 21);
            this.nrOfModules.TabIndex = 4;
            this.nrOfModules.SelectedIndexChanged += new System.EventHandler(this.nrOfModules_SelectedIndexChanged);
            // 
            // picBtn1
            // 
            this.picBtn1.Location = new System.Drawing.Point(196, 183);
            this.picBtn1.Name = "picBtn1";
            this.picBtn1.Size = new System.Drawing.Size(100, 100);
            this.picBtn1.TabIndex = 5;
            this.picBtn1.TabStop = false;
            this.picBtn1.Click += new System.EventHandler(this.picBtn_Click);
            // 
            // picBtn2
            // 
            this.picBtn2.Location = new System.Drawing.Point(316, 183);
            this.picBtn2.Name = "picBtn2";
            this.picBtn2.Size = new System.Drawing.Size(100, 100);
            this.picBtn2.TabIndex = 6;
            this.picBtn2.TabStop = false;
            this.picBtn2.Visible = false;
            this.picBtn2.Click += new System.EventHandler(this.picBtn_Click);
            // 
            // picBtn3
            // 
            this.picBtn3.Location = new System.Drawing.Point(196, 301);
            this.picBtn3.Name = "picBtn3";
            this.picBtn3.Size = new System.Drawing.Size(100, 100);
            this.picBtn3.TabIndex = 7;
            this.picBtn3.TabStop = false;
            this.picBtn3.Visible = false;
            this.picBtn3.Click += new System.EventHandler(this.picBtn_Click);
            // 
            // picBtn4
            // 
            this.picBtn4.Location = new System.Drawing.Point(316, 301);
            this.picBtn4.Name = "picBtn4";
            this.picBtn4.Size = new System.Drawing.Size(100, 100);
            this.picBtn4.TabIndex = 8;
            this.picBtn4.TabStop = false;
            this.picBtn4.Visible = false;
            this.picBtn4.Click += new System.EventHandler(this.picBtn_Click);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Location = new System.Drawing.Point(509, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 150);
            this.panel1.TabIndex = 9;
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 469);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picBtn4);
            this.Controls.Add(this.picBtn3);
            this.Controls.Add(this.picBtn2);
            this.Controls.Add(this.picBtn1);
            this.Controls.Add(this.nrOfModules);
            this.Controls.Add(this.listBox_names);
            this.Controls.Add(this.button1);
            this.Name = "Start";
            this.Text = "Start";
            this.Load += new System.EventHandler(this.Start_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBtn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtn4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox_names;
        private System.Windows.Forms.ComboBox nrOfModules;
        private System.Windows.Forms.PictureBox picBtn1;
        private System.Windows.Forms.PictureBox picBtn2;
        private System.Windows.Forms.PictureBox picBtn3;
        private System.Windows.Forms.PictureBox picBtn4;
        private System.Windows.Forms.Panel panel1;
    }
}