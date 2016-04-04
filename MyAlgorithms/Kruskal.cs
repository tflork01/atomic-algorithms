using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyAlgorithms
{
    public class Kruskal
    {
        public static Graph ComputeMst(Graph g)
        {
            //organize all the edges in sorted order
            var edges = new List<Edge>();
            foreach (var al in g.AdjacencyList)
            {
                edges.AddRange(al.Where(e => !e.UndirectedCopy));
            }
            edges.Sort((edge1, edge2) => edge1.Weight.CompareTo(edge2.Weight));

            //initialize new empty tree (graph)
            var result = new Graph(g.VertexCount);

            //going in increasing weight order, add the edge to our tree if it doesn't add a cycle
            foreach (var e in edges)
            {
                result.AddEdge(e.From, e.To, e.Weight);
                if (result.HasCycle())
                {
                    result.DeleteEdge(e.From, e.To);
                }
            }
            return result;
        }

        public static int MaxDistanceKClusters(Graph g, int k)
        {
            var uf = new UnionFind(g.VertexCount);
            //organize all the edges in sorted order
            var edges = new List<Edge>();
            foreach (var al in g.AdjacencyList)
            {
                edges.AddRange(al.Where(e => !e.UndirectedCopy));
            }
            edges.Sort((edge1, edge2) => edge1.Weight.CompareTo(edge2.Weight));

            //initialize new empty tree (graph)
            var result = new Graph(g.VertexCount);

            //going in increasing weight order, add the edge to our tree if it doesn't add a cycle
            foreach (var e in edges)
            {
                result.AddEdge(e.From, e.To, e.Weight);
                if (result.HasCycle())
                {
                    result.DeleteEdge(e.From, e.To);
                }
                else if (uf.NumClusters() <= k)
                {
                    return e.Weight;
                }
                else
                {
                    uf.Union(e.From, e.To);
                }
            }
            throw new Exception("Unable to build K clusters with the given graph input.");
        }

        public static int MaxKClustersWithImpliedEdges(int bitsPerNode, List<BitArray> nodes, int maxSpacing)
        {
            var uf = new UnionFind(nodes.Count);

            //going in increasing weight order, add the edge to our tree if it doesn't add a cycle - cycle check performed by partitioning using "lazy unions" with path compression
            foreach (var s in TraverseIncreasingHammingDistance(bitsPerNode, nodes, maxSpacing))
            {
                if (uf.Find(s.Item1) != uf.Find(s.Item2))
                {
                    uf.Union(s.Item1, s.Item2);
                }
            }
            return uf.NumClusters();
        }

        private static IEnumerable<Tuple<int, int>> TraverseIncreasingHammingDistance(int bitsPerNode, List<BitArray> nodes, int maxSpacing)
        {
            var dict = new Dictionary<BitArray, List<int>>(new BitArrayEqualityComparer());
            for (int i = 0; i < nodes.Count; i+=1)
            {
                if (!dict.ContainsKey(nodes[i]))
                {
                    dict.Add(nodes[i], new List<int>(){i});
                }
                else
                {
                    dict[nodes[i]].Add(i);
                }
            }

            for (int i = 1; i < maxSpacing; i += 1)
            {
                var hammingXorPermutations = HammingDistance.HammingXorPermutations(bitsPerNode, i);
                for (int j = 0; j < nodes.Count; j+= 1)
                {
                    var node = nodes[j];
                    foreach (var hammingXorPermutation in hammingXorPermutations)
                    {
                        var xorResult = new BitArray(node);
                        xorResult.Xor(hammingXorPermutation);
                        if (dict.ContainsKey(xorResult))
                        {
                            foreach (var idx in dict[xorResult])
                            {
                                yield return new Tuple<int, int>(j + 1, idx + 1); //+1 because vertex numbers start at 1 while nodes indexing starts at 0    
                            }
                        }
                    }
                }
            }
        }
    }
}
