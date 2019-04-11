using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using TriangleSpin;

namespace Display
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var size = 120;

			AddTriangleSpin(new dgPoint(0, 0), new dgPoint(0, size), new dgPoint(size, size / 2.0f));
		}

		public void AddTriangleSpin(dgPoint p1, dgPoint p2, dgPoint p3)
		{
			var pointQueue = new Queue<dgPoint>();

			pointQueue.Enqueue(p1);
			pointQueue.Enqueue(p2);
			pointQueue.Enqueue(p3);

			while(true)
			{
				var first = pointQueue.Dequeue();
				var second = pointQueue.Peek();
				var line = new dgLine(first, second);
				AddLine(line);
				pointQueue.Enqueue(line.Fraction(0.13f));
				if (length(line) < 15) break;

			}
		}

		private double length(dgLine l)
		{
			return Math.Sqrt((l.p1.X-l.p2.X) * (l.p1.X - l.p2.X) + (l.p1.Y - l.p2.Y) * (l.p1.Y - l.p2.Y));
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
