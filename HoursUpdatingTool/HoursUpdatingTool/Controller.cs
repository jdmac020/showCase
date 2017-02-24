using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using HoursUpdatingTool.Services;
using Excel = Microsoft.Office.Interop.Excel;

namespace HoursUpdatingTool
{
    public class Controller
    {
        private List<Restaurant> restaurantList;
        private ProgressForm progForm;

        public Controller()
        {
            progForm = new ProgressForm();
        }

        public void GetRestaurantList(string restaurantFilePath)
        {
            ExcelService excel = new ExcelService(restaurantFilePath);

            excel.StartProgressBar += progForm.SetupProgressBar;
            excel.IncreaseProgressBar += progForm.UpdateProgressBar;
            progForm.Show();

            restaurantList = excel.CreateRestaurantListFromFile();

            excel.StartProgressBar -= progForm.SetupProgressBar;
            excel.IncreaseProgressBar -= progForm.UpdateProgressBar;
            progForm.Hide();
        }

        public void UpdateRestaurantFile(string restaurantFilePath)
        {
            ExcelService excel = new ExcelService(restaurantFilePath);

            excel.StartProgressBar += progForm.SetupProgressBar;
            excel.IncreaseProgressBar += progForm.UpdateProgressBar;
            progForm.Show();

            excel.UpdateExcelFile(restaurantList);

            excel.StartProgressBar -= progForm.SetupProgressBar;
            excel.IncreaseProgressBar -= progForm.UpdateProgressBar;
            progForm.Hide();
        }

        public void OpenHoursUpdaterForm()
        {
            HoursUpdatingForm updater = new HoursUpdatingForm(restaurantList);
            updater.Show();
        }
        
    }
}
