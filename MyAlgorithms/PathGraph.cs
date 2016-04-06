using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithms
{
    public class PathGraph
    {
        private readonly int[] _vertexWeight;

        public PathGraph(int vertexCount)
        {
            _vertexWeight = new int[vertexCount + 1];
        }

        public int[] VertexWeight
        {
            get { return _vertexWeight; }
        }
    }
}
