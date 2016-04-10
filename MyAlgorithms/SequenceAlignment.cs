
using System;

namespace MyAlgorithms
{
    public class SequenceAlignment
    {
        /// <summary>
        /// Hardcoded
        /// Penalty for gap: +1
        /// Penalty for match: 0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static int Solve(string X, string Y)
        {
            var A = ConstructArray(X, Y);
            return A[X.Length, Y.Length];
        }

        private static int[,] ConstructArray(string X, string Y)
        {
            var A = new int[X.Length+1, Y.Length+1];

            //A[i,0] is really tracking the min value of matching first i characters of X with 0 characters of Y (empty string) , so we have to prefill it with cost of gaps
            // same for A[0,j]
            for (int i = 1; i <= X.Length; i++) {A[i, 0] = i;}
            for (int i = 1; i <= Y.Length; i++) A[0,i] = i;

            //keep in mind A will have additional 0th indexed row with all zeros so indexing won't quite match up between A and X/Y
            for (var i = 1; i <= X.Length; i ++)
            {
                for (var j = 1; j <= Y.Length; j++)
                {
                    A[i, j] = Math.Min(A[i - 1, j] + 1, A[i, j - 1] + 1);
                    if (X[i - 1] == Y[j - 1]) A[i, j] = Math.Min(A[i, j], A[i - 1, j - 1]);
                }
            }

            return A;
        }
    }
}
