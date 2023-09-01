using Microsoft.Maui;
using RacingGame.Drawables;
using SharpHook.Reactive;
using System.Diagnostics;

namespace RacingGame;

public partial class AboutPage : ContentPage
{
    private Player player;

    public AboutPage(Player player)
    {
        InitializeComponent();
        this.player = player;
    }

    private void Navigate(object sender, EventArgs e)
    {
        Application.Current.MainPage = new MainPage(player);
    }
}