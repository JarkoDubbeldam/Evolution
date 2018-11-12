using System.Linq;
using System.Collections.Generic;
using System;

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
      var kaarten = cards.ToArray(); // maak een array 'kaarten' aan en zet de cards in dat array
      cards.Clear(); //maak de stapel cards leeg
      return kaarten; // return de set kaarten. 
    }
  }
}