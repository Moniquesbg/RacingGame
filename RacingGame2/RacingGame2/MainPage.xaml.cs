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

    private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private void OnRectangleTapped(object sender, EventArgs e)
    {
        Frame tappedFrame = (Frame)sender;

        if (selectedFrame != null)
        {
            //Deselecteert de vorige geselecteerde frame
            selectedFrame.BorderColor = Color.FromHex("#00000000"); 
        }

        if (selectedFrame == tappedFrame)
        {
            // Als de geselecteerde rechthoek al geselecteerd is, dan clear
            selectedFrame = null;
        }
        else
        {
            // De geselecteerde frame
            tappedFrame.BorderColor = Color.FromHex("#000000"); 
            selectedFrame = tappedFrame;
        }
    }

    private void Navigate(object sender, EventArgs e)
	{
        string playerName = entry.Text;
        string selectedRectangle = "";

        if (selectedFrame == OrangeFrame)
            selectedRectangle = "Orange";
        else if (selectedFrame == GreenFrame)
            selectedRectangle = "Green";
        else if (selectedFrame == BlueFrame)
            selectedRectangle = "Blue";

        Player player = new Player(playerName, selectedRectangle);


        Application.Current.MainPage = new GamePage();
    }
}

