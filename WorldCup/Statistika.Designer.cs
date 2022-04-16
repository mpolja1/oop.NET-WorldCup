namespace WorldCup
{
    partial class Statistika
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
            this.flwAttendence = new System.Windows.Forms.FlowLayoutPanel();
            this.flwPlayerStats = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAttendance = new System.Windows.Forms.Label();
            this.lblPlayerStats = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGoals = new System.Windows.Forms.Button();
            this.bntCards = new System.Windows.Forms.Button();
            this.bntPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flwAttendence
            // 
            this.flwAttendence.AutoScroll = true;
            this.flwAttendence.Location = new System.Drawing.Point(479, 44);
            this.flwAttendence.Name = "flwAttendence";
            this.flwAttendence.Size = new System.Drawing.Size(291, 405);
            this.flwAttendence.TabIndex = 0;
            // 
            // flwPlayerStats
            // 
            this.flwPlayerStats.AutoScroll = true;
            this.flwPlayerStats.Location = new System.Drawing.Point(47, 41);
            this.flwPlayerStats.Name = "flwPlayerStats";
            this.flwPlayerStats.Size = new System.Drawing.Size(271, 408);
            this.flwPlayerStats.TabIndex = 1;
            // 
            // lblAttendance
            // 
            this.lblAttendance.AutoSize = true;
            this.lblAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttendance.Location = new System.Drawing.Point(559, 14);
            this.lblAttendance.Name = "lblAttendance";
            this.lblAttendance.Size = new System.Drawing.Size(102, 20);
            this.lblAttendance.TabIndex = 2;
            this.lblAttendance.Text = "Attendance";
            // 
            // lblPlayerStats
            // 
            this.lblPlayerStats.AutoSize = true;
            this.lblPlayerStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerStats.Location = new System.Drawing.Point(105, 14);
            this.lblPlayerStats.Name = "lblPlayerStats";
            this.lblPlayerStats.Size = new System.Drawing.Size(106, 20);
            this.lblPlayerStats.TabIndex = 3;
            this.lblPlayerStats.Text = "Player Stats";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(479, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(267, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "Sort by Attendence";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGoals
            // 
            this.btnGoals.Location = new System.Drawing.Point(47, 453);
            this.btnGoals.Name = "btnGoals";
            this.btnGoals.Size = new System.Drawing.Size(114, 37);
            this.btnGoals.TabIndex = 5;
            this.btnGoals.Text = "ByGoals";
            this.btnGoals.UseVisualStyleBackColor = true;
            this.btnGoals.Click += new System.EventHandler(this.btnGoals_Click);
            // 
            // bntCards
            // 
            this.bntCards.Location = new System.Drawing.Point(188, 453);
            this.bntCards.Name = "bntCards";
            this.bntCards.Size = new System.Drawing.Size(118, 37);
            this.bntCards.TabIndex = 6;
            this.bntCards.Text = "ByYellowCards";
            this.bntCards.UseVisualStyleBackColor = true;
            this.bntCards.Click += new System.EventHandler(this.bntCards_Click);
            // 
            // bntPrint
            // 
            this.bntPrint.Location = new System.Drawing.Point(324, 216);
            this.bntPrint.Name = "bntPrint";
            this.bntPrint.Size = new System.Drawing.Size(149, 40);
            this.bntPrint.TabIndex = 7;
            this.bntPrint.Text = "Print";
            this.bntPrint.UseVisualStyleBackColor = true;
            this.bntPrint.Click += new System.EventHandler(this.bntPrint_Click);
            // 
            // Statistika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(806, 502);
            this.Controls.Add(this.bntPrint);
            this.Controls.Add(this.bntCards);
            this.Controls.Add(this.btnGoals);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPlayerStats);
            this.Controls.Add(this.lblAttendance);
            this.Controls.Add(this.flwPlayerStats);
            this.Controls.Add(this.flwAttendence);
            this.Name = "Statistika";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistika";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Statistika_FormClosing);
            this.Load += new System.EventHandler(this.Statistika_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flwAttendence;
        private System.Windows.Forms.FlowLayoutPanel flwPlayerStats;
        private System.Windows.Forms.Label lblAttendance;
        private System.Windows.Forms.Label lblPlayerStats;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGoals;
        private System.Windows.Forms.Button bntCards;
        private System.Windows.Forms.Button bntPrint;
    }
}