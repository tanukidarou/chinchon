using ChinchonApp.Core.Desk;
using ChinchonApp.GUI;
using System;

List<Player> players = new List<Player>();

while (true)
{
    // -- Preparo el Juego --
    int turn = 0;
    int winnerPlayer = 0;

    // workarround
    if (players.Count == 0)
    {
        players.Add(new Player(1));
        players.Add(new Player(2));
    }

    foreach (Player player in players)
        player.hand.Clean();

    // -- Inicio el Juego --
    Console.WriteLine("New Game!");
    var playeableDesk = new PlayeableDesk();
    var discardDesk = new DiscardDesk();
    playeableDesk.Shuffle();

    // Agregar cartas a la mano
    for (int i = 1; i <= 7; ++i)
    {
        foreach (Player player in players)
            player.hand.AddCard(playeableDesk.RemoveTopCard());
    }

    // Mostrar la mano
    foreach (Player player in players)
    {
        Console.WriteLine($"Player {player.PlayerNumer} Hand:");
        GUI.ShowHand(player.hand);
    }


    // -- Turno de los jugadores --
    while (true)
    {
        ++turn;

        if (playeableDesk.IsEmpty() && (playeableDesk.NumberofCards() < players.Count))
            break;

        // CONDICION DE SALIDA FALOPA - COMODIN
        foreach (var player in players)
        {
            if (player.hand.HaveAJoker())
            {
                winnerPlayer = player.PlayerNumer;
                break;
            }
        }

        if (winnerPlayer != 0)
            break;

        Console.WriteLine($"Turno {turn}");

        // Se hace la jugada
        foreach (var player in players)
        {
            if (playeableDesk.IsEmpty())
                break;

            var cardFromDesk = playeableDesk.RemoveTopCard();
            player.hand.AddCard(cardFromDesk);

            Card removedCardFromHand = player.hand.RemoveTopCard();
            discardDesk.AddCardToTopCard(removedCardFromHand);

            Console.WriteLine($"El jugador {player.PlayerNumer} aggarro el {GUI.ShowCard(cardFromDesk)} y descarto el {GUI.ShowCard(removedCardFromHand)}");
        }


        Console.ReadLine();
    }


    // -- Termino el juego --

    Console.WriteLine($"Termino el Juego. Gano el jugador {winnerPlayer}");

    Console.WriteLine("Estado de Jugadores:");
    foreach (var player in players)
    {
        if (player.PlayerNumer == winnerPlayer)
            player.ScoreVictory();
        else
            player.ScoreDefeat();

        Console.WriteLine($"Jugador {player.PlayerNumer} Tiene {player.Victories} victorias y {player.Defeats} derrotas.");
    }

    Console.ReadLine();
    Console.Clear();
}