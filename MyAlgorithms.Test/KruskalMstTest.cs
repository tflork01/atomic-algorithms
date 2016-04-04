using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyAlgorithms.Test
{
    [TestClass]
    public class KruskalMstTest
    {
        [TestMethod]
        public void MstOf1VertexGraphIsTheGraph()
        {
            var g = new Graph(1);
            var mst = Kruskal.ComputeMst(g);
            
            Assert.IsNotNull(mst);
            Assert.IsTrue(mst.VertexCount == 1);
            Assert.IsTrue(mst.EdgeCount == 0);
            Assert.IsFalse(mst.HasCycle());
        }

        [TestMethod]
        public void MstOf2VertexGraphIsTheGraph()
        {
            var g = new Graph(2);
            g.AddEdge(1,2,1);
            var mst = Kruskal.ComputeMst(g);

            Assert.IsNotNull(mst);
            Assert.IsTrue(mst.VertexCount == 2);
            Assert.IsTrue(mst.EdgeCount == 1);
            Assert.IsFalse(mst.HasCycle());
        }

        [TestMethod]
        public void MstOfSimple3VertexGraphIsTheGraph()
        {
            var g = new Graph(3);
            g.AddEdge(1,2,1);
            g.AddEdge(2, 3, 1);
            var mst = Kruskal.ComputeMst(g);

            Assert.IsNotNull(mst);
            Assert.IsTrue(mst.VertexCount == 3);
            Assert.IsTrue(mst.EdgeCount == 2);
            Assert.IsFalse(mst.HasCycle());
        }

        [TestMethod]
        public void MstOf3VertexGraphWithMultiplePaths()
        {
            var g = new Graph(3);
            g.AddEdge(1, 2, 1);
            g.AddEdge(2, 3, 2);
            g.AddEdge(1, 3, 1);
            var mst = Kruskal.ComputeMst(g);

            Assert.IsNotNull(mst);
            Assert.IsTrue(mst.VertexCount == 3);
            Assert.IsTrue(mst.EdgeCount == 2);
            Assert.IsFalse(mst.HasCycle());
        }

        [TestMethod]
        public void MstOfComplexGraph()
        {
            var g = new Graph(4);
            g.AddEdge(1, 2, 3);
            g.AddEdge(1, 3, 1);
            g.AddEdge(1, 4, 6);
            g.AddEdge(2, 3, 1);
            g.AddEdge(2, 4, 2);
            g.AddEdge(3, 4, 3);
            var mst = Kruskal.ComputeMst(g);

            Assert.IsNotNull(mst);
            Assert.IsTrue(mst.VertexCount == 4);
            Assert.IsTrue(mst.EdgeCount == 3);
            Assert.IsFalse(mst.HasCycle());
        }


    }
}
