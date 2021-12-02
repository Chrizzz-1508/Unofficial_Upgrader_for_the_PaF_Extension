namespace Pokemon_and_Friends_Upgrader
{
    partial class frmSelectShiny
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectShiny));
            this.pbPreview1 = new System.Windows.Forms.PictureBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbPreview2 = new System.Windows.Forms.PictureBox();
            this.pbPreview3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview3)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPreview1
            // 
            this.pbPreview1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPreview1.Image = ((System.Drawing.Image)(resources.GetObject("pbPreview1.Image")));
            this.pbPreview1.Location = new System.Drawing.Point(21, 100);
            this.pbPreview1.Name = "pbPreview1";
            this.pbPreview1.Size = new System.Drawing.Size(240, 240);
            this.pbPreview1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview1.TabIndex = 5;
            this.pbPreview1.TabStop = false;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(322, 361);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(82, 54);
            this.btnPrevious.TabIndex = 4;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.btnNext.Location = new System.Drawing.Point(423, 361);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(82, 54);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(93, 361);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 54);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "...";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUse
            // 
            this.btnUse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUse.BackgroundImage")));
            this.btnUse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUse.Location = new System.Drawing.Point(628, 361);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(82, 54);
            this.btnUse.TabIndex = 7;
            this.btnUse.UseVisualStyleBackColor = true;
            this.btnUse.Click += new System.EventHandler(this.btnUse_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(581, 85);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Shiny Wallpaper \r\n(Custom Resolution must be 240x240)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPreview2
            // 
            this.pbPreview2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPreview2.Image = ((System.Drawing.Image)(resources.GetObject("pbPreview2.Image")));
            this.pbPreview2.Location = new System.Drawing.Point(285, 100);
            this.pbPreview2.Name = "pbPreview2";
            this.pbPreview2.Size = new System.Drawing.Size(240, 240);
            this.pbPreview2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview2.TabIndex = 11;
            this.pbPreview2.TabStop = false;
            // 
            // pbPreview3
            // 
            this.pbPreview3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPreview3.Image = ((System.Drawing.Image)(resources.GetObject("pbPreview3.Image")));
            this.pbPreview3.Location = new System.Drawing.Point(549, 100);
            this.pbPreview3.Name = "pbPreview3";
            this.pbPreview3.Size = new System.Drawing.Size(240, 240);
            this.pbPreview3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview3.TabIndex = 12;
            this.pbPreview3.TabStop = false;
            // 
            // frmSelectShiny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 436);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUse);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pbPreview1);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pbPreview2);
            this.Controls.Add(this.pbPreview3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSelectShiny";
            this.Text = "Select Shiny Screen";
            this.Load += new System.EventHandler(this.frmSelectShiny_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPreview1;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbPreview2;
        private System.Windows.Forms.PictureBox pbPreview3;
    }
}