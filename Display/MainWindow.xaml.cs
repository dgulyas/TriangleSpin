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
		}

		private void Clear(object sender, RoutedEventArgs e)
		{
			myCanvas.Children.Clear();
		}

		private void Drawing1(object sender, RoutedEventArgs e)
		{
			DrawLines(DesignPrinter.Design1(myCanvas.Height, myCanvas.Width));
		}

		private void DrawLines(List<dgLine> lines)
		{
			foreach (var line in lines)
			{
				AddLine(line);
			}
		}

		public void AddLine(dgLine dgLine)
		{
			var myLine = new Line
			{
				Stroke = Brushes.Black,
				X1 = dgLine.p1.X,
				X2 = dgLine.p2.X,
				Y1 = dgLine.p1.Y,
				Y2 = dgLine.p2.Y,
				HorizontalAlignment = HorizontalAlignment.Left,
				VerticalAlignment = VerticalAlignment.Center,
				StrokeThickness = 2
			};
			myCanvas.Children.Add(myLine);
		}

	}
}
