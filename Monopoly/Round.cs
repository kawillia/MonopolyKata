using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly;

namespace Monopoly
{
    public class Round
    {
        private IList<Player> players;

        public Round()
        {
            this.players = new List<Player>();
        }

        public IEnumerable<Player> Players
        {
            get { return new List<Player>(this.players); }
        }

        public Int32 NumberOfPlayers
        {
            get { return this.players.Count(); }
        }

        public void AddPlayerTurn(Player player)
        {
            this.players.Add(player);
        }
    }
}
