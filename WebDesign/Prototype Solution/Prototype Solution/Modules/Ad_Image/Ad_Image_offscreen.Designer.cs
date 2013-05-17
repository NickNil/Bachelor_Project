namespace Prototype_Solution
{
    partial class Ad_Image_offscreen
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.sliderTime = new System.Windows.Forms.TrackBar();
            this.labelSlider = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 26);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Velg Bilde";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // sliderTime
            // 
            this.sliderTime.Location = new System.Drawing.Point(0, 59);
            this.sliderTime.Maximum = 30;
            this.sliderTime.Name = "sliderTime";
            this.sliderTime.Size = new System.Drawing.Size(141, 45);
            this.sliderTime.SmallChange = 5;
            this.sliderTime.TabIndex = 1;
            this.sliderTime.TickFrequency = 5;
            this.sliderTime.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderTime.Value = 10;
            this.sliderTime.ValueChanged += new System.EventHandler(this.sliderTime_ValueChanged);
            // 
            // labelSlider
            // 
            this.labelSlider.AutoSize = true;
            this.labelSlider.Location = new System.Drawing.Point(3, 43);
            this.labelSlider.Name = "labelSlider";
            this.labelSlider.Size = new System.Drawing.Size(55, 13);
            this.labelSlider.TabIndex = 2;
            this.labelSlider.Text = "Hastighet:";
            // 
            // Ad_Image_offscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSlider);
            this.Controls.Add(this.sliderTime);
            this.Controls.Add(this.btnAdd);
            this.Name = "Ad_Image_offscreen";
            this.Size = new System.Drawing.Size(942, 629);
            ((System.ComponentModel.ISupportInitialize)(this.sliderTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TrackBar sliderTime;
        private System.Windows.Forms.Label labelSlider;
    }
}