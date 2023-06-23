using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace RacingGame2
{
	public class Player
	{
		public string name { get; set; }
		public string chosenRectangle { get; set; }

		public Player(string name, string chosenRectangle)
		{
			this.name = name;
			this.chosenRectangle = chosenRectangle;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

	}
}
