// See https://aka.ms/new-console-template for more information

using ChinchonApp.Core.Desk;

class NormalCard : Card
{
    public int Number { get; }

    public NormalCard(CardType cardType, int number)
    {
        if (cardType == CardType.Joker)
            throw new Exception("Invalid Type");
        
        
        Number = number;
        CardType = cardType;
    }
}
