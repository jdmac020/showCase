using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MacGregorLab12.Views;

namespace MacGregorLab12
{
    /* Author:      Johnathan MacGregor
     * Date:        12/11/16
     * Program:     Lab12 Currency Converter
     * Program
     * Description: Program that fetches exchange rate API data and leverages it to display conversions to and from US dollars.
     * Class:       Program
     * Class 
     * Description: It's the main class that sets it all in motion. No modifications were made here in the making of this app.
     */
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new CurrencyConverterForm());
        }
    }
}
