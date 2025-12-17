using ChinchonApp.Core.Desk.Card;
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
                return $"Joker";

            if (card is NormalCard)
            {
                var normalCard = (NormalCard)card;
                return $"{normalCard.CardType} {normalCard.Number}";
            }

            throw new NotImplementedException();
        }

        internal static Card SelectCardFromHand(Hand hand, string message = "")
        {
            int value = 0;

            

            while (true)
            {
                int index = 0;

                Console.WriteLine(message);
                foreach (var card in hand.GetHandCards())
                {
                    ++index;
                    Console.WriteLine($"{index}. {ShowCard(card)}");
                }
                Console.WriteLine("");

                string? input = Console.ReadLine();

                if (input == null)
                    continue;

                if(int.TryParse(input, out value))
                {
                    if (value > 0 && value <= index)
                        break;
                }          
            }

            
            return hand.GetCardAt(value);
        }
    }
}
