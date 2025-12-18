using ChinchonApp.Core.Conditions;
using ChinchonApp.Core.Desk.Card;

namespace ChinchonTests.Conditions
{
    public class HandAnalyzerShould
    {
        private HandAnalyzer winConditions;

        [SetUp]
        public void Setup()
        {
            winConditions = new HandAnalyzer();
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
            var result = winConditions.HaveCardsOfDiferentTypeButSameNumber(winhand);

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
            var result = winConditions.HaveCardsOfDiferentTypeButSameNumber(winhand);

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
            var result = winConditions.HaveCardsOfDiferentTypeButSameNumber(winhand);

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
            var result = winConditions.HaveCardsOfDiferentTypeButSameNumber(winhand);

            // There
            Assert.IsTrue(result);
        }

        [Test]
        public void WinWithOnlyThreeCardsOfDiferentTypeAndConsecutiveNumber()
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Oro, 1));
            winhand.Add(new NormalCard(CardType.Oro, 2));
            winhand.Add(new NormalCard(CardType.Oro, 3));


            // When
            var result = winConditions.HaveCardsOfSameTypeButDiferentNumberInConsecutive(winhand);

            // There
            Assert.IsTrue(result);
        }

        [Test]
        public void AnotherWinWithOnlyThreeCardsOfDiferentTypeAndConsecutiveNumber()
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Basto, 5));
            winhand.Add(new NormalCard(CardType.Basto, 6));
            winhand.Add(new NormalCard(CardType.Basto, 7));


            // When
            var result = winConditions.HaveCardsOfSameTypeButDiferentNumberInConsecutive(winhand);

            // There
            Assert.IsTrue(result);
        }

        [Test]
        public void WinWithOnlyThreeCardsOfDiferentTypeAndConsecutiveNumberWithAnotherCards()
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Basto, 2));
            winhand.Add(new NormalCard(CardType.Basto, 5));
            winhand.Add(new NormalCard(CardType.Basto, 6));
            winhand.Add(new NormalCard(CardType.Basto, 7));


            // When
            var result = winConditions.HaveCardsOfSameTypeButDiferentNumberInConsecutive(winhand);

            // There
            Assert.IsTrue(result);
        }


        [Test]
        public void WinWithPairOfThreeCardsOfDiferentTypeAndConsecutiveNumberAndAnotherCards()
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
            var result = winConditions.HaveCardsOfSameTypeButDiferentNumberInConsecutive(winhand);

            // There
            Assert.IsTrue(result);
        }

        [Test]
        public void LoseWithOnlyTwoCardsOfDiferentTypeAndConsecutiveNumber()
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Basto, 5));
            winhand.Add(new NormalCard(CardType.Basto, 6));
            winhand.Add(new NormalCard(CardType.Basto, 8));


            // When
            var result = winConditions.HaveCardsOfSameTypeButDiferentNumberInConsecutive(winhand);

            // There
            Assert.IsFalse(result);
        }


    }
}