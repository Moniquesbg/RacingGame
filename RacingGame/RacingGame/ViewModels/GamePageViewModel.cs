using RacingGame.Drawables;
using SharpHook.Native;
using SharpHook;
using SharpHook.Reactive;
using System.Diagnostics;
using System.Timers;

namespace RacingGame;

public partial class GamePage : ContentPage
{ 
	private const float aspect = 1.5f;
	private static int screenWidth, screenHeight = 750;
	private GraphicsView graphicsView;
	private GameDrawable gameDrawable;
	private const float playerSpeed = 20;
    private System.Timers.Timer scoreTimer;

    TimeSpan periodTimeSpan = TimeSpan.FromMilliseconds(100);

    public GamePage(Player player, string playerName)
    {
        InitializeComponent();

        var hook = new SimpleReactiveGlobalHook();
        hook.KeyPressed.Subscribe(e => OnKeyReleased(e, hook));
        hook.RunAsync();

        screenWidth = (int)(screenHeight / aspect);

        graphicsView = new GraphicsView();

        graphicsView.VerticalOptions = LayoutOptions.Start;
        graphicsView.HorizontalOptions = LayoutOptions.Start;
        graphicsView.WidthRequest = screenWidth;
        graphicsView.HeightRequest = screenHeight;

        gameDrawable = new GameDrawable(player, screenWidth, (screenWidth / 4f) * 1.5f, screenHeight - 100);
        graphicsView.Drawable = gameDrawable;
        Content = graphicsView;

        scoreTimer = new System.Timers.Timer();
        scoreTimer.Interval = 1000;
        scoreTimer.Elapsed += TimerElapsed;
        scoreTimer.Start();

        var carTimer = Application.Current.Dispatcher.CreateTimer();
        carTimer.Interval = periodTimeSpan;
        carTimer.Tick += (s, e) => MoveCar();
        carTimer.Start();
    }

    private void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        gameDrawable.IncreaseScore(1000);
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
        float halfWidth = gameDrawable.playerDrawable.player.car.w / 2;
        float halfHeight = gameDrawable.playerDrawable.player.car.h / 2;

        double newPlayerX = gameDrawable.GetPlayerPosition().X + x;
        double newPlayerY = gameDrawable.GetPlayerPosition().Y + y;

        if (newPlayerX > halfWidth && newPlayerX < screenWidth - halfWidth &&
            newPlayerY > halfHeight && newPlayerY < screenHeight - halfHeight)
        {
            gameDrawable.UpdatePosition(x, y);
            graphicsView.Invalidate();
        }
    }

    void MoveCar()
    {
        gameDrawable.UpdateCarPosition(0, 30, screenWidth, screenHeight);
        try
        {
            graphicsView.Invalidate();
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