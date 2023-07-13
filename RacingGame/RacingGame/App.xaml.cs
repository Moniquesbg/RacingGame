namespace RacingGame;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainPage();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        var windows = base.CreateWindow(activationState);

        windows.Height = 825;
        windows.Width = 575;

        windows.X = 560;
        windows.Y = 30;

        return windows;
    }
}
