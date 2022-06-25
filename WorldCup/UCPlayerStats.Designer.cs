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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPlayerStats));
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
            resources.ApplyResources(this.pbPlayerPhoto, "pbPlayerPhoto");
            this.pbPlayerPhoto.BackColor = System.Drawing.Color.White;
            this.pbPlayerPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPlayerPhoto.Name = "pbPlayerPhoto";
            this.pbPlayerPhoto.TabStop = false;
            // 
            // lblFullName
            // 
            resources.ApplyResources(this.lblFullName, "lblFullName");
            this.lblFullName.Name = "lblFullName";
            // 
            // lblGoals
            // 
            resources.ApplyResources(this.lblGoals, "lblGoals");
            this.lblGoals.Name = "lblGoals";
            // 
            // lblYellowCards
            // 
            resources.ApplyResources(this.lblYellowCards, "lblYellowCards");
            this.lblYellowCards.Name = "lblYellowCards";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // UCPlayerStats
            // 
            resources.ApplyResources(this, "$this");
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
