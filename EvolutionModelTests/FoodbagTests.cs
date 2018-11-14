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

            uint expectedCount = 0;
            var actualCount = foodbag.Foodamount;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [TestMethod]
        public void KanEtenToevoegen(){
            var foodbag = new Foodbag();
            foodbag.AddFood(5);
            uint check = 5;
            Assert.AreEqual(foodbag.Foodamount, check);

        }
        [TestMethod]
        public void Overflowcheck() {
            var bag = new Foodbag();
            bag.AddFood(1); // Foodbag now contains a positive amount of food.
            Assert.ThrowsException<OverflowException>(() => bag.AddFood(uint.MaxValue));
        }
    }
}
