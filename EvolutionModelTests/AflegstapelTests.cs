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
      var aflegsapel = new Aflegstapel();
      var cards = Enumerable.Range(0, 5).Select(x => new Card());

      foreach(var card in cards) {
        aflegsapel.Add(card);
      }

      Assert.AreEqual(5, aflegsapel.Count);

      var emptiedCards = aflegsapel.Empty();

      Assert.AreEqual(5, emptiedCards.Count());
      foreach(var card in cards) {
        // Check that each card is present in the returned set of cards.
        Assert.IsTrue(emptiedCards.Contains(card));
      }
    }
  }
}
