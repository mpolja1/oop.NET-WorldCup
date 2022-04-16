namespace WorldCup
{
    partial class UCPlayerStats
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
            this.pbPlayerPhoto = new System.Windows.Forms.PictureBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblGoals = new System.Windows.Forms.Label();
            this.lblYellowCards = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPlayerPhoto
            // 
            this.pbPlayerPhoto.BackColor = System.Drawing.Color.White;
            this.pbPlayerPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPlayerPhoto.Location = new System.Drawing.Point(3, 3);
            this.pbPlayerPhoto.Name = "pbPlayerPhoto";
            this.pbPlayerPhoto.Size = new System.Drawing.Size(120, 123);
            this.pbPlayerPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlayerPhoto.TabIndex = 0;
            this.pbPlayerPhoto.TabStop = false;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(131, 16);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(129, 23);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "Name";
            // 
            // lblGoals
            // 
            this.lblGoals.AutoSize = true;
            this.lblGoals.Location = new System.Drawing.Point(172, 49);
            this.lblGoals.Name = "lblGoals";
            this.lblGoals.Size = new System.Drawing.Size(34, 13);
            this.lblGoals.TabIndex = 2;
            this.lblGoals.Text = "Goals";
            // 
            // lblYellowCards
            // 
            this.lblYellowCards.AutoSize = true;
            this.lblYellowCards.Location = new System.Drawing.Point(172, 88);
            this.lblYellowCards.Name = "lblYellowCards";
            this.lblYellowCards.Size = new System.Drawing.Size(67, 13);
            this.lblYellowCards.TabIndex = 3;
            this.lblYellowCards.Text = "Yellow-cards";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Goals:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cards: ";
            // 
            // UCPlayerStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblYellowCards);
            this.Controls.Add(this.lblGoals);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.pbPlayerPhoto);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "UCPlayerStats";
            this.Size = new System.Drawing.Size(263, 129);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlayerPhoto;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblGoals;
        private System.Windows.Forms.Label lblYellowCards;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
