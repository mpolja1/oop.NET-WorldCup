namespace WorldCup
{
    partial class UCPlayer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPlayer));
            this.pbPlayerPhoto = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblShirtNumber = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblCapitan = new System.Windows.Forms.Label();
            this.pbFavoritePlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavoritePlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPlayerPhoto
            // 
            this.pbPlayerPhoto.ErrorImage = null;
            this.pbPlayerPhoto.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbPlayerPhoto.InitialImage")));
            this.pbPlayerPhoto.Location = new System.Drawing.Point(-2, -2);
            this.pbPlayerPhoto.Name = "pbPlayerPhoto";
            this.pbPlayerPhoto.Size = new System.Drawing.Size(148, 172);
            this.pbPlayerPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlayerPhoto.TabIndex = 0;
            this.pbPlayerPhoto.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(152, 17);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(24, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Ime";
            // 
            // lblShirtNumber
            // 
            this.lblShirtNumber.AutoSize = true;
            this.lblShirtNumber.Location = new System.Drawing.Point(152, 46);
            this.lblShirtNumber.Name = "lblShirtNumber";
            this.lblShirtNumber.Size = new System.Drawing.Size(25, 13);
            this.lblShirtNumber.TabIndex = 2;
            this.lblShirtNumber.Text = "Broj";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(152, 73);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(43, 13);
            this.lblPosition.TabIndex = 3;
            this.lblPosition.Text = "Pozicija";
            // 
            // lblCapitan
            // 
            this.lblCapitan.AutoSize = true;
            this.lblCapitan.Location = new System.Drawing.Point(152, 104);
            this.lblCapitan.Name = "lblCapitan";
            this.lblCapitan.Size = new System.Drawing.Size(47, 13);
            this.lblCapitan.TabIndex = 4;
            this.lblCapitan.Text = "Kapetan";
            // 
            // pbFavoritePlayer
            // 
            this.pbFavoritePlayer.Location = new System.Drawing.Point(221, 119);
            this.pbFavoritePlayer.Name = "pbFavoritePlayer";
            this.pbFavoritePlayer.Size = new System.Drawing.Size(43, 33);
            this.pbFavoritePlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFavoritePlayer.TabIndex = 5;
            this.pbFavoritePlayer.TabStop = false;
            // 
            // UCPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pbFavoritePlayer);
            this.Controls.Add(this.lblCapitan);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblShirtNumber);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbPlayerPhoto);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "UCPlayer";
            this.Size = new System.Drawing.Size(276, 168);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavoritePlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlayerPhoto;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblShirtNumber;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblCapitan;
        private System.Windows.Forms.PictureBox pbFavoritePlayer;
    }
}
