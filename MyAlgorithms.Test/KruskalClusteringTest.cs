using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyAlgorithms.Test
{
    [TestClass]
    public class KruskalClusteringTest
    {
        [TestMethod]
        public void Simple4VertexGraphWith2Clusters()
        {
            var g = new Graph(4);
            g.AddEdge(1, 2, 3);
            g.AddEdge(1, 3, 1);
            g.AddEdge(1, 4, 5);
            g.AddEdge(2, 4, 2);
            g.AddEdge(3, 4, 4);

            var dist = Kruskal.MaxDistanceKClusters(g, 2);
            Assert.IsTrue(dist == 3);
        }
    }
}
