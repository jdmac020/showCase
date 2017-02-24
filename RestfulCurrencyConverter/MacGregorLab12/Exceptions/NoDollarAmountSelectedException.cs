using System;

namespace MacGregorLab12.Exceptions
{
    /* Author:      Johnathan MacGregor
     * Date:        12/11/16
     * Program:     Lab12 Currency Converter
     * Program
     * Description: Program that fetches exchange rate API data and leverages it to display conversions to and from US dollars.
     * Class:       NoDollarAmountSelectedException
     * Class 
     * Description: It's a custom, descriptive exception that should look very familiar. VisualStudio added a Serializable tag on its
     *              own, and I figured it wasn't hurting anything (though as of this commenting I haven't researched why it did that).
     */
    [Serializable]
    internal class NoDollarAmountSelectedException : Exception
    {
        /// <summary>
        /// Instantiates a new instance of the named exception.
        /// </summary>
        public NoDollarAmountSelectedException()
        {
        }
        
    }
}