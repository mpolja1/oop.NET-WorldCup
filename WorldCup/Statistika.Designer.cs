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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistika));
            this.flwAttendence = new System.Windows.Forms.FlowLayoutPanel();
            this.flwPlayerStats = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAttendance = new System.Windows.Forms.Label();
            this.lblPlayerStats = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGoals = new System.Windows.Forms.Button();
            this.bntCards = new System.Windows.Forms.Button();
            this.bntPrint = new System.Windows.Forms.Button();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // flwAttendence
            // 
            resources.ApplyResources(this.flwAttendence, "flwAttendence");
            this.flwAttendence.Name = "flwAttendence";
            // 
            // flwPlayerStats
            // 
            resources.ApplyResources(this.flwPlayerStats, "flwPlayerStats");
            this.flwPlayerStats.Name = "flwPlayerStats";
            // 
            // lblAttendance
            // 
            resources.ApplyResources(this.lblAttendance, "lblAttendance");
            this.lblAttendance.Name = "lblAttendance";
            // 
            // lblPlayerStats
            // 
            resources.ApplyResources(this.lblPlayerStats, "lblPlayerStats");
            this.lblPlayerStats.Name = "lblPlayerStats";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGoals
            // 
            resources.ApplyResources(this.btnGoals, "btnGoals");
            this.btnGoals.Name = "btnGoals";
            this.btnGoals.UseVisualStyleBackColor = true;
            this.btnGoals.Click += new System.EventHandler(this.btnGoals_Click);
            // 
            // bntCards
            // 
            resources.ApplyResources(this.bntCards, "bntCards");
            this.bntCards.Name = "bntCards";
            this.bntCards.UseVisualStyleBackColor = true;
            this.bntCards.Click += new System.EventHandler(this.bntCards_Click);
            // 
            // bntPrint
            // 
            resources.ApplyResources(this.bntPrint, "bntPrint");
            this.bntPrint.Name = "bntPrint";
            this.bntPrint.UseVisualStyleBackColor = true;
            this.bntPrint.Click += new System.EventHandler(this.bntPrint_Click);
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(this.printPreviewDialog, "printPreviewDialog");
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Name = "printPreviewDialog";
            // 
            // Statistika
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.Controls.Add(this.bntPrint);
            this.Controls.Add(this.bntCards);
            this.Controls.Add(this.btnGoals);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPlayerStats);
            this.Controls.Add(this.lblAttendance);
            this.Controls.Add(this.flwPlayerStats);
            this.Controls.Add(this.flwAttendence);
            this.Name = "Statistika";
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
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
    }
}