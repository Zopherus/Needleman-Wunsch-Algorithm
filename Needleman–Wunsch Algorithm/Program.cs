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

		static void Main(string[] args)
		{
			string DNA1 = "GCATGCU";
			string DNA2 = "GATTA";
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
					grid[x, y] = Math.Max(1,2);
				}
			}
			return grid;
		}

		static int CalculateScore(int[,] grid, int x, int y)
		{
			int left = grid[x - 1, y];
			int topLeft = grid[x - 1, y - 1];
			int top = grid[x, y - 1];
			return Math.Max(left - 1, top - 1, topLeft);
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
