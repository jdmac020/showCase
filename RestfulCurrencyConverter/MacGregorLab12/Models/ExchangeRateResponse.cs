using System.Collections.Generic;

namespace MacGregorLab12.Models
{
    /* Author:      Johnathan MacGregor
     * Date:        12/11/16
     * Program:     Lab12 Currency Converter
     * Program
     * Description: Program that fetches exchange rate API data and leverages it to display conversions to and from US dollars.
     * Class:       ExchangeRateResponse
     * Class 
     * Description: The freshly-deserialized-from-JSON object that provides the actual exchange rates.
     */

    /// <summary>
    /// Deserialized-from-JSON object that primarily provides currency codes and their exchange rates.
    /// </summary>
    class ExchangeRateResponse
    {
        public string Disclaimer { get; set; }
        public string License { get; set; }
        public int Timestamp { get; set; }
        public string Base { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }

    }
}
