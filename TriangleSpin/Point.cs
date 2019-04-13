namespace TriangleSpin
{
	public class DgPoint
	{
		public double X;
		public double Y;

		public DgPoint(double x, double y)
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
