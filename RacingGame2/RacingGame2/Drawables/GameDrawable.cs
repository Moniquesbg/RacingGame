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

			canvas.FillColor = new Color(0.2f, 0.2f, 0.2f);
			canvas.FillRectangle(0, 0, screenWidth, screenHeight);

			canvas.StrokeColor = Colors.White;
			canvas.StrokeSize = 5;
			canvas.StrokeDashPattern = new float[] { 10, 10 };
			canvas.DrawLine(screenWidth / 4, 0, screenWidth / 4, screenHeight);
			canvas.DrawLine((screenWidth / 4) * 2, 0, (screenWidth / 4) * 2, screenHeight);
			canvas.DrawLine((screenWidth / 4) * 3, 0, (screenWidth / 4) * 3, screenHeight);
		}
	}
}
