using GogoKit;
using GogoKit.Models.Request;
using GogoKit.Models.Response;
using HalKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace ViagogoCodingTest.Models
{
    public class ViagogoAPI
    {

        private ViagogoClient client;

        public ViagogoAPI ()
        {
            client = new ViagogoClient(new ProductHeaderValue("AwesomeApp", "1.0"),
                                          "TaRJnBcw1ZvYOXENCtj5",
                                          "ixGDUqRA5coOHf3FQysjd704BPptwbk6zZreELW2aCYSmIT8XJ9ngvN1MuKV");
            verifyToken();
        }

        public async void verifyToken()
        {
            var token = await client.OAuth2.GetClientAccessTokenAsync(new string[] { });
            await client.TokenStore.SetTokenAsync(token);
        }

        // decide what to do with the SearchRequest
        public async Task<int> getCatId (string artistName)
        {
            var request = new SearchResultRequest { Embed = new[] { SearchResultEmbed.Category, SearchResultEmbed.Event} };
            var searchResult = await client.Search.GetAllAsync(artistName, request);
            return searchResult[0].Category.Id.Value;
        }

        public async Task<IReadOnlyList<Event>> getEvents(int categoryId)
        {
            var events = await client.Events.GetAllByCategoryAsync(categoryId);
            return events;
        }
        
        public async Task<IReadOnlyList<Listing>> getListings (int eventId)
        {
            var listings = await client.Listings.GetAllByEventAsync(eventId);
            return listings;
        }

        public async Task<Event> getListingsEvent (Link eventLink)
        {
            var listingsEvent = await client.Hypermedia.GetAsync<Event>(eventLink);
            return listingsEvent;
        }

    }
}