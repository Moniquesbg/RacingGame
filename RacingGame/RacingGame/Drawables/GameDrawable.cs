using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace RacingGame.Drawables
{
    internal class GameDrawable : IDrawable
    {

        private const int carCount = 4;
        private const float randomizer = 800;
        private int score = 0;
        private Player player;
        private Random rand = new Random();

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

        public void UpdateCarPosition(float x, float y, int screenW, int screenH)
        {
            List<int> freeLanes = new List<int> { 0, 1, 2, 3 };
            List<int> occupiedLanes = new List<int>();

            if (cars.Length > 0)
            {
                for (int i = 0; i < cars.Length; i++)
                {
                    CarDrawable carD = cars[i];
                    Car car = carD.car;

                    // Move the bot car down the screen
                    car.y += y;

                    // Check if the bot car has reached the bottom of the screen
                    if (car.y - car.h > screenH)
                    {
                        // Remove the lane from occupiedLanes and add it back to the freeLanes
                        int lane = (int)(car.x / (screenW / 4f));
                        occupiedLanes.Remove(lane);
                        freeLanes.Add(lane);

                        // Pick a new lane at random
                        int newLane = rand.Next(0, 4);
                        while (occupiedLanes.Contains(newLane))
                        {
                            newLane = rand.Next(0, 4);
                        }

                        // Mark the new lane as occupied
                        occupiedLanes.Add(newLane);
                        freeLanes.Remove(newLane);

                        // Set the new position of the car and spawn it in
                        float newX = newLane * (screenW / 4f) + (screenW / 8f);
                        float newY = -rand.Next(0, screenH);

                        cars[i] = new CarDrawable(newX, newY);
                    }
                    else
                    {
                        // Check which lane the car is in
                        int lane = (int)(car.x / (screenW / 4f));

                        // Check if the lane of the car already is in occupiedLanes
                        if (occupiedLanes.Contains(lane))
                        {
                         
                        }
                        else
                        {
                            // Mark the lane as occupied
                            occupiedLanes.Add(lane);
                        }
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
