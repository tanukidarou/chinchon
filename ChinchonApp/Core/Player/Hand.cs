// See https://aka.ms/new-console-template for more information

using ChinchonApp.Core.Desk;

class Hand
{
    List<Card> cards = new List<Card>();

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    /*public void RemoveCard(Card card)
    {
        cards.Remove(card);
    }*/

    public Card RemoveCardAt(int index)
    {
        if (IsEmpty())
            throw new Exception("The hand is empty");
        
        var card = cards[index];
        cards.RemoveAt(index);
        return card;
    }

    public Card RemoveLastCard()
    {
        if (IsEmpty())
            throw new Exception("The hand is empty");

        var card = cards[cards.Count-1];
        cards.RemoveAt(cards.Count-1);
        return card;
    }

    public Card RemoveTopCard()
    {
        if (IsEmpty())
            throw new Exception("The hand is empty");

        var card = cards[0];
        cards.RemoveAt(0);
        return card;
    }

    internal List<Card> GetHandCards()
    {
        return cards;
    }

    internal bool HaveAJoker()
    {
        foreach (var card in cards)
        {
            if(card.CardType == CardType.Joker)
                return true;
        }

        return false;
    }

    internal void Clean()
    {
        cards.Clear();
    }

    internal bool IsEmpty()
    {
        return cards.Count == 0;
    }
}