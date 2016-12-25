using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ViagogoCodingTest.Models;
using ViagogoCodingTest.ViewModels;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace ViagogoCodingTest.Controllers
{
    public class HomeController : Controller
    {

        
       

        public async Task<ActionResult> Events ()
        {
            ViagogoAPI viagogo = new ViagogoAPI();
            Artist peteTong = new Artist("Pete Tong");
            peteTong.catId = await viagogo.getCatId(peteTong.name);
            peteTong.eventsList = await viagogo.getEvents(peteTong.catId);

            EventsViewModel events = new EventsViewModel();
            events.artist = peteTong; 
            events.artistEvents = new List<CustomEvent>();
            
            foreach (var upcEvent in peteTong.eventsList)
            {    
                var customEvent = new CustomEvent(upcEvent.Id.Value, upcEvent.Name, upcEvent.StartDate.Value, upcEvent.Venue.Name, upcEvent.Venue.City, upcEvent.Venue.Country.Name,upcEvent.MinTicketPrice.Display);
                events.artistEvents.Add(customEvent);         
            }

            return View(events);
        }

        public async Task<ActionResult> Tickets (int ticketId)
        {

            ViagogoAPI viagogo = new ViagogoAPI();
            TicketsViewModel tickets = new TicketsViewModel();
            tickets.listings = await viagogo.getListings(ticketId);
            tickets.listingsEvent = await viagogo.getListingsEvent(tickets.listings[0].EventLink);
            tickets.numberTickets = 3;
            tickets.getEventDate();
            return View(tickets);
        }
        
        
        public async Task<ActionResult> Listings()
        {
            ViagogoAPI viagogo = new ViagogoAPI();
            TicketsViewModel tickets = new TicketsViewModel();
            tickets.listings = await viagogo.getListings(2006283);

            List<CustomListing> ticketListings = new List<CustomListing>();
            foreach (var listing in tickets.listings)
            {
                ticketListings.Add(new CustomListing(listing.Seating.Section, listing.TicketPrice.Display, listing.NumberOfTickets.Value));
            }
            var json = JsonConvert.SerializeObject(ticketListings);
            return Json(json, JsonRequestBehavior.AllowGet);
        }


    }
}