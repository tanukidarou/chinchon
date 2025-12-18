using ChinchonApp.Core.Conditions;
using ChinchonApp.Core.Desk.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinchonTests.Conditions
{
    public class WinConditionsShould
    {
        private WinConditions winConditions;

        [SetUp]
        public void Setup()
        {
            var handAnalyzer = new HandAnalyzer();
            winConditions = new WinConditions(handAnalyzer);
        }

        [Test]
        public void WinWithTwoPairOfHands() // rev nombre
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Oro, 1));
            winhand.Add(new NormalCard(CardType.Copa, 1));
            winhand.Add(new NormalCard(CardType.Espada, 1));

            winhand.Add(new NormalCard(CardType.Oro, 5));
            winhand.Add(new NormalCard(CardType.Copa, 5));
            winhand.Add(new NormalCard(CardType.Espada, 5));

            winhand.Add(new NormalCard(CardType.Oro, 12));

            // When
            var result = winConditions.IsWinHand(winhand);

            // There
            Assert.IsTrue(result);
        }

        [Test]
        public void WinWithTwoPairOfHands2() // rev nombre
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Oro, 1));
            winhand.Add(new NormalCard(CardType.Oro, 2));
            winhand.Add(new NormalCard(CardType.Oro, 3));

            winhand.Add(new NormalCard(CardType.Espada, 5));
            winhand.Add(new NormalCard(CardType.Espada, 6));
            winhand.Add(new NormalCard(CardType.Espada, 7));

            winhand.Add(new NormalCard(CardType.Oro, 12));

            // When
            var result = winConditions.IsWinHand(winhand);

            // There
            Assert.IsTrue(result);
        }

        [Test]
        public void WinWithTwoPairOfHands3() // rev nombre
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Oro, 1));
            winhand.Add(new NormalCard(CardType.Oro, 2));
            winhand.Add(new NormalCard(CardType.Oro, 3));

            winhand.Add(new NormalCard(CardType.Oro, 5));
            winhand.Add(new NormalCard(CardType.Copa, 5));
            winhand.Add(new NormalCard(CardType.Espada, 5));

            winhand.Add(new NormalCard(CardType.Oro, 12));

            // When
            var result = winConditions.IsWinHand(winhand);

            // There
            Assert.IsTrue(result);
        }

        [Test]
        public void WinWithTwoPairOfHands_Fail() // rev nombre
        {
            // Given
            var winhand = new List<Card>();
            winhand.Add(new NormalCard(CardType.Oro, 1));
            winhand.Add(new NormalCard(CardType.Oro, 2));
            winhand.Add(new NormalCard(CardType.Oro, 3));

            winhand.Add(new NormalCard(CardType.Oro, 5));
            winhand.Add(new NormalCard(CardType.Copa, 6));
            winhand.Add(new NormalCard(CardType.Espada, 7));
            winhand.Add(new NormalCard(CardType.Oro, 12));

            // When
            var result = winConditions.IsWinHand(winhand);

            // There
            Assert.IsFalse(result);
        }
    }
}
