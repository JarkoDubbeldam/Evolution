using Evolution.Model;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvolutionModelTests {
  [TestClass]
  public class WateringHoleTests {
    [TestMethod]
    public void WateringHoleConstructionStartsEmpty() {
      var wateringhole = new WateringHole();

      int expectedCount = 0;
      var actualCount = wateringhole.FoodAmount;

      Assert.AreEqual(expectedCount, actualCount);
    }

    [TestMethod]
    public void WateringHoleAddFoodIncreasesFoodAmount() {
      var wateringhole = new WateringHole();

      Assert.AreEqual(0, wateringhole.FoodAmount);

      wateringhole.AddFood(10);

      Assert.AreEqual(10, wateringhole.FoodAmount);

      wateringhole.AddFood(20);

      Assert.AreEqual(30, wateringhole.FoodAmount);
    }

    [TestMethod]
    public void WaterHoleAddFoodDecreasesFoodAmountWhenNegativeValueIsAdded() {
      var wateringhole = new WateringHole();

      wateringhole.AddFood(10);

      Assert.AreEqual(10, wateringhole.FoodAmount);

      wateringhole.AddFood(-5);

      Assert.AreEqual(5, wateringhole.FoodAmount);
    }

    [TestMethod]
    public void WaterHoleAddFoodCannotDecreaseFoodAmountBeyond0() {
      var wateringhole = new WateringHole();

      wateringhole.AddFood(10);

      Assert.AreEqual(10, wateringhole.FoodAmount);

      wateringhole.AddFood(-20);

      Assert.AreEqual(0, wateringhole.FoodAmount);
    }

        [TestMethod]
        public void WaterHoleTryEatCanEat(){
            var wateringhole = new WateringHole();
            var species = new MockSpecies();
            species.IsPredator = false;
            wateringhole.AddFood(10);
            Assert.AreEqual(10, wateringhole.FoodAmount);
            var result = wateringhole.TryEat(species, out int food);
            Assert.AreEqual(1, food);
            Assert.AreEqual(9, wateringhole.FoodAmount);
            Assert.IsTrue(result);
           
        }

        [TestMethod]
        public void WaterHoleEatCanEat()
        {
            var wateringhole = new WateringHole();
            var species = new MockSpecies();
            species.IsPredator = false;
            wateringhole.AddFood(10);
            var result = wateringhole.Eat(species);
            Assert.AreEqual(9, wateringhole.FoodAmount);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void WaterHoleCannotTryEatIfHoleIsEmpty()
        {
            var wateringhole = new WateringHole();
            var species = new MockSpecies();
            species.IsPredator = false;
            var result = wateringhole.TryEat(species, out int food);
            Assert.AreEqual(0, food);
            Assert.IsFalse(result);
            Assert.AreEqual(0, wateringhole.FoodAmount);
        }

        [TestMethod]
        public void WaterHoleThrowsCannotEatIfWaterHoleIsEmpty()
        {
            var wateringhole = new WateringHole();
            var species = new MockSpecies();
            species.IsPredator = false;
            Assert.ThrowsException<InvalidOperationException>(()=> wateringhole.Eat(species));
            Assert.AreEqual(0, wateringhole.FoodAmount);
        }

        [TestMethod]
        public void WaterHoleTryEatCannotEatAsPredator()
        {
            var wateringhole = new WateringHole();
            var species = new MockSpecies();
            species.IsPredator = true;
            wateringhole.AddFood(10);
            Assert.AreEqual(10, wateringhole.FoodAmount);
            var result = wateringhole.TryEat(species, out int food);
            Assert.AreEqual(0, food);
            Assert.AreEqual(10, wateringhole.FoodAmount);
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void WaterHoleEatCannotEatAsPredator()
        {
            var wateringhole = new WateringHole();
            var species = new MockSpecies();
            species.IsPredator = true;
            wateringhole.AddFood(10);
            Assert.ThrowsException<InvalidOperationException>(() => wateringhole.Eat(species));
            Assert.AreEqual(10, wateringhole.FoodAmount);
        }

        [TestMethod]
        public void WaterHoleCannotTryEatIfHoleIsEmptyAndPredator()
        {
            var wateringhole = new WateringHole();
            var species = new MockSpecies();
            species.IsPredator = true;
            var result = wateringhole.TryEat(species, out int food);
            Assert.AreEqual(0, food);
            Assert.IsFalse(result);
            Assert.AreEqual(0, wateringhole.FoodAmount);
        }

        [TestMethod]
        public void WaterHoleThrowsExceptionIfEatIsEmptyAndPredator()
        {
            var wateringhole = new WateringHole();
            var species = new MockSpecies();
            species.IsPredator = true;
            Assert.ThrowsException<InvalidOperationException>(() => wateringhole.Eat(species));
            Assert.AreEqual(0, wateringhole.FoodAmount);
        }

        [TestMethod]
        public void WaterholeCanBeEatenByNoPredatorWithFood() {
            var wateringhole = new WateringHole();
            var species = new MockSpecies();
            species.IsPredator = false;
            wateringhole.AddFood(10);
            Assert.IsTrue(wateringhole.CanBeEatenBy(species));
            Assert.AreEqual(10, wateringhole.FoodAmount);

        }

        [TestMethod]
        public void WaterholeCanNotBeEatenByPredatorWithFood() {
            var wateringhole = new WateringHole();
            var species = new MockSpecies();
            wateringhole.AddFood(10);
            species.IsPredator = true;
            Assert.IsFalse(wateringhole.CanBeEatenBy(species));
            Assert.AreEqual(10, wateringhole.FoodAmount);
        }

        [TestMethod]
        public void WaterholeCanNotBeEatenByNoPredatorNoFood() {
            var wateringhole = new WateringHole();
            var species = new MockSpecies();
            species.IsPredator = false;
            Assert.IsFalse(wateringhole.CanBeEatenBy(species));
            Assert.AreEqual(0, wateringhole.FoodAmount);
        }

        [TestMethod]
        public void WaterholeCanNotBeEatenByPredatorNoFood() {
            var wateringhole = new WateringHole();
            var species = new MockSpecies();
            species.IsPredator = true;
            Assert.IsFalse(wateringhole.CanBeEatenBy(species));
            Assert.AreEqual(0, wateringhole.FoodAmount);
        }
    }
}

/* Begin met CanBeEatenBy, Wanner moet die true geven, en wanneer moet die false geven, 
 * Er kan wel of niet eten aanwezig zijn, en het dier kan wel of niet predator zijn, 
 * Daar heb je vier combinaties van, en dus ook vier mogelijke uitkomsten, die je ieder moet testen.
 * Daarnaast de vier mogelijkhedenin canbeeatenby
 */ 
