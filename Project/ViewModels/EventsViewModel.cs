using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViagogoCodingTest.Models;
namespace ViagogoCodingTest.ViewModels
{
    public class EventsViewModel
    {
        public Artist artist { get; set; }
        public List<CustomEvent> artistEvents {get;set;}
        public List<Country> countriesList;

        public EventsViewModel ()
        {
            countriesList = new List<Country> ();
        }

        public void getCountriesEvents ()
        {
            foreach (var artistEvent in this.artistEvents)
            {
                var country = this.countriesList.Find(c => c.name == artistEvent.country);

                if (country==null)
                {
                    var newCountry = new Country(artistEvent.country);
                    newCountry.events.Add(artistEvent);
                    countriesList.Add(newCountry);
                }
                else
                {                 
                    country.events.Add(artistEvent);
                }
            }
        }

        public void getCheapestEvents ()
        {
            foreach(var country in countriesList)
            {
                country.getCheapestEvent();
            }
        }
           
    }
}