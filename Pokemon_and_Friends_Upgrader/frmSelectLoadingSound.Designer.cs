namespace Pokemon_and_Friends_Upgrader
{
    partial class frmSelectLoadingSound
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectLoadingSound));
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbSound = new System.Windows.Forms.ListBox();
            this.pbPlay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(410, 85);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 60);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "...";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUse
            // 
            this.btnUse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUse.BackgroundImage")));
            this.btnUse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUse.Location = new System.Drawing.Point(410, 296);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(105, 54);
            this.btnUse.TabIndex = 7;
            this.btnUse.UseVisualStyleBackColor = true;
            this.btnUse.Click += new System.EventHandler(this.btnUse_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 61);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a loading music";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSound
            // 
            this.lbSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lbSound.FormattingEnabled = true;
            this.lbSound.ItemHeight = 29;
            this.lbSound.Location = new System.Drawing.Point(12, 85);
            this.lbSound.Name = "lbSound";
            this.lbSound.Size = new System.Drawing.Size(377, 265);
            this.lbSound.TabIndex = 8;
            this.lbSound.SelectedIndexChanged += new System.EventHandler(this.lbSound_SelectedIndexChanged);
            this.lbSound.DoubleClick += new System.EventHandler(this.pbPlay_Click);
            // 
            // pbPlay
            // 
            this.pbPlay.Image = ((System.Drawing.Image)(resources.GetObject("pbPlay.Image")));
            this.pbPlay.Location = new System.Drawing.Point(410, 167);
            this.pbPlay.Name = "pbPlay";
            this.pbPlay.Size = new System.Drawing.Size(105, 105);
            this.pbPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlay.TabIndex = 63;
            this.pbPlay.TabStop = false;
            this.pbPlay.Click += new System.EventHandler(this.pbPlay_Click);
            // 
            // frmSelectLoadingSound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 368);
            this.Controls.Add(this.pbPlay);
            this.Controls.Add(this.lbSound);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUse);
            this.Controls.Add(this.btnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSelectLoadingSound";
            this.Text = "Select Shiny Screen";
            this.Load += new System.EventHandler(this.frmSelectLoadingSound_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbSound;
        private System.Windows.Forms.PictureBox pbPlay;
    }
}