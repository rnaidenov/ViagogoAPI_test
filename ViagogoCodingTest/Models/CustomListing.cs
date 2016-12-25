using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViagogoCodingTest.Models
{
    public class CustomListing
    {
        public string section { get; set; }
        public string price { get; set; }
        public int ticketsAvailable { get; set; }

        public CustomListing (string section,string price,int ticketsAvailable)
        {
            this.section = section;
            this.price = price;
            this.ticketsAvailable = ticketsAvailable;
        }

    }
}