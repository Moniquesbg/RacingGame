using System.Collections.ObjectModel;

namespace RacingGame;

public partial class HighscorePage : ContentPage
{
    private string playerName;

    //constructor without playername
    public HighscorePage()
    {
        this.InitializeComponent();
    }
    //constructor with playername
    public HighscorePage(string playerName)
    {
        this.InitializeComponent();
        this.playerName = playerName;
    }

    private void Navigate(object sender, EventArgs e)
    {
        Application.Current.MainPage = new MainPage(playerName);
    }
}