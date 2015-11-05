using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Needleman_Wunsch_Algorithm
{
	class Node
	{
		public int Score;
		//The node where the score came from
		public Node ScoreNode;

		public Node() { }
		public Node(int Score, Node ScoreNode)
		{
			this.Score = Score;
			this.ScoreNode = ScoreNode;
		}



	}
}
