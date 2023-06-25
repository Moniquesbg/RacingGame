using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingGame2
{
    public class Car
    {
        public float x, y, w = 75, h = 125;
        public string imageSource { get; set; }

		public Car(float x, float y, string imageSource)
		{
			this.x = x;
			this.y = y;
			this.imageSource = imageSource;
		}


	}
}
