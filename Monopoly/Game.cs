using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly;
using Monopoly.Board;

namespace Monopoly
{
    public class Game
    {
        public const Int32 MaximumNumberOfPlayers = 8;      
        public const Int32 MinimumNumberOfPlayers = 2;

        private GameBoard gameBoard;
        private Dice dice;
        private Round currentRound;
        private List<Round> rounds;
        private List<Player> players;
        private IEnumerable<Player> shuffledPlayerList;
        private Shuffler<Player> shuffler;

        public Int32 NumberOfRoundsPlayed
        {
            get { return this.rounds.Count; }
        }
        
        public List<Round> Rounds
        {
            get { return new List<Round>(this.rounds); }
        }

        public Game(GameBoard gameBoard, Dice dice)
        {
            this.gameBoard = gameBoard;
            this.dice = dice;
            this.players = new List<Player>();
            this.shuffler = new Shuffler<Player>();
        }

        public void AddPlayer(Player playerToAdd)
        {
            if (this.players.Any(p => p.Name == playerToAdd.Name))
                throw new InvalidOperationException("Cannot add the same player to the game more than once.");

            this.players.Add(playerToAdd);
        }

        public void Start()
        {
            if (this.players.Count < MinimumNumberOfPlayers || this.players.Count > MaximumNumberOfPlayers)
                throw new InvalidOperationException("Cannot start the game with less than the minimum or greater than the maximum number of players.");

            this.rounds = new List<Round>();
            this.shuffledPlayerList = shuffler.Shuffle(this.players);
        }

        public void PlayRound()
        {
            this.currentRound = new Round();

            foreach (Player player in this.shuffledPlayerList)
                TakeTurn(player);

            this.rounds.Add(this.currentRound);
        }

        private void TakeTurn(Player player)
        {
            Turn turn = new Turn(this.dice, player, this.gameBoard);
            turn.Take();

            this.currentRound.AddPlayerTurn(player);
        }
    }
}
