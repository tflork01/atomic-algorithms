using System;
using System.Collections.Generic;

namespace MyAlgorithms
{
    public class MaxWeightIndependentSet
    {
        public static int ComputeSetWeight(PathGraph p)
        {
            var A = CreateArray(p);
            return A[p.VertexWeight.Length - 1];
        }

        public static Stack<int> ComputeActualSet(PathGraph p)
        {
            int maxIdxVertices = p.VertexWeight.Length - 1;
            var A = CreateArray(p);
            var result = new Stack<int>();
            ActualSetHelper(p, maxIdxVertices, A, result);
            return result;
        }

        private static void ActualSetHelper(PathGraph p, int i, int[] A, Stack<int> set)
        {
            if (i <= 0) return;

            int s1 = A[i - 1];

            if (s1 == A[i])
            {
                set.Push(i-1);
                ActualSetHelper(p, i - 3, A, set);
            }
            else
            {
                set.Push(i);
                ActualSetHelper(p, i - 2, A, set);
            }
        }

        private static int[] CreateArray(PathGraph p)
        {
            var A = new int[p.VertexWeight.Length];
            if (p.VertexWeight.Length <= 1) return A;
            A[0] = 0;
            A[1] = p.VertexWeight[1];
            for (int i = 2; i < p.VertexWeight.Length; i += 1)
            {
                A[i] = Math.Max(A[i - 1], A[i - 2] + p.VertexWeight[i]);
            }
            return A;
        }

    }
}
