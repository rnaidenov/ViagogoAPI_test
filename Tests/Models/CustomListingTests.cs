using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagogoCodingTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoCodingTest.Models.Tests
{
    [TestClass()]
    public class CustomListingTests
    {
        [TestMethod()]
        public void CustomListingTest()
        {
            CustomListing newCustomListing = new CustomListing("Box", 420, "GBP", 6);
            string rightPrice = "$516.6";
            Assert.AreEqual(rightPrice, newCustomListing.price);
        }
    }
}