using Decks.Cards;

namespace DeckTest
{
    using NUnit.Framework;
    using System;
    using Decks;

    [TestFixture]
    public class TestDeck
    {
        [Test]
        public void TestInitializeValidDeckNotToThrow()
        {
            var deck = new Deck();
        }

        [Test]
        public void TestDeckToHave24CardsAtStart()
        {
            int expectedNumberOfCards = 24;
            var deck = new Deck();

            Assert.AreEqual(expectedNumberOfCards, deck.CardsLeft, "Initial number of cards is not correct");

        }

        [Test]
        public void TestDeckToHaveCorrectNumberOfCardsAfterDrawing()
        {
            int expectedNumberOfCards = 20;
            var deck = new Deck();
            for (int i = 0; i < 4; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(expectedNumberOfCards, deck.CardsLeft, "Number of cards during game is not correct");

        }

        [Test]
        public void TestIfGetNextCardRetunsACard()
        {
            var deck = new Deck();
            var card = deck.GetNextCard();

            Assert.IsInstanceOf(typeof(Card), card, "The method does not return an instace of Card class");
        }

        [Test]
        public void TestIfTrumpCardReturnsACard()
        {
            var deck = new Deck();
            var card = deck.GetTrumpCard;

            Assert.IsInstanceOf(typeof(Card), card, "The method does not return an instace of Card class");
        }

        [Test]
        public void TestIfDeckChangesTheTrumpCard()
        {
            var deck = new Deck();
            var initialTrumpCard = deck.GetTrumpCard;
            var newCard = deck.GetNextCard();
            deck.ChangeTrumpCard(newCard);
            Assert.AreNotSame(initialTrumpCard, deck.GetTrumpCard, "The deck does not change trump card");
        }

        [TestCase(26)]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeckWhenHaveNoMoreCardsLeftToThrow(int cardsToDraw)
        {
            var deck = new Deck();
            for (int i = 0; i < cardsToDraw; i++)
            {
                deck.GetNextCard();
            }
        }
    }
}
