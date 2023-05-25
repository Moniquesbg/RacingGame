using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingGame2.Drawables
{
    internal class GameDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            float screenWidth = (float)Application.Current.MainPage.Width;
            float screenHeight = (float)Application.Current.MainPage.Height;

            canvas.FillColor = Colors.White;
            canvas.FillRectangle(0, 0, screenWidth, screenHeight);
        }
    }
}
