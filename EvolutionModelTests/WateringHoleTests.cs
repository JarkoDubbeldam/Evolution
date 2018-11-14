using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evolution.Model;

namespace EvolutionModelTests {
    [TestClass]
    public class WateringHoleTests {
        [TestMethod]
        public void WateringHoleConstructionStartsEmpty() {
            var wateringhole = new WateringHole();

            uint expectedCount = 0;
            var actualCount = wateringhole.Foodamount;

            Assert.AreEqual(expectedCount, actualCount);
        }
    
    }
}