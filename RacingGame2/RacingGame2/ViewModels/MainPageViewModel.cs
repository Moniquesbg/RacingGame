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
                string selectedImageSource = "RacingGame2.Resources.Images." + ((Image)selectedFrame.Content).Source.ToString().Substring(6);

                Player player = new Player(entry.Text, new Car(0, 0, selectedImageSource));
                Application.Current.MainPage = new GamePage(player);
            }
        }
    }
}

