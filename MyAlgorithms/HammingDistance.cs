using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyAlgorithms
{
    public class HammingDistance
    {
        public static List<BitArray> HammingXorPermutations(int bits, int distance)
        {
            var result = new List<BitArray>();
            HammingXorHelper(bits, distance, string.Empty, result);
            return result;
        }

        private static void HammingXorHelper(int bitsRemaining, int distance, string current, List<BitArray> result)
        {
            if (bitsRemaining == 0)
            {
                if (distance == 0)
                    result.Add(StringToByteArray(current));
                return;
            }

            if (distance > 0)
            {
                HammingXorHelper(bitsRemaining - 1, distance - 1, current + "1", result);    
            }
            HammingXorHelper(bitsRemaining - 1, distance, current + "0", result);
        }

        public static BitArray StringToByteArray(string input)
        {
            var result = new BitArray(input.Length);
            for (int i = 0; i < input.Length; i += 1) result[i] = input[i] == '1';
            return result;
        }

        public static string BitArrayToString(BitArray input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i += 1)
            {
                sb.Append(input[i] ? "1" : "0");
            }
            return sb.ToString();
        }
    }
}
