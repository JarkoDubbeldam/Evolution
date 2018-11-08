using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evolution.Model;

namespace EvolutionModelTests {
  [TestClass]
  public class AflegstapelTests {
    [TestMethod]
    public void AflegstapelBegintLeeg() {
      var aflegstapel = new Aflegstapel();
      
      var expectedCount = 0;
      var actualCount = aflegstapel.Count;

      Assert.AreEqual(expectedCount, actualCount);
    }

    [TestMethod]
    public void CanAddCardsToAflegStapel() {
      var aflegstapel = new Aflegstapel();

      Card kaart = new Card();

      aflegstapel.Add(kaart);
    }

    [TestMethod]
    public void IfACardIsAddedCountIncreases() {
      var aflegstapel = new Aflegstapel();
      
      for(var cardAmount = 1; cardAmount < 20; cardAmount++) {
        var newcard = new Card();
        aflegstapel.Add(newcard);
        var actualCount = aflegstapel.Count;

        Assert.AreEqual(cardAmount, actualCount);
      }
    }

    [TestMethod]
    public void AflegstapelIsLeegNaEmpty() {
      var aflegstapel = new Aflegstapel();

      for(int i = 0; i < 5; i++) {
        var card = new Card();
        aflegstapel.Add(card);
      }
      Assert.AreEqual(5, aflegstapel.Count);

      aflegstapel.Empty();
      Assert.AreEqual(0, aflegstapel.Count);
    }

    [TestMethod]
    public void AflegstapelReturntAlleKaartenDieErinZatenNaEmpty() {
      var aflegstapelInstance = new Aflegstapel(); //Nieuwe aflegstapel voor deze test
      var cards = Enumerable.Range(0, 5).Select(x => new TestCard(x)); //We maken 5 kaarten met een nummertje

      foreach(var card in cards) { // We stoppen de 5 kaarten in de aflegstapel
        aflegstapelInstance.Add(card);
      }

      Assert.AreEqual(5, aflegstapelInstance.Count); // Check of er ook echt 5 inzitten

      var emptiedCards = aflegstapelInstance.Empty(); //Maken een lege stapel en legen de aflegstapel daarheen

      Assert.AreEqual(5, emptiedCards.Count()); //Check of er 5 kaarten in de stapel zitten
      foreach(TestCard card in emptiedCards) {
        // Check that each of the returned cards is present in the initial set of cards.
        bool isPresent = Contains(cards, card);
        Assert.IsTrue(isPresent);
      }
    }

    private static bool Contains<T>(IEnumerable<T> sequence, T item) where T : IEquatable<T> {
      foreach (var value in sequence) {
        if (value.Equals(item)) {
          return true;
        }
      }
      return false;
    }

    private class TestCard : Card, IEquatable<TestCard> {
      public TestCard(int nummertje) {
        Nummertje = nummertje;
      }

      public int Nummertje { get; set; }

      public bool Equals(TestCard other) {
        return other.Nummertje == this.Nummertje;
      }
    }
  }
}
