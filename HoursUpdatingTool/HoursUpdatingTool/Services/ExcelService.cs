using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace HoursUpdatingTool.Services
{
    class ExcelService
    {
        public event ProgressInitializeEventHandler StartProgressBar;
        public event ProgressIncreaseEventHandler IncreaseProgressBar;

        private readonly string restaurantFilePath;

        private Excel.Application app;
        private Excel.Workbook book;
        private Excel.Worksheet sheet;

        private int totalUsedRows;
        private int totalUsedColumns;

        public ExcelService(string fileLocation)
        {
            restaurantFilePath = fileLocation;
        }
        public List<Restaurant> CreateRestaurantListFromFile()
        {
            CreateExcelComponents();

            GetUsedTotals();
            
            var restaurants = CreateRestaurantList(totalUsedRows);

            CleanupExcelComponents();

            return restaurants;
            
        }

        public void UpdateExcelFile(List<Restaurant> restaurants)
        {
            CreateExcelComponents();

            OnProgressBarSetup(new ProgressInitializeEventArgs("Updating Restaurant File...", 1, restaurants.Count, 1, 1));
            
            int currentRow = 2;
            

            foreach (var restaurant in restaurants)
            {
                string currentCell = "A" + currentRow;

                Excel.Range activeRange = sheet.Range[currentCell].EntireRow;

                int open = 15; // Monday open time
                int close = 22; // Monday close time

                foreach (var day in restaurant.DaysOpen)
                {

                    if (day.Open)
                    {
                        if (day.OpenTime == default(DateTime))
                        {
                            activeRange.Cells[1, open].Value = "Missing!";
                        }
                        else
                        {
                            activeRange.Cells[1, open].Value = day.OpenTime.ToShortTimeString();
                        }

                        if (day.CloseTime == default(DateTime))
                        {
                            activeRange.Cells[1, close].Value = "Missing!";
                        }
                        else
                        {
                            activeRange.Cells[1, close].Value = day.CloseTime.ToShortTimeString();
                        }
                        
                    }
                    else
                    {
                        activeRange.Cells[1, open] = "Closed";
                        activeRange.Cells[1, close] = "Closed";
                    }

                    open++;
                    close++;
                }

                activeRange.Cells[1, close] = restaurant.Comments;

                OnProgressBarMove(new ProgressIncreaseEventArgs());
                currentRow++;
            }
            
            book.Save();

            CleanupExcelComponents();

        }

        private void CleanupExcelComponents()
        {
            OnProgressBarSetup(new ProgressInitializeEventArgs("Finishing Up...", 1, 4, 1, 3));

            GC.Collect();
            GC.WaitForPendingFinalizers();
            OnProgressBarMove(new ProgressIncreaseEventArgs());
            
            Marshal.ReleaseComObject(sheet);
            OnProgressBarMove(new ProgressIncreaseEventArgs());

            book.Close();
            Marshal.ReleaseComObject(book);
            OnProgressBarMove(new ProgressIncreaseEventArgs());

            app.Quit();
            Marshal.ReleaseComObject(app);
            OnProgressBarMove(new ProgressIncreaseEventArgs());
        }

        private void GetUsedTotals()
        {
            OnProgressBarSetup(new ProgressInitializeEventArgs("Formatting File...", 1, 3, 1, 2));

            // Unhide All Cells and clear formats
            sheet.Columns.ClearFormats();
            OnProgressBarMove(new ProgressIncreaseEventArgs());
            sheet.Rows.ClearFormats();
            OnProgressBarMove(new ProgressIncreaseEventArgs());

            // Detect Last used Row - Ignore cells that contains formulas that result in blank values
            totalUsedRows = sheet.Cells.Find(
                "*",
                System.Reflection.Missing.Value,
                Excel.XlFindLookIn.xlValues,
                Excel.XlLookAt.xlWhole,
                Excel.XlSearchOrder.xlByRows,
                Excel.XlSearchDirection.xlPrevious,
                false,
                System.Reflection.Missing.Value,
                System.Reflection.Missing.Value).Row;
            OnProgressBarMove(new ProgressIncreaseEventArgs());
            // Detect Last Used Column  - Ignore cells that contains formulas that result in blank values
            totalUsedColumns = sheet.Cells.Find(
                "*",
                System.Reflection.Missing.Value,
                System.Reflection.Missing.Value,
                System.Reflection.Missing.Value,
                Excel.XlSearchOrder.xlByColumns,
                Excel.XlSearchDirection.xlPrevious,
                false,
                System.Reflection.Missing.Value,
                System.Reflection.Missing.Value).Column;
            
        }

        private void CreateExcelComponents()
        {
            OnProgressBarSetup(new ProgressInitializeEventArgs("Opening File...", 1, 3, 1, 2));

            app = new Excel.Application();
            app.DisplayAlerts = false;
            OnProgressBarMove(new ProgressIncreaseEventArgs());
            book = app.Workbooks.Open(restaurantFilePath);
            OnProgressBarMove(new ProgressIncreaseEventArgs());
            sheet = (Excel.Worksheet) book.Worksheets.Item[2];
            OnProgressBarMove(new ProgressIncreaseEventArgs());
        }


        private List<Restaurant> CreateRestaurantList(int totalRows)
        {
            OnProgressBarSetup(new ProgressInitializeEventArgs("Generating Restaurant List...", 1, totalRows, 1, 1));

            List<Restaurant> restaurants = new List<Restaurant>();

            for (int i = 2; i < totalRows + 1; i++)
            {
                string currentCell = "A" + i;
                Excel.Range activeRange = sheet.Range[currentCell].EntireRow;

                Restaurant restaurant = CreateRestaurant(activeRange);

                AddRestaurantComment(activeRange, restaurant);

                int open = 15; // Monday open time
                int close = 22; // Monday close time

                foreach (var day in restaurant.DaysOpen)
                {

                    AddOpenHoursToDay(activeRange, open, day);

                    AddClosingHoursToDay(activeRange, close, day);

                    open++;
                    close++;
                }

                restaurants.Add(restaurant);
                OnProgressBarMove(new ProgressIncreaseEventArgs());
            }

            return restaurants;

        }

        private static void AddClosingHoursToDay(Excel.Range activeRange, int close, OperatingDays day)
        {
            if (activeRange.Cells[1, close].Value == null)
            {
                day.CloseTime = default(DateTime);
            }
            else if (string.Equals(activeRange.Cells[1, close].Value, "Missing!"))
            {
                day.CloseTime = default(DateTime);
            }
            else if (string.Equals(activeRange.Cells[1, close].Value, "Closed"))
            {
                day.Open = false;
                day.CloseTime = default(DateTime);
            }
            else
            {
                day.CloseTime = DateTime.FromOADate(activeRange.Cells[1, close].Value);
            }
        }

        private static void AddOpenHoursToDay(Excel.Range activeRange, int open, OperatingDays day)
        {
            if (activeRange.Cells[1, open].Value == null)
            {
                day.OpenTime = default(DateTime);
            }
            else if (string.Equals(activeRange.Cells[1, open].Value, "Missing!"))
            {
                day.OpenTime = default(DateTime);
            }
            else if (string.Equals(activeRange.Cells[1, open].Value, "Closed"))
            {
                day.Open = false;
                day.OpenTime = default(DateTime);
            }
            else
            {
                day.OpenTime = DateTime.FromOADate(activeRange.Cells[1, open].Value);
            }
        }

        private static Restaurant CreateRestaurant(Excel.Range activeRange)
        {
            Restaurant restaurant = new Restaurant()
            {
                Name = activeRange.Cells[1, 1].Value.ToString(),
                Street = activeRange.Cells[1, 2].Value.ToString(),
                City = activeRange.Cells[1, 3].Value.ToString(),
                State = activeRange.Cells[1, 4].Value.ToString(),
                ZipCode = activeRange.Cells[1, 5].Value.ToString(),
                Phone = activeRange.Cells[1, 6].Value.ToString()
            };
            return restaurant;
        }

        private static void AddRestaurantComment(Excel.Range activeRange, Restaurant restaurant)
        {
            if (activeRange.Cells[1, 29].Value == null)
            {
                restaurant.Comments = string.Empty;
            }
            else
            {
                restaurant.Comments = activeRange.Cells[1, 29].Value.ToString();
            }
        }

        private void OnProgressBarSetup(ProgressInitializeEventArgs args)
        {
            if (StartProgressBar != null)
            {
                StartProgressBar.Invoke(this, args);
            }
        }

        private void OnProgressBarMove(ProgressIncreaseEventArgs args)
        {
            if (IncreaseProgressBar != null)
            {
                IncreaseProgressBar.Invoke(this,args);
            }
        }
    }
}
