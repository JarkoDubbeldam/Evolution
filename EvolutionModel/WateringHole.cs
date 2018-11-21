using System;

namespace Evolution.Model {
  public class WateringHole : IFoodContainer, IEatable {
    private int foodAmount;
    public int FoodAmount {
      get {
        return foodAmount;
      }
      private set {
        if (value < 0) {
          value = 0;
        }
        foodAmount = value;
      }
    }

    public WateringHole() => FoodAmount = 0;

    public void AddFood(int additionalfood) {
      checked {
        FoodAmount += additionalfood;
      }
    }

    public bool CanBeEatenBy(Species eater) => !eater.IsPredator && FoodAmount > 0;

        public bool GetsEaten(bool eater, out int foodEaten)
        {
            // Doe iets aan voorbereiding als dat nodig is.

            if(CanBeEatenBy(eater)
            {
                FoodAmount--;
                foodEaten = 1;
                return true;
            } 
            else {
                foodEaten = default(int);
                return false;
            }
        }
    }
}
