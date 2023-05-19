using RacingGame.Drawables;
using System.Diagnostics;

namespace RacingGame;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();
        
        GraphicsView gv = new GraphicsView();
        
        Trace.WriteLine(Application.Current.MainPage.Width);
        Trace.WriteLine(Application.Current.MainPage.Height);

        gv.VerticalOptions = LayoutOptions.End;
        gv.HorizontalOptions = LayoutOptions.Center;
        gv.WidthRequest = Application.Current.MainPage.Width;
		gv.HeightRequest = Application.Current.MainPage.Height;
		gv.Drawable = new GameDrawable();

        Content = gv;

    }
}