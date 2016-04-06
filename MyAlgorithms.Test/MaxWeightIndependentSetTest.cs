using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyAlgorithms.Test
{
    [TestClass]
    public class MaxWeightIndependentSetTest
    {
        [TestMethod]
        public void MWIS_of_single_vertex_path_is_weight_of_single_vertex()
        {
            PathGraph p = new PathGraph(1);
            p.VertexWeight[1] = 4;
            var r = MaxWeightIndependentSet.ComputeSetWeight(p);
            Assert.IsTrue(r == 4);
        }
        
        [TestMethod]
        public void MWIS_of_2_vertices_is_the_larger_vertex()
        {
            PathGraph p = new PathGraph(2);
            p.VertexWeight[1] = 4;
            p.VertexWeight[2] = 44;
            var r = MaxWeightIndependentSet.ComputeSetWeight(p);
            Assert.IsTrue(r == 44);
        }

        [TestMethod]
        public void MWIS_of_3_vertices_is_2_outside_vertices()
        {
            PathGraph p = new PathGraph(3);
            p.VertexWeight[1] = 4;
            p.VertexWeight[2] = 44;
            p.VertexWeight[3] = 41;
            var r = MaxWeightIndependentSet.ComputeSetWeight(p);
            Assert.IsTrue(r == 45);
        }

        [TestMethod]
        public void MWIS_of_3_vertices_is_center_vertex()
        {
            PathGraph p = new PathGraph(3);
            p.VertexWeight[1] = 4;
            p.VertexWeight[2] = 64;
            p.VertexWeight[3] = 41;
            var r = MaxWeightIndependentSet.ComputeSetWeight(p);
            Assert.IsTrue(r == 64);
        }

        [TestMethod]
        public void MWIS_of_complex_path()
        {
            PathGraph p = new PathGraph(5);
            p.VertexWeight[1] = 1;
            p.VertexWeight[2] = 2;
            p.VertexWeight[3] = 3;
            p.VertexWeight[4] = 4;
            p.VertexWeight[5] = 5;
            var r = MaxWeightIndependentSet.ComputeSetWeight(p);
            Assert.IsTrue(r == 9);
        }

        [TestMethod]
        public void MWISP_of_empty_path_is_empty()
        {
            PathGraph p = new PathGraph(0);
            var r = MaxWeightIndependentSet.ComputeActualSet(p);
            Assert.IsTrue(r.Count == 0);
        }

        [TestMethod]
        public void MWISP_of_single_vertex_is_that_vertex()
        {
            PathGraph p = new PathGraph(1);
            p.VertexWeight[1] = 1;
            var r = MaxWeightIndependentSet.ComputeActualSet(p);
            Assert.IsTrue(r.Count == 1);
            Assert.IsTrue(r.Contains(1));
        }

        [TestMethod]
        public void MWISP_of_2_vertices_is_the_first_vertex()
        {
            PathGraph p = new PathGraph(2);
            p.VertexWeight[1] = 5;
            p.VertexWeight[2] = 3;
            var r = MaxWeightIndependentSet.ComputeActualSet(p);
            Assert.IsTrue(r.Count == 1);
            Assert.IsTrue(r.Contains(1));
        }
        
        [TestMethod]
        public void MWISP_of_2_vertices_is_the_second_vertex()
        {
            PathGraph p = new PathGraph(2);
            p.VertexWeight[1] = 1;
            p.VertexWeight[2] = 3;
            var r = MaxWeightIndependentSet.ComputeActualSet(p);
            Assert.IsTrue(r.Count == 1);
            Assert.IsTrue(r.Contains(2));
        }

        [TestMethod]
        public void MWISP_of_3_vertices_is_the_2_outside_vertices()
        {
            PathGraph p = new PathGraph(3);
            p.VertexWeight[1] = 5;
            p.VertexWeight[2] = 3;
            p.VertexWeight[3] = 2;
            var r = MaxWeightIndependentSet.ComputeActualSet(p);
            Assert.IsTrue(r.Count == 2);
            Assert.IsTrue(r.Contains(1));
            Assert.IsTrue(r.Contains(3));
        }

        [TestMethod]
        public void MWISP_of_3_vertices_is_the_inside_vertex()
        {
            PathGraph p = new PathGraph(3);
            p.VertexWeight[1] = 5;
            p.VertexWeight[2] = 13;
            p.VertexWeight[3] = 2;
            var r = MaxWeightIndependentSet.ComputeActualSet(p);
            Assert.IsTrue(r.Count == 1);
            Assert.IsTrue(r.Contains(2));
        }

        [TestMethod]
        public void MWISP_of_4_vertices_is_1_and_3()
        {
            PathGraph p = new PathGraph(4);
            p.VertexWeight[1] = 5;
            p.VertexWeight[2] = 13;
            p.VertexWeight[3] = 22;
            p.VertexWeight[4] = 2;
            var r = MaxWeightIndependentSet.ComputeActualSet(p);
            Assert.IsTrue(r.Count == 2);
            Assert.IsTrue(r.Contains(1));
            Assert.IsTrue(r.Contains(3));
        }

        [TestMethod]
        public void MWISP_of_4_vertices_is_2_and_4()
        {
            PathGraph p = new PathGraph(4);
            p.VertexWeight[1] = 5;
            p.VertexWeight[2] = 13;
            p.VertexWeight[3] = 22;
            p.VertexWeight[4] = 72;
            var r = MaxWeightIndependentSet.ComputeActualSet(p);
            Assert.IsTrue(r.Count == 2);
            Assert.IsTrue(r.Contains(2));
            Assert.IsTrue(r.Contains(4));
        }
    }
}
