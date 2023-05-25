using RacingGame2.Drawables;
using System.Diagnostics;

namespace RacingGame2;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();
        
        GraphicsView gv = new GraphicsView();

		Trace.WriteLine(Application.Current.MainPage.Width);
        Trace.WriteLine(Application.Current.MainPage.Height);

        gv.VerticalOptions = LayoutOptions.Start;
        gv.HorizontalOptions = LayoutOptions.Start;
        gv.WidthRequest = 337;
		gv.HeightRequest = 600;
		gv.Drawable = new GameDrawable();

        Content = gv;
    }

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Window.Width = 337;
		Window.Height = 600;
		Application.Current.MainPage.WidthRequest = 337;
		Application.Current.MainPage.HeightRequest = 600;
	}
}