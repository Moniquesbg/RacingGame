using RacingGame2.Drawables;
using SharpHook.Native;
using SharpHook;
using SharpHook.Reactive;
using System.Diagnostics;

namespace RacingGame2;

public partial class GamePage : ContentPage
{ 
	private float aspect = 1.5f;
	private int screenWidth, screenHeight = 750;
	private GraphicsView gv;
	private GameDrawable gd;
	private float playerSpeed = 20;

    TimeSpan periodTimeSpan = TimeSpan.FromMilliseconds(100);

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

        gd = new GameDrawable(screenWidth, (screenWidth / 4f) * 1.5f, screenHeight - 100);
        gv.Drawable = gd;
        Content = gv;

		var timer = Application.Current.Dispatcher.CreateTimer();
		timer.Interval = periodTimeSpan;
		timer.Tick += (s, e) => MoveCar();
		timer.Start();

		var scoreTimer = Application.Current.Dispatcher.CreateTimer();
		scoreTimer.Interval = TimeSpan.FromMilliseconds(1);
		scoreTimer.Tick += (s, e) => gd.IncreaseScore();
		scoreTimer.Start();
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
        float hw = gd.pd.w / 2;
        float hh = gd.pd.h / 2;

        if (gd.GetPlayerPosition().X + x > hw && gd.GetPlayerPosition().X + x < screenWidth - hw &&
            gd.GetPlayerPosition().Y + y > hh && gd.GetPlayerPosition().Y + y < screenHeight - hh)
        {
            gd.UpdatePosition(x, y);
            gv.Invalidate();
        }
    }

    void MoveCar()
    {
        gd.UpdateCarPosition(0, 30, screenWidth, screenHeight);
        try
        {
            gv.Invalidate();
        }
        catch { }
    }

    private void OnKeyReleased(KeyboardHookEventArgs e, IReactiveGlobalHook hook)
    {
        if (e.Data.KeyCode == KeyCode.VcD)
        {
            MovePlayer(playerSpeed, 0);
        }
        else if (e.Data.KeyCode == KeyCode.VcA)
        {
            MovePlayer(-playerSpeed, 0);
        }
    }
}