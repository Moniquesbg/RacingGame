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

        public float w { get; private set; } = 75;
        public float h { get; private set; } = 100;
        public Color color { get; private set; }

        public CarDrawable(float x, float y)
        {
            this.x = x;
            this.y += y;
            color = GetRandomColor();
        }

        public CarDrawable(float x, float y, Color color)
        {
            this.x = x;
            this.y += y;
            this.color = color;
        }

        public void Draw(ICanvas canvas)
        {
            canvas.FillColor = color;
            canvas.FillRectangle(x - w / 2f, y - h / 2f, w, h);
        }

        private Color GetRandomColor()
        {
            var random = new Random();
            return new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
        }
    }
}
