﻿namespace Vang_de_volger
{
    partial class StartScreen
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
            this.creatorLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.Exit_button = new System.Windows.Forms.Button();
            this.Start_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // creatorLabel
            // 
            this.creatorLabel.AutoSize = true;
            this.creatorLabel.Location = new System.Drawing.Point(515, 427);
            this.creatorLabel.Name = "creatorLabel";
            this.creatorLabel.Size = new System.Drawing.Size(278, 17);
            this.creatorLabel.TabIndex = 7;
            this.creatorLabel.Text = "Made by: Shivam Akloe & Sang Phan Thanh";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(252, 69);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(255, 39);
            this.titleLabel.TabIndex = 6;
            this.titleLabel.Text = "Vang de volger!";
            // 
            // Exit_button
            // 
            this.Exit_button.Location = new System.Drawing.Point(311, 193);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(136, 31);
            this.Exit_button.TabIndex = 5;
            this.Exit_button.Text = "Exit Game";
            this.Exit_button.UseVisualStyleBackColor = true;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // Start_Button
            // 
            this.Start_Button.Location = new System.Drawing.Point(311, 135);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(136, 42);
            this.Start_Button.TabIndex = 4;
            this.Start_Button.Text = "Start Game";
            this.Start_Button.UseVisualStyleBackColor = true;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.creatorLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.Start_Button);
            this.Name = "StartScreen";
            this.Text = "Vang de volger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label creatorLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button Exit_button;
        private System.Windows.Forms.Button Start_Button;
    }
}