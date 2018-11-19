using System;

namespace Evolution.Model {
  public class Foodbag : IFoodContainer {
    public int FoodAmount {
      get;
      private set;
    }

    public Foodbag() {
      FoodAmount = 0;
    }

    public void AddFood(int additionalFood) {
      if(additionalFood < 0) {
        throw new InvalidOperationException($"Not allowed to remove food from the foodbag. {nameof(additionalFood)} is {additionalFood}.");
      }

      checked {
        FoodAmount += additionalFood;
      }
    }
  }
}

