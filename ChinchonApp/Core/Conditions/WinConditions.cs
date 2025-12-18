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
        public HandAnalyzer handAnalyzer;

        private const int MIN_NUMBER_OF_CARDS_IN_HAND = 7;

        public WinConditions(HandAnalyzer handAnalyzer)
        {
            this.handAnalyzer = handAnalyzer;
        }

        public bool IsWinHand(List<Card> cards)
        {
            if(cards.Count < MIN_NUMBER_OF_CARDS_IN_HAND)
                return false;
            
            var value_1 = handAnalyzer.HaveCardsOfDiferentTypeButSameNumber(cards);

            var value_2 = handAnalyzer.HaveCardsOfSameTypeButDiferentNumberInConsecutive(cards);

            return value_1 || value_2;
        }

    }
}
