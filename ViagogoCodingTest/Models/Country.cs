using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViagogoCodingTest.Models
{
    public class Country
    {

        public string name {get;set;}
        public List<CustomEvent> events = new List<CustomEvent>();
        public CustomEvent cheapestEvent { get; set; }

        public Country (string countryName)
        {
            this.name = countryName;
        }

        public void getCheapestEvent ()
        {
            if (events.Count > 1)
            {
                double price = events[0].minTicketPriceAmount;
                foreach (var artistEvent in events)
                {
                    if (artistEvent.minTicketPriceAmount < price)
                    {
                        price = artistEvent.minTicketPriceAmount;
                        artistEvent.cheapestInCountry = true;
                        cheapestEvent = artistEvent;
                    }
                }
            }
        }


    }
}