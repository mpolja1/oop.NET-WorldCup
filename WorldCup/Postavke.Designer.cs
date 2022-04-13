namespace WorldCup
{
    partial class Postavke
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
            this.cbJezik = new System.Windows.Forms.ComboBox();
            this.cbPrvenstvo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbJezik
            // 
            this.cbJezik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJezik.FormattingEnabled = true;
            this.cbJezik.Items.AddRange(new object[] {
            "Hrvatski",
            "Engleski"});
            this.cbJezik.Location = new System.Drawing.Point(56, 113);
            this.cbJezik.Name = "cbJezik";
            this.cbJezik.Size = new System.Drawing.Size(242, 21);
            this.cbJezik.TabIndex = 0;
            // 
            // cbPrvenstvo
            // 
            this.cbPrvenstvo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrvenstvo.FormattingEnabled = true;
            this.cbPrvenstvo.Items.AddRange(new object[] {
            "Muško",
            "Žensko"});
            this.cbPrvenstvo.Location = new System.Drawing.Point(56, 214);
            this.cbPrvenstvo.Name = "cbPrvenstvo";
            this.cbPrvenstvo.Size = new System.Drawing.Size(242, 21);
            this.cbPrvenstvo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "ODABERITE JEZIK";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "ODABERITE PRVNESTVO";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(124, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "SPREMI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSave);
            // 
            // Postavke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 363);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPrvenstvo);
            this.Controls.Add(this.cbJezik);
            this.Name = "Postavke";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Postavke";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Postavke_FormClosing);
            this.Load += new System.EventHandler(this.Postavke_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbJezik;
        private System.Windows.Forms.ComboBox cbPrvenstvo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

