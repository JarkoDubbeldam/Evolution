using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.Model {
    public class Foodbag {
        public uint Foodamount {
            get;
            private set;
        }

        public Foodbag(){ 
            Foodamount = 0;
        }

        public void AddFood(uint additionalFood){
            checked
            {
                Foodamount += additionalFood;
            } 
        }
    }
}

