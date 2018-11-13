using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evolution.Model;

namespace EvolutionModelTests{
    [TestClass]
    public class FoodbagTests{
        [TestMethod]
        public void FoodbagBegintLeeg(){
            var foodbag = new Foodbag();

            var expectedCount = 0;
            var actualCount = foodbag.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [TestMethod]
        public void KanEtenToevoegen(){
            var foodbag = new Foodbag();
            foodbag.AddFood(5);
            var check = 5;
            Assert.AreEqual(foodbag, check);

        }
    }
}
