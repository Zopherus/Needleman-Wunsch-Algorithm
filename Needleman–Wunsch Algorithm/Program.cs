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

		List<LinkedList<Node>> ThisHurts = new List<LinkedList<Node>>();
		static void Main(string[] args)
		{
			DNA1 = "GCATGCU";
			DNA2 = "GATTACA";
			Console.WriteLine(ToString(NeedlemanWunsch(DNA1, DNA2)));
			Console.ReadLine();
		}

		static Node[,] NeedlemanWunsch(string a, string b)
		{
			//first string determines number of rows
			//second string determines number of columns
			//Imagine first string on left side of grid, second string on top
			Node[,] grid = new Node[a.Length + 1, b.Length + 1];

			for (int x = 0; x < grid.GetLength(0); x++)
			{
				for (int y = 0; y < grid.GetLength(1); y++)
				{
					grid[x, y] = CalculateScore(grid, x, y);
				}
			}
			return grid;
		}

		static Node CalculateScore(Node[,] grid, int x, int y)
		{
			Node resultNode = new Node();

			//Negative infinity
			int left = -1000;
			int topLeft = -1000;
			int top = -1000;

			if (x == 0 && y == 0)
				left = 0;
			if (x != 0)
				left = grid[x - 1, y].Score + INDEL;
			if (x != 0 && y != 0)
			{
				topLeft = grid[x - 1, y - 1].Score;
				if (DNA1.ElementAt(y - 1).Equals(DNA2.ElementAt(x - 1)))
					topLeft += MATCH;
				else
					topLeft += MISMATCH;
			}
			if (y != 0)
				top = grid[x, y- 1].Score + INDEL;

			resultNode.Score = Math.Max(left, Math.Max(top, topLeft));
			if (resultNode.Score == left && x != 0)
				resultNode.ScoreNodes.Add(grid[x - 1, y]);
			if (resultNode.Score == top && y != 0)
				resultNode.ScoreNodes.Add(grid[x, y - 1]);
			if (resultNode.Score == topLeft && x != 0 && y != 0)
				resultNode.ScoreNodes.Add(grid[x - 1, y - 1]);

			return resultNode;
		}

		static string ToString(Node[,] grid)
		{
			string result = "";
			for (int x = 0; x < grid.GetLength(0); x++)
			{
				for (int y = 0; y < grid.GetLength(1); y++)
				{
					result += grid[x, y].Score.ToString();
					if (y != grid.GetLength(1) - 1)
						result += ",";
				}
				result += "\n";
			}
			return result;
		}
	}
}
