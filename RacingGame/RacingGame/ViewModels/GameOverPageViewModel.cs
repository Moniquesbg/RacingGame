using System.Diagnostics;

namespace RacingGame;

public partial class GameOverPage : ContentPage
{
    private Player player;
    public GameOverPage(Player player)
    {
        InitializeComponent();
        this.player = player;
    }

    private void HighscoreButton(object sender, EventArgs e)
    {
        Application.Current.MainPage = new HighscorePage(player);
    }

    private void MainMenuButton(object sender, EventArgs e)
    {
        Application.Current.MainPage = new MainPage(player);
    }
}