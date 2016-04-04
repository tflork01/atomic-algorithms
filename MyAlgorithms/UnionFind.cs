
using System.Linq;

namespace MyAlgorithms
{
    public class UnionFind
    {
        private int[] _leaders;

        // not using index 0
        public UnionFind(int objectCount)
        {
            this._leaders = new int[objectCount+1];
            for (int i = 1; i < _leaders.Length; i += 1)
            {
                this._leaders[i] = i;
            }
        }

        public void Union(int node1, int node2)
        {
            var leaderOfNode1 = Find(node1);
            var leaderOfNode2 = Find(node2);

            _leaders[leaderOfNode2] = leaderOfNode1;
        }

        public int Find(int node)
        {
            if (_leaders[node] == node) return node;
            var result = Find(_leaders[node]);
            _leaders[node] = result; //path compression
            return result;
        }

        public int NumClusters()
        {
            var result = 0;
            for (int i = 1; i < _leaders.Length; i += 1)
            {
                if (_leaders[i] == i) result++;
            }
            return result;
        }
    }
}
