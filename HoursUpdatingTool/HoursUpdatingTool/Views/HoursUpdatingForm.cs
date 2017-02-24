using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using CheckBox = System.Windows.Forms.CheckBox;
using TextBox = System.Windows.Forms.TextBox;

namespace HoursUpdatingTool
{
    public partial class HoursUpdatingForm : Form
    {
        private readonly List<Restaurant> restaurantsToUpdate;
        private readonly List<ComboBox> hoursBoxes;
        private readonly List<ComboBox> minutesBoxes;
        private readonly List<CheckBox> openCheckBoxes;
        private readonly List<CheckBox> amCheckBoxes;
        private int currentIndex;

        internal HoursUpdatingForm(List<Restaurant> restaurants)
        {
            InitializeComponent();
            restaurantsToUpdate = restaurants;
            hoursBoxes = GenerateHoursComboBoxList();
            minutesBoxes = GenerateMinutesComboBoxList();
            openCheckBoxes = GenerateOpenCheckBoxList();
            amCheckBoxes = GenerateAmCheckBoxList();
            currentIndex = 0;
        }

        private List<CheckBox> GenerateOpenCheckBoxList()
        {
            return new List<CheckBox>()
            {
                mondayOpenCheckBox,
                tuesdayOpenCheckBox,
                wednesdayOpenCheckBox,
                thursdayOpenCheckBox,
                fridayOpenCheckBox,
                saturdayOpenCheckBox,
                sundayOpenCheckBox
            };
        }

        private List<CheckBox> GenerateAmCheckBoxList()
        {
            return new List<CheckBox>()
            {
                mondayOpenAmCheckBox,
                mondayCloseAmCheckBox,
                tuesdayOpenAmCheckBox,
                tuesdayCloseAmCheckBox,
                wednesdayOpenAmCheckBox,
                wednesdayCloseAmCheckBox,
                thursdayOpenAmCheckBox,
                thursdayCloseAmCheckBox,
                fridayOpenAmCheckBox,
                fridayCloseAmCheckBox,
                saturdayOpenAmCheckBox,
                saturdayCloseAmCheckBox,
                sundayOpenAmCheckBox,
                sundayCloseAmCheckBox
            };
        }

        private void HoursUpdatingForm_Load(object sender, EventArgs e)
        {
            LoadRestaurantInfo();
        }

        private void LoadRestaurantInfo()
        {

            Restaurant currentRestaurant = restaurantsToUpdate[currentIndex];
            List<OperatingDays> days = currentRestaurant.DaysOpen;

            GetRestaurantBasicInfo(currentRestaurant);

            GetRestaurantOpenDays(currentRestaurant);

            int boxCounter = 0;
            int amCounter = 0;

            foreach (OperatingDays day in days)
            {
                GetRestaurantHours(day, ref boxCounter, ref amCounter);
            }
        }

        private void GetRestaurantHours(OperatingDays day, ref int boxCounter, ref int amCounter)
        {
            string openHour = day.OpenTime.ToString("%h");
            string openMinutes = day.OpenTime.Minute.ToString();
            string closeHour = day.CloseTime.ToString("%h");
            string closeMinutes = day.CloseTime.Minute.ToString();

            if (day.OpenTime != default(DateTime))
            {
                GetOpenHours(ref boxCounter, openHour, openMinutes, day, ref amCounter);

                GetCloseHours(ref boxCounter, closeHour, closeMinutes, day, ref amCounter);
            }
            else if (day.Open)
            {
                MarkHoursMissing(ref boxCounter);
                MarkHoursMissing(ref boxCounter);
            }
            else
            {
                MarkHoursNa(ref boxCounter);
                MarkHoursNa(ref boxCounter);
            }
        }

        private void GetCloseHours(ref int boxCounter, string closeHour, string closeMinutes, OperatingDays day,
            ref int amCounter)
        {
            hoursBoxes[boxCounter].Text = closeHour;
            minutesBoxes[boxCounter].Text = closeMinutes;
            boxCounter++;

            if (day.CloseTime.ToString("tt") == "AM")
            {
                amCheckBoxes[amCounter].Checked = true;
            }

            amCounter++;
        }

        private void GetOpenHours(ref int boxCounter, string openHour, string openMinutes, OperatingDays day, ref int amCounter)
        {
            hoursBoxes[boxCounter].Text = openHour;
            minutesBoxes[boxCounter].Text = openMinutes;
            boxCounter++;

            if (day.OpenTime.ToString("tt") == "AM")
            {
                amCheckBoxes[amCounter].Checked = true;
            }

            amCounter++;
        }

        private void MarkHoursNa(ref int boxCounter)
        {
            hoursBoxes[boxCounter].Text = "N/A";
            minutesBoxes[boxCounter].Text = "N/A";
            boxCounter++;
        }

        private void MarkHoursMissing(ref int boxCounter)
        {
            hoursBoxes[boxCounter].Text = "Missing";
            minutesBoxes[boxCounter].Text = "Missing";
            boxCounter++;
        }

        private void GetRestaurantOpenDays(Restaurant currentRestaurant)
        {
            int openCounter = 0;

            foreach (var box in openCheckBoxes)
            {
                box.Checked = currentRestaurant.DaysOpen[openCounter].Open;

                openCounter++;
            }
        }

        private void GetRestaurantBasicInfo(Restaurant currentRestaurant)
        {
            restaurantInfoTextBox.Text = currentRestaurant.Name + " " + currentRestaurant.Street + " " +
                                         currentRestaurant.City +
                                         " " + currentRestaurant.State + " " + currentRestaurant.ZipCode;

            restaurantInfoTextBox.SelectAll();
            restaurantInfoTextBox.Focus();

            commentsTextBox.Text = currentRestaurant.Comments;
        }

        private List<ComboBox> GenerateHoursComboBoxList()
        {
            List<ComboBox> boxes = new List<ComboBox>
            {
                mondayOpenHoursComboBox,
                mondayCloseHourComboBox,
                tuesdayOpenHoursComboBox,
                tuesdayCloseHourComboBox,
                wednesdayOpenHoursComboBox,
                wednesdayCloseHourComboBox,
                thursdayOpenHoursComboBox,
                thursdayCloseHourComboBox,
                fridayOpenHoursComboBox,
                fridayCloseHourComboBox,
                saturdayOpenHoursComboBox,
                saturdayCloseHourComboBox,
                sundayOpenHoursComboBox,
                sundayCloseHourComboBox,
            };


            return boxes;
        }

        private List<ComboBox> GenerateMinutesComboBoxList()
        {
            List<ComboBox> boxes = new List<ComboBox>
            {
                mondayOpenMinutesComboBox,
                mondayCloseMinutesComboBox,
                tuesdayOpenMinutesComboBox,
                tuesdayCloseMinutesComboBox,
                wednesdayOpenMinutesComboBox,
                wednesdayCloseMinutesComboBox,
                thursdayOpenMinutesComboBox,
                thursdayCloseMinutesComboBox,
                fridayOpenMinutesComboBox,
                fridayCloseMinutesComboBox,
                saturdayOpenMinutesComboBox,
                saturdayCloseMinutesComboBox,
                sundayOpenMinutesComboBox,
                sundayCloseMinutesComboBox,
            };


            return boxes;
        }

        private void nextRestaurantButton_Click(object sender, EventArgs e)
        {
            if (currentIndex < restaurantsToUpdate.Count - 1)
            {
                try
                {
                    UpdateRestaurantInfo();
                }
                catch (InvalidTimeException ite)
                {
                    MessageBox.Show(ite.Message);
                    return;
                }

                currentIndex++;
                LoadRestaurantInfo();
            }

        }

        private void UpdateRestaurantInfo()
        {
            Restaurant restaurant = restaurantsToUpdate[currentIndex];
            List<OperatingDays> days = restaurant.DaysOpen;

            int amCounter = 0;
            int boxCounter = 0;
            int hoursBoxCounter = 0;
            int dayCounter = 0;
            string inputString = string.Empty;

            foreach (OperatingDays day in days)
            {

                if (openCheckBoxes[dayCounter].Checked)
                {

                    if (hoursBoxes[hoursBoxCounter].Text != "Missing")
                    {

                        day.OpenTime = GetUpdatedTime(amCounter, inputString, boxCounter);

                        amCounter++;
                        boxCounter++;

                    }
                    else
                    {
                        day.OpenTime = default(DateTime);

                        amCounter++;
                        boxCounter++;
                    }

                    if (hoursBoxes[hoursBoxCounter].Text != "Missing")
                    {

                        day.CloseTime = GetUpdatedTime(amCounter, inputString, boxCounter);

                        amCounter++;
                        boxCounter++;

                    }
                    else
                    {
                        day.CloseTime = default(DateTime);

                        amCounter++;
                        boxCounter++;
                    }

                }
                else
                {
                    day.Open = false;
                    day.OpenTime = default(DateTime);

                    amCounter++;
                    boxCounter++;

                    day.CloseTime = default(DateTime);

                    amCounter++;
                    boxCounter++;
                }

                dayCounter++;
            }

            restaurant.Comments = commentsTextBox.Text;


        }

        private DateTime GetUpdatedTime(int amCounter, string inputString, int boxCounter)
        {
            if (amCheckBoxes[amCounter].Checked)
            {
                inputString = GetInputStringAm(boxCounter, inputString);
            }
            else
            {
                inputString = GetInputStringPm(boxCounter, inputString);
            }

            return DateTime.Parse(inputString);
        }

        private string GetInputStringPm(int boxCounter, string inputString)
        {
            string hour = hoursBoxes[boxCounter].Text;
            string minutes = minutesBoxes[boxCounter].Text;

            inputString = $"{hour}:{minutes} pm";
            return inputString;
        }

        private string GetInputStringAm(int boxCounter, string inputString)
        {
            string hour = hoursBoxes[boxCounter].Text;
            string minutes = minutesBoxes[boxCounter].Text;

            inputString = $"{hour}:{minutes} am";
            return inputString;
        }

        private void previousRestaurntButton_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                try
                {
                    UpdateRestaurantInfo();
                }
                catch (InvalidTimeException ite)
                {
                    MessageBox.Show(ite.Message);
                    return;
                }

                currentIndex--;
                LoadRestaurantInfo();
            }

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach (var box in hoursBoxes)
            {
                box.Text = string.Empty;
            }

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
