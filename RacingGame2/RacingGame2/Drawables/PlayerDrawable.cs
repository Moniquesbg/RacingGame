using Microsoft.Maui.Graphics.Win2D;
using System.Diagnostics;
using System.Reflection;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace RacingGame2.Drawables
{
	internal class PlayerDrawable
	{
		public Player player { get; private set; }
		public PlayerDrawable(Player player, float x, float y)
		{
			this.player = player;
			player.car.x = x;
			player.car.y += y;
		}

		public void Draw(ICanvas canvas)
		{
            Trace.WriteLine("draw");
            IImage image = null;
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(player.car.imageSource);

            if (stream != null)
            {
                image = new W2DImageLoadingService().FromStream(stream);
            }

            if (image != null)
            {
                Trace.WriteLine("drawing image: " + image.ToString() + " at: " + player.car.x);
                canvas.DrawImage(image, player.car.x - player.car.w / 2, player.car.y - player.car.h / 2, player.car.w, player.car.h);
            }
            else
            {
                Random rnd = new Random();
                Color randomColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                canvas.FillColor = randomColor;
                canvas.FillRectangle(player.car.x - player.car.w / 2f, player.car.y - player.car.h / 2f, player.car.w, player.car.h);
            }
        }
	}
}
