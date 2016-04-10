using System;
using System.Collections.Generic;

namespace MyAlgorithms
{
    public class Knapsack
    {
        public static int Solve(List<int> values, List<int> weights, int capacity)
        {
            var A = ConstructArray(values, weights, capacity);
            return A[values.Count, capacity];
        }

        public static List<int> SolveSet(List<int> values, List<int> weights, int capacity)
        {
            var A = ConstructArray(values, weights, capacity);
            var result = new List<int>();

            var x = capacity;
            for (int i = values.Count; i > 0; i -= 1)
            {
                if (A[i, x] != A[i - 1, x])   
                {
                    result.Add(i-1);
                    x -= weights[i - 1];
                }
            }
            return result;
        }

        private static int[,] ConstructArray(List<int> values, List<int> weights, int capacity)
        {
            var A = new int[values.Count + 1, capacity + 1];

            for (int i = 1; i < values.Count + 1; i += 1)
            {
                for (int x = 1; x < capacity + 1; x += 1)
                {
                    if (weights[i - 1] > x)
                    {

                        A[i, x] = A[i - 1, x];
                    }
                    else
                    {
                        A[i, x] = Math.Max(A[i - 1, x], A[i - 1, x - weights[i - 1]] + values[i - 1]);
                    }
                }
            }
            return A;
        }
    }
}
