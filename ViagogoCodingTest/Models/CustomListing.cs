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
        public bool lastAvailable { get; set; }

        public CustomListing(string section, decimal priceAmount,string priceCurrency, int ticketsAvailable)
        {
            this.section = section;
            this.price = "$";
            convertCurrency(priceAmount, priceCurrency);
            this.ticketsAvailable = ticketsAvailable;
        }


        private void convertCurrency (decimal priceAmount,string priceCurrency)
        {
            double amount = (double)priceAmount;
            switch (priceCurrency)
            {
                case "USD":
                    price += Math.Round((amount),2);
                    break;
                case "GBP":
                    price += Math.Round((amount * 1.23),2);
                    break;
                case "EUR":
                    price += Math.Round((amount / 1.05),2);
                    break;
                case "CZK":
                    price += Math.Round((amount / 25.86),2);
                    break;
            }
        }
    }
}