using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.Model {
  public interface IEatable {
    bool CanBeEatenBy(IEater eater);
    int Eat(IEater eater);
    bool TryEat(IEater eater, out int amountEaten);
  }
}
