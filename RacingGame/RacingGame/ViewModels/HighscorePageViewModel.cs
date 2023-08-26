using System.Collections.ObjectModel;

namespace RacingGame;

public partial class HighscorePage : ContentPage
{
    private Player player;

    //constructor without playername
    public HighscorePage()
    {
        this.InitializeComponent();
    }
    //constructor with playername
    public HighscorePage(Player player)
    {
        this.InitializeComponent();
        this.player = player;
    }

    private void Navigate(object sender, EventArgs e)
    {
        Application.Current.MainPage = new MainPage(player);
    }
}