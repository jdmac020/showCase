using System.Collections.Generic;

namespace HoursUpdatingTool
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public List<OperatingDays> DaysOpen { get; set; }
        public bool HoursChecked { get; set; }
        public string Comments { get; set; }

        public Restaurant()
        {
            CreateDaysList();
            HoursChecked = false;
        }

        private void CreateDaysList()
        {
            DaysOpen = new List<OperatingDays>();

            for (int i = 0; i < 7; i++)
            {
                DaysOpen.Add(new OperatingDays { Name = (OperatingDays.Days)i });
            }
            
        }
    }
}