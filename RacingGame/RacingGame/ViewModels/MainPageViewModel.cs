using SharpHook.Native;
using SharpHook.Reactive;
using SharpHook;
using System.Diagnostics;
using RacingGame.Drawables;

namespace RacingGame;

public partial class MainPage : ContentPage
{
    private Frame selectedFrame;

    public MainPage()
    {
        InitializeComponent();

    }

    private void OnImageTapped(object sender, EventArgs e)
    {
        Image tappedImage = (Image)sender;
        Frame tappedFrame = FindParentFrame(tappedImage);

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

    private Frame FindParentFrame(Element element)
    {
        Element parent = element.Parent;
        while (parent != null)
        {
            if (parent is Frame frame)
                return frame;

            parent = parent.Parent;
        }

        return null;
    }



    private void Navigate(object sender, EventArgs e)
    {
        Button clickedBtn = (Button)sender;

        switch (clickedBtn.Text)
        {
            case "Highscores":
                Application.Current.MainPage = new HighscorePage();
                break;
            case "About":
                Application.Current.MainPage = new AboutPage();
                break;
            case "Start!":
                if (string.IsNullOrWhiteSpace(entry.Text))
                {
                    Errormessage.Text = "Please fill in a name";
                }
                else
                {
                    string selectedImageSource = "RacingGame.Resources.Images." + ((Image)selectedFrame.Content).Source.ToString().Substring(6);
                    Player player = new Player(entry.Text, new Car(0, 0, selectedImageSource));
                    Application.Current.MainPage = new GamePage(player);
                }
                break;
            default:
                break;
        }
    }
}

