using System;

namespace Evolution.Model {
  public class WateringHole : IFoodContainer, IEatable {
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

    public WateringHole() => FoodAmount = 0;

    public void AddFood(int additionalfood) {
            checked{
                FoodAmount += additionalfood;
            } 
    }

    bool CanBeEatenBy(Species Eater) => !Eater.IsPredator;

    int GetsEaten(Eater){
            if (CanBeEatenBy(Eater) == true){
                if (FoodAmount > 1){
                    FoodAmount -= 1;
                    return 1;
                }
                else throw new InvalidOperationException($"The {nameof(WateringHole)} is empty!")
            } 
            else throw new InvalidOperationException($"{nameof(Species)} is a carnivore.")
        }
    }
}
