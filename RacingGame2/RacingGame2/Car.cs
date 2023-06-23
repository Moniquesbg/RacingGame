using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingGame2
{
    internal class Car
    {
        public float x, y, w = 75, h = 100;
        public Color color { get; set; }

        public Car(float x, float y, float w, float h, Color color)
        {
            this.x = x;
            this.y = y; 
            this.w = w;
            this.h = h;
            this.color = color;
        }

		public Car(float x, float y, Color color)
		{
			this.x = x;
			this.y = y;
			this.color = color;
		}


	}
}
