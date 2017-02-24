namespace MacGregorLab12.Views
{

    partial class CurrencyConverterForm
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
            this.amountListBoxLabel = new System.Windows.Forms.Label();
            this.amountListBox = new System.Windows.Forms.ListBox();
            this.exchangeRateListView = new System.Windows.Forms.ListView();
            this.currencyHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.conversionOutputLabel = new System.Windows.Forms.Label();
            this.convertButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.currencyConverterMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toDollarsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromDollarsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshRatesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastUpdateLabel = new System.Windows.Forms.Label();
            this.currencyConverterMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // amountListBoxLabel
            // 
            this.amountListBoxLabel.Location = new System.Drawing.Point(16, 41);
            this.amountListBoxLabel.Name = "amountListBoxLabel";
            this.amountListBoxLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.amountListBoxLabel.Size = new System.Drawing.Size(100, 13);
            this.amountListBoxLabel.TabIndex = 0;
            this.amountListBoxLabel.Text = "US Dollars:";
            this.amountListBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // amountListBox
            // 
            this.amountListBox.FormattingEnabled = true;
            this.amountListBox.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "20",
            "50",
            "100",
            "1,000",
            "5,000",
            "10,000"});
            this.amountListBox.Location = new System.Drawing.Point(33, 57);
            this.amountListBox.Name = "amountListBox";
            this.amountListBox.Size = new System.Drawing.Size(62, 43);
            this.amountListBox.TabIndex = 0;
            // 
            // exchangeRateListView
            // 
            this.exchangeRateListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.currencyHeader,
            this.rateHeader});
            this.exchangeRateListView.FullRowSelect = true;
            this.exchangeRateListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.exchangeRateListView.HideSelection = false;
            this.exchangeRateListView.Location = new System.Drawing.Point(128, 41);
            this.exchangeRateListView.Name = "exchangeRateListView";
            this.exchangeRateListView.Size = new System.Drawing.Size(278, 109);
            this.exchangeRateListView.TabIndex = 2;
            this.exchangeRateListView.UseCompatibleStateImageBehavior = false;
            this.exchangeRateListView.View = System.Windows.Forms.View.Details;
            // 
            // currencyHeader
            // 
            this.currencyHeader.Text = "Currency";
            this.currencyHeader.Width = 190;
            // 
            // rateHeader
            // 
            this.rateHeader.Text = "Rate";
            this.rateHeader.Width = 67;
            // 
            // conversionOutputLabel
            // 
            this.conversionOutputLabel.AutoSize = true;
            this.conversionOutputLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.conversionOutputLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conversionOutputLabel.Location = new System.Drawing.Point(16, 164);
            this.conversionOutputLabel.Name = "conversionOutputLabel";
            this.conversionOutputLabel.Size = new System.Drawing.Size(2, 15);
            this.conversionOutputLabel.TabIndex = 3;
            this.conversionOutputLabel.Visible = false;
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(77, 195);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(75, 23);
            this.convertButton.TabIndex = 3;
            this.convertButton.Text = "&Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.ConvertHandler);
            // 
            // clearButton
            // 
            this.clearButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.clearButton.Location = new System.Drawing.Point(180, 195);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "C&lear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearHandler);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(283, 195);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "E&xit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitHandler);
            // 
            // currencyConverterMenu
            // 
            this.currencyConverterMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.currencyConverterMenu.Location = new System.Drawing.Point(0, 0);
            this.currencyConverterMenu.Name = "currencyConverterMenu";
            this.currencyConverterMenu.Size = new System.Drawing.Size(434, 24);
            this.currencyConverterMenu.TabIndex = 7;
            this.currencyConverterMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertMenuItem,
            this.modeToolStripMenuItem,
            this.toolStripSeparator2,
            this.refreshRatesMenuItem,
            this.toolStripSeparator1,
            this.exitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // convertMenuItem
            // 
            this.convertMenuItem.Name = "convertMenuItem";
            this.convertMenuItem.Size = new System.Drawing.Size(144, 22);
            this.convertMenuItem.Text = "&Convert";
            this.convertMenuItem.Click += new System.EventHandler(this.ConvertHandler);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toDollarsMenuItem,
            this.fromDollarsMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.modeToolStripMenuItem.Text = "&Mode";
            // 
            // toDollarsMenuItem
            // 
            this.toDollarsMenuItem.Name = "toDollarsMenuItem";
            this.toDollarsMenuItem.Size = new System.Drawing.Size(141, 22);
            this.toDollarsMenuItem.Text = "To &Dollars";
            this.toDollarsMenuItem.Click += new System.EventHandler(this.SwitchModeHandler);
            // 
            // fromDollarsMenuItem
            // 
            this.fromDollarsMenuItem.Enabled = false;
            this.fromDollarsMenuItem.Name = "fromDollarsMenuItem";
            this.fromDollarsMenuItem.Size = new System.Drawing.Size(141, 22);
            this.fromDollarsMenuItem.Text = "&From Dollars";
            this.fromDollarsMenuItem.Click += new System.EventHandler(this.SwitchModeHandler);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // refreshRatesMenuItem
            // 
            this.refreshRatesMenuItem.Name = "refreshRatesMenuItem";
            this.refreshRatesMenuItem.Size = new System.Drawing.Size(144, 22);
            this.refreshRatesMenuItem.Text = "&Refresh Rates";
            this.refreshRatesMenuItem.Click += new System.EventHandler(this.RefreshRatesHandler);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(144, 22);
            this.exitMenuItem.Text = "E&xit";
            this.exitMenuItem.Click += new System.EventHandler(this.ExitHandler);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "E&dit";
            // 
            // clearMenuItem
            // 
            this.clearMenuItem.Name = "clearMenuItem";
            this.clearMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearMenuItem.Text = "C&lear";
            this.clearMenuItem.Click += new System.EventHandler(this.ClearHandler);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutMenuItem.Text = "&About";
            this.aboutMenuItem.Click += new System.EventHandler(this.AboutHandler);
            // 
            // lastUpdateLabel
            // 
            this.lastUpdateLabel.AutoSize = true;
            this.lastUpdateLabel.Location = new System.Drawing.Point(74, 224);
            this.lastUpdateLabel.Name = "lastUpdateLabel";
            this.lastUpdateLabel.Size = new System.Drawing.Size(156, 13);
            this.lastUpdateLabel.TabIndex = 15;
            this.lastUpdateLabel.Text = "Exchange Rates Last Updated:";
            // 
            // CurrencyConverterForm
            // 
            this.AcceptButton = this.convertButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.clearButton;
            this.ClientSize = new System.Drawing.Size(434, 244);
            this.Controls.Add(this.lastUpdateLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.conversionOutputLabel);
            this.Controls.Add(this.exchangeRateListView);
            this.Controls.Add(this.amountListBox);
            this.Controls.Add(this.amountListBoxLabel);
            this.Controls.Add(this.currencyConverterMenu);
            this.MainMenuStrip = this.currencyConverterMenu;
            this.Name = "CurrencyConverterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convert From Dollars";
            this.Load += new System.EventHandler(this.CurrencyConverterForm_Load);
            this.currencyConverterMenu.ResumeLayout(false);
            this.currencyConverterMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader currencyHeader;
        private System.Windows.Forms.ColumnHeader rateHeader;
        private System.Windows.Forms.ToolStripMenuItem convertMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem refreshRatesMenuItem;
        private System.Windows.Forms.Label lastUpdateLabel;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toDollarsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromDollarsMenuItem;
        private System.Windows.Forms.ListBox amountListBox;
        private System.Windows.Forms.Label amountListBoxLabel;
        private System.Windows.Forms.ListView exchangeRateListView;
        private System.Windows.Forms.Label conversionOutputLabel;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.MenuStrip currencyConverterMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    }
}