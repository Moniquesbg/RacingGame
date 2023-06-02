using System.Diagnostics;
using RacingGame2.Drawables;

namespace RacingGame2;

public partial class GamePage : ContentPage
{
	private float aspect = 1.5f;
	private int screenWidth, screenHeight = 750;

	public GamePage()
	{
		InitializeComponent();

		screenWidth = (int)(screenHeight / aspect);

		GraphicsView gv = new GraphicsView();

		gv.VerticalOptions = LayoutOptions.Start;
		gv.HorizontalOptions = LayoutOptions.Start;
		gv.WidthRequest = screenWidth;
		gv.HeightRequest = screenHeight;
		gv.Drawable = new GameDrawable();

		getMouseCoord(gv);

		Content = gv;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		screenWidth = (int)(screenHeight / aspect);

		Window.Width = screenWidth + 75;
		Window.Height = screenHeight + 75;
		Application.Current.MainPage.WidthRequest = screenWidth;
		Application.Current.MainPage.HeightRequest = screenHeight;
	}

	void getMouseCoord(View view)
	{
		DragGestureRecognizer dragGestureRecognizer = new DragGestureRecognizer();
		PointerGestureRecognizer pointerGestureRecognizer = new PointerGestureRecognizer();
		Point startPoint, endPoint;

		pointerGestureRecognizer.PointerEntered
			+= (s, e) =>
			{
				startPoint = new Point(e.GetPosition((View)s).Value.X, e.GetPosition((View)s).Value.Y);
				Trace.WriteLine(startPoint);
			};

		//dragGestureRecognizer.DragStarting += (sender, eventArgs) =>
		//{

		//	//Point? relativeToContainerPosition = eventArgs.GetPosition((View)sender);
		//	eventArgs.Data.Text = "dsadas";
		//	//point = new Point(relativeToContainerPosition.Value.X, relativeToContainerPosition.Value.Y);
		//	//Trace.WriteLine(point.ToString());
		//};

		view.GestureRecognizers.Add(pointerGestureRecognizer);
	}

	void move(Point point)
	{
	}
}