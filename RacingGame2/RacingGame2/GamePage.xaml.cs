using System.Diagnostics;
using RacingGame2.Drawables;

namespace RacingGame2;

public partial class GamePage : ContentPage
{
	private float aspect = 1.5f;
	private int screenWidth, screenHeight = 750;

	public GamePage()
	{
		InitializeComponent();

		screenWidth = (int)(screenHeight / aspect);

		GraphicsView gv = new GraphicsView();

        gv.VerticalOptions = LayoutOptions.Start;
        gv.HorizontalOptions = LayoutOptions.Start;
        gv.WidthRequest = screenWidth;
		gv.HeightRequest = screenHeight;
		gv.Drawable = new GameDrawable();

		TapGestureRecognizer gr = new TapGestureRecognizer();
		gr.Tapped += (sender, eventArgs) =>
		{
			Point? relativeToContainerPosition = eventArgs.GetPosition((View)sender);
			Trace.WriteLine(relativeToContainerPosition.Value.X);
			Trace.WriteLine(relativeToContainerPosition.Value.Y);
		};
		gv.GestureRecognizers.Add(gr);

        Content = gv;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		screenWidth = (int)(screenHeight / aspect);

		Window.Width = screenWidth;
		Window.Height = screenHeight;
		Application.Current.MainPage.WidthRequest = screenWidth;
		Application.Current.MainPage.HeightRequest = screenHeight;
	}
}