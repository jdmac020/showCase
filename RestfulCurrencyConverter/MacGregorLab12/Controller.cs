using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MacGregorLab12.Exceptions;
using MacGregorLab12.Models;
using MacGregorLab12.Views;

namespace MacGregorLab12
{
    /* Author:      Johnathan MacGregor
     * Date:        12/11/16
     * Program:     Lab12 Currency Converter
     * Program
     * Description: Program that fetches exchange rate API data and leverages it to display conversions to and from US dollars.
     * Class:       Controller
     * Class 
     * Description: Calls upon the exchange rate service to do its thing, and passes information back to the form it knows nothing about
     */

    public class Controller
    {
        private readonly ExchangeRateService exchangeRates;
        private readonly CrucialInfo about;

        public Controller()
        {
            exchangeRates = new ExchangeRateService();
            about = new CrucialInfo();
        }

        // Calls on the exchange rate service to pull in a new JSON object, returns a datetime if successful
        public DateTime UpdateCache()
        {

            try
            {
                return exchangeRates.UpdateExchangeRateCache();
            }
            catch (WebException)
            {

                throw new ConnectionErrorException();
            }

            return exchangeRates.UpdateExchangeRateCache();
        }

        // Gets the date time of the last time the exchange rate file was written to
        public DateTime GetLastTimeUpdated()
        {
            return exchangeRates.GetCacheLastUpdated();
        }

        // Calls for the list of exchange rates and converts them into ListViewItems for the form
        public List<ListViewItem> GetCurrencyListViewItems()
        {
            List<ListViewItem> items = new List<ListViewItem>();

            List<ExchangeRate> rates = new List<ExchangeRate>();

            try
            {
                rates = exchangeRates.GetExchangeRates();
            }
            catch (FileNotFoundException)
            {
                
                throw new BadCacheException();
            }

            foreach (ExchangeRate rate in rates)
            {
                ListViewItem item = new ListViewItem(rate.CurrencyName);
                item.SubItems.Add(rate.Rate.ToString());

                items.Add(item);
            }

            return items;
        }

        // Based on arguments from the calling form creates an exchange rate item and sends it to the exchange rate service for conversion
        public decimal GetCurrencyConversion(bool isToDollars, decimal amountConvert, ListViewItem selectedCurrency)
        {
            ExchangeRate exchangeRate = new ExchangeRate
            {
                CurrencyName = selectedCurrency.SubItems[0].ToString(),
                Rate = decimal.Parse(selectedCurrency.SubItems[1].Text)
            };

            if (isToDollars)
            {
                return exchangeRates.ConvertToDollars(amountConvert, exchangeRate);
            }
            else
            {
                return exchangeRates.ConvertFromDollars(amountConvert, exchangeRate);
            }

        }

        // Shows the "about" form when called
        public void ShowAbout()
        {
            about.ShowDialog();
        }

    }
}
