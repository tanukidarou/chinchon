using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinchonApp.Core.Desk.Card;

namespace ChinchonApp.Core.Conditions
{
    public class WinConditions
    {
        // + La mano debe tener 2 parejas
        // + Pueden ser por combinacio de minimo 3 cartas de tipos iguales y numerado consecutivo.
        // + Tambien puede ser de tipos diferentes pero del mismo numeor
        // + La combinacion no puede repetir cartas. La que se usa para uno queda en ese.
        // + Lo que no se usa se debe contar como sobrante
        // + El sobrante no puede ser mayor a un determinaod numero.

        private const int MIN_CARDS_FOR_PAREJA = 3;

        public bool IsValidWinHand(List<Card> cards)
        {
            return HaveThreeCardsOfDiferentTypebutSameNumber(cards) || 
                HaveThreeCardsOfSameTypeButDiferentNumberInConsecutive(cards);
        }

        private bool HaveThreeCardsOfDiferentTypebutSameNumber(List<Card> cards)
        {
            var normalCards = cards.Where(c => c is NormalCard);

            Dictionary <int, int> count = new Dictionary<int, int>() { };
            
            foreach (NormalCard card in normalCards)
            {
                if (count.ContainsKey(card.Number) == false)
                    count.Add(card.Number, 1);
                else
                    count[card.Number] = ++count[card.Number];
            }

            return count.Any(vk => vk.Value >= MIN_CARDS_FOR_PAREJA);
        }

        private bool HaveThreeCardsOfSameTypeButDiferentNumberInConsecutive(List<Card> cards)
        {
            var normalCards = cards.Where(c => c is NormalCard);

            var listofTypes = new Dictionary<CardType, Dictionary<int, int>>();

            foreach (NormalCard card in normalCards)
            {
                if(listofTypes.ContainsKey(card.CardType) == false)
                {
                    listofTypes.Add(card.CardType, new Dictionary<int, int>() { { card.Number, 1 } });
                    continue;
                }

                if (listofTypes[card.CardType].ContainsKey(card.Number) == false)
                {
                    listofTypes[card.CardType].Add(card.Number, 1);
                    continue;
                }

                listofTypes[card.CardType][card.Number] = ++listofTypes[card.CardType][card.Number]; // esto nunca va a ocurrir
            }

            foreach (var list in listofTypes.Values)
            {
                var cardsArray = list.Keys.ToArray();
                var maxLength = cardsArray.Length - (MIN_CARDS_FOR_PAREJA - 1);

                for (int i = 0; i < maxLength; i++)
                {
                    var value_1 = cardsArray[i];
                    var value_2 = cardsArray[i + 1] - 1;
                    var value_3 = cardsArray[i + 2] - 2;

                    if (value_1 == value_2 && value_1 == value_3)
                        return true;
                }
            }

            return false;
        }
    }
}
