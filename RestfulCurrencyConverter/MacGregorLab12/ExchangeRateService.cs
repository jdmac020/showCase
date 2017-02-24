using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using MacGregorLab12.Models;
using Newtonsoft.Json;

namespace MacGregorLab12
{
    /* Author:      Johnathan MacGregor
     * Date:        12/11/16
     * Program:     Lab12 Currency Converter
     * Program
     * Description: Program that fetches exchange rate API data and leverages it to display conversions to and from US dollars.
     * Class:       ExchangeRateService
     * Class 
     * Description: Handles the interaction with the API and converting the JSON into POCO. Creates files sent to the /debug folder
     *              to allow off-line use of app.
     */

    /// <summary>
    /// Service that handles the interaction with the API and processes the downloaded data.
    /// </summary>
    public class ExchangeRateService
    {

        private const string EXCHANGE_RATE_OBJECT_URL =
            "https://openexchangerates.org/api/latest.json?app_id=f36fb0f953a34ddaaac09a6bd67e9fc9";
        private const string CURRENCY_FULL_NAMES_URL = "https://openexchangerates.org/api/currencies.json";
        private const string RATES_FILE_NAME = "cachedExchangeRates.json";
        private const string CURRENCIES_FILE_NAME = "cachedCurrencies.json";
        private readonly string ratesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RATES_FILE_NAME);
        private readonly string currenciesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CURRENCIES_FILE_NAME);

        /// <summary>
        /// Downloads the exchange rate and currency information and saves them to local file. Returns time of completion if successful.
        /// </summary>
        public DateTime UpdateExchangeRateCache()
        {
            using (WebClient client = new WebClient())
            {
                var jsonExchangeRate = client.DownloadString(EXCHANGE_RATE_OBJECT_URL);
                var jsonCurrencies = client.DownloadString(CURRENCY_FULL_NAMES_URL);

                File.WriteAllText(ratesPath, jsonExchangeRate);
                File.WriteAllText(currenciesPath, jsonCurrencies);
            }

            return DateTime.Now;
        }

        /// <summary>
        /// Returns the last time currency rates file was written to. Used in the event of using cached instead of downloaded data.
        /// </summary>
        public DateTime GetCacheLastUpdated()
        {
            return File.GetLastWriteTime(ratesPath);
        }

        /// <summary>
        /// Returns the list of exchange rates based on the current file data.
        /// </summary>
        public List<ExchangeRate> GetExchangeRates()
        {

            List<ExchangeRate> rates = new List<ExchangeRate>();

            var response = JsonConvert.DeserializeObject<ExchangeRateResponse>(File.ReadAllText(ratesPath));
            var currencies = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(currenciesPath));

            foreach (var rate in response.Rates)
            {
                string currency;

                currencies.TryGetValue(rate.Key, out currency);

                var exchangeRate = new ExchangeRate { CurrencyCode = rate.Key, CurrencyName = currency, Rate = rate.Value };
                rates.Add(exchangeRate);
            }

            return rates;
        }

        /// <summary>
        /// Converts a passed amount of dollars to a new amount foreign currency based on the passed exchange rate.
        /// </summary>
        public decimal ConvertFromDollars(decimal dollarAmount, ExchangeRate exchangeRate)
        {
            return dollarAmount * exchangeRate.Rate;
        }

        /// <summary>
        /// Converts a passed amount of currency to a new amount of dollars based on the passed exchange rate.
        /// </summary>
        public decimal ConvertToDollars(decimal currencyAmount, ExchangeRate exchangeRate)
        {
            return currencyAmount / exchangeRate.Rate;
        }
    }
}
