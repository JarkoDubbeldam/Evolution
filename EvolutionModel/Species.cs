using System.Linq;
using System.Collections.Generic;
using System;

namespace Evolution.Model {
  public class Species : IEater {
        public bool IsPredator => throw new NotImplementedException();
  }
}