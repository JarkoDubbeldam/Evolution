using Evolution.Model;
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
        public void WaterHoleTryEatingCanEat()
        {

        }

        [TestMethod]
        public void WaterHoleEatingCanEat()
        {

        }

        [TestMethod]
        public void WaterHoleCannotTryEatingIfHoleIsEmpty()
        {

        }

        [TestMethod]
        public void WaterHoleThrowsExceptionIfEatingIsEmpty()
        {

        }
  }
}