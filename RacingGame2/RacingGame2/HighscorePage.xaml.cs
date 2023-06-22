using System.Collections.ObjectModel;

namespace RacingGame2;

public partial class HighscorePage : ContentPage
{
	public HighscoreBoard MyProduct { get; set; }
	public HighscorePage()
	{
		MyProduct = new HighscoreBoard();
		this.BindingContext = MyProduct;
		this.InitializeComponent();
	}
}