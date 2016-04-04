using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyAlgorithms.Test
{
    [TestClass]
    public class UnionFindTest
    {
        [TestMethod]
        public void OneElementIsOneSet()
        {
            var uf = new UnionFind(1);
            Assert.IsTrue(uf.Find(1) == 1);
            Assert.IsTrue(uf.NumClusters() == 1);
        }

        [TestMethod]
        public void TwoElementsStartInSeparateSetsAndAreJoinedViaUnion()
        {
            var uf = new UnionFind(2);
            Assert.IsTrue(uf.Find(1) == 1);
            Assert.IsTrue(uf.Find(2) == 2);
            
            uf.Union(1, 2);
            Assert.IsTrue(uf.Find(1) == 1);
            Assert.IsTrue(uf.Find(2) == 1);
            Assert.IsTrue(uf.NumClusters() == 1);
        }

        [TestMethod]
        public void MultipleElementsPartitionedIntoMultipleSetsViaUnion()
        {
            var uf = new UnionFind(10);
            uf.Union(1, 2);
            uf.Union(1, 3);
            uf.Union(1, 4);
            uf.Union(1, 9);
            uf.Union(5, 10);
            uf.Union(6, 1);

            Assert.IsTrue(uf.Find(1) == 6);
            Assert.IsTrue(uf.Find(2) == 6);
            Assert.IsTrue(uf.Find(3) == 6);
            Assert.IsTrue(uf.Find(4) == 6);
            Assert.IsTrue(uf.Find(9) == 6);
            Assert.IsTrue(uf.Find(6) == 6);

            Assert.IsTrue(uf.Find(10) == 5);
            Assert.IsTrue(uf.Find(5) == 5);

            Assert.IsTrue(uf.Find(7) == 7);
            Assert.IsTrue(uf.Find(8) == 8);

            Assert.IsTrue(uf.NumClusters() == 4);
        }
    }
}
