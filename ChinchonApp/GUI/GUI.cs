using ChinchonApp.Core.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinchonApp.GUI
{
    internal static class GUI
    {
        public static void ShowDesk(Desk desk)
        {
            Console.WriteLine("Show Desk:");

            foreach (var card in desk.GetAllCards())
            {
                Console.WriteLine(ShowCard(card));
            }
        }

        public static void ShowHand(Hand hand)
        {
            List<Card> cards = hand.GetHandCards();
            foreach (var card in cards)
            {
                Console.WriteLine(ShowCard(card));
            }
        }

        public static string ShowCard(Card card)
        {
            if (card is JokerCard)
                return $"Joker Card";

            if (card is NormalCard)
            {
                var normalCard = (NormalCard)card;
                return $"Card {normalCard.CardType} {normalCard.Number}";
            }

            throw new NotImplementedException();
        }
    }
}
