using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingGame
{
	internal class Highscore : IComparable<Highscore>
	{
		private Player player { get; set; }
		private TimeSpan score { get; set; }

		public Highscore(Player player, TimeSpan score)
		{
			this.player = player;
			this.score = score;
		}

		public override string ToString()
		{
			string formattedScore = string.Format("{0:D2}m:{1:D2}s",
						this.score.Minutes,
						this.score.Seconds);
			return this.player.name + " : " + formattedScore;
		}

		public int CompareTo(Highscore obj)
		{
			if (obj.score > this.score) return 1;
			else if (obj.score < this.score) return -1;
			else return 0;
		}
	}
}
