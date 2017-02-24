using System;

namespace MacGregorLab12.Exceptions
{
    /* Author:      Johnathan MacGregor
     * Date:        12/11/16
     * Program:     Lab12 Currency Converter
     * Program
     * Description: Program that fetches exchange rate API data and leverages it to display conversions to and from US dollars.
     * Class:       NoExchangeCurrencySelectedException
     * Class 
     * Description: It's a custom, descriptive exception to be thrown when the user fails to select a currency option.
     */
    [Serializable]
    internal class NoExchangeCurrencySelectedException : Exception
    {
        /// <summary>
        /// Instantiates a new instance of the named exception.
        /// </summary>
        public NoExchangeCurrencySelectedException()
        {
        }
    }
}