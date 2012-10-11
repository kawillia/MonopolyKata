using System;

namespace Monopoly
{
    public class GameController
    {
        public const Int32 NumberOfRoundsToPlay = 20;
        private Game Game { get; set; }

        public GameController(Game game)
        {
            Game = game;
        }

        public void Play()
        {
            Game.Start();

            while (GameIsNotOver())
                Game.PlayRound();
        }

        private Boolean GameIsNotOver()
        {
            return Game.NumberOfRoundsPlayed < NumberOfRoundsToPlay;
        }
    }
}
