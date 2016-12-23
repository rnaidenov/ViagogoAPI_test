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
        
    }
}