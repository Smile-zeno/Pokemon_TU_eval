using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge
{
    public class Pathfinding
    {
        public Pathfinding(string map1)
        {
        }

        public char[,] Grid { get; internal set; }

        internal Path BreadthFirstSearch(Vector2 start, Vector2 destination)
        {
            throw new NotImplementedException();
        }

        internal char GetCoord(Vector2 el)
        {
            throw new NotImplementedException();
        }

        internal List<char> GetNeighboors(Vector2 vector2)
        {
            throw new NotImplementedException();
        }

        internal List<char> GetNeighboors(Vector2 vector2, List<Vector2> exclude)
        {
            throw new NotImplementedException();
        }

        internal bool IsOutOfBound(Vector2 vector2)
        {
            throw new NotImplementedException();
        }
    }

}
