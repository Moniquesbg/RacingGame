namespace RacingGame2.Drawables
{
	internal class PlayerDrawable
	{
		public float x, y;
        public float w { get; private set; } = 75;
        public float h { get; private set; } = 100;

        public PlayerDrawable()
		{
			this.x = 0;
			this.y = 0;
		}

		public PlayerDrawable(float x, float y)
		{
			this.x = x;
			this.y += y;
		}

		public void Draw(ICanvas canvas)
		{
			canvas.FillColor = new Color(1f, 0f, 0f);
			canvas.FillRectangle(x - w / 2f, y - h / 2f, w, h);
		}
    }
}
