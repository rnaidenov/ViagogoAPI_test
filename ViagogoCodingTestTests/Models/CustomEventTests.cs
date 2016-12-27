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
    public class CustomEventTests
    {
        [TestMethod()]
        public void CustomEventTest()
        {
            DateTimeOffset now = DateTimeOffset.Now;
            CustomEvent ce = new CustomEvent(5345, "Bon Jovi Presents", now, "Yalta", "Sofia", "Bulgaria", "$254,43");
            double rightDouble = (double)254.43;
            Assert.AreEqual(rightDouble, ce.minTicketPriceAmount);
        }
    }
}