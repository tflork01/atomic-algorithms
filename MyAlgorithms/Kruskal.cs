﻿using System;
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
                if (uf.Find(e.From) != uf.Find(e.To))
                {
                    if (uf.NumClusters() <= k)
                    {
                        return e.Weight;
                    }
                    uf.Union(e.From, e.To);
                    result.AddEdge(e.From, e.To, e.Weight);
                }
            }
            throw new Exception("Unable to build K clusters with the given graph input.");
        }

        public static int MaxKClustersWithImpliedEdges(int bitsPerNode, List<BitArray> nodes, int maxSpacing)
        {
            var uf = new UnionFind(nodes.Count);

            //going in increasing weight order, add the edge to our tree if it doesn't add a cycle - cycle check performed by partitioning using "lazy unions" with path compression
            foreach (var s in GenerateNextNodeIncreasingHammingDistance(bitsPerNode, nodes, maxSpacing))
            {
                if (uf.Find(s.Item1) != uf.Find(s.Item2)) //cycle would be if the two nodes were in the same partition already
                {
                    uf.Union(s.Item1, s.Item2);
                }
            }
            return uf.NumClusters();
        }

        private static IEnumerable<Tuple<int, int>> GenerateNextNodeIncreasingHammingDistance(int bitsPerNode, List<BitArray> nodes, int maxSpacing)
        {
            var dict = new Dictionary<BitArray, int>(new BitArrayEqualityComparer()); //needs its own equalitycomparer because default does equality by reference, which wouldn't work for lookups here
            for (int i = 0; i < nodes.Count; i+=1)
            {
                dict.Add(nodes[i], i);
            }

            //main idea: we know that 
            //a xor b = c 
            // and 
            //a xor c = b
            // so if we know all of the hamming distance bitarrays that would be generated if we xor'ed a node with a string that was i bits away (these can be generated using the HammingXorPermutations)
            // and we combine that with a O(1) lookup into our nodes collection, we have a fast way of telling if there exists a node that is i bits hamming distance away from current node
            for (int i = 1; i < maxSpacing; i += 1)
            {
                var hammingXorPermutations = HammingDistance.HammingXorPermutations(bitsPerNode, i); //generate all the possible hamming distance bitarrays that we would get if we xor'ed with a string that differed by i bits
                for (int j = 0; j < nodes.Count; j+= 1)
                {
                    var node = nodes[j];
                    foreach (var hammingXorPermutation in hammingXorPermutations)
                    {
                        var xorResult = new BitArray(node); 
                        xorResult.Xor(hammingXorPermutation); //xor the node with the hamming distance bitarray... and then check if the resulting string is in the set of nodes 
                        if (dict.ContainsKey(xorResult))
                        {
                                yield return new Tuple<int, int>(j + 1, dict[xorResult] + 1); //+1 because vertex numbers start at 1 while nodes indexing starts at 0    
                        }
                    }
                }
            }
        }
    }
}
