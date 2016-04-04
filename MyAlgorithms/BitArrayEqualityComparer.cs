using System;
using System.Collections;
using System.Collections.Generic;

namespace MyAlgorithms
{
    public class BitArrayEqualityComparer : IEqualityComparer<BitArray>
    {
        public bool Equals(BitArray x, BitArray y)
        {
            for (int i = 0; i < x.Length; i += 1)
            {
                if (x[i] != y[i]) return false;
            }
            return true;
        }

        public int GetHashCode(BitArray obj)
        {
            return getIntFromBitArray(obj);
        }

        private int getIntFromBitArray(BitArray bitArray)
        {
            if (bitArray.Length > 32)
                throw new ArgumentException("Argument length shall be at most 32 bits.");

            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }
    }
}
