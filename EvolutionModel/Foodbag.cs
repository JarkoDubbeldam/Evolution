namespace Evolution.Model {
  public class Foodbag : IFoodContainer {
    public uint FoodAmount {
      get;
      private set;
    }

    public Foodbag() {
      FoodAmount = 0;
    }

    public void AddFood(uint additionalFood) {
      checked {
        FoodAmount += additionalFood;
      }
    }
  }
}

