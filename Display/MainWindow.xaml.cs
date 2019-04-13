using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using TriangleSpin;

namespace Display
{
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();

			BtnC.Click += Clear;
			Btn1.Click += Drawing1;
			Btn2.Click += Drawing2;
		}

		private void Clear(object sender, RoutedEventArgs e)
		{
			MyCanvas.Children.Clear();
		}

		private void Drawing1(object sender, RoutedEventArgs e)
		{
			DrawLines(DesignPrinter.Design1(MyCanvas.Height, MyCanvas.Width));
		}

		private void Drawing2(object sender, RoutedEventArgs e)
		{
			DrawLines(DesignPrinter.Design2(MyCanvas.Height, MyCanvas.Width));
		}

		private void DrawLines(IEnumerable<DgLine> lines)
		{
			foreach (var line in lines)
			{
				AddLine(line);
			}
		}

		public void AddLine(DgLine dgLine)
		{
			var myLine = new Line
			{
				Stroke = Brushes.Black,
				X1 = dgLine.P1.X,
				X2 = dgLine.P2.X,
				Y1 = dgLine.P1.Y,
				Y2 = dgLine.P2.Y,
				HorizontalAlignment = HorizontalAlignment.Left,
				VerticalAlignment = VerticalAlignment.Center,
				StrokeThickness = 2
			};
			MyCanvas.Children.Add(myLine);
		}

	}
}
