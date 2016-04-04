using System.Collections.Generic;
using System.Linq;

namespace MyAlgorithms
{
    public class Graph
    {
        public Graph(int vertexCount, bool directed = false)
        {
            VertexCount = vertexCount;
            AdjacencyList = new List<List<Edge>>();
            for (int i = 0; i <= vertexCount; i += 1)
            {
                AdjacencyList.Add(new List<Edge>());
            }
            _directed = directed;
        }
        
        private readonly bool _directed;

        public int VertexCount { get; set; }
        public List<List<Edge>> AdjacencyList { get; set; }

        public void AddEdge(int fromVertex, int toVertex, int weight = 0)
        {
            AdjacencyList[fromVertex].Add(new Edge(fromVertex, toVertex, weight));
            if (!_directed) AdjacencyList[toVertex].Add(new Edge(toVertex, fromVertex, weight, true));
        }

        public void DeleteEdge(int fromVertex, int toVertex)
        {
            AdjacencyList[fromVertex].RemoveAll(e => (e.From == fromVertex && e.To == toVertex));
            if (!_directed) AdjacencyList[toVertex].RemoveAll(e => (e.From == toVertex && e.To == fromVertex));
        }

        public int EdgeCount
        {
            get { return _directed ? AdjacencyList.Sum(aj => aj.Count) : (AdjacencyList.Sum(aj => aj.Count) / 2); }
        }

        public bool HasCycle()
        {
            var discovered = new HashSet<int>();
            var processed = new HashSet<int>();
            for (int i = 1; i <= this.VertexCount; i += 1)
            {
                if (processed.Contains(i)) continue;

                var hasCycle = HasCycleInternal(i, 0, discovered, processed);
                if (hasCycle) return true;
            }
            return false;
        }

        private bool HasCycleInternal(int curr, int prev, HashSet<int> discovered, HashSet<int> processed)
        {
            if (discovered.Contains(curr)) return true;
            discovered.Add(curr);
            foreach (var e in this.AdjacencyList[curr].Where(e => e.To != prev))
            {
                var result = HasCycleInternal(e.To, curr, discovered, processed);
                if (result) return true;
            }
            processed.Add(curr);
            return false;
        }

        //running hascycle for only the paths affected by fromvertex/tovertex edge
        public bool HasCycle(int fromVertex, int toVertex)
        {
            var discovered = new HashSet<int>();
            var processed = new HashSet<int>();
            var hasCycle = HasCycleInternal(toVertex, fromVertex, discovered, processed);
            if (hasCycle) return true;
            return false;
        }
    }

    public class Edge
    {
        public Edge(int from, int to, int weight, bool undirectedCopy = false)
        {
            From = from;
            To = to;
            Weight = weight;
            _undirectedCopy = undirectedCopy;
        }

        private readonly bool _undirectedCopy;

        public bool UndirectedCopy {get { return _undirectedCopy; }}
        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }
    }
}
