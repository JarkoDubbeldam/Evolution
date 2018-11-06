﻿using System;
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
      var aflegstapelInstance = new Aflegstapel();
      var cards = Enumerable.Range(0, 5).Select(x => new TestCard(x));

      foreach(var card in cards) {
        aflegstapelInstance.Add(card);
      }

      Assert.AreEqual(5, aflegstapelInstance.Count);

      var emptiedCards = aflegstapelInstance.Empty();

      Assert.AreEqual(5, emptiedCards.Count());
      foreach(var card in cards) {
        // Check that each card is present in the returned set of cards.
        var isPresent = false;
        foreach(TestCard afgelegdeKaart in emptiedCards) {
          if (afgelegdeKaart.Equals(card)) {
            isPresent = true;
          }
        }
        Assert.IsTrue(isPresent);
      }
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
