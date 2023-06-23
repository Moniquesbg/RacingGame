using SharpHook.Native;
using SharpHook.Reactive;
using SharpHook;
using System.Diagnostics;
using RacingGame2.Drawables;

namespace RacingGame2;

public partial class MainPage : ContentPage
{
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
        bool filled = true;
        Button clickedBtn = (Button)sender;

        if (clickedBtn == HighscoreBtn)
        {
            Application.Current.MainPage = new HighscorePage();
        }
        else if (clickedBtn == AboutBtn)
        {
            Application.Current.MainPage = new AboutPage();
        }
        else if (clickedBtn == Startbtn)
        {
            if (string.IsNullOrWhiteSpace(entry.Text))
            {
                filled = false;
                Errormessage.Text = "Please fill in a name";
            }
            else
            {
                string playerName = entry.Text;
                string selectedRectangle = "";
                if (selectedFrame == OrangeFrame)
                    selectedRectangle = "#FFA500";
                else if (selectedFrame == GreenFrame)
                    selectedRectangle = "#008000";
                else if (selectedFrame == BlueFrame)
                    selectedRectangle = "#0000FF";
                else
                {
                    filled = false;
                    Errormessage.Text = "Please select a rectangle";
                }
                if (filled)
                {
                    Player player = new Player(playerName, selectedRectangle);

                    Application.Current.MainPage = new GamePage(player);
                }
            }
        } 
        
    }
}

