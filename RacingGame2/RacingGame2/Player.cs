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
		public string name { get; private set; }
		public Car car { get; private set; }

        public Player(string name, Car car)
		{
			this.name = name;
			this.car = car;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

	}
}
