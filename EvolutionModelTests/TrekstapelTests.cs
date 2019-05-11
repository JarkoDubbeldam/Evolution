using System.Collections.Generic;
using System.Linq;
using Evolution.Model;
using EvolutionModelTests.AssertExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvolutionModelTests {

  [TestClass]
  public class TrekstapelTests {
    public IList<Card> GetCards(int amount) {
      return Enumerable.Range(0, amount).Select(_ => new Card()).ToList();
    }

    [DataTestMethod]
    [DataRow(5)]
    [DataRow(10)]
    [DataRow(100)]
    public void DeckBegintMetEvenveelKaartenAlsAangeleverdInConstructor(int numberOfCards) {
      var cards = GetCards(numberOfCards);
      var deck = new Trekstapel(cards);
      var count = deck.Count;

      Assert.AreEqual(cards.Count, count);
    }

    [TestMethod]
    public void DeckGeeftKaartenTerugInVolgordeVanAanleveren() {
      var cards = GetCards(10);
      var deck = new Trekstapel(cards);

      deck.TryDraw(out var drawnCard);

      Assert.IsTrue(ReferenceEquals(cards[0], drawnCard));

      deck.TryDraw(out drawnCard);
      Assert.IsTrue(ReferenceEquals(cards[1], drawnCard));
    }
       
    [TestMethod]
    public void IfCardIsDrawnCountDecreases() {
      var cards = GetCards(10);
      var deck = new Trekstapel(cards);

      deck.TryDraw(out _);
      Assert.AreEqual(9, deck.Count);

      deck.TryDraw(out _);
      Assert.AreEqual(8, deck.Count);
    }

    [TestMethod]
    public void TryDrawReturnsTrueIfCardIsDrawn() {
      var cards = GetCards(1);
      var deck = new Trekstapel(cards);

      Assert.IsTrue(deck.TryDraw(out _));
    }

    [TestMethod]
    public void TryDrawReturnsFalseIfAflegstapelIsEmpty() {
      var cards = GetCards(0);
      var deck = new Trekstapel(cards);

      Assert.IsFalse(deck.TryDraw(out _));
    }

    [TestMethod]
    public void TrekstapelFiresTrekstapelEmptiedEventWhenLastCardIsDrawn() {
      var deck = new Trekstapel(GetCards(1));

      AssertExtension.TriggersEvent(x => deck.TrekstapelEmptied += x, () => deck.TryDraw(out _));
    }

    [TestMethod]
    public void TrekstapelDoesNotFireTrekstapelEmptiedEventWhenCardIsDrawnWithMoreCardsLeft() {
      var deck = new Trekstapel(GetCards(2));

      AssertExtension.DoesNotTriggerEvent(x => deck.TrekstapelEmptied += x, () => deck.TryDraw(out _));
    }

    [TestMethod]
    public void TrekstapelDoesNotFireTrekstapelEmptiedEventWhenDeckIsAlreadyEmpty() {
      var deck = new Trekstapel(GetCards(0));

      AssertExtension.DoesNotTriggerEvent(x => deck.TrekstapelEmptied += x, () => deck.TryDraw(out _));

    }
  }
}
