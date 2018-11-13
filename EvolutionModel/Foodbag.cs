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

        public uint Count => Foodamount;

        public void AddFood(uint erbij){
            Foodamount += erbij;
        }
    }
}

