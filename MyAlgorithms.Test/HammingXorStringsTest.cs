using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyAlgorithms.Test
{
    [TestClass]
    public class HammingXorStringsTest
    {
        [TestMethod]
        public void Hamming4BitStringsWithDistance0()
        {
            var result = HammingDistance.HammingXorPermutations(4, 0);
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(HammingDistance.BitArrayToString(result[0]) == "0000");
        }

        [TestMethod]
        public void Hamming4BitStringsWithDistance1()
        {
            var result = HammingDistance.HammingXorPermutations(4, 1);
            Assert.IsTrue(result.Count == 4);
            string[] validStrings = {"0001", "0010", "0100", "1000"};
            foreach (var bitArray in result)
            {
                Assert.IsTrue(validStrings.Contains(HammingDistance.BitArrayToString(bitArray)));
            }
        }
        
        [TestMethod]
        public void Hamming4BitStringsWithDistance2()
        {
            var result = HammingDistance.HammingXorPermutations(4, 2);
            Assert.IsTrue(result.Count == 6);

            string[] validStrings = { "0011", "0110", "1100", "1001", "1010", "0101" };
            foreach (var bitArray in result)
            {
                Assert.IsTrue(validStrings.Contains(HammingDistance.BitArrayToString(bitArray)));
            }
        }
    }
}
