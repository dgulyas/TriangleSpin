namespace TriangleSpin
{
	public class DgLine
	{
		public readonly DgPoint P1;
		public readonly DgPoint P2;

		public DgLine(DgPoint p1, DgPoint p2)
		{
			P1 = p1;
			P2 = p2;
		}

		public DgPoint Fraction(float fraction)
		{
			return new DgPoint(P1.X + fraction * (P2.X - P1.X),
				P1.Y + fraction * (P2.Y - P1.Y));
		}
	}
}
