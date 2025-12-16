// See https://aka.ms/new-console-template for more information

class Player
{
    public Hand hand = new Hand();
    public int Victories { get; private set; } = 0;
    public int Defeats { get; private set; } = 0;

    public int PlayerNumer{ get; }

    public Player(int playerNumer)
    {
        this.PlayerNumer = playerNumer;
    }

    public void ScoreVictory()
    {
        ++Victories;
    }

    public void ScoreDefeat()
    {
        ++Defeats;
    }
}
