using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using TriangleSpin;

namespace Display
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var topLeft = new dgPoint(0,0);
			var topRight = new dgPoint(myCanvas.Width, 0);
			var bottomLeft = new dgPoint(0, myCanvas.Height);
			var bottomRight = new dgPoint(myCanvas.Width, myCanvas.Height);
			var middle = new dgPoint(myCanvas.Width / 2, myCanvas.Height / 2);

			AddTriangleSpin(middle, topRight, topLeft);
			AddTriangleSpin(middle, topLeft, bottomLeft);
			AddTriangleSpin(middle, bottomLeft, bottomRight);
			AddTriangleSpin(middle, bottomRight, topRight);
		}

		private void AddTriangleSpin(dgPoint p1, dgPoint p2, dgPoint p3)
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
				pointQueue.Enqueue(line.Fraction(0.03f));
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
