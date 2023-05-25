using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingGame2
{
    internal class Player
    {
        private String name { get; set; }
        private Image chosenCar { get; set; }

        public Player(String name)
        {
            this.name = name;
            this.chosenCar = new Image();
        }

    }
}
