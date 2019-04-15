using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using TriangleSpin;
using Brushes = System.Windows.Media.Brushes;

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
			Btn3.Click += Drawing3;
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

		private void Drawing3(object sender, RoutedEventArgs e)
		{
			DrawLines(DesignPrinter.Design3(MyCanvas.Height, MyCanvas.Width));
		}

		private void DrawLines(IEnumerable<DgLine> lines)
		{
			foreach (var line in lines)
			{
				AddLine(line);
			}
		}

		private void DrawPoints(List<DgPoint> points)
		{
			foreach (var point in points)
			{
				AddPoint(point);
			}
		}

		private void AddPoint(DgPoint point)
		{
			var dot = new Ellipse
			{
				Width = 5,
				Height = 5,
				Stroke = Brushes.Red,
				Fill = Brushes.Red
			};
			MyCanvas.Children.Add(dot);
			Canvas.SetTop(dot, point.Y);
			Canvas.SetLeft(dot, point.X);
		}

		private void AddLine(DgLine dgLine)
		{
			var line = new Line
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
			MyCanvas.Children.Add(line);
		}

	}
}
