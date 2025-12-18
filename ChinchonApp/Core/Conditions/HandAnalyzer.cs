using ChinchonApp.Core.Desk.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinchonApp.Core.Conditions
{
    public class HandAnalyzer
    {
        private const int MIN_CARDS_FOR_PAREJA = 3;

        public bool HaveCardsOfDiferentTypeButSameNumber(List<Card> cards) // out List<Card> usedCards
        {
            var normalCards = cards.Where(c => c is NormalCard);

            Dictionary<int, int> count = new Dictionary<int, int>() { };

            //var listofTypes = OrganizeCards(normalCards);

            foreach (NormalCard card in normalCards)
            {
                if (count.ContainsKey(card.Number) == false)
                    count.Add(card.Number, 1);
                else
                    count[card.Number] = ++count[card.Number];
            }
            
            //usedCards = new List<Card>();

            return count.Any(vk => vk.Value >= MIN_CARDS_FOR_PAREJA);
        }

        public bool HaveCardsOfSameTypeButDiferentNumberInConsecutive(List<Card> cards)
        {
            var normalCards = cards.Where(c => c is NormalCard).ToList();

            var listofTypes = OrganizeCards(normalCards);

            foreach (var list in listofTypes.Values)
            {
                var cardsArray = list.Keys.ToArray();
                var maxLength = cardsArray.Length - (MIN_CARDS_FOR_PAREJA - 1);

                // No esta preparado para diferentes MIN_CARDS_FOR_PAREJA
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

        private Dictionary<CardType, Dictionary<int, List<Card>>> OrganizeCards(List<Card> normalCards)
        {
            var listofTypes = new Dictionary<CardType, Dictionary<int, List<Card>>>();

            foreach (NormalCard card in normalCards)
            {
                if (listofTypes.ContainsKey(card.CardType) == false)
                {
                    listofTypes.Add(card.CardType, new Dictionary<int, List<Card>>() { { card.Number, new List<Card>() { card } } });
                    continue;
                }

                if (listofTypes[card.CardType].ContainsKey(card.Number) == false)
                {
                    listofTypes[card.CardType].Add(card.Number, new List<Card>() { card });
                    continue;
                }

                listofTypes[card.CardType][card.Number].Add(card); // esto nunca va a ocurrir
            }

            return listofTypes;
        }
    }
}
