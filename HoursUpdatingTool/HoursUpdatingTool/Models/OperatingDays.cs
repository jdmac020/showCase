using System;
using Microsoft.Office.Interop.Excel;

namespace HoursUpdatingTool
{
    public class OperatingDays
    {
        public enum Days
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        };

        public Days Name { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public bool Open { get; set; }

        public OperatingDays()
        {
            Open = true;
        }

    }
}