using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.Model {
    public class Foodbag {
        private int foodamount;

        public Foodbag(){
            foodamount = 0;
        }

        public int Count => foodamount;

        public void AddFood(int erbij){
            foodamount = foodamount + erbij;
        }
    }
}

