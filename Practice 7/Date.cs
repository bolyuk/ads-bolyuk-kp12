using System;
namespace adsbolyuklab7
{
    public class Date
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }

        public Date(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }
        public string toString()
        {
            return day + "." + month + "." + year;
        }
    }
}
