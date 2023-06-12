using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingGame2.Drawables
{
    internal class GameDrawable : IDrawable
    {
        public PlayerDrawable pd { get; private set; }
        public CarDrawable[] cars { get; private set; }

        public GameDrawable(int screenW, float playerX, float playerY)
        {
            pd = new PlayerDrawable(playerX, playerY);
            cars = new CarDrawable[10];

            for (int i = 0; i < 10; i++)
            {
                Random rand = new Random();
                float x = rand.Next(0, 4) * (screenW / 4f) + (screenW / 8f);
                Trace.WriteLine(x + " / " + screenW);

                float y = rand.Next(0, 1500);
                y = (float)Math.Round(y / 400);
                y *= 200;

                cars[i] = new CarDrawable(x, -y);
            }
        }

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

            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].Draw(canvas);
            }

            pd.Draw(canvas);
        }

        public Point GetPlayerPosition()
        {
            return new Point(pd.x, pd.y);
        }

        public void UpdatePosition(float x, float y)
        {
            pd = new PlayerDrawable(pd.x + x, pd.y + y);
        }

        public void UpdateCarPosition(float x, float y, int screenW, int screenH)
        {
            if (cars.Length > 0)
            {
                for (int i = 0; i < cars.Length; i++)
                {
                    CarDrawable car = cars[i];

                    if (car.y - car.h + y < screenH)
                    {
                        cars[i] = new CarDrawable(car.x + x, car.y + y, car.color);
                    }
                    else
                    {
                        Random rand = new Random();
                        float randX = rand.Next(0, 4) * (screenW / 4f) + (screenW / 8f);
                        Trace.WriteLine(x + " / " + screenW);

                        float randY = rand.Next(0, screenH);
                        y = (float)Math.Round(y / 400);
                        y *= 200;

                        cars[i] = new CarDrawable(randX, -randY);
                    }
                }
            }
        }
    }
}
