namespace WorldCup
{
    partial class UCMatchStats
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
            this.lblLocationn = new System.Windows.Forms.Label();
            this.lblAttendance = new System.Windows.Forms.Label();
            this.lblHomeTeam = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAwayTeam = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLocationn
            // 
            this.lblLocationn.Location = new System.Drawing.Point(5, 10);
            this.lblLocationn.Name = "lblLocationn";
            this.lblLocationn.Size = new System.Drawing.Size(96, 20);
            this.lblLocationn.TabIndex = 0;
            this.lblLocationn.Text = "Lokacija";
            // 
            // lblAttendance
            // 
            this.lblAttendance.AutoSize = true;
            this.lblAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttendance.Location = new System.Drawing.Point(108, 10);
            this.lblAttendance.Name = "lblAttendance";
            this.lblAttendance.Size = new System.Drawing.Size(93, 16);
            this.lblAttendance.TabIndex = 1;
            this.lblAttendance.Text = "Posjećenost";
            // 
            // lblHomeTeam
            // 
            this.lblHomeTeam.AutoSize = true;
            this.lblHomeTeam.Location = new System.Drawing.Point(3, 44);
            this.lblHomeTeam.Name = "lblHomeTeam";
            this.lblHomeTeam.Size = new System.Drawing.Size(49, 13);
            this.lblHomeTeam.TabIndex = 2;
            this.lblHomeTeam.Text = "Domaćin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "VS";
            // 
            // lblAwayTeam
            // 
            this.lblAwayTeam.AutoSize = true;
            this.lblAwayTeam.Location = new System.Drawing.Point(128, 44);
            this.lblAwayTeam.Name = "lblAwayTeam";
            this.lblAwayTeam.Size = new System.Drawing.Size(29, 13);
            this.lblAwayTeam.TabIndex = 4;
            this.lblAwayTeam.Text = "Gost";
            // 
            // UCMatchStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblAwayTeam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblHomeTeam);
            this.Controls.Add(this.lblAttendance);
            this.Controls.Add(this.lblLocationn);
            this.Name = "UCMatchStats";
            this.Size = new System.Drawing.Size(249, 80);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLocationn;
        private System.Windows.Forms.Label lblAttendance;
        private System.Windows.Forms.Label lblHomeTeam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAwayTeam;
    }
}
