using Microsoft.Maui;
using RacingGame2.Drawables;
using SharpHook.Reactive;
using System.Diagnostics;

namespace RacingGame2;

public partial class AboutPage : ContentPage
{
    private GraphicsView gv;

    public AboutPage()
	{
        InitializeComponent();
    }

    protected override void OnAppearing()
    {

    }
    private void Navigate(object sender, EventArgs e)
    {
        Application.Current.MainPage = new MainPage();
    }
}