namespace TriangleSpin
{
	public class dgLine
	{
		public readonly DgPoint p1;
		public readonly DgPoint p2;

		public dgLine(DgPoint p1, DgPoint p2)
		{
			this.p1 = p1;
			this.p2 = p2;
		}

		public DgPoint Fraction(float frac)
		{
			return new DgPoint(p1.X + frac * (p2.X - p1.X),
				p1.Y + frac * (p2.Y - p1.Y));
		}
	}
}
