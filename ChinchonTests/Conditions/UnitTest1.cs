using ChinchonApp.Core.Conditions;
using ChinchonApp.Core.Desk.Card;

namespace ChinchonTests.Conditions
{
    public class Tests
    {
        private WinConditions winConditions;

        [SetUp]
        public void Setup()
        {
            winConditions = new WinConditions();
        }

        [Test]
        public void WinWithOnlyThreeCardsOfTheSameType()
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Oro, 1));
            winhand.Add(new NormalCard(CardType.Copa, 1));
            winhand.Add(new NormalCard(CardType.Espada, 1));

            // When
            var result = winConditions.IsValidWinHand(winhand);

            // There
            Assert.IsTrue(result);
        }

        [Test]
        public void WinWithOnlyFordCardsOfTheSameType()
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Oro, 1));
            winhand.Add(new NormalCard(CardType.Copa, 1));
            winhand.Add(new NormalCard(CardType.Espada, 1));
            winhand.Add(new NormalCard(CardType.Basto, 1));

            // When
            var result = winConditions.IsValidWinHand(winhand);

            // There

            Assert.IsTrue(result);
        }

        [Test]
        public void LoseWithOnlyTwoCardsOfTheSameType()
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Oro, 1));
            winhand.Add(new NormalCard(CardType.Copa, 1));

            // When
            var result = winConditions.IsValidWinHand(winhand);

            // There

            Assert.IsFalse(result);
        }

        [Test]
        public void WinWithOnlyThreeCardsOfTheSameTypeAndOtherCardLeft()
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Oro, 1));
            winhand.Add(new NormalCard(CardType.Copa, 1));
            winhand.Add(new NormalCard(CardType.Espada, 1));
            winhand.Add(new NormalCard(CardType.Espada, 7));

            // When
            var result = winConditions.IsValidWinHand(winhand);

            // There
            Assert.IsTrue(result);
        }

        [Test]
        public void Test()
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Oro, 1));
            winhand.Add(new NormalCard(CardType.Oro, 2));
            winhand.Add(new NormalCard(CardType.Oro, 3));


            // When
            var result = winConditions.IsValidWinHand(winhand);

            // There
            Assert.IsTrue(result);
        }

        [Test]
        public void Test2()
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Basto, 5));
            winhand.Add(new NormalCard(CardType.Basto, 6));
            winhand.Add(new NormalCard(CardType.Basto, 7));


            // When
            var result = winConditions.IsValidWinHand(winhand);

            // There
            Assert.IsTrue(result);
        }

        [Test]
        public void Test3()
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Basto, 2));
            winhand.Add(new NormalCard(CardType.Basto, 5));
            winhand.Add(new NormalCard(CardType.Basto, 6));
            winhand.Add(new NormalCard(CardType.Basto, 7));


            // When
            var result = winConditions.IsValidWinHand(winhand);

            // There
            Assert.IsTrue(result);
        }


        [Test]
        public void Test31()
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Basto, 2));
            winhand.Add(new NormalCard(CardType.Basto, 4));
            winhand.Add(new NormalCard(CardType.Basto, 5));
            winhand.Add(new NormalCard(CardType.Basto, 6));
            winhand.Add(new NormalCard(CardType.Basto, 8));
            winhand.Add(new NormalCard(CardType.Basto, 10));
            winhand.Add(new NormalCard(CardType.Basto, 11));
            winhand.Add(new NormalCard(CardType.Basto, 12));

            // When
            var result = winConditions.IsValidWinHand(winhand);

            // There
            Assert.IsTrue(result);
        }

        [Test]
        public void Test4()
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Basto, 5));
            winhand.Add(new NormalCard(CardType.Basto, 6));
            winhand.Add(new NormalCard(CardType.Basto, 8));


            // When
            var result = winConditions.IsValidWinHand(winhand);

            // There
            Assert.IsFalse(result);
        }


    }
}