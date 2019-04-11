namespace TriangleSpin
{
	public class dgLine
	{
		public readonly dgPoint p1;
		public readonly dgPoint p2;

		public dgLine(dgPoint p1, dgPoint p2)
		{
			this.p1 = p1;
			this.p2 = p2;
		}

		public dgPoint Fraction(float frac)
		{
			return new dgPoint(p1.X + frac * (p2.X - p1.X),
				p1.Y + frac * (p2.Y - p1.Y));
		}
	}
}
