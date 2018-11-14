using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.Model
{
    class WateringHole{
        public uint Foodamount {
            get;
            private set;
        }

        public WateringHole() {
            Foodamount = 0;
        }
    }
}
