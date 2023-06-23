using System.Collections.ObjectModel;

namespace RacingGame2;

public partial class HighscorePage : ContentPage
{
	public HighscorePage()
	{
		this.InitializeComponent();
	}

	private void Navigate(object sender, EventArgs e)
	{
		Application.Current.MainPage = new MainPage();
	}
}