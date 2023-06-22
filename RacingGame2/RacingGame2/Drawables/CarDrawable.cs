namespace RacingGame2.Drawables
{
    internal class CarDrawable
    {
        public Car car { get; private set; }

        public CarDrawable(Car car)
        {
            this.car = car;
        }

		public CarDrawable(float x, float y)
		{
            Random rnd = new Random();
			Color randomColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

			this.car = new Car(x, y, randomColor);
		}

		public CarDrawable(float x, float y, Color color)
		{
			this.car = new Car(x, y, color);
		}

		public void Draw(ICanvas canvas)
        {
            canvas.FillColor = car.color;
            canvas.FillRectangle(car.x - car.w / 2f, car.y - car.h / 2f, car.w, car.h);
        }
    }
}
