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
        private String chosenRectangle { get; set; }

        public Player(String name, String chosenRectangle)
        {
            this.name = name;
            this.chosenRectangle = chosenRectangle;
        }

    }
}
