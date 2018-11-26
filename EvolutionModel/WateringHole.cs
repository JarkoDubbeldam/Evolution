using System.Linq;
using System.Collections.Generic;
using System;

namespace Evolution.Model {
  public class WateringHole : IFoodContainer, IEatable{
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

    public bool CanBeEatenBy(IEater eater) => !eater.IsPredator && FoodAmount > 0;

        public bool TryEat(IEater eater, out int amountEaten){
            if(CanBeEatenBy(eater)){
                FoodAmount--;
                amountEaten = 1;
                return true;
            } 
            else {
                amountEaten = default(int);
                return false;
            }
        }

        public int Eat(IEater eater){
            if(CanBeEatenBy(eater)){
                FoodAmount -- ;
                return 1;
            }  
            else{
                throw new InvalidOperationException($"{nameof(IEater)} cannot eat from this source and/or the source is empty.");
            }
        }
    }
}
