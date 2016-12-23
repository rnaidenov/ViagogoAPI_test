using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ViagogoCodingTest.Models;
using ViagogoCodingTest.ViewModels;

namespace ViagogoCodingTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Main
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
    }
}