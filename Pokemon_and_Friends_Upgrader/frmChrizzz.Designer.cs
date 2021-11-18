namespace Pokemon_and_Friends_Upgrader
{
    partial class frmChrizzz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChrizzz));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbTwitch = new System.Windows.Forms.PictureBox();
            this.pbPayPal = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPayPal)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pokemon_and_Friends_Upgrader.Properties.Resources.chrizzz_twitch_logo;
            this.pictureBox1.Location = new System.Drawing.Point(36, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(333, 332);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 150);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbTwitch
            // 
            this.pbTwitch.Image = ((System.Drawing.Image)(resources.GetObject("pbTwitch.Image")));
            this.pbTwitch.Location = new System.Drawing.Point(12, 527);
            this.pbTwitch.Name = "pbTwitch";
            this.pbTwitch.Size = new System.Drawing.Size(180, 78);
            this.pbTwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTwitch.TabIndex = 2;
            this.pbTwitch.TabStop = false;
            this.pbTwitch.Click += new System.EventHandler(this.pbTwitch_Click);
            // 
            // pbPayPal
            // 
            this.pbPayPal.Image = ((System.Drawing.Image)(resources.GetObject("pbPayPal.Image")));
            this.pbPayPal.Location = new System.Drawing.Point(205, 526);
            this.pbPayPal.Name = "pbPayPal";
            this.pbPayPal.Size = new System.Drawing.Size(197, 78);
            this.pbPayPal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPayPal.TabIndex = 3;
            this.pbPayPal.TabStop = false;
            this.pbPayPal.Click += new System.EventHandler(this.pbPaypal_Click);
            // 
            // frmChrizzz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 610);
            this.Controls.Add(this.pbPayPal);
            this.Controls.Add(this.pbTwitch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmChrizzz";
            this.Text = "Support Me";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPayPal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbTwitch;
        private System.Windows.Forms.PictureBox pbPayPal;
    }
}