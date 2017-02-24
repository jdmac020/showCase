namespace HoursUpdatingTool
{
    partial class ProgressForm
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
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.progLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(56, 40);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(184, 23);
            this.progBar.TabIndex = 0;
            // 
            // progLabel
            // 
            this.progLabel.AutoSize = true;
            this.progLabel.Location = new System.Drawing.Point(56, 66);
            this.progLabel.Name = "progLabel";
            this.progLabel.Size = new System.Drawing.Size(35, 13);
            this.progLabel.TabIndex = 1;
            this.progLabel.Text = "label1";
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 118);
            this.Controls.Add(this.progLabel);
            this.Controls.Add(this.progBar);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Name = "ProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processing...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ProgressBar progBar;
        internal System.Windows.Forms.Label progLabel;
    }
}