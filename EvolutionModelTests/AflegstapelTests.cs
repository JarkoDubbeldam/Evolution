using System;
using System.Collections.Generic;
using System.Text;
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
  }
}
