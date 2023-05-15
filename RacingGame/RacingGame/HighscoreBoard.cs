using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingGame
{
    internal class HighscoreBoard
    {
        private List<Highscore> highscores { get; set; }

        public HighscoreBoard()
        {
            highscores = new List<Highscore>();
        }

    }
}
