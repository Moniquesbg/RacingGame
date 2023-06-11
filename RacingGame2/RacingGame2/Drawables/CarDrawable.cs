using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingGame2.Drawables
{
	internal class CarDrawable
    {
		public float x, y;
		private float w = 75, h = 100;

		public CarDrawable()
		{
			this.x = 0;
			this.y = 0;
		}

		public CarDrawable(float x, float y)
		{
			this.x = x;
			this.y += y;
		}

		public void Draw(ICanvas canvas)
		{
			Trace.WriteLine(x);
			Trace.WriteLine(y);
			canvas.FillColor = new Color(1f, 0f, 0f);
			canvas.FillRectangle(x - w / 2f, y - h / 2f, w, h);
		}

		public float getWidth() { return w; }
		public float getHeight() { return h; }
    }
}
