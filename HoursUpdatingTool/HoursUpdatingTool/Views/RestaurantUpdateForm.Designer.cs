namespace HoursUpdatingTool
{
    partial class RestaurantUpdateForm
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
            this.components = new System.ComponentModel.Container();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateHoursMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createListButton = new System.Windows.Forms.Button();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.updateFileButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.viewEditHoursButton = new System.Windows.Forms.Button();
            this.selectSourceFileButton = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(338, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectSourceToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // selectSourceToolStripMenuItem
            // 
            this.selectSourceToolStripMenuItem.Name = "selectSourceToolStripMenuItem";
            this.selectSourceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.selectSourceToolStripMenuItem.Text = "&Select Source";
            this.selectSourceToolStripMenuItem.Click += new System.EventHandler(this.selectSourceToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateHoursMenuItem});
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.updateToolStripMenuItem.Text = "&Update";
            // 
            // updateHoursMenuItem
            // 
            this.updateHoursMenuItem.Enabled = false;
            this.updateHoursMenuItem.Name = "updateHoursMenuItem";
            this.updateHoursMenuItem.Size = new System.Drawing.Size(159, 22);
            this.updateHoursMenuItem.Text = "View/Edit &Hours";
            this.updateHoursMenuItem.Click += new System.EventHandler(this.updateAllToolStripMenuItem_Click);
            // 
            // createListButton
            // 
            this.createListButton.Enabled = false;
            this.createListButton.Location = new System.Drawing.Point(116, 145);
            this.createListButton.Name = "createListButton";
            this.createListButton.Size = new System.Drawing.Size(106, 23);
            this.createListButton.TabIndex = 1;
            this.createListButton.Text = "Import Source File";
            this.toolTip1.SetToolTip(this.createListButton, "Must import the spreadsheet before viewing/editing hours");
            this.createListButton.UseVisualStyleBackColor = true;
            this.createListButton.Click += new System.EventHandler(this.createListButton_Click);
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Location = new System.Drawing.Point(8, 62);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(35, 13);
            this.filePathLabel.TabIndex = 2;
            this.filePathLabel.Text = "label1";
            // 
            // updateFileButton
            // 
            this.updateFileButton.Enabled = false;
            this.updateFileButton.Location = new System.Drawing.Point(116, 219);
            this.updateFileButton.Name = "updateFileButton";
            this.updateFileButton.Size = new System.Drawing.Size(106, 23);
            this.updateFileButton.TabIndex = 3;
            this.updateFileButton.Text = "Update Source File";
            this.toolTip1.SetToolTip(this.updateFileButton, "Click to save changes made to your source file. You will be reminded to save when" +
        " exiting.");
            this.updateFileButton.UseVisualStyleBackColor = true;
            this.updateFileButton.Click += new System.EventHandler(this.UpdateFileButton_Click);
            // 
            // viewEditHoursButton
            // 
            this.viewEditHoursButton.Enabled = false;
            this.viewEditHoursButton.Location = new System.Drawing.Point(116, 182);
            this.viewEditHoursButton.Name = "viewEditHoursButton";
            this.viewEditHoursButton.Size = new System.Drawing.Size(106, 23);
            this.viewEditHoursButton.TabIndex = 4;
            this.viewEditHoursButton.Text = "View/Edit &Hours";
            this.toolTip1.SetToolTip(this.viewEditHoursButton, "Click to view or edit restaurant hours");
            this.viewEditHoursButton.UseVisualStyleBackColor = true;
            this.viewEditHoursButton.Click += new System.EventHandler(this.updateAllToolStripMenuItem_Click);
            // 
            // selectSourceFileButton
            // 
            this.selectSourceFileButton.Location = new System.Drawing.Point(116, 107);
            this.selectSourceFileButton.Name = "selectSourceFileButton";
            this.selectSourceFileButton.Size = new System.Drawing.Size(106, 23);
            this.selectSourceFileButton.TabIndex = 5;
            this.selectSourceFileButton.Text = "Select Source File";
            this.toolTip1.SetToolTip(this.selectSourceFileButton, "Click to browse to your file location");
            this.selectSourceFileButton.UseVisualStyleBackColor = true;
            this.selectSourceFileButton.Click += new System.EventHandler(this.selectSourceToolStripMenuItem_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(113, 35);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(81, 13);
            this.fileLabel.TabIndex = 6;
            this.fileLabel.Text = "Current Source:";
            // 
            // RestaurantUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 261);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.selectSourceFileButton);
            this.Controls.Add(this.viewEditHoursButton);
            this.Controls.Add(this.updateFileButton);
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.createListButton);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "RestaurantUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurant Update Central";
            this.Activated += new System.EventHandler(this.RestaurantUpdateForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RestaurantUpdateForm_FormClosing);
            this.Load += new System.EventHandler(this.RestaurantUpdateForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectSourceToolStripMenuItem;
        private System.Windows.Forms.Button createListButton;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateHoursMenuItem;
        private System.Windows.Forms.Button updateFileButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button viewEditHoursButton;
        private System.Windows.Forms.Button selectSourceFileButton;
        private System.Windows.Forms.Label fileLabel;
    }
}

