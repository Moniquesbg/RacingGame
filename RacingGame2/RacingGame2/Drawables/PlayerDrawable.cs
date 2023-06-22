namespace RacingGame2.Drawables
{
	internal class PlayerDrawable
	{
		public float x, y;
		public float w { get; private set; } = 75;
		public float h { get; private set; } = 100;
		private Player player;

		public PlayerDrawable(Player player, float x, float y)
		{
			this.player = player;
			this.x = x;
			this.y += y;
		}

		public void Draw(ICanvas canvas)
		{
			canvas.FillColor = Color.FromArgb(player.chosenRectangle);
			canvas.FillRectangle(x - w / 2f, y - h / 2f, w, h);
		}
	}
}
