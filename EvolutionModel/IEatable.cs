using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.Model {
  public interface IEatable {
    bool CanBeEatenBy(Species eater);
    int Eat(Species eater);
    bool TryEat(Species eater, out int amountEaten);
  }
}
