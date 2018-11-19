using System;

namespace Evolution.Model {
  public class WateringHole : IFoodContainer {
    private int foodAmount;
    public int FoodAmount {
      get {
        return foodAmount;
      }
      private set {
        if(value < 0) {
          value = 0;
        }
        foodAmount = value;
      }
    }

    public WateringHole() {
      FoodAmount = 0;
    }

    public void AddFood(int FoodAmount) {
      throw new NotImplementedException();
    }
  }
}
