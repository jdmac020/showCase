namespace MacGregorLab12.Models
{
    /* Author:      Johnathan MacGregor
     * Date:        12/11/16
     * Program:     Lab12 Currency Converter
     * Program
     * Description: Program that fetches exchange rate API data and leverages it to display conversions to and from US dollars.
     * Class:       ExchangeRate
     * Class 
     * Description: The refined finished product POCO that combines CurrenciesResponse and ExchangeRateResponse into one
     *              mildly robust object.
     */

    /// <summary>
    /// Class that combines data from both CurrenciesResponse and ExchangeRateResponse objects into one object.
    /// </summary>
    public class ExchangeRate
    {
        
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public decimal Rate { get; set; }
    }
}
