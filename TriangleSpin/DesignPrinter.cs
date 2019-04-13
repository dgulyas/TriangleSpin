using System;
using System.Collections.Generic;

namespace TriangleSpin
{
	public static class DesignPrinter
	{
		public static List<dgLine> Design1(double height, double width)
		{
			var lines = new List<dgLine>();

			var topLeft = new DgPoint(0, 0);
			var topRight = new DgPoint(width, 0);
			var bottomLeft = new DgPoint(0, height);
			var bottomRight = new DgPoint(width, height);
			var middle = new DgPoint(width / 2, height / 2);

			lines.AddRange(AddTriangleSpin(middle, topRight, topLeft));
			lines.AddRange(AddTriangleSpin(middle, topLeft, bottomLeft));
			lines.AddRange(AddTriangleSpin(middle, bottomLeft, bottomRight));
			lines.AddRange(AddTriangleSpin(middle, bottomRight, topRight));

			return lines;
		}

		private static List<dgLine> AddTriangleSpin(DgPoint p1, DgPoint p2, DgPoint p3)
		{
			var lines = new List<dgLine>();
			var pointQueue = new Queue<DgPoint>();

			pointQueue.Enqueue(p1);
			pointQueue.Enqueue(p2);
			pointQueue.Enqueue(p3);

			while (true)
			{
				var first = pointQueue.Dequeue();
				var second = pointQueue.Peek();
				var line = new dgLine(first, second);
				lines.Add(line);
				pointQueue.Enqueue(line.Fraction(0.03f));
				if (length(line) < 15) break;
			}

			return lines;
		}

		private static double length(dgLine l)
		{
			return Math.Sqrt((l.p1.X - l.p2.X) * (l.p1.X - l.p2.X) + (l.p1.Y - l.p2.Y) * (l.p1.Y - l.p2.Y));
		}

	}
}
