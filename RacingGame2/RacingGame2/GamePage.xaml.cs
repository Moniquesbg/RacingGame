using System.Diagnostics;
using RacingGame2.Drawables;
using SharpHook.Native;
using SharpHook;
using SharpHook.Reactive;

namespace RacingGame2;

public partial class GamePage : ContentPage
{
	private float aspect = 1.5f;
	private int screenWidth, screenHeight = 750;
	private GraphicsView gv;
	private GameDrawable gd;

	public GamePage()
	{
		InitializeComponent();

		var hook = new SimpleReactiveGlobalHook();
		hook.KeyPressed.Subscribe(e => OnKeyReleased(e, hook));
		hook.RunAsync();

		screenWidth = (int)(screenHeight / aspect);

		gv = new GraphicsView();

		gv.VerticalOptions = LayoutOptions.Start;
		gv.HorizontalOptions = LayoutOptions.Start;
		gv.WidthRequest = screenWidth;
		gv.HeightRequest = screenHeight;
		gd = new GameDrawable((screenWidth / 4f) * 1.5f, screenHeight - 100);
		gv.Drawable = gd;

		Content = gv;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		screenWidth = (int)(screenHeight / aspect);

		Window.Width = screenWidth + 75;
		Window.Height = screenHeight + 75;
		Application.Current.MainPage.WidthRequest = screenWidth;
		Application.Current.MainPage.HeightRequest = screenHeight;
	}

	void MovePlayer(float x, float y)
	{
		if (gd.GetPlayerPosition().x + x > 0 && gd.GetPlayerPosition().x + x < screenWidth &&
			gd.GetPlayerPosition().y + y > 0 && gd.GetPlayerPosition().y + y < screenHeight)
		{
			gd.UpdatePosition(x, y);
			gv.Invalidate();
		}
	}

	private void OnKeyReleased(KeyboardHookEventArgs e, IReactiveGlobalHook hook)
	{
		if (e.Data.KeyCode == KeyCode.VcD)
		{
			Trace.WriteLine("Move Right");

			MovePlayer(10, 0);
		}
		else if (e.Data.KeyCode == KeyCode.VcA)
		{
			Trace.WriteLine("Move Left");

			MovePlayer(-10, 0);
		}
	}
}