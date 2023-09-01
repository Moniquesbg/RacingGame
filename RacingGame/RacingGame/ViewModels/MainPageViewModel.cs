using SharpHook.Native;
using SharpHook.Reactive;
using SharpHook;
using System.Diagnostics;
using RacingGame.Drawables;

namespace RacingGame;

public partial class MainPage : ContentPage
{
    private Frame selectedFrame;
    private Player player;

    public MainPage()
    {
        InitializeComponent();
    }

    // Constructor with playername
    public MainPage(Player player)
    {
        InitializeComponent();

        this.player = player;

        fillPlayerName(player.name);
    }

    // Refills the playername after losing, so the player doesn't have to fill it back in again
    public void fillPlayerName(string playername)
    {
        if(playername != "")
        {
            entry.Text = playername;
        }
    }

    private void OnImageTapped(object sender, EventArgs e)
    {
        Image tappedImage = (Image)sender;
        Frame tappedFrame = FindParentFrame(tappedImage);

        if (selectedFrame != null)
        {
            // Deselects the last selected frame
            selectedFrame.BorderColor = Color.FromArgb("#00000000");
        }
        if (selectedFrame == tappedFrame)
        {
            // If the selected frame already has been selected, clear it
            selectedFrame = null;
        }
        else
        {
            // The selected frame
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

        // Check which page to navigate to based on the text of the buttons in the menu
        switch (clickedBtn.Text)
        {
            case "Highscores":
                Application.Current.MainPage = new HighscorePage(player);
                break;
            case "About":
                Application.Current.MainPage = new AboutPage(player);
                break;
            case "Start!":
                // Check if the playername is empty
                if (!(string.IsNullOrWhiteSpace(entry.Text)))
                {
                    if (selectedFrame != null)
                    {
                        string selectedImage = ((Image)selectedFrame.Content)?.Source?.ToString()?.Substring(6);
                        string playerName = entry.Text;

                        if (selectedImage == "red_car_maui.png")
                        {
                            string selectedImageSource = "RacingGame.Resources.Images.red_car.png";
                            Player player = new Player(playerName, new Car(0, 0, selectedImageSource));
                            Application.Current.MainPage = new GamePage(player, playerName);
                        }
                        else if (selectedImage == "yellow_car_maui.png")
                        {
                            string selectedImageSource = "RacingGame.Resources.Images.yellow_car.png";
                            Player player = new Player(playerName, new Car(0, 0, selectedImageSource));
                            Application.Current.MainPage = new GamePage(player, playerName);
                        }
                        else if (selectedImage == "white_car_maui.png")
                        {
                            string selectedImageSource = "RacingGame.Resources.Images.white_car.png";
                            Player player = new Player(playerName, new Car(0, 0, selectedImageSource));
                            Application.Current.MainPage = new GamePage(player, playerName);
                        }
                    }
                    else
                    {
                        Errormessage.Text = "Please select a car";
                    }
                }
                else
                {
                    Errormessage.Text = "Please fill in a username";
                }
                break;
            default:
                break;
        }
    }
}

