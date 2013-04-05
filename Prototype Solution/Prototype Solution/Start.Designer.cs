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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listBox_0 = new System.Windows.Forms.ListBox();
            this.listBox_1 = new System.Windows.Forms.ListBox();
            this.listBox_2 = new System.Windows.Forms.ListBox();
            this.listBox_names = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(260, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBox_2);
            this.splitContainer1.Size = new System.Drawing.Size(150, 142);
            this.splitContainer1.SplitterDistance = 105;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AllowDrop = true;
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.listBox_0);
            this.splitContainer2.Panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.splitContainer2.Panel1.DragOver += new System.Windows.Forms.DragEventHandler(this.listBox_DragOver);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listBox_1);
            this.splitContainer2.Size = new System.Drawing.Size(150, 105);
            this.splitContainer2.TabIndex = 0;
            // 
            // listBox_0
            // 
            this.listBox_0.AllowDrop = true;
            this.listBox_0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_0.FormattingEnabled = true;
            this.listBox_0.Location = new System.Drawing.Point(0, 0);
            this.listBox_0.Name = "listBox_0";
            this.listBox_0.Size = new System.Drawing.Size(50, 105);
            this.listBox_0.TabIndex = 0;
            this.listBox_0.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.listBox_0.DragOver += new System.Windows.Forms.DragEventHandler(this.listBox_DragOver);
            this.listBox_0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
            // 
            // listBox_1
            // 
            this.listBox_1.AllowDrop = true;
            this.listBox_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_1.FormattingEnabled = true;
            this.listBox_1.Location = new System.Drawing.Point(0, 0);
            this.listBox_1.Name = "listBox_1";
            this.listBox_1.Size = new System.Drawing.Size(96, 105);
            this.listBox_1.TabIndex = 0;
            this.listBox_1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.listBox_1.DragOver += new System.Windows.Forms.DragEventHandler(this.listBox_DragOver);
            this.listBox_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
            // 
            // listBox_2
            // 
            this.listBox_2.AllowDrop = true;
            this.listBox_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_2.FormattingEnabled = true;
            this.listBox_2.Location = new System.Drawing.Point(0, 0);
            this.listBox_2.Name = "listBox_2";
            this.listBox_2.Size = new System.Drawing.Size(150, 33);
            this.listBox_2.TabIndex = 0;
            this.listBox_2.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.listBox_2.DragOver += new System.Windows.Forms.DragEventHandler(this.listBox_DragOver);
            this.listBox_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
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
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 435);
            this.Controls.Add(this.listBox_names);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button1);
            this.Name = "Start";
            this.Text = "Start";
            this.Load += new System.EventHandler(this.Start_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox listBox_names;
        private System.Windows.Forms.ListBox listBox_0;
        private System.Windows.Forms.ListBox listBox_1;
        private System.Windows.Forms.ListBox listBox_2;

    }
}