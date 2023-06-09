﻿using RacingGame.Drawables;
using SharpHook.Native;
using SharpHook;
using SharpHook.Reactive;
using System.Diagnostics;
using System.Timers;

namespace RacingGame;

public partial class GamePage : ContentPage
{ 
	private float aspect = 1.5f;
	private int screenWidth, screenHeight = 750;
	private GraphicsView gv;
	private GameDrawable gd;
	private float playerSpeed = 20;
    private System.Timers.Timer scoreTimer;

    TimeSpan periodTimeSpan = TimeSpan.FromMilliseconds(100);

    public GamePage(Player player)
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

        gd = new GameDrawable(player, screenWidth, (screenWidth / 4f) * 1.5f, screenHeight - 100);
        gv.Drawable = gd;
        Content = gv;

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
        
        gd.IncreaseScore(1000);
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
        float hw = gd.pd.player.car.w / 2;
        float hh = gd.pd.player.car.h / 2;

        double newPlayerX = gd.GetPlayerPosition().X + x;
        double newPlayerY = gd.GetPlayerPosition().Y + y;

        if (newPlayerX > hw && newPlayerX < screenWidth - hw &&
            newPlayerY > hh && newPlayerY < screenHeight - hh)
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