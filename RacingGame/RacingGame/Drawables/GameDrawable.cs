namespace RacingGame.Drawables
{
    internal class GameDrawable : IDrawable
    {

        private int carCount = 6;
        private float randomizer = 800;
        private int score = 0;
        private Player player;

        public PlayerDrawable playerDrawable { get; private set; }
        public CarDrawable[] cars { get; private set; }

        public GameDrawable(Player player, int screenw, float playerX, float playerY)
        {
            this.player = player;
            playerDrawable = new PlayerDrawable(player, playerX, playerY);
            cars = new CarDrawable[carCount];
            Random rand = new Random();

            for (int i = 0; i < cars.Length; i++)
            {
                float x = rand.Next(0, 4) * (screenw / 4f) + (screenw / 8f);

                float y = rand.Next(0, (int)randomizer * 2);
                y = (float)Math.Round(y / randomizer);
                y *= randomizer / 2;

                cars[i] = new CarDrawable(x, -y);
            }
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            float screenwidth = (float)Application.Current.MainPage.Width;
            float screenHeight = (float)Application.Current.MainPage.Height;

            canvas.FillColor = new Color(0.2f, 0.2f, 0.2f);
            canvas.FillRectangle(0, 0, screenwidth, screenHeight);

            canvas.StrokeColor = Colors.White;
            canvas.StrokeSize = 5;
            canvas.StrokeDashPattern = new float[] { 10, 10 };
            canvas.DrawLine(screenwidth / 4, 0, screenwidth / 4, screenHeight);
            canvas.DrawLine((screenwidth / 4) * 2, 0, (screenwidth / 4) * 2, screenHeight);
            canvas.DrawLine((screenwidth / 4) * 3, 0, (screenwidth / 4) * 3, screenHeight);

            for (int i = 0; i < cars.Length; i++)
            {
                CarDrawable carD = cars[i];
                carD.Draw(canvas);
                Car car = carD.car;


                bool overlap = isRectangleOverlap(
                    new Rect(car.x, car.y, car.w, car.h),
                    new Rect(player.car.x, player.car.y, player.car.w, player.car.h)
                );

                if (overlap)
                {
                    HighscoreBoard.AddScore(player, TimeSpan.FromMilliseconds(score));
                    Application.Current.MainPage = new GameOverPage(player);
                }
            }

            canvas.FontSize = 20;
            canvas.FontColor = Color.FromArgb("#ffffff");

            TimeSpan time = TimeSpan.FromMilliseconds(score);
            string formattedScore = string.Format("{0:D2}m:{1:D2}s",
                        time.Minutes,
                        time.Seconds);
            canvas.DrawString("Score: " + formattedScore, 20, 20, HorizontalAlignment.Left);

            playerDrawable.Draw(canvas);
        }

        public void IncreaseScore(int amount)
        {
            score += amount;
        }

        public Point GetPlayerPosition()
        {
            return new Point(player.car.x, player.car.y);
        }

        public void UpdatePosition(float x, float y)
        {
            playerDrawable = new PlayerDrawable(player, player.car.x + x, player.car.y + y);
        }

        public void UpdateCarPosition(float x, float y, int screenw, int screenH)
        {
            if (cars.Length > 0)
            {
                for (int i = 0; i < cars.Length; i++)
                {
                    CarDrawable carD = cars[i];
                    Car car = carD.car;

                    if (car.y - car.h + y < screenH)
                    {
                        cars[i] = new CarDrawable(car.x + x, car.y + y, car.imageSource);
                    }
                    else
                    {
                        Random rand = new Random();
                        float randX = rand.Next(0, 4) * (screenw / 4f) + (screenw / 8f);

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
