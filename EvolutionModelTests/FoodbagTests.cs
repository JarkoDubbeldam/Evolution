using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evolution.Model;

namespace EvolutionModelTests{
    [TestClass]
    public class FoodbagTests {
        [TestMethod]
        public void FoodbagConstructionStartsWithEmptyFoodbag() {
            var foodbag = new Foodbag();

            int expectedCount = 0;
            var actualCount = foodbag.FoodAmount;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [TestMethod]
        public void FoodbagAddFoodIncreasesFoodamountWithPassedValue() {
            var foodbag = new Foodbag();
            foodbag.AddFood(5);
            int check = 5;
            Assert.AreEqual(foodbag.FoodAmount, check);

        }
        [TestMethod]
        public void FoodbagAddFoodThrowsExceptionWhenFoodamountOverflows() {
            var bag = new Foodbag();
            bag.AddFood(1); // Foodbag now contains a positive amount of food.
            Assert.ThrowsException<OverflowException>(() => bag.AddFood(int.MaxValue));
        }
        [TestMethod]
        public void FoodbagCannotHaveFoodRemoved(){
            var foodbag = new Foodbag();
            Assert.ThrowsException<InvalidOperationException>(() => foodbag.AddFood(-2));
            Assert.AreEqual(foodbag.FoodAmount, 0);
        }
    }
}
