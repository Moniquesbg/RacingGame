using System.Diagnostics;

namespace RacingGame;

public partial class GameOverPage : ContentPage
{
	private Player player;
	private string playerName;
	public GameOverPage(Player player, string playerName)
	{
		InitializeComponent();
		this.player = player;
		this.playerName = playerName;
	}

	private void HighscoreButton(object sender, EventArgs e)
	{
		Application.Current.MainPage = new HighscorePage(playerName);
	}

	private void MainMenuButton(object sender, EventArgs e)
	{
		Application.Current.MainPage = new MainPage(playerName);
	}
}