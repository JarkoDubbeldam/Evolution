using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evolution.Model;

namespace EvolutionModelTests {

    [TestClass]
    public class DeckTests{
        [TestMethod]
        public void DeckBegintVol() {
            var deck = new Deck();
            var expectedCount = 129;
            var actualCount = deck.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void DeckKanGeschudWorden() {

        }

        [TestMethod]
        public void DeckGeeftBovensteKaart() {

        }

        [TestMethod]
        public void DeckKanBijgevuldWorden() {

        }

        [TestMethod]
        public void DeckGeeftHoeveelheidKaartenInDeck() {

        }

        [TestMethod]
        public void IfCardIsSubstracedCountDecreases() {

        }
    }
}
