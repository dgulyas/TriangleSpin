namespace TriangleSpin
{
	public class dgPoint
	{
		public double X;
		public double Y;

		public dgPoint(double x, double y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return $"X:{X} Y:{Y}";
		}

	}
}
