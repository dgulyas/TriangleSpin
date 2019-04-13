using System;
using System.Collections.Generic;

namespace TriangleSpin
{
	public static class DesignPrinter
	{
		public static List<DgLine> Design1(double height, double width)
		{
			var topLeft = new DgPoint(0, 0);
			var topRight = new DgPoint(width, 0);
			var bottomLeft = new DgPoint(0, height);
			var bottomRight = new DgPoint(width, height);
			var middle = new DgPoint(width / 2, height / 2);

			var lines = new List<DgLine>();
			lines.AddRange(ShapeSpin(new List<DgPoint> { middle, topRight, topLeft }));
			lines.AddRange(ShapeSpin(new List<DgPoint> { middle, topLeft, bottomLeft }));
			lines.AddRange(ShapeSpin(new List<DgPoint> { middle, bottomLeft, bottomRight }));
			lines.AddRange(ShapeSpin(new List<DgPoint> { middle, bottomRight, topRight }));

			return lines;
		}

		public static List<DgLine> Design2(double height, double width)
		{
			var points = new List<DgPoint>();
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					points.Add(new DgPoint(width / 2 * i, height / 2 * j));
				}
			}

			var lines = new List<DgLine>();
			lines.AddRange(ShapeSpin(new List<DgPoint> { points[3], points[4], points[1], points[0] }));
			lines.AddRange(ShapeSpin(new List<DgPoint> { points[1], points[2], points[5], points[4] }));
			lines.AddRange(ShapeSpin(new List<DgPoint> { points[6], points[7], points[4], points[3] }));
			lines.AddRange(ShapeSpin(new List<DgPoint> { points[4], points[5], points[8], points[7] }));
			return lines;
		}

		//points = List of points making up the shapes perimeter is order
		private static IEnumerable<DgLine> ShapeSpin(List<DgPoint> points)
		{
			var lines = new List<DgLine>();
			var pointQueue = new Queue<DgPoint>();

			//The algorithm misses the line connecting the first and last point of the perimieter, so add it.
			lines.Add(new DgLine(points[0], points[points.Count-1]));

			foreach (var point in points)
			{
				pointQueue.Enqueue(point);
			}

			while (true)
			{
				var first = pointQueue.Dequeue();
				var second = pointQueue.Peek();
				var line = new DgLine(first, second);
				lines.Add(line);
				pointQueue.Enqueue(line.Fraction(0.03f));
				if (Length(line) < 18) break;
			}

			return lines;
		}

		private static double Length(DgLine l)
		{
			return Math.Sqrt((l.P1.X - l.P2.X) * (l.P1.X - l.P2.X) + (l.P1.Y - l.P2.Y) * (l.P1.Y - l.P2.Y));
		}

	}
}
