using System.Diagnostics;

namespace RacingGame2;

public partial class GameOverPage : ContentPage
{
	private Player player;
	public GameOverPage(Player player)
	{
		InitializeComponent();
	}

	private void HighscoreButton(object sender, EventArgs e)
	{
		Application.Current.MainPage = new HighscorePage();
	}

	private void MainMenuButton(object sender, EventArgs e)
	{
		Application.Current.MainPage = new MainPage();
	}
}