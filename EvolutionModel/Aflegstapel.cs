using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.Model {
  public class Aflegstapel {
    private Stack<Card> cards;

    public Aflegstapel() {
      cards = new Stack<Card>(129);
    }

    public int Count => cards.Count;

    public void Add(Card kaart) {
      cards.Push(kaart);
    }

    // De kaarten moeten van de aflegstapel naar het deck want er zijn nog kaarten in het spel die niet naar het deck moeten. 
    public IEnumerable<Card> Empty() {
            // throw new NotImplementedException();
       var tijdelijkdeck = new Aflegstapel();
       foreach(var card in cards)
            {
                tijdelijkdeck.Add(card)
            }
    }
  }
}