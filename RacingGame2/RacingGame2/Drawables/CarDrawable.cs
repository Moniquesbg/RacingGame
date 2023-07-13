using Microsoft.Maui.Graphics.Win2D;
using System.Reflection;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace RacingGame2.Drawables
{
    internal class CarDrawable
    {
        public Car car { get; private set; }

        private string[] carImages = new string[]
        {
            "red_car.png",
            "white_car.png",
            "yellow_car.png",
            "bugatti.png",
            "lamborghini.png",
            "lightningmcqueen.png",
            "rusteze.png",
        };

        public CarDrawable(Car car)
        {
            this.car = car;
        }

		public CarDrawable(float x, float y)
		{
            string imageSource = "RacingGame2.Resources.Images.Npc_cars." + carImages[new Random().Next(carImages.Length)];

            this.car = new Car(x, y, imageSource);
		}

		public CarDrawable(float x, float y, string imageSource)
		{
			this.car = new Car(x, y, imageSource);
		}

		public void Draw(ICanvas canvas)
        {
            IImage image = null;
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(car.imageSource);

            if (stream != null)
            {
                image = new W2DImageLoadingService().FromStream(stream);
            }

            if (image != null)
            {
                canvas.DrawImage(image, car.x - car.w / 2, car.y - car.h / 2, car.w, car.h);
            }
            else
            {
                Random rnd = new Random();
                Color randomColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                canvas.FillColor = randomColor;
                canvas.FillRectangle(car.x - car.w / 2f, car.y - car.h / 2f, car.w, car.h);
            }
        }
    }
}
