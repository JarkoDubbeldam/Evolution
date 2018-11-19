using System;

namespace Evolution.Model {
  public class WateringHole : IFoodContainer {
    public uint FoodAmount {
      get;
      private set;
    }

    public WateringHole() {
      FoodAmount = 0;
    }

    public void AddFood(uint FoodAmount) {
      throw new NotImplementedException();
    }
  }
}
