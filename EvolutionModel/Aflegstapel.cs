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
  }
}
