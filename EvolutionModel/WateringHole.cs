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

        /* public int GetsEaten(Species eater) {
           if (CanBeEatenBy(eater) == true) {
               FoodAmount--;
               return 1;
           } 
           else {
                // Geef text terug: $"{nameof(eater)} is a carnivore, and cannot eat this."
                return 0;
           }
         }
        

    public int GetsEaten = ;
    public bool Succes = TryDoSomething(out result); 
    */
  }
}
