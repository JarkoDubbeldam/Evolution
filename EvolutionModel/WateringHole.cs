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

        public bool TryToEat(Species eater, out int amountEaten){
            if(CanBeEatenBy(eater){
                FoodAmount--;
                amountEaten = 1;
                return true;
            } 
            else {
                amountEaten = default(int);
                return false;
            }
        }

        public int GetsEaten(Species eater){
            if(CanBeEatenBy(eater){
                if(FoodAmount >= 1){
                    FoodAmount -= 1;
                    return 1;
                } 
                else{
                    return default(int);
                    throw new InvalidOperationException($"The {nameof(WateringHole)} is empty!");
                }
            } 
            else{
                return default(int);
                throw new InvalidOperationException($"{nameof(Species)} is a carnivore.");
            }
        }
    }
}
