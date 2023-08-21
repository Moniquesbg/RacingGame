using Microsoft.Maui;
using RacingGame.Drawables;
using SharpHook.Reactive;
using System.Diagnostics;

namespace RacingGame;

public partial class AboutPage : ContentPage
{
    private string playerName;

    public AboutPage(string playerName)
	{
        InitializeComponent();
        this.playerName = playerName;
    }


    private void Navigate(object sender, EventArgs e)
    {
        Application.Current.MainPage = new MainPage(playerName);
    }
}