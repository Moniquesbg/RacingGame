using SharpHook.Native;
using SharpHook.Reactive;
using SharpHook;
using System.Diagnostics;

namespace RacingGame2;

public partial class MainPage : ContentPage
{
	int count = 0;
    private Frame selectedFrame;

    public MainPage()
	{
		InitializeComponent();

    }

    private void OnRectangleTapped(object sender, EventArgs e)
    {
        Frame tappedFrame = (Frame)sender;

        if (selectedFrame != null)
        {
            //Deselecteert de vorige geselecteerde frame
            selectedFrame.BorderColor = Color.FromArgb("#00000000"); 
        }

        if (selectedFrame == tappedFrame)
        {
            // Als de geselecteerde rechthoek al geselecteerd is, dan clear
            selectedFrame = null;
        }
        else
        {
            // De geselecteerde frame
            tappedFrame.BorderColor = Color.FromArgb("#000000"); 
            selectedFrame = tappedFrame;
        }
    }

    private void Navigate(object sender, EventArgs e)
	{
        string playerName = entry.Text;
        string selectedRectangle = "";

        if (selectedFrame == OrangeFrame)
            selectedRectangle = "#FFA500";
        else if (selectedFrame == GreenFrame)
            selectedRectangle = "#008000";
        else if (selectedFrame == BlueFrame)
            selectedRectangle = "#0000FF";

        Player player = new Player(playerName, selectedRectangle);

        Application.Current.MainPage = new GamePage(player);
    }

    private void AboutNavigate(object sender, EventArgs e)
    {
        Application.Current.MainPage = new AboutPage();
    }
}

