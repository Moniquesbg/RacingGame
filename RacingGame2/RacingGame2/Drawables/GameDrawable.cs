using System.Diagnostics;

namespace RacingGame2.Drawables
{
	internal class GameDrawable : IDrawable
	{
		public PlayerDrawable pd { get; private set; }
		public CarDrawable[] cars { get; private set; }

		private int carCount = 6;
		private float randomizer = 800;
		private int score = 0;
		private Player player;

		public GameDrawable(Player player, int screenW, float playerX, float playerY)
		{
			this.player = player;
			pd = new PlayerDrawable(player, playerX, playerY);
			cars = new CarDrawable[carCount];
			Random rand = new Random();


			for (int i = 0; i < cars.Length; i++)
			{
				float x = rand.Next(0, 4) * (screenW / 4f) + (screenW / 8f);

				float y = rand.Next(0, (int)randomizer * 2);
				y = (float)Math.Round(y / randomizer);
				y *= randomizer / 2;

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
				CarDrawable carD = cars[i];
				carD.Draw(canvas);
				Car car = carD.car;

				bool overlap = isRectangleOverlap(
					new Rect(car.x, car.y, car.w, car.h),
					new Rect(pd.x, pd.y, pd.w, pd.h)
				);

				if (overlap)
				{
					HighscoreBoard.AddScore(player, TimeSpan.FromMilliseconds(score));
					Application.Current.MainPage = new GameOverPage(player);
				}
			}

			canvas.FontSize = 20;
			canvas.FontColor = Color.FromArgb("#ffffff");

			TimeSpan t = TimeSpan.FromMilliseconds(score);
			string formattedScore = string.Format("{0:D2}m:{1:D2}s:{2:D3}ms",
						t.Minutes,
						t.Seconds,
						t.Milliseconds);
			canvas.DrawString("Score: " + formattedScore, 20, 20, HorizontalAlignment.Left);

			pd.Draw(canvas);
		}

		public void IncreaseScore(int amount)
		{
			score += amount;
		}

		public Point GetPlayerPosition()
		{
			return new Point(pd.x, pd.y);
		}

		public void UpdatePosition(float x, float y)
		{
			pd = new PlayerDrawable(player, pd.x + x, pd.y + y);
		}

		public void UpdateCarPosition(float x, float y, int screenW, int screenH)
		{
			if (cars.Length > 0)
			{
				for (int i = 0; i < cars.Length; i++)
				{
					CarDrawable carD = cars[i];
					Car car = carD.car;

					if (car.y - car.h + y < screenH)
					{
						cars[i] = new CarDrawable(car.x + x, car.y + y, car.color);
					}
					else
					{
						Random rand = new Random();
						float randX = rand.Next(0, 4) * (screenW / 4f) + (screenW / 8f);

						float randY = rand.Next(0, screenH);
						y = (float)Math.Round(y / 400);
						y *= 200;

						cars[i] = new CarDrawable(randX, -randY);
					}
				}
			}
		}

		public static bool isRectangleOverlap(Rect r1, Rect r2)
		{
			bool widthIsPositive = Math.Min(r1.X + r1.Width, r2.X + r2.Width) > Math.Max(r1.X, r2.X);
			bool heightIsPositive = Math.Min(r1.Y + r1.Height, r2.Y + r2.Height) > Math.Max(r1.Y, r2.Y);
			return (widthIsPositive && heightIsPositive);
		}

	}
}
