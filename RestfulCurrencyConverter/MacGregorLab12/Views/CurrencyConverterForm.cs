using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MacGregorLab12.Exceptions;

namespace MacGregorLab12.Views
{
    /* Author:      Johnathan MacGregor
     * Date:        12/11/16
     * Program:     Lab12 Currency Converter
     * Program
     * Description: Program that fetches exchange rate API data and leverages it to display conversions to and from US dollars.
     * Class:       CurrencyConverterForm
     * Class 
     * Description: Event handlers, input wranglers, and view-specific data for the user-facing portion.
     */

    public partial class CurrencyConverterForm : Form
    {
        private readonly Controller control;
        private DateTime lastUpdate;
        private bool toDollars;
        private readonly List<string> amountLabelOptions;
        private readonly List<string> formTextOptions;

        /// <summary>
        /// Sole user interface for this program -- Allows user to convert to and from US Dollars in a variety of currencies.
        /// </summary>
        public CurrencyConverterForm()
        {
            InitializeComponent();
            control = new Controller();
            toDollars = false;
            amountLabelOptions = new List<string> {"US Dollars:", "Amount to Convert:"};
            formTextOptions = new List<string> {"Convert From Dollars", "Convert To Dollars"};
        }

        // load event handler
        private void CurrencyConverterForm_Load(object sender, EventArgs e)
        {
            try
            {
                lastUpdate = control.UpdateCache();
            }
            catch (ConnectionErrorException)
            {
                ResolveConnectionIssue();
            }
            
            PopulateExchangeRateListView();
            UpdateTimeStamp();
        }

        // Convert event handler for button and menu
        private void ConvertHandler(object sender, EventArgs e)
        {
            decimal amountConverting = 0;
            ListViewItem currencyChoice = null;

            conversionOutputLabel.Visible = false;

            try
            {
                amountConverting = GetAmountToConvert();
                currencyChoice = GetSelectedCurrency();
            }
            catch (NoDollarAmountSelectedException ndase)
            {
                MessageBox.Show("No Amount Selected!", "Can't Do That", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (NoExchangeCurrencySelectedException necse)
            {
                MessageBox.Show("No Currency Selected!", "Can't Do That", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal convertedTotal = control.GetCurrencyConversion(toDollars, amountConverting, currencyChoice);
            string currency = currencyChoice.SubItems[0].Text;

            string result = GetConversionOutputString(amountConverting, currency, convertedTotal);

            conversionOutputLabel.Visible = true;
            conversionOutputLabel.Text = result;

        }

        // Exit event handler for button and menu
        private void ExitHandler(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Clear event handler for button and menu
        private void ClearHandler(object sender, EventArgs e)
        {
            ClearForm();
        }

        // Handles the mode switch event
        private void SwitchModeHandler(object sender, EventArgs e)
        {
            ClearForm();

            if (toDollars == false)
            {
                TurnToDollarsModeOn();
            }
            else
            {
                TurnToDollarsModeOff();
            }
        }

        // Handles the About event
        private void AboutHandler(object sender, EventArgs e)
        {
            control.ShowAbout();
        }

        // Handles the refresh event
        private void RefreshRatesHandler(object sender, EventArgs e)
        {
            lastUpdate = control.UpdateCache();
            UpdateTimeStamp();
            MessageBox.Show("Exchange rates have been updated to most recent available data.", "Good Happy Success!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Begin control update helpers 

        // Updates the "last updated" time stamp
        private void UpdateTimeStamp()
        {
            lastUpdateLabel.Text = $"Exchange Rates Last Updated: {lastUpdate:G}";
        }

        // Pulls list of currencies in from controller then adds them to the appropriate list box, unless file is missing
        private void PopulateExchangeRateListView()
        {
            List<ListViewItem> exchangeRateItems = new List<ListViewItem>();
            
            try
            {
                exchangeRateItems = control.GetCurrencyListViewItems();
            }
            catch (BadCacheException)
            {
                MessageBox.Show("Looks like there is an issue connecting to the database and/or the data cache is incomplete or corrupted. " +
                                "\nPlease try again when you have an internet connection.", "Missing Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            exchangeRateListView.Items.AddRange(exchangeRateItems.ToArray());
        }

        // clears/hides or otherwise resets all controls on the form
        private void ClearForm()
        {
            amountListBox.SelectedIndex = -1;
            exchangeRateListView.SelectedItems.Clear();
            conversionOutputLabel.Text = string.Empty;
            conversionOutputLabel.Visible = false;
        }

        // changes form control properties to reflect the change in the form's purpose
        private void TurnToDollarsModeOff()
        {
            toDollars = false;

            this.Text = formTextOptions[0];

            amountListBoxLabel.Text = amountLabelOptions[0];

            toDollarsMenuItem.Enabled = true;
            fromDollarsMenuItem.Enabled = false;

        }

        // Begin logic helpers

        // changes form and control properties to reflect the change in the form's purpose
        private void TurnToDollarsModeOn()
        {
            toDollars = true;

            this.Text = formTextOptions[1];

            amountListBoxLabel.Text = amountLabelOptions[1];

            toDollarsMenuItem.Enabled = false;
            fromDollarsMenuItem.Enabled = true;

        }

        // Gets the amount selected, throws an exception if no seelection is made
        private decimal GetAmountToConvert()
        {
            decimal amountConverting;

            try
            {
                amountConverting = decimal.Parse((string)amountListBox.SelectedItem);
            }
            catch (ArgumentNullException ane)
            {
                throw new NoDollarAmountSelectedException();
            }

            return amountConverting;
        }

        // Checks that there is actually a selection made, then returns that selection or throws exception
        private ListViewItem GetSelectedCurrency()
        {

            if (exchangeRateListView.SelectedItems.Count < 1)
            {
                throw new NoExchangeCurrencySelectedException();
            }

            return exchangeRateListView.SelectedItems[0];
        }

        // Based on the form's current mode, returns the appropriate string
        private string GetConversionOutputString(decimal amountConverting, string currency, decimal convertedTotal)
        {
            string result;

            if (toDollars)
            {
                result = $"{amountConverting} {currency} = {convertedTotal:N} US Dollars";
            }
            else
            {
                result = $"{amountConverting} US Dollars = {convertedTotal:N} {currency}";
            }

            return result;
        }
        
        private void ResolveConnectionIssue()
        {
            DialogResult useCache =
                MessageBox.Show(
                    "There appears to be an issue retrieving the exchange rate data.\nDo you want you use the most recent cache?",
                    "Oh noes!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (useCache == DialogResult.Yes)
            {
                lastUpdate = control.GetLastTimeUpdated();
            }
            else
            {
                MessageBox.Show("Program will now close, thank you!", "Bye Then", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                Application.Exit();
            }
        }
    }
}
