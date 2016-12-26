using GogoKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViagogoCodingTest.Models
{
    public class Artist
    {
        public string name { get; set; }
        public int catId { get; set; }
        public IReadOnlyList<Event> eventsList { get; set; }

        public Artist (string name)
        {
            this.name = name;
        }

    }
}