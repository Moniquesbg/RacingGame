using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingGame
{
    internal class Highscore
    {
        private Player player { get; set; }
        private TimeSpan score { get; set; }

        public Highscore(Player player, TimeSpan score)
        {
            this.player = player;
            this.score = score;
        }
        
    }
}
