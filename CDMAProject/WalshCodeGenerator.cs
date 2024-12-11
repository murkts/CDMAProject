using System;
using System.Collections.Generic;

namespace CDMAProject
{
    public static class WalshCodeGenerator
    {
        public static List<int[]> GenerateWalshCodes(int length)
        {
            int size = (int)Math.Pow(2, length);
            var walshMatrix = new int[size, size];

            walshMatrix[0, 0] = 1;

            for (int n = 1; n < size; n *= 2)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        walshMatrix[i + n, j] = walshMatrix[i, j];
                        walshMatrix[i, j + n] = walshMatrix[i, j];
                        walshMatrix[i + n, j + n] = -walshMatrix[i, j];
                    }
                }
            }

            var codes = new List<int[]>();
            for (int i = 0; i < size; i++)
            {
                var row = new int[size];
                for (int j = 0; j < size; j++)
                {
                    row[j] = walshMatrix[i, j];
                }
                codes.Add(row);
            }

            return codes;
        }
    }
}