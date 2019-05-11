using System;
using System.Collections.Generic;
using System.Linq;

namespace Evolution.Model {
  public class Trekstapel {
    private readonly Stack<Card> cards;

    public Trekstapel(IEnumerable<Card> cards) {
      this.cards = new Stack<Card>(cards.Reverse());
    }

    public int Count => cards.Count;

    public event EventHandler TrekstapelEmptied;

    public bool TryDraw(out Card drawnCard) {
      if(cards.Count == 0) {
        drawnCard = default;
        return false;
      } else {
        drawnCard = cards.Pop();
        if (cards.Count == 0) {
          TrekstapelEmptied?.Invoke(this, new EventArgs());
        }
        return true;
      }
    }
  }
}
