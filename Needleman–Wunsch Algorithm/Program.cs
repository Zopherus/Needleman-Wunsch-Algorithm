using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Needleman_Wunsch_Algorithm
{
	class Program
	{
		const int MATCH = 1;
		const int INDEL = -1;
		const int MISMATCH = -1;

		static string DNA1 = "";
		static string DNA2 = "";
		static void Main(string[] args)
		{
			DNA1 = "GCATGCU";
			DNA2 = "GATTACA";
			Console.WriteLine(ToString(NeedlemanWunsch(DNA1, DNA2)));
			Console.ReadLine();
		}

		static int[,] NeedlemanWunsch(string a, string b)
		{
			//first string determines number of rows
			//second string determines number of columns
			//Imagine first string on left side of grid, second string on top
			int[,] grid = new int[a.Length + 1, b.Length + 1];

			for (int x = 0; x < grid.GetLength(0); x++)
			{
				for (int y = 0; y < grid.GetLength(1); y++)
				{
					grid[x, y] = CalculateScore(grid, x, y);
				}
			}
			return grid;
		}

		static int CalculateScore(int[,] grid, int x, int y)
		{
			int left = -1000;
			int topLeft = -1000;
			int top = -1000;
			if (x == 0 && y == 0)
				return 0;
			if (x != 0)
				left = grid[x - 1, y] + INDEL;
			if (x != 0 && y != 0)
			{
				topLeft = grid[x - 1, y - 1];
				if (DNA1.ElementAt(y - 1).Equals(DNA2.ElementAt(x - 1)))
					topLeft += MATCH;
				else
					topLeft += MISMATCH;
			}
			if (y != 0)
				top = grid[x, y- 1] + INDEL;
			return Math.Max(left, Math.Max(top, topLeft));
		}


		static string ToString(int[,] grid)
		{
			string result = "";
			for (int x = 0; x < grid.GetLength(0); x++)
			{
				for (int y = 0; y < grid.GetLength(1); y++)
				{
					result += grid[x, y].ToString();
					if (y != grid.GetLength(1) - 1)
						result += ",";
				}
				result += "\n";
			}
			return result;
		}
	}
}
