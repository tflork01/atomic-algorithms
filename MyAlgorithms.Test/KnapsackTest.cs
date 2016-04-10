using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyAlgorithms.Test
{
    [TestClass]
    public class KnapsackTest
    {
        [TestMethod]
        public void Single_value_is_that_value()
        {
            var values = new List<int> {1};
            var weights = new List<int> {5};
            var r = Knapsack.Solve(values, weights, 10);
            Assert.IsTrue(r == 1);
            var r2 = Knapsack.SolveSet(values, weights, 10);
            Assert.IsTrue(r2.Count == 1);
            Assert.IsTrue(r2[0] == 0);
        }

        [TestMethod]
        public void Two_values_capacity_for_both()
        {
            var values = new List<int> { 1,2 };
            var weights = new List<int> { 5,6 };
            var r = Knapsack.Solve(values, weights, 100);
            Assert.IsTrue(r == 3);
            var r2 = Knapsack.SolveSet(values, weights, 100);
            Assert.IsTrue(r2.Count == 2);
        }

        [TestMethod]
        public void Two_values_capacity_for_one()
        {
            var values = new List<int> { 1, 2 };
            var weights = new List<int> { 5, 6 };
            var r = Knapsack.Solve(values, weights, 5);
            Assert.IsTrue(r == 1);
            var r2 = Knapsack.SolveSet(values, weights, 5);
            Assert.IsTrue(r2.Count == 1);
            Assert.IsTrue(r2[0] == 0);
        }

        [TestMethod]
        public void Three_values_capacity_for_none()
        {
            var values = new List<int> { 1, 2,3  };
            var weights = new List<int> { 5, 6, 7 };
            var r = Knapsack.Solve(values, weights, 1);
            Assert.IsTrue(r == 0);
            var r2 = Knapsack.SolveSet(values, weights, 1);
            Assert.IsTrue(r2.Count == 0);
        }

        [TestMethod]
        public void Three_values_capacity_for_one()
        {
            var values = new List<int> { 1, 2, 3 };
            var weights = new List<int> { 5, 6, 7 };
            var r = Knapsack.Solve(values, weights, 6);
            Assert.IsTrue(r == 2);
            var r2 = Knapsack.SolveSet(values, weights, 6);
            Assert.IsTrue(r2.Count == 1);
            Assert.IsTrue(r2[0] == 1);
        }

        [TestMethod]
        public void Three_values_capacity_for_one_alternate()
        {
            var values = new List<int> { 1, 2, 3 };
            var weights = new List<int> { 5, 6, 7 };
            var r = Knapsack.Solve(values, weights, 7);
            Assert.IsTrue(r == 3);
            var r2 = Knapsack.SolveSet(values, weights, 7);
            Assert.IsTrue(r2.Count == 1);
            Assert.IsTrue(r2[0] == 2);
        }

        [TestMethod]
        public void Three_values_capacity_for_all()
        {
            var values = new List<int> { 1, 2, 3 };
            var weights = new List<int> { 5, 6, 7 };
            var r = Knapsack.Solve(values, weights, 77);
            Assert.IsTrue(r == 6);
            var r2 = Knapsack.SolveSet(values, weights, 77);
            Assert.IsTrue(r2.Count == 3);
        }
    }
}
