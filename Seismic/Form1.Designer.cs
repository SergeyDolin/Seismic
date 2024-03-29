﻿namespace Seismic
{
    partial class FormSeismic
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
            this.utc = new System.Windows.Forms.Button();
            this.inetrtions = new System.Windows.Forms.Button();
            this.earthquakes = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.report = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tai = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // utc
            // 
            this.utc.Location = new System.Drawing.Point(12, 12);
            this.utc.Name = "utc";
            this.utc.Size = new System.Drawing.Size(114, 31);
            this.utc.TabIndex = 0;
            this.utc.Text = "UT1-UTC";
            this.utc.UseVisualStyleBackColor = true;
            this.utc.Click += new System.EventHandler(this.Utc_Click);
            // 
            // inetrtions
            // 
            this.inetrtions.Location = new System.Drawing.Point(13, 96);
            this.inetrtions.Name = "inetrtions";
            this.inetrtions.Size = new System.Drawing.Size(322, 54);
            this.inetrtions.TabIndex = 1;
            this.inetrtions.Text = "Moments of inertia";
            this.inetrtions.UseVisualStyleBackColor = true;
            this.inetrtions.Click += new System.EventHandler(this.Inertia_Click);
            // 
            // earthquakes
            // 
            this.earthquakes.Location = new System.Drawing.Point(13, 173);
            this.earthquakes.Name = "earthquakes";
            this.earthquakes.Size = new System.Drawing.Size(322, 50);
            this.earthquakes.TabIndex = 2;
            this.earthquakes.Text = "Earthquakes";
            this.earthquakes.UseVisualStyleBackColor = true;
            this.earthquakes.Click += new System.EventHandler(this.Earthquakes_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(341, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(400, 282);
            this.textBox1.TabIndex = 3;
            // 
            // report
            // 
            this.report.Location = new System.Drawing.Point(13, 247);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(322, 47);
            this.report.TabIndex = 4;
            this.report.Text = "Report";
            this.report.UseVisualStyleBackColor = true;
            this.report.Click += new System.EventHandler(this.Report_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tai
            // 
            this.tai.Location = new System.Drawing.Point(13, 49);
            this.tai.Name = "tai";
            this.tai.Size = new System.Drawing.Size(113, 32);
            this.tai.TabIndex = 5;
            this.tai.Text = "TAI-UTC";
            this.tai.UseVisualStyleBackColor = true;
            this.tai.Click += new System.EventHandler(this.Tai_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(132, 12);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(203, 69);
            this.start.TabIndex = 6;
            this.start.Text = "Run";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // FormSeismic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 307);
            this.Controls.Add(this.start);
            this.Controls.Add(this.tai);
            this.Controls.Add(this.report);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.earthquakes);
            this.Controls.Add(this.inetrtions);
            this.Controls.Add(this.utc);
            this.Name = "FormSeismic";
            this.Text = "Seismic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button utc;
        private System.Windows.Forms.Button inetrtions;
        private System.Windows.Forms.Button earthquakes;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button report;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button tai;
        private System.Windows.Forms.Button start;
    }
}

