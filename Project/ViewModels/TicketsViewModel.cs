using GogoKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViagogoCodingTest.ViewModels
{
    public class TicketsViewModel
    {
        public Event listingsEvent { get; set; }
        public string listingsEventDate { get; set; }
        public IReadOnlyList<Listing> listings { get; set; }
        public int numberTickets { get; set;}
        
        public void getEventDate ()
        {
            var dateString = this.listingsEvent.StartDate.Value.ToString("dd/MM/yyyy");
            listingsEventDate = dateString;
        }

       

    }
}