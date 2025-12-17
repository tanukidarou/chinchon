// See https://aka.ms/new-console-template for more information

using ChinchonApp.Core.Desk.Card;
using System.Collections.Generic;

abstract class Desk
{
    internal List<Card> cards = new List<Card>();
    
    public List<Card> GetAllCards()
    {
        return cards;
    }

    internal Card RemoveTopCard()
    {
        if (IsEmpty())
            throw new Exception("The desk is empty");
        
        var card = cards[0];
        cards.RemoveAt(0);
        return card;
    }

    internal void AddCardToTop(Card card)
    {
        cards.Add(card);
    }

    internal void Shuffle()
    {
        Random rng = new Random();

        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }
    }

    internal bool IsEmpty()
    {
        return cards.Count == 0;
    }

    internal void AddCardToTopCard(Card card)
    {
        cards.Add(card);
    }

    internal int NumberofCards()
    {
        return cards.Count;
    }
}


class PlayeableDesk : Desk
{
    public PlayeableDesk()
    {
        for (int i = 1; i <= 12; i++)
        {
            cards.Add(new NormalCard(CardType.Oro, i));
        }

        for (int i = 1; i <= 12; i++)
        {
            cards.Add(new NormalCard(CardType.Copa, i));
        }

        for (int i = 1; i <= 12; i++)
        {
            cards.Add(new NormalCard(CardType.Espada, i));
        }

        for (int i = 1; i <= 12; i++)
        {
            cards.Add(new NormalCard(CardType.Basto, i));
        }

        // Se removio temporalemente por la difultad extra de desarrollo
        /*for (int i = 1; i <= 2; i++)
        {
            cards.Add(new JokerCard());
        }*/
    }
}

class DiscardDesk : Desk
{
    
}