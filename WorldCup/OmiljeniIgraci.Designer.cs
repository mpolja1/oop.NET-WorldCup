﻿namespace WorldCup
{
    partial class OmiljeniIgraci
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OmiljeniIgraci));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flpAllPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flpFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStatistic = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // flpAllPlayers
            // 
            resources.ApplyResources(this.flpAllPlayers, "flpAllPlayers");
            this.flpAllPlayers.AllowDrop = true;
            this.flpAllPlayers.Name = "flpAllPlayers";
            this.flpAllPlayers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flpFavoritePlayers_MouseDown);
            // 
            // flpFavoritePlayers
            // 
            resources.ApplyResources(this.flpFavoritePlayers, "flpFavoritePlayers");
            this.flpFavoritePlayers.AllowDrop = true;
            this.flpFavoritePlayers.Name = "flpFavoritePlayers";
            this.flpFavoritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragDrop);
            this.flpFavoritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragEnter);
            this.flpFavoritePlayers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flpFavoritePlayers_MouseDown);
            // 
            // btnStatistic
            // 
            resources.ApplyResources(this.btnStatistic, "btnStatistic");
            this.btnStatistic.Name = "btnStatistic";
            this.btnStatistic.UseVisualStyleBackColor = true;
            this.btnStatistic.Click += new System.EventHandler(this.btnStatistic_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_Clear_click);
            // 
            // OmiljeniIgraci
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStatistic);
            this.Controls.Add(this.flpFavoritePlayers);
            this.Controls.Add(this.flpAllPlayers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OmiljeniIgraci";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OmiljeniIgraci_FormClosing);
            this.Load += new System.EventHandler(this.OmiljeniIgraci_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpAllPlayers;
        private System.Windows.Forms.FlowLayoutPanel flpFavoritePlayers;
        private System.Windows.Forms.Button btnStatistic;
        private System.Windows.Forms.Button button1;
    }
}