using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GogoKit.Models.Request;
using System.Globalization;

namespace ViagogoCodingTest.Models
{
    public class CustomEvent
    {
        public int id { get; set; }
        public string name {get;set;}
        public string dayOfWeek { get; set; }
        public int dayOfMonth { get; set; }
        public string month { get; set; }
        public string venue { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string minTicketPrice { get; set; }

        public CustomEvent (int id, string name, DateTimeOffset date,string venueName, string city,string country,string minTicketPrice)
        {
            this.id = id;
            this.name = name;
            getDateDetail(date);
            this.venue = venueName;
            this.city = city;
            this.country = country;
           // convertCurrency(minTicketPrice);
            this.minTicketPrice = minTicketPrice;
        }

        private void getDateDetail(DateTimeOffset date)
        {
            string[] months = { "JAN", "FEB", "MAR", "APR", "MAY", "JUNE", "JULY", "AUG", "SEPT", "OCT", "NOV", "DEC" };
            month = months[date.Month-1];
            var dayOfWeekLong = date.DayOfWeek.ToString();
            this.dayOfWeek = dayOfWeekLong.Substring(0, 3);
            this.dayOfMonth = date.Day;
        }

        private void convertCurrency(string minTicketPrice)
        {
            CultureInfo uk = CultureInfo.GetCultureInfo("en-GB");

        }


    }
}