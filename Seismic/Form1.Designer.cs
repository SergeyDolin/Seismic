namespace Seismic
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
            this.derivatives = new System.Windows.Forms.Button();
            this.earthquakes = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.report = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // utc
            // 
            this.utc.Location = new System.Drawing.Point(12, 12);
            this.utc.Name = "utc";
            this.utc.Size = new System.Drawing.Size(322, 60);
            this.utc.TabIndex = 0;
            this.utc.Text = "UT1-UTC";
            this.utc.UseVisualStyleBackColor = true;
            this.utc.Click += new System.EventHandler(this.Utc_Click);
            // 
            // derivatives
            // 
            this.derivatives.Location = new System.Drawing.Point(13, 96);
            this.derivatives.Name = "derivatives";
            this.derivatives.Size = new System.Drawing.Size(322, 54);
            this.derivatives.TabIndex = 1;
            this.derivatives.Text = "Partial derivatives";
            this.derivatives.UseVisualStyleBackColor = true;
            this.derivatives.Click += new System.EventHandler(this.Derivatives_Click);
            // 
            // earthquakes
            // 
            this.earthquakes.Location = new System.Drawing.Point(13, 173);
            this.earthquakes.Name = "earthquakes";
            this.earthquakes.Size = new System.Drawing.Size(322, 50);
            this.earthquakes.TabIndex = 2;
            this.earthquakes.Text = "Earthquakes";
            this.earthquakes.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(341, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
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
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormSeismic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 307);
            this.Controls.Add(this.report);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.earthquakes);
            this.Controls.Add(this.derivatives);
            this.Controls.Add(this.utc);
            this.Name = "FormSeismic";
            this.Text = "Seismic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button utc;
        private System.Windows.Forms.Button derivatives;
        private System.Windows.Forms.Button earthquakes;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button report;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

