using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.Players;
using Monopoly.Exceptions;

namespace Monopoly
{
    public class Game
    {
        public const int MaximumLocationIndex = 39;
        public const int MaximumNumberOfPlayers = 8;
        public const int MaximumNumberOfRounds = 20;
        public const int MinimumNumberOfPlayers = 2;
        public const int NumberOfLocations = 40;

        private List<Player> players;
        private List<Player> orderedPlayerList;

        private int numberOfRoundsPlayed;
        private Random randomOrderGenerator;

        public int NumberOfRoundsPlayed
        {
            get { return numberOfRoundsPlayed; }
        }

        public Game()
        {
            this.players = new List<Player>();
            this.numberOfRoundsPlayed = 0;
            this.randomOrderGenerator = new Random(1);
        }

        public void AddPlayer(Player playerToAdd)
        {
            if (this.players.Any(p => p.Name == playerToAdd.Name))
                throw new DuplicatePlayerAddedException();

            this.players.Add(playerToAdd);
        }

        public void Setup()
        {
            int originalNumberOfPlayers = players.Count;

            //TODO: Move to seperate method in class...
            for (int i = 0; i < originalNumberOfPlayers; i++)
            {
                int playerRollPosition = randomOrderGenerator.Next(0, players.Count - 1);
                orderedPlayerList.Add(players[playerRollPosition]);
                players.RemoveAt(playerRollPosition);
            }
        }

        public void Play()
        {
            if (this.players.Count < MinimumNumberOfPlayers || this.players.Count > MaximumNumberOfPlayers)
                throw new ArgumentOutOfRangeException("players");

            Dice dice = new Dice();

            while (this.numberOfRoundsPlayed < MaximumNumberOfRounds)
            {
                foreach (Player player in orderedPlayerList)
                {
                    player.Move(dice.Roll());
                }

                this.numberOfRoundsPlayed++;
            }
        }
    }
}
