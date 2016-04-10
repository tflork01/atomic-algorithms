using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyAlgorithms.Test
{
    [TestClass]
    public class SequenceAlignmentTest
    {
        [TestMethod]
        public void Two_matching_strings()
        {
            var r = SequenceAlignment.Solve("G", "G");
            Assert.IsTrue(r == 0);
            r = SequenceAlignment.Solve("GA", "GA");
            Assert.IsTrue(r == 0);
        }

        [TestMethod]
        public void Two_strings_off_by_one_gap()
        {
            var r = SequenceAlignment.Solve("GP", "GAP");
            Assert.IsTrue(r == 1);
            r = SequenceAlignment.Solve("GAP", "GP");
            Assert.IsTrue(r == 1);
            r = SequenceAlignment.Solve("GAP", "GAPS");
            Assert.IsTrue(r == 1);
            r = SequenceAlignment.Solve("GAPS", "GAP");
            Assert.IsTrue(r == 1);
            r = SequenceAlignment.Solve("GAPS", "APS");
            Assert.IsTrue(r == 1);
            r = SequenceAlignment.Solve("APS", "GAPS");
            Assert.IsTrue(r == 1);
        }

        [TestMethod]
        public void Two_strings_off_by_two_gaps()
        {
            var r = SequenceAlignment.Solve("GP", "GAPS");
            Assert.IsTrue(r == 2);
            r = SequenceAlignment.Solve("GAPS", "GP");
            Assert.IsTrue(r == 2);
            r = SequenceAlignment.Solve("AS", "GAPS");
            Assert.IsTrue(r == 2);
            r = SequenceAlignment.Solve("GAPS", "AS");
            Assert.IsTrue(r == 2);
            r = SequenceAlignment.Solve("GAPS", "GA");
            Assert.IsTrue(r == 2);
            r = SequenceAlignment.Solve("GA", "GAPS");
            Assert.IsTrue(r == 2);
            r = SequenceAlignment.Solve("GAPS", "PS");
            Assert.IsTrue(r == 2);
            r = SequenceAlignment.Solve("PS", "GAPS");
            Assert.IsTrue(r == 2);
        }

        [TestMethod]
        public void Two_entirely_different_strings()
        {
            var r = SequenceAlignment.Solve("GA", "PS");
            Assert.IsTrue(r == 4);
            r = SequenceAlignment.Solve("GAPS", "HOLES");
            Assert.IsTrue(r == 7);
        }
    }
}
