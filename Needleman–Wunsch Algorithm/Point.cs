using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Needleman_Wunsch_Algorithm
{
	class Point
	{
		public int X;
		public int Y;

		public Point() { }

		public Point(int X, int Y)
		{
			this.X = X;
			this.Y = Y;
		}



		public override string ToString()
		{
			return "(" + X.ToString() + ", " + Y.ToString() + ")";
		}
	}
}
