namespace WindowsFormsApp1
{
    partial class MainForm
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tB_alphabet = new System.Windows.Forms.TextBox();
            this.rTB_log = new System.Windows.Forms.RichTextBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 415);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(776, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // tB_alphabet
            // 
            this.tB_alphabet.Location = new System.Drawing.Point(12, 12);
            this.tB_alphabet.Multiline = true;
            this.tB_alphabet.Name = "tB_alphabet";
            this.tB_alphabet.ReadOnly = true;
            this.tB_alphabet.Size = new System.Drawing.Size(380, 332);
            this.tB_alphabet.TabIndex = 2;
            // 
            // rTB_log
            // 
            this.rTB_log.Location = new System.Drawing.Point(398, 12);
            this.rTB_log.Name = "rTB_log";
            this.rTB_log.Size = new System.Drawing.Size(390, 332);
            this.rTB_log.TabIndex = 4;
            this.rTB_log.Text = "";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(12, 368);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(776, 23);
            this.progressBar2.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.rTB_log);
            this.Controls.Add(this.tB_alphabet);
            this.Controls.Add(this.progressBar1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox tB_alphabet;
        private System.Windows.Forms.RichTextBox rTB_log;
        private System.Windows.Forms.ProgressBar progressBar2;
    }
}

