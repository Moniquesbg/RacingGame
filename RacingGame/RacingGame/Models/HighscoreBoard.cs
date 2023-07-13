using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingGame
{
	public static class HighscoreBoard
	{
		private static List<Highscore> highscores { get; set; }

		static HighscoreBoard()
		{
			highscores = new List<Highscore>();
		}

		internal static void AddScore(Player player, TimeSpan score)
		{
			highscores.Add(new Highscore(player, score));
		}

		public static string FirstPlace
		{
			get
			{
				if (highscores.Count > 0)
				{
					if (highscores.Count > 1) highscores.Sort();
					return "1. " + highscores.ToArray()[0].ToString();
				}
				return "1. ---";
			}
			set { }
		}

		public static string SecondPlace
		{
			get
			{
				if (highscores.Count > 1)
				{
					highscores.Sort();
					return "2. " + highscores.ToArray()[1].ToString();
				}
				return "2. ---";
			}
			set { }
		}

		public static string ThirdPlace
		{
			get
			{
				if (highscores.Count > 2)
				{
					highscores.Sort();
					return "3. " + highscores.ToArray()[2].ToString();
				}
				return "3. ---";
			}
			set { }
		}

		public static string FourthPlace
		{
			get
			{
				if (highscores.Count > 3)
				{
					highscores.Sort();
					return "4. " + highscores.ToArray()[3].ToString();
				}
				return "4. ---";
			}
			set { }
		}

		public static string FifthPlace
		{
			get
			{
				if (highscores.Count > 4)
				{
					highscores.Sort();
					return "5. " + highscores.ToArray()[4].ToString();
				}
				return "5. ---";
			}
			set { }
		}

	}
}
