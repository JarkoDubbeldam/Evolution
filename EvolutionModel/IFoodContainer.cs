﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.Model {
  public interface IFoodContainer {
    uint FoodAmount { get; }
    void AddFood(uint FoodAmount);
  }
}
