using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.Model
{
    public class Deck{
        private Stack<Card> Cards;

        public Deck(){
            cards = new Stack<Card>(129);
        }

    }
}
